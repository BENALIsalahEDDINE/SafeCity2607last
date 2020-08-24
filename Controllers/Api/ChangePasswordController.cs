using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeCity2607last.Data;
using SafeCity2607last.Models;
using SafeCity2607last.Models.ManageViewModels;
using SafeCity2607last.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SafeCity2607last.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/ChangePassword")]
    public class ChangePasswordController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ChangePasswordController(ApplicationDbContext context,
                        UserManager<ApplicationUser> userManager,
                        RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: api/ChangePassword
        [HttpGet]
        public IActionResult GetChangePassword()
        {
            List<ApplicationUser> Items = new List<ApplicationUser>();
            Items = _context.Users.ToList();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }
        
        

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody]CrudViewModel<ChangePasswordViewModel> payload)
        {
            ChangePasswordViewModel changePasswordViewModel = payload.value;
            var user = _context.Users.SingleOrDefault(x => x.Id.Equals(changePasswordViewModel.Id));

            if (user != null &&
                changePasswordViewModel.NewPassword.Equals(changePasswordViewModel.ConfirmPassword))
            {
                await _userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
            }

            return Ok();
        }
        
    }
}