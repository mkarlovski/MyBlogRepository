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

        [HttpPost]
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
                    ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await AuthService.SignOutAsync(HttpContext);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
            var signUpModel = new SignUpModel();
            return View(signUpModel);
        }

        [HttpPost]
        public IActionResult SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var response = AuthService.SignUp(model.Username, model.Password);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.Message);
                    return View(model);
                }
                
            }
            return View(model);
        }

    }
}