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
    [Authorize(Roles = Pages.MainMenu.DateDébutFinControleurQ.RoleName)]
    public class DateDébutFinControleurQController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public DateDébutFinControleurQController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            DateDébutFinControleurQ purchaseOrder = _context.DateDébutFinControleurQ.SingleOrDefault(x => x.PurchaseOrderId.Equals(id));

            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }
    }
}