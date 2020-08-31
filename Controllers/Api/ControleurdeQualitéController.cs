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
    [Route("api/ControleurdeQualité")]
    public class ControleurdeQualitéController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public ControleurdeQualitéController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<IActionResult> GetCQ()
        {
            List<UserProfile> Items = await _context.UserProfile.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<ControleurdeQualité> cq)
        {
            ControleurdeQualité commess = cq.value;
            _context.ControleurdeQualité.Add(commess);
            _context.SaveChanges();
            return Ok(commess);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<UserProfile> cq)
        {
            UserProfile commess = cq.value;
            _context.UserProfile.Update(commess);
            _context.SaveChanges();
            return Ok(commess);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<UserProfile> cq)
        {
            UserProfile commess = _context.UserProfile
                .Where(x => x.UserProfileId == (int)cq.key)
                .FirstOrDefault();
            _context.UserProfile.Remove(commess);
            _context.SaveChanges();
            return Ok(commess);

        }
    }
}