using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using MyBlog.Models;
using MyBlog.Service.Interfaces;
using MyBlog.Data;
using MyBlog.Helpers;
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
        public IActionResult Index(string section)
        {
            var blogs = BlogService.GetBySection(section);
            var overviewViewModel = blogs.Select(x => ModelConverter.ConvertToOverviewModel(x)).ToList();

            return View(overviewViewModel);
        }
        public IActionResult ViewFullBlog(int id)
        {
            var blog = BlogService.GetById(id);
            return View(blog);
        }

        public IActionResult Create()
        {
            var blog = new Blog();
            return View(blog);
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                var converted=SectionConverter.ConvertToSection(blog);
                BlogService.CreateBlog(converted);
                return RedirectToAction("Index");
            }
            else
            {
                return View(blog);
            }
        }

        public IActionResult ModifyOverview()
        {
            var blogs = BlogService.GetAll();
            return View(blogs);
        }
        public IActionResult Delete(int id)
        {
            BlogService.Delete(id);
            return RedirectToAction("ModifyOverview");
        }

        public IActionResult Modify(int id)
        {
            var blog = BlogService.GetById(id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult Modify(Blog blog)
        {
            if (ModelState.IsValid)
            {
                BlogService.UpdateBlog(blog);
                return RedirectToAction("ModifyOverview");
            }
            else
            {
                return View(blog);
            }
        }

       
    }
}
