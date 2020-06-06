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
    }
}
