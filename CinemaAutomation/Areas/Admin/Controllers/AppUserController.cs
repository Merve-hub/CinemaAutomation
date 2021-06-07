using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAutomation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AppUserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: AppUserController
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();

            return View(users);
        }

        public async Task<IActionResult> AdminRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await userManager.AddToRoleAsync(user, "admin");
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
