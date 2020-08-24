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
    [Route("api/PropositionsAdmin")]
    public class PropositionsAdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public PropositionsAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesType
        [HttpGet]
        public async Task<IActionResult> GetSalesType()
        {
            List<PropositionsAdmin> Items = await _context.PropositionsAdmin.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<PropositionsAdmin> payload)
        {
            PropositionsAdmin salesType = payload.value;
            _context.PropositionsAdmin.Add(salesType);
            _context.SaveChanges();
            return Ok(salesType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<PropositionsAdmin> payload)
        {
            PropositionsAdmin salesType = payload.value;
            _context.PropositionsAdmin.Update(salesType);
            _context.SaveChanges();
            return Ok(salesType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<PropositionsAdmin> payload)
        {
            PropositionsAdmin salesType = _context.PropositionsAdmin
                .Where(x => x.SalesTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.PropositionsAdmin.Remove(salesType);
            _context.SaveChanges();
            return Ok(salesType);

        }
    }
}