using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.APP.AppServices.IServices;
using TodoApi.DATA.DTO;


namespace TodoApp.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly IUserService _userService;
      

        public UserInfoController(IUserService userService)
        {
            _userService = userService;
        }

        // GET

        [Route("add")]
        [HttpPost]

        public async Task<IActionResult> AddUserAsync([FromBody] UserInfoDTO userInfo)
        {
            await _userService.AddUserAsync(userInfo);
            return Ok();
        }
    }

}