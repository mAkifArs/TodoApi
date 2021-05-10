using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.DATA.DTO;
using TodoApi.DATA.Entities;

namespace TodoApi.APP.AppServices.IServices
{
    public interface IUserService
    {
        Task AddUserAsync(UserInfoDTO userInfoDto);
    }
}