using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.APP.AppServices.IServices;
using TodoApi.DATA.DTO;
using TodoApi.DATA.Entities;
using TodoApi.DATA.Repositories.IRepository;

namespace TodoApi.APP.AppServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        public UserService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }
        public async Task AddUserAsync(UserInfoDTO userInfoDto )
        {
            var userInfo = new UserInfo
            {
                Name = userInfoDto.Name,
                Mail = userInfoDto.Mail
            };
            _userInfoRepository.AddUserInfo(userInfo);
        }

        public async Task<UserInfoDTO> GetAsync(int userid)
        {
        }
        
    }
    
}