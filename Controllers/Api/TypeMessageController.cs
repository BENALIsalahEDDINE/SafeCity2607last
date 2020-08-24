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
    [Route("api/TypeMessage")]
    public class TypeMessageController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeMessageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceType
        [HttpGet]
        public async Task<IActionResult> GetInvoiceType()
        {
            List<TypeMessage> Items = await _context.TypeMessage.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<TypeMessage> payload)
        {
            TypeMessage invoiceType = payload.value;
            _context.TypeMessage.Add(invoiceType);
            _context.SaveChanges();
            return Ok(invoiceType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<TypeMessage> payload)
        {
            TypeMessage invoiceType = payload.value;
            _context.TypeMessage.Update(invoiceType);
            _context.SaveChanges();
            return Ok(invoiceType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<TypeMessage> payload)
        {
            TypeMessage invoiceType = _context.TypeMessage
                .Where(x => x.InvoiceTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.TypeMessage.Remove(invoiceType);
            _context.SaveChanges();
            return Ok(invoiceType);

        }
    }
}