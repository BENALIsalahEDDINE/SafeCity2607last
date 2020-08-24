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
    [Route("api/DateDébutFinControleurQ")]
    public class DateDébutFinControleurQController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;

        public DateDébutFinControleurQController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/PurchaseOrder
        [HttpGet]
        public async Task<IActionResult> GetPurchaseOrder()
        {
            List<DateDébutFinControleurQ> Items = await _context.DateDébutFinControleurQ.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNotReceivedYet()
        {
            List<DateDébutFinControleurQ> purchaseOrders = new List<DateDébutFinControleurQ>();
            try
            {
                List<InfoPublicationControleurQ> grns = new List<InfoPublicationControleurQ>();
                grns = await _context.InfoPublicationControleurQ.ToListAsync();
                List<int> ids = new List<int>();

                foreach (var item in grns)
                {
                    ids.Add(item.PurchaseOrderId);
                }

                purchaseOrders = await _context.DateDébutFinControleurQ
                    .Where(x => !ids.Contains(x.PurchaseOrderId))
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(purchaseOrders);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            DateDébutFinControleurQ result = await _context.DateDébutFinControleurQ
                .Where(x => x.PurchaseOrderId.Equals(id))
                .Include(x => x.DateDébutFinControleurQLines)
                .FirstOrDefaultAsync();

            return Ok(result);
        }

        private void UpdatePurchaseOrder(int purchaseOrderId)
        {
            try
            {
                DateDébutFinControleurQ purchaseOrder = new DateDébutFinControleurQ();
                purchaseOrder = _context.DateDébutFinControleurQ
                    .Where(x => x.PurchaseOrderId.Equals(purchaseOrderId))
                    .FirstOrDefault();

                if (purchaseOrder != null)
                {
                    List<DateDébutFinControleurQLine> lines = new List<DateDébutFinControleurQLine>();
                    lines = _context.DateDébutFinControleurQLine.Where(x => x.PurchaseOrderId.Equals(purchaseOrderId)).ToList();

                    //update master data by its lines
                    purchaseOrder.Amount = lines.Sum(x => x.Amount);
                    purchaseOrder.SubTotal = lines.Sum(x => x.SubTotal);

                    purchaseOrder.Discount = lines.Sum(x => x.DiscountAmount);
                    purchaseOrder.Tax = lines.Sum(x => x.TaxAmount);

                    purchaseOrder.Total = purchaseOrder.Freight + lines.Sum(x => x.Total);

                    _context.Update(purchaseOrder);

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<DateDébutFinControleurQ> payload)
        {
            DateDébutFinControleurQ purchaseOrder = payload.value;
            purchaseOrder.PurchaseOrderName = _numberSequence.GetNumberSequence("PO");
            _context.DateDébutFinControleurQ.Add(purchaseOrder);
            _context.SaveChanges();
            this.UpdatePurchaseOrder(purchaseOrder.PurchaseOrderId);
            return Ok(purchaseOrder);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<DateDébutFinControleurQ> payload)
        {
            DateDébutFinControleurQ purchaseOrder = payload.value;
            _context.DateDébutFinControleurQ.Update(purchaseOrder);
            _context.SaveChanges();
            this.UpdatePurchaseOrder(purchaseOrder.PurchaseOrderId);
            return Ok(purchaseOrder);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<DateDébutFinControleurQ> payload)
        {
            DateDébutFinControleurQ purchaseOrder = _context.DateDébutFinControleurQ
                .Where(x => x.PurchaseOrderId == (int)payload.key)
                .FirstOrDefault();
            _context.DateDébutFinControleurQ.Remove(purchaseOrder);
            _context.SaveChanges();
            this.UpdatePurchaseOrder(purchaseOrder.PurchaseOrderId);
            return Ok(purchaseOrder);

        }
    }
}