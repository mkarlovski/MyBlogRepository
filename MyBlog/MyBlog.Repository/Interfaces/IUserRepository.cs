using MyBlog.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        void Add(User newUser);
        List<User> GetAll();
        void Delete(int id);
        User GetById(int id);
        void Update(User dbUser);
    }
}
