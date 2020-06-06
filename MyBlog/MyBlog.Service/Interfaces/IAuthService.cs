using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(string username, string password,HttpContext httpContext);
        Task SignOutAsync(HttpContext httpContext);
    }
}
