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
using MyBlog.ViewModels;
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
            var detailsViewModel = ModelConverter.ConvertToDetailsModel(blog);
            return View(detailsViewModel);
        }

        public IActionResult Create()
        {
            //var blog = new Blog();
            var blog = new BlogCreateModel();
            return View(blog);
        }

        [HttpPost]
        public IActionResult Create(BlogCreateModel blogCreate)
        {
            if (ModelState.IsValid)
            {
                
                var blog = ModelConverter.ConvertFromCreateModel(blogCreate);
                var converted = SectionConverter.ConvertToSection(blog);
                BlogService.CreateBlog(converted);
                return RedirectToAction("Index");
            }
            else
            {
                return View(blogCreate);
            }
        }

        public IActionResult ModifyOverview()
        {
            var blogs = BlogService.GetAll();
            var modifyOverview = blogs.Select(x => ModelConverter.ConvertToModifyOverview(x)).ToList();
            return View(modifyOverview);
        }
        public IActionResult Delete(int id)
        {
            BlogService.Delete(id);
            return RedirectToAction("ModifyOverview");
        }

        public IActionResult Modify(int id)
        {
            var blog = BlogService.GetById(id);
            var blogModify = ModelConverter.ConvertToBlogModify(blog);
            return View(blogModify);
        }

        [HttpPost]
        public IActionResult Modify(BlogModifyModel blogModify)
        {
            if (ModelState.IsValid)
            {
                var blog = ModelConverter.ConvertFromBlogModify(blogModify);
                var blogConverted = SectionConverter.ConvertToSection(blog);
                BlogService.UpdateBlog(blogConverted);
                return RedirectToAction("ModifyOverview");
            }
            else
            {
                return View(blogModify);
            }
        }

       
    }
}
