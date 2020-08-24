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
    [Route("api/PropositionPublic")]
    public class PropositionPublicController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public PropositionPublicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CashBank
        [HttpGet]
        public async Task<IActionResult> GetCashBank()
        {
            List<PropositionPublic> Items = await _context.PropositionPublic.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<PropositionPublic> payload)
        {
            PropositionPublic cashBank = payload.value;
            _context.PropositionPublic.Add(cashBank);
            _context.SaveChanges();
            return Ok(cashBank);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<PropositionPublic> payload)
        {
            PropositionPublic cashBank = payload.value;
            _context.PropositionPublic.Update(cashBank);
            _context.SaveChanges();
            return Ok(cashBank);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<PropositionPublic> payload)
        {
            PropositionPublic cashBank = _context.PropositionPublic
                .Where(x => x.CashBankId == (int)payload.key)
                .FirstOrDefault();
            _context.PropositionPublic.Remove(cashBank);
            _context.SaveChanges();
            return Ok(cashBank);

        }
    }
}