using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyBlog.Data;
//using Microsoft.Owin.Security.Cookies;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.DtoModels;
using MyBlog.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class AuthService : IAuthService
    {
        public IUserRepository UserRepository { get; set; }
        public AuthService(IUserRepository userRepo)
        {
            UserRepository = userRepo;
        }

        public async Task<bool> SignInAsync(string username, string password, HttpContext httpContext)
        {
            var user = UserRepository.GetByUsername(username);
            if(user!=null && user.Password==password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Username),
                    new Claim(ClaimTypes.Name,user.Username),
                    new Claim("IsAdmin",user.IsAdmin.ToString()),
                    new Claim("Id",user.Id.ToString())
                };
                var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await httpContext.SignInAsync(principal);

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        public SignUpResponse SignUp(string username, string password)
        {
            var user = UserRepository.GetByUsername(username);
            var response = new SignUpResponse();
            if (user == null)
            {
                var newUser = new User
                {
                    Username=username,
                    Password=password
                };
                UserRepository.Add(newUser);
                response.IsSuccessful = true;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "User with that username already exists";
            }

            return response;

        }
    }
}
