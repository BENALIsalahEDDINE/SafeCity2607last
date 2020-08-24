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
    [Route("api/Lieu")]
    public class LieuController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public LieuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Warehouse
        [HttpGet]
        public async Task<IActionResult> GetWarehouse()
        {
            List<Lieu> Items = await _context.Lieu.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Lieu> payload)
        {
            Lieu warehouse = payload.value;
            _context.Lieu.Add(warehouse);
            _context.SaveChanges();
            return Ok(warehouse);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Lieu> payload)
        {
            Lieu warehouse = payload.value;
            _context.Lieu.Update(warehouse);
            _context.SaveChanges();
            return Ok(warehouse);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Lieu> payload)
        {
            Lieu warehouse = _context.Lieu
                .Where(x => x.WarehouseId == (int)payload.key)
                .FirstOrDefault();
            _context.Lieu.Remove(warehouse);
            _context.SaveChanges();
            return Ok(warehouse);

        }
    }
}