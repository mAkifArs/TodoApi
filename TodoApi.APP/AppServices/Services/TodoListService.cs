using System.Threading.Tasks;
using TodoApi.APP.AppServices.IServices;
using TodoApi.DATA.DTO;
using TodoApi.DATA.Entities;
using TodoApi.DATA.Repositories.IRepository;
using TodoApi.DATA.Repositories.Repository;

namespace TodoApi.APP.AppServices.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoListRepository _todoListRepository;

        public TodoListService(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public async Task AddTodoListAsync(TodoListDTO todoListDto)
        {
            var todoList = new TodoList
            {
                UserId = todoListDto.UserId,
                Content = todoListDto.Content,
                DateofJob = todoListDto.DateofJob
            };
            _todoListRepository.AddTodoList(todoList);
        }
    }
}