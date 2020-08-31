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
    [Route("api/Chercheur")]
    public class ChercheurController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public ChercheurController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetChercheur()
        {
            List<UserProfile> Items = await _context.UserProfile.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<UserProfile> chercheur)
        {
            UserProfile cher = chercheur.value;
            _context.UserProfile.Add(cher);
            _context.SaveChanges();
            return Ok(cher);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<UserProfile> chercheur)
        {
            UserProfile cher = chercheur.value;
            _context.UserProfile.Update(cher);
            _context.SaveChanges();
            return Ok(cher);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<UserProfile> chercheur)
        {
            UserProfile cher = _context.UserProfile
                .Where(x => x.UserProfileId == (int)chercheur.key)
                .FirstOrDefault();
            _context.UserProfile.Remove(cher);
            _context.SaveChanges();
            return Ok(cher);

        }
    }
}
