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
    [Route("api/SujetPublication")]
    public class SujetPublicationController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public SujetPublicationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UnitOfMeasure
        [HttpGet]
        public async Task<IActionResult> GetUnitOfMeasure()
        {
            List<SujetPublication> Items = await _context.SujetPublication.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<SujetPublication> payload)
        {
            SujetPublication unitOfMeasure = payload.value;
            _context.SujetPublication.Add(unitOfMeasure);
            _context.SaveChanges();
            return Ok(unitOfMeasure);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<SujetPublication> payload)
        {
            SujetPublication unitOfMeasure = payload.value;
            _context.SujetPublication.Update(unitOfMeasure);
            _context.SaveChanges();
            return Ok(unitOfMeasure);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<SujetPublication> payload)
        {
            SujetPublication unitOfMeasure = _context.SujetPublication
                .Where(x => x.UnitOfMeasureId == (int)payload.key)
                .FirstOrDefault();
            _context.SujetPublication.Remove(unitOfMeasure);
            _context.SaveChanges();
            return Ok(unitOfMeasure);

        }
    }
}