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
    [Route("api/PropositionsControleurQualité")]
    public class PropositionsControleurQualitéController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public PropositionsControleurQualitéController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseType
        [HttpGet]
        public async Task<IActionResult> GetPurchaseType()
        {
            List<PropositionsControleurQualité> Items = await _context.PropositionsControleurQualité.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<PropositionsControleurQualité> payload)
        {
            PropositionsControleurQualité purchaseType = payload.value;
            _context.PropositionsControleurQualité.Add(purchaseType);
            _context.SaveChanges();
            return Ok(purchaseType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<PropositionsControleurQualité> payload)
        {
            PropositionsControleurQualité purchaseType = payload.value;
            _context.PropositionsControleurQualité.Update(purchaseType);
            _context.SaveChanges();
            return Ok(purchaseType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<PropositionsControleurQualité> payload)
        {
            PropositionsControleurQualité purchaseType = _context.PropositionsControleurQualité
                .Where(x => x.PurchaseTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.PropositionsControleurQualité.Remove(purchaseType);
            _context.SaveChanges();
            return Ok(purchaseType);

        }
    }
}