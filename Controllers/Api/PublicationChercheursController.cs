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
    [Route("api/PublicationChercheurs")]
    public class PublicationChercheursController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicationChercheursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            List<PublicationChercheurs> Items = await _context.PublicationChercheurs.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<PublicationChercheurs> payload)
        {
            PublicationChercheurs product = payload.value;
            _context.PublicationChercheurs.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<PublicationChercheurs> payload)
        {
            PublicationChercheurs product = payload.value;
            _context.PublicationChercheurs.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<PublicationChercheurs> payload)
        {
            PublicationChercheurs product = _context.PublicationChercheurs
                .Where(x => x.ProductId == (int)payload.key)
                .FirstOrDefault();
            _context.PublicationChercheurs.Remove(product);
            _context.SaveChanges();
            return Ok(product);

        }
    }
}