using CinemaAutomation.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Identity.Core;
using DataAccess.Entities;

namespace CinemaAutomation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;


        public AccountController( UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

      public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.Email
                };

                var result = await userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    
                }

                return View(registerVM);
            }
            else
            {
                return View(registerVM);
            }
        }
      
        public IActionResult Login()
        {

            return View();
        }

        public async Task<IActionResult> LogOut(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await signInManager.SignOutAsync();
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Login(LoginVM loginVM)
        {
            if (userManager.Users.Any(x => x.UserName == loginVM.UserName))

            {
                AppUser user = await userManager.FindByNameAsync(loginVM.UserName);
                var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsPersistant, false);
                
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        return View();
                    }
                
            }

            return View();
        }

        public async Task<IActionResult> Profile(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }

            return View();
        }
    }

}
