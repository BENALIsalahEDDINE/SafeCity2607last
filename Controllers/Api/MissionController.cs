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
using SafeCity2607last.Services;
using Microsoft.AspNetCore.Authorization;

namespace SafeCity2607last.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Mission")]
    public class MissionController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public MissionController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetBranch()
        {
            List<Mission> Items = await _context.Mission.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Mission> payload)
        {
            Mission branch = payload.value;
            _context.Mission.Add(branch);
            _context.SaveChanges();
            return Ok(branch);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Mission> payload)
        {
            Mission branch = payload.value;
            _context.Mission.Update(branch);
            _context.SaveChanges();
            return Ok(branch);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Mission> payload)
        {
            Mission branch = _context.Mission
                .Where(x => x.BranchId == (int)payload.key)
                .FirstOrDefault();
            _context.Mission.Remove(branch);
            _context.SaveChanges();
            return Ok(branch);

        }
        
    }
}