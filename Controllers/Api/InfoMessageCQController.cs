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
    [Route("api/InfoMessageCQ")]
    public class InfoMessageCQController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;

        public InfoMessageCQController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/PaymentVoucher
        [HttpGet]
        public async Task<IActionResult> GetPaymentVoucher()
        {
            List<InfoMessageCQ> Items = await _context.InfoMessageCQ.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<InfoMessageCQ> payload)
        {
            InfoMessageCQ paymentVoucher = payload.value;
            paymentVoucher.PaymentVoucherName = _numberSequence.GetNumberSequence("PAYVCH");
            _context.InfoMessageCQ.Add(paymentVoucher);
            _context.SaveChanges();
            return Ok(paymentVoucher);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<InfoMessageCQ> payload)
        {
            InfoMessageCQ paymentVoucher = payload.value;
            _context.InfoMessageCQ.Update(paymentVoucher);
            _context.SaveChanges();
            return Ok(paymentVoucher);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<InfoMessageCQ> payload)
        {
            InfoMessageCQ paymentVoucher = _context.InfoMessageCQ
                .Where(x => x.PaymentvoucherId == (int)payload.key)
                .FirstOrDefault();
            _context.InfoMessageCQ.Remove(paymentVoucher);
            _context.SaveChanges();
            return Ok(paymentVoucher);

        }
    }
}