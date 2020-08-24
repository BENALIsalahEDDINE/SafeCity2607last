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
    [Route("api/PaymentType")]
    public class PublicationPublicController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicationPublicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentType
        [HttpGet]
        public async Task<IActionResult> GetPaymentType()
        {
            List<PublicationPublic> Items = await _context.PublicationPublic.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<PublicationPublic> payload)
        {
            PublicationPublic paymentType = payload.value;
            _context.PublicationPublic.Add(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<PublicationPublic> payload)
        {
            PublicationPublic paymentType = payload.value;
            _context.PublicationPublic.Update(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<PublicationPublic> payload)
        {
            PublicationPublic paymentType = _context.PublicationPublic
                .Where(x => x.PaymentTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.PublicationPublic.Remove(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);

        }
    }
}