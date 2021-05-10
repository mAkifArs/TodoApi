using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.APP.AppServices.IServices;
using TodoApi.DATA.DTO;

namespace TodoApp.API.Controllers
{
    public class TodoListController : Controller
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        //ADD 
        [Route("api/todolist/add")]
        [HttpPost]
        public async Task<IActionResult> AddListAsync([FromBody]TodoListDTO todoList)
        {
            await _todoListService.AddTodoListAsync(todoList);
            return Ok();
        }

        [Route("api/todolist/get")]
        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromBody]string name)
        {
            await _todoListService.GetTodoLists(name);
            return Ok();
        }
    }
}