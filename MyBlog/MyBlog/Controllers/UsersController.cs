using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Custom;
using MyBlog.Helpers;
using MyBlog.Service.Interfaces;

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
            var user = userService.GetById(id);
            var modifyUser = ModelConverter.ConvertToUserModifyModel(user);
            return View(modifyUser);
        }


    }
}