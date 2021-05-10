using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.APP.AppServices.IServices;
using TodoApi.DATA.DTO;
using TodoApi.DATA.Repositories.IRepository;


namespace TodoApp.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoController(IUserService userService, IUserInfoRepository userInfoRepository)
        {
            _userService = userService;
            _userInfoRepository = userInfoRepository;
        }

        // GET

        [Route("add")]
        [HttpPost]

        public async Task<IActionResult> AddUserAsync(UserInfoDTO userInfo)
        {
            await _userService.AddUserAsync(userInfo);
            return Ok();
        }
    }

}