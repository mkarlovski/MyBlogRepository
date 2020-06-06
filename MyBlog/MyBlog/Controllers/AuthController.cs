using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Service.Interfaces;
using MyBlog.ViewModels;

namespace MyBlog.Controllers
{
    public class AuthController : Controller
    {
        public IAuthService AuthService { get; set; }
        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }
        public IActionResult SignIn()
        {
            var signInModel = new SignInModel();
            return View(signInModel);
        }

        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var isSignedIn = await AuthService.SignInAsync(model.Username, model.Password,HttpContext);
                if (isSignedIn)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                }
            }
            return View(model);
        }
    }
}