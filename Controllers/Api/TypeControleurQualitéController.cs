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
    [Route("api/TypeControleurQualité")]
    public class TypeControleurQualitéController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeControleurQualitéController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VendorType
        [HttpGet]
        public async Task<IActionResult> GetVendorType()
        {
            List<TypeControleurQualité> Items = await _context.TypeControleurQualité.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<TypeControleurQualité> payload)
        {
            TypeControleurQualité vendorType = payload.value;
            _context.TypeControleurQualité.Add(vendorType);
            _context.SaveChanges();
            return Ok(vendorType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<TypeControleurQualité> payload)
        {
            TypeControleurQualité vendorType = payload.value;
            _context.TypeControleurQualité.Update(vendorType);
            _context.SaveChanges();
            return Ok(vendorType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<TypeControleurQualité> payload)
        {
            TypeControleurQualité vendorType = _context.TypeControleurQualité
                .Where(x => x.VendorTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.TypeControleurQualité.Remove(vendorType);
            _context.SaveChanges();
            return Ok(vendorType);

        }
    }
}