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
    [Route("api/Grade")]
    public class GradeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public GradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Currency
        [HttpGet]
        public async Task<IActionResult> GetCurrency()
        {
            List<Grade> Items = await _context.Currency.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByBranchId([FromRoute]int id)
        {
            Mission branch = new Mission();
            Grade currency = new Grade();
            branch = await _context.Mission.SingleOrDefaultAsync(x => x.BranchId.Equals(id));
            if (branch != null && branch.CurrencyId != 0)
            {
                currency = await _context.Currency.SingleOrDefaultAsync(x => x.CurrencyId.Equals(branch.CurrencyId));
                
            }
            return Ok(currency);
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Grade> payload)
        {
            Grade currency = payload.value;
            _context.Currency.Add(currency);
            _context.SaveChanges();
            return Ok(currency);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Grade> payload)
        {
            Grade currency = payload.value;
            _context.Currency.Update(currency);
            _context.SaveChanges();
            return Ok(currency);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Grade> payload)
        {
            Grade currency = _context.Currency
                .Where(x => x.CurrencyId == (int)payload.key)
                .FirstOrDefault();
            _context.Currency.Remove(currency);
            _context.SaveChanges();
            return Ok(currency);

        }
    }
}