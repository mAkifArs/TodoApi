using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.APP.AppServices.IServices;
using TodoApi.DATA;
using TodoApi.DATA.DTO;
using TodoApi.DATA.Entities;

namespace TodoApi.APP.AppServices.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly TodoApiDataContext _context;

        public TodoListService(TodoApiDataContext context)
        {
            _context = context;
        }


        public async Task AddTodoListAsync(TodoListDTO todoListDto)
        {
            var user =  _context.UserInfos
                .Include(x => x.TodoLists)
                .FirstOrDefault(x => todoListDto.UserId==x.UserId);
            if (user == null )
            {
                throw new Exception("User not found");
            }

            var todolist = new TodoList
            {
                Content = todoListDto.Content,
                DateofJob = todoListDto.DateofJob,
                UserInfo = user
            };
            await _context.TodoLists.AddAsync(todolist);
            await _context.SaveChangesAsync();

        }

        public Task<TodoListDTO> GetTodoList(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TodoListDTO>> GetTodoLists(string username)
        {
            var user = _context.UserInfos.Include(x => x.TodoLists).FirstOrDefault(x => x.Name == username);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            var dto = new List<TodoListDTO>();
            if (user.TodoLists != null)
                foreach (var list in user.TodoLists)
                {
                    dto.Add(new TodoListDTO
                    {
                        Content = list.Content,
                        DateofJob = list.DateofJob,
                        UserId = user.UserId,
                        UserInfoDto = new UserInfoDTO
                        {
                            Mail = user.Mail,
                            Name = user.Name
                        }
                    });
                }

            if (dto.Count==0)
            {
                throw new Exception("Kullanıcının yapılacaklar listesi boş");
            }

            return dto;
        }

        public async Task<List<TodoListDTO>> GetTodoLists(string username)
        {
            var user = _context.UserInfos.Include(x => x.TodoLists).FirstOrDefault(x => x.Name == username);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            var dto = new List<TodoListDTO>();
            if (user.TodoLists != null)
                foreach (var list in user.TodoLists)
                {
                    if(list.DateofJob == DateTime.Today) {
                        dto.Add(new TodoListDTO
                        {
                            Content = list.Content,
                            DateofJob = list.DateofJob,
                            UserId = user.UserId,
                            UserInfoDto = new UserInfoDTO
                            {
                                Mail = user.Mail,
                                Name = user.Name
                            }
                        });
                    }
                }

            if (dto.Count==0)
            {
                throw new Exception("Kullanıcının yapılacaklar listesi boş");
            }

            return dto;
        }
    }
}