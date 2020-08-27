using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeCity2607last.Data;
using SafeCity2607last.Models;
using SafeCity2607last.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;

namespace SafeCity2607last.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Chercheur")]
    public class ChercheurController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public ChercheurController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetVendor()
        {
            List<Chercheur> Items = await _context.Chercheur.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Chercheur> payload)
        {
            Chercheur vendor = payload.value;
            _context.Chercheur.Add(vendor);
            _context.SaveChanges();
            return Ok(vendor);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Chercheur> payload)
        {
            Chercheur vendor = payload.value;
            _context.Chercheur.Update(vendor);
            _context.SaveChanges();
            return Ok(vendor);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Chercheur> payload)
        {
            Chercheur vendor = _context.Chercheur
                .Where(x => x.VendorId == (int)payload.key)
                .FirstOrDefault();
            _context.Chercheur.Remove(vendor);
            _context.SaveChanges();
            return Ok(vendor);

        }
    }
}
