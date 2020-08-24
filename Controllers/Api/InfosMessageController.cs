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
    [Route("api/InfosMessage")]
    public class InfosMessageController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;

        public InfosMessageController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/PaymentReceive
        [HttpGet]
        public async Task<IActionResult> GetPaymentReceive()
        {
            List<InfosMessage> Items = await _context.InfosMessage.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<InfosMessage> payload)
        {
            InfosMessage paymentReceive = payload.value;
            paymentReceive.PaymentReceiveName = _numberSequence.GetNumberSequence("PAYRCV");
            _context.InfosMessage.Add(paymentReceive);
            _context.SaveChanges();
            return Ok(paymentReceive);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<InfosMessage> payload)
        {
            InfosMessage paymentReceive = payload.value;
            _context.InfosMessage.Update(paymentReceive);
            _context.SaveChanges();
            return Ok(paymentReceive);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<InfosMessage> payload)
        {
            InfosMessage paymentReceive = _context.InfosMessage
                .Where(x => x.PaymentReceiveId == (int)payload.key)
                .FirstOrDefault();
            _context.InfosMessage.Remove(paymentReceive);
            _context.SaveChanges();
            return Ok(paymentReceive);

        }
    }
}