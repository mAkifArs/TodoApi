using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MockMailbox;
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
        public async Task<List<TodoListDTO>> GetTodoLists(string username)
        {
            var user = _context.UserInfos.Include(x => x.TodoLists).FirstOrDefault(x => x.Name == username);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            var dto = new List<TodoListDTO>();
            if (user.TodoLists != null){
                dto = user.TodoLists
                    .Select(todo => new TodoListDTO()
                    {
                        Content = todo.Content,
                        DateofJob = todo.DateofJob,
                        UserId = user.UserId,
                        UserInfoDto = new UserInfoDTO
                        {
                            Mail = user.Mail,
                            Name = user.Name
                        }
                    }).ToList();
            }

            if (dto.Count==0)
            {
                throw new Exception("Kullanıcının yapılacaklar listesi boş");
            }

            return dto;
        }

        public async Task<List<TodoListDTO>> GetTodoListWithDate(string username, DateTime dateTime)
        {
            var user = _context.UserInfos.Include(x => x.TodoLists).FirstOrDefault(x => x.Name == username);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            var dto = new List<TodoListDTO>();
            if (user.TodoLists != null){
                dto = user.TodoLists.Where(todo =>
                        todo.DateofJob.ToShortDateString().Equals(dateTime.ToShortDateString()))
                    .Select(todo => new TodoListDTO()
                    {
                        Content = todo.Content,
                        DateofJob = todo.DateofJob,
                        UserId = user.UserId,
                        UserInfoDto = new UserInfoDTO
                        {
                            Mail = user.Mail,
                            Name = user.Name
                        }
                    }).ToList();
            }
            if (dto.Count==0)
            {
                throw new Exception("Kullanıcının yapılacaklar listesi boş");
            }
            return dto;
        }

        public async Task TodaysTodoSendEmail(string username)
        {
            var user = _context.UserInfos.Include(x => x.TodoLists).FirstOrDefault(x => x.Name == username);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            var usersTodayTodos = await GetTodoListWithDate(username,DateTime.Now);
            await SendMail(user.Mail, usersTodayTodos.Select(x => x.Content).ToArray());
        }
        public async Task TomorrowsTodo(string username)
        {
            var user = _context.UserInfos.Include(x => x.TodoLists).FirstOrDefault(x => x.Name == username);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            var usersTodayTodos = await GetTodoListWithDate(username,DateTime.Today.AddDays(1));
            await SendMail(user.Mail, usersTodayTodos.Select(x => x.Content).ToArray());
        }

        public async Task SendMail(string userMail,string [] mailContent)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ars.makif@gmail.com", "SvS2270780"),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };
            var mailMessage = new MailAddress(userMail);
            smtpClient.Send("ars.makif@gmail.com",""+mailMessage +"","Günlük Hatırlatma",@"Merhaba Bugün Yapacaklarınız :"+ String.Join(", ", mailContent.ToArray())+"")  ;

        }
    }

    
}