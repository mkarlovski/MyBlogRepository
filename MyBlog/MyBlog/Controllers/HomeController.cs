using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Service.Interfaces;
//using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        public IBlogService BlogService { get; set; }

        public HomeController(IBlogService blogService)
        {
            BlogService = blogService;
        }
        public IActionResult Index()
        {
            var blogs = BlogService.GetAll();
            return View(blogs);
        }
        public IActionResult ViewFullBlog(int id)
        {
            var blog = BlogService.GetById(id);
            return View(blog);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
