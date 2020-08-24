using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeCity2607last.Data;
using SafeCity2607last.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SafeCity2607last.Controllers
{
    [Authorize(Roles = Pages.MainMenu.DateDébutFinAdmin.RoleName)]
    public class DateDébutFinAdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public DateDébutFinAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            DateDébutFinAdmin salesOrder = _context.DateDébutFinAdmin.SingleOrDefault(x => x.SalesOrderId.Equals(id));

            if (salesOrder == null)
            {
                return NotFound();
            }

            return View(salesOrder);
        }
    }
}