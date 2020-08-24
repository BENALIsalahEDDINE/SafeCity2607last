using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeCity2607last.Data;
using SafeCity2607last.Models;
using SafeCity2607last.Services;
using SafeCity2607last.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;

namespace SafeCity2607last.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;

        public MessageController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/Invoice
        [HttpGet]
        public async Task<IActionResult> GetInvoice()
        {
            List<Message> Items = await _context.Message.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNotPaidYet()
        {
            List<Message> invoices = new List<Message>();
            try
            {
                List<InfosMessage> receives = new List<InfosMessage>();
                receives = await _context.InfosMessage.ToListAsync();
                List<int> ids = new List<int>();

                foreach (var item in receives)
                {
                    ids.Add(item.InvoiceId);
                }

                invoices = await _context.Message
                    .Where(x => !ids.Contains(x.InvoiceId))
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(invoices);
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Message> payload)
        {
            Message invoice = payload.value;
            invoice.InvoiceName = _numberSequence.GetNumberSequence("INV");
            _context.Message.Add(invoice);
            _context.SaveChanges();
            return Ok(invoice);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Message> payload)
        {
            Message invoice = payload.value;
            _context.Message.Update(invoice);
            _context.SaveChanges();
            return Ok(invoice);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Message> payload)
        {
            Message invoice = _context.Message
                .Where(x => x.InvoiceId == (int)payload.key)
                .FirstOrDefault();
            _context.Message.Remove(invoice);
            _context.SaveChanges();
            return Ok(invoice);

        }
    }
}