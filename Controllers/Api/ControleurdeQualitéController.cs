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
    [Route("api/ControleurdeQualité")]
    public class ControleurdeQualitéController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public ControleurdeQualitéController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<IActionResult> GetVendor()
        {
            List<ControleurdeQualité> Items = await _context.ControleurdeQualité.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<ControleurdeQualité> payload)
        {
            ControleurdeQualité vendor = payload.value;
            _context.ControleurdeQualité.Add(vendor);
            _context.SaveChanges();
            return Ok(vendor);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<ControleurdeQualité> payload)
        {
            ControleurdeQualité vendor = payload.value;
            _context.ControleurdeQualité.Update(vendor);
            _context.SaveChanges();
            return Ok(vendor);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<ControleurdeQualité> payload)
        {
            ControleurdeQualité vendor = _context.ControleurdeQualité
                .Where(x => x.VendorId == (int)payload.key)
                .FirstOrDefault();
            _context.ControleurdeQualité.Remove(vendor);
            _context.SaveChanges();
            return Ok(vendor);

        }
    }
}