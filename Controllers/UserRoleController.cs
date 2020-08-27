using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeCity2607last.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SafeCity2607last.Controllers
{
    
    public class UserRoleController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRoleController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [Authorize(Roles = Pages.MainMenu.User.RoleName)]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = Pages.MainMenu.ChangePassword.RoleName)]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize(Roles = Pages.MainMenu.Role.RoleName)]
        public IActionResult Role()
        {
            return View();
        }

        [Authorize(Roles ="Change Role")]
        public IActionResult ChangeRole()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> UserProfile()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            return View(user);
        }
    }
}