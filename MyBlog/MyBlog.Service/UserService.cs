using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.DtoModels;
using MyBlog.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public ModifyUserResult ModifyUser(User user)
        {
            var result = new ModifyUserResult();
            var currentUser = userRepository.GetByUsername(user.Username);
            if(currentUser==null || currentUser.Id == user.Id)
            {
                var dbUser = userRepository.GetById(user.Id);
                dbUser.Username = user.Username;
                dbUser.IsAdmin = user.IsAdmin;

                userRepository.Update(dbUser);
                result.Status = true;
            }
            else
            {
                result.Status = false;
                result.Message = "User already exists";
            }

            return result;
        }
    }
}
