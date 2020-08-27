using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SafeCity2607last.Controllers
{
    public class ChercheurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
