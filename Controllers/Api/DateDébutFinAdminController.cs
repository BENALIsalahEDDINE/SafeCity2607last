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
    [Route("api/DateDébutFinAdmin")]
    public class DateDébutFinAdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;

        public DateDébutFinAdminController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/SalesOrder
        [HttpGet]
        public async Task<IActionResult> GetSalesOrder()
        {
            List<DateDébutFinAdmin> Items = await _context.DateDébutFinAdmin.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNotShippedYet()
        {
            List<DateDébutFinAdmin> salesOrders = new List<DateDébutFinAdmin>();
            try
            {
                List<InfosPublicationsAdmin> shipments = new List<InfosPublicationsAdmin>();
                shipments = await _context.InfosPublicationsAdmin.ToListAsync();
                List<int> ids = new List<int>();

                foreach (var item in shipments)
                {
                    ids.Add(item.SalesOrderId);
                }

                salesOrders = await _context.DateDébutFinAdmin
                    .Where(x => !ids.Contains(x.SalesOrderId))
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(salesOrders);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            DateDébutFinAdmin result = await _context.DateDébutFinAdmin
                .Where(x => x.SalesOrderId.Equals(id))
                .Include(x => x.DateDébutFinAdminLines)
                .FirstOrDefaultAsync();

            return Ok(result);
        }

        private void UpdateSalesOrder(int salesOrderId)
        {
            try
            {
                DateDébutFinAdmin salesOrder = new DateDébutFinAdmin();
                salesOrder = _context.DateDébutFinAdmin
                    .Where(x => x.SalesOrderId.Equals(salesOrderId))
                    .FirstOrDefault();

                if (salesOrder != null)
                {
                    List<DateDébutFinAdminLine> lines = new List<DateDébutFinAdminLine>();
                    lines = _context.DateDébutFinAdminLine.Where(x => x.SalesOrderId.Equals(salesOrderId)).ToList();

                    //update master data by its lines
                    salesOrder.Amount = lines.Sum(x => x.Amount);
                    salesOrder.SubTotal = lines.Sum(x => x.SubTotal);

                    salesOrder.Discount = lines.Sum(x => x.DiscountAmount);
                    salesOrder.Tax = lines.Sum(x => x.TaxAmount);

                    salesOrder.Total = salesOrder.Freight + lines.Sum(x => x.Total);

                    _context.Update(salesOrder);

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<DateDébutFinAdmin> payload)
        {
            DateDébutFinAdmin salesOrder = payload.value;
            salesOrder.SalesOrderName = _numberSequence.GetNumberSequence("SO");
            _context.DateDébutFinAdmin.Add(salesOrder);
            _context.SaveChanges();
            this.UpdateSalesOrder(salesOrder.SalesOrderId);
            return Ok(salesOrder);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<DateDébutFinAdmin> payload)
        {
            DateDébutFinAdmin salesOrder = payload.value;
            _context.DateDébutFinAdmin.Update(salesOrder);
            _context.SaveChanges();
            return Ok(salesOrder);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<DateDébutFinAdmin> payload)
        {
            DateDébutFinAdmin salesOrder = _context.DateDébutFinAdmin
                .Where(x => x.SalesOrderId == (int)payload.key)
                .FirstOrDefault();
            _context.DateDébutFinAdmin.Remove(salesOrder);
            _context.SaveChanges();
            return Ok(salesOrder);

        }
    }
}