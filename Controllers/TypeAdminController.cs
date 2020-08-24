using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SafeCity2607last.Controllers
{
    [Authorize(Roles = Pages.MainMenu.TypeAdmin.RoleName)]
    public class TypeAdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}