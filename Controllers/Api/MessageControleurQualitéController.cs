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
    [Route("api/MessageControleurQualité")]
    public class MessageControleurQualitéController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;

        public MessageControleurQualitéController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/Bill
        [HttpGet]
        public async Task<IActionResult> GetBill()
        {
            List<MessageControleurQualité> Items = await _context.MessageControleurQualité.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNotPaidYet()
        {
            List<MessageControleurQualité> bills = new List<MessageControleurQualité>();
            try
            {
                List<InfoMessageCQ> vouchers = new List<InfoMessageCQ>();
                vouchers = await _context.InfoMessageCQ.ToListAsync();
                List<int> ids = new List<int>();

                foreach (var item in vouchers)
                {
                    ids.Add(item.BillId);
                }

                bills = await _context.MessageControleurQualité
                    .Where(x => !ids.Contains(x.BillId))
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(bills);
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<MessageControleurQualité> payload)
        {
            MessageControleurQualité bill = payload.value;
            bill.BillName = _numberSequence.GetNumberSequence("MessageControleurQualité");
            _context.MessageControleurQualité.Add(bill);
            _context.SaveChanges();
            return Ok(bill);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<MessageControleurQualité> payload)
        {
            MessageControleurQualité bill = payload.value;
            _context.MessageControleurQualité.Update(bill);
            _context.SaveChanges();
            return Ok(bill);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<MessageControleurQualité> payload)
        {
            MessageControleurQualité bill = _context.MessageControleurQualité
                .Where(x => x.BillId == (int)payload.key)
                .FirstOrDefault();
            _context.MessageControleurQualité.Remove(bill);
            _context.SaveChanges();
            return Ok(bill);

        }
    }
}