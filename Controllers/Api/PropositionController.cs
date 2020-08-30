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
        public async Task<IActionResult> GetCashBank()
        {
            List<Proposition> Items = await _context.Proposition.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Proposition> payload)
        {
            Proposition cashBank = payload.value;
            _context.Proposition.Add(cashBank);
            _context.SaveChanges();
            return Ok(cashBank);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Proposition> payload)
        {
            Proposition cashBank = payload.value;
            _context.Proposition.Update(cashBank);
            _context.SaveChanges();
            return Ok(cashBank);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Proposition> payload)
        {
            Proposition cashBank = _context.Proposition
                .Where(x => x.Id_Prop == (int)payload.key)
                .FirstOrDefault();
            _context.Proposition.Remove(cashBank);
            _context.SaveChanges();
            return Ok(cashBank);

        }
    }
}