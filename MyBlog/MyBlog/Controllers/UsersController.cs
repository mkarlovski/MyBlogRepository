using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Custom;
using MyBlog.Helpers;
using MyBlog.Service.Interfaces;
using MyBlog.ViewModels;

namespace MyBlog.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult UsersModifyOverview()
        {
            var users = userService.GetAll();
            var usersModify = users.Select(x => ModelConverter.ConvertToUserModifyOverviewModel(x)).ToList();
            return View(usersModify);
        }

        public IActionResult Delete(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            userService.Delete(id);

            if (Convert.ToInt32(User.FindFirst("Id").Value) == id)
            {
                RedirectToAction("SignOut", "Auth");
            }

            return RedirectToAction("SuccessfulUserChange");
        }

        public IActionResult Modify(int id)
        {
            if (AuthorizeService.AuthorizeUser(User,id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            var user = userService.GetById(id);
            var modifyUser = ModelConverter.ConvertToUserModifyModel(user);
            return View(modifyUser);
        }

        [HttpPost]
        public IActionResult Modify(UserModifyModel model)
        {
            if (AuthorizeService.AuthorizeUser(User, model.Id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            if (ModelState.IsValid)
            {
                var user = ModelConverter.ConvertFromUserModifyModel(model);
                var result = userService.ModifyUser(user);
                if (result.Status)
                {
                    RedirectToAction("SuccessfulUserChange");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
           
            return View(model);
        }

        public IActionResult SuccessfulUserChange()
        {
            return View();
        }




    }
}