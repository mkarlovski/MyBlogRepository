using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repository
{
    public class UserRepository: IUserRepository
    {
        private MyBlogDBContext Context { get; set; }

        public UserRepository(MyBlogDBContext context)
        {
            Context = context;
        }

        public User GetByUsername(string username)
        {
            return Context.Users.FirstOrDefault(x=>x.Username==username);
        }

        public void Add(User newUser)
        {
            Context.Users.Add(newUser);
            Context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public void Delete(int id)
        {
            var user = new User
            {
                Id = id
            };

            Context.Users.Remove(user);
            Context.SaveChanges();
        }

        public User GetById(int id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User dbUser)
        {
            Context.Users.Update(dbUser);
            Context.SaveChanges();
        }
    }
}
