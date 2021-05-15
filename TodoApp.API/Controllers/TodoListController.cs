using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hangfire;
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
        [HttpPost]
        public async Task<IActionResult> GetListAsync([FromQuery]string username)
        {
            return Ok(await _todoListService.GetTodoLists(username));
        }

        [Route("api/todolist/getTodoListWithDate")]
        [HttpPost]
        public async Task<IActionResult> GetTodoListWithDate([FromQuery]string username,DateTime dateTime)
        {
            return Ok(await _todoListService.GetTodoListWithDate(username,dateTime));
        }

        [Route("api/todolist/todayslist")]
        [HttpPost]
        public IActionResult TodaysTodoSendEmail(string username)
        {
            return Ok(_todoListService.TodaysTodoSendEmail(username));
        }
        [Route("api/todolist/mailSender")]
        [HttpPost]
        public  IActionResult SendMail(string userMail,string [] mailContent)
        {
            return Ok(_todoListService.SendMail(userMail,mailContent));
        }

        [Route("api/todolist/TomorrowsTodo")]
        [HttpPost]
        public IActionResult TomorrowsTodo(string username)
        {
            return Ok(_todoListService.TomorrowsTodo(username));
        }

        [Route("api/hangfire/Mailsender")]
        [HttpPost]
        public async Task<IActionResult> GetAllUserTodo()
        {
            RecurringJob.AddOrUpdate(() => GetAllUserTodo(),Cron.Daily(8,30));
            return Ok(_todoListService.GetAllUserTodo());
        }
    }
}