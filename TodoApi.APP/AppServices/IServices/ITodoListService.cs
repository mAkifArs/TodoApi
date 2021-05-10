using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.DATA.DTO;

namespace TodoApi.APP.AppServices.IServices
{
    public interface ITodoListService
    {
        Task AddTodoListAsync(TodoListDTO todoListDto);
        Task<TodoListDTO> GetTodoList(int id);
        Task<List<TodoListDTO>> GetTodoLists(string username);
        Task<List<TodoListDTO>> GetTodoListsToday(string username);
    }
}