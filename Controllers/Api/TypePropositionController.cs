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
    [Route("api/TypeProposition")]
    public class TypePropositionController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public TypePropositionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BillType
        [HttpGet]
        public async Task<IActionResult> GetBillType()
        {
            List<TypeProposition> Items = await _context.TypeProposition.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<TypeProposition> payload)
        {
            TypeProposition billType = payload.value;
            _context.TypeProposition.Add(billType);
            _context.SaveChanges();
            return Ok(billType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<TypeProposition> payload)
        {
            TypeProposition billType = payload.value;
            _context.TypeProposition.Update(billType);
            _context.SaveChanges();
            return Ok(billType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<TypeProposition> payload)
        {
            TypeProposition billType = _context.TypeProposition
                .Where(x => x.BillTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.TypeProposition.Remove(billType);
            _context.SaveChanges();
            return Ok(billType);

        }
    }
}