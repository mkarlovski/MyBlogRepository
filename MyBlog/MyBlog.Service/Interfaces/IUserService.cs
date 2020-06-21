using MyBlog.Data;
using MyBlog.Service.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Service.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        void Delete(int id);
        User GetById(int id);
        ModifyUserResult ModifyUser(User user);
    }
}
