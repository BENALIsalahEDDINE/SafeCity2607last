using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SafeCity2607last.Controllers
{
    
    public class StatistiquesController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Authorize(Roles = Pages.MainMenu.Statistiques.RoleName)]
        public IActionResult Index()
        {
            return View();
        }
    }
}