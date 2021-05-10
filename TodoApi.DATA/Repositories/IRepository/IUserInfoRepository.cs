using System.Collections.Generic;
using System.Linq;
using TodoApi.DATA.Entities;

namespace TodoApi.DATA.Repositories.IRepository
{
    public interface IUserInfoRepository
    {
        public void AddUserInfo(UserInfo userInfo);
        public void GetUsers(UserInfo userInfo);
    }
}