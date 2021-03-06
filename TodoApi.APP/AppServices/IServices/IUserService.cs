using System.Threading.Tasks;
using TodoApi.DATA.DTO;

namespace TodoApi.APP.AppServices.IServices
{
    public interface IUserService
    {
        Task AddUserAsync(UserInfoDTO userInfoDto);
    }
}