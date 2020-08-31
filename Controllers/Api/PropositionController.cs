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
    [Route("api/Proposition")]
    public class PropositionController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public PropositionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CashBank
        [HttpGet]
        public async Task<IActionResult> GetProposition()
        {
            List<Proposition> Items = await _context.Proposition.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Proposition> proposition)
        {
            Proposition propo = proposition.value;
            _context.Proposition.Add(propo);
            _context.SaveChanges();
            return Ok(propo);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Proposition> proposition)
        {
            Proposition propo = proposition.value;
            _context.Proposition.Update(propo);
            _context.SaveChanges();
            return Ok(propo);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Proposition> proposition)
        {
            Proposition propo = _context.Proposition
                .Where(x => x.Id_Prop == (int)proposition.key)
                .FirstOrDefault();
            _context.Proposition.Remove(propo);
            _context.SaveChanges();
            return Ok(propo);

        }
    }
}