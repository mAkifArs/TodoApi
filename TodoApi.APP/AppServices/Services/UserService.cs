using System.Threading.Tasks;
using TodoApi.APP.AppServices.IServices;
using TodoApi.DATA;
using TodoApi.DATA.DTO;
using TodoApi.DATA.Entities;

namespace TodoApi.APP.AppServices.Services
{
    public class UserService : IUserService
    {
        private readonly TodoApiDataContext _db;

        public UserService(TodoApiDataContext db)
        {
            _db = db;
        }


        public async Task AddUserAsync(UserInfoDTO userInfoDto)
        {
            var user = new UserInfo
            {
                UserId = userInfoDto.UserId,
                Mail = userInfoDto.Mail,
                Name = userInfoDto.Name
            };
            await _db.UserInfos.AddAsync(user);
            await _db.SaveChangesAsync();
        }
    }
}