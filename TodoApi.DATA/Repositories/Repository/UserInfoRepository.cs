using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TodoApi.DATA.DTO;
using TodoApi.DATA.Entities;
using TodoApi.DATA.Repositories.IRepository;

namespace TodoApi.DATA.Repositories.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly TodoApiDataContext _todoApiDataContext;

        public UserInfoRepository(TodoApiDataContext todoApiDataContext)
        {
            _todoApiDataContext = todoApiDataContext;
        }
        
        public void AddUserInfo(UserInfo userInfo)
        {
            _todoApiDataContext.UserInfos.Add(userInfo);
            _todoApiDataContext.SaveChanges();
        }

        public void GetUsers(UserInfo userInfo)
        {
            _todoApiDataContext.UserInfos.Map(userInfo);
            
        }
        
    }
}