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
    [Route("api/DateDébutFinAdminLine")]
    public class DateDébutFinAdminLineController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public DateDébutFinAdminLineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesOrderLine
        [HttpGet]
        public async Task<IActionResult> GetSalesOrderLine()
        {
            var headers = Request.Headers["SalesOrderId"];
            int salesOrderId = Convert.ToInt32(headers);
            List<DateDébutFinAdminLine> Items = await _context.DateDébutFinAdminLine
                .Where(x => x.SalesOrderId.Equals(salesOrderId))
                .ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSalesOrderLineByShipmentId()
        {
            var headers = Request.Headers["ShipmentId"];
            int shipmentId = Convert.ToInt32(headers);
            InfosPublicationsAdmin shipment = await _context.InfosPublicationsAdmin.SingleOrDefaultAsync(x => x.ShipmentId.Equals(shipmentId));
            List<DateDébutFinAdminLine> Items = new List<DateDébutFinAdminLine>();
            if (shipment != null)
            {
                int salesOrderId = shipment.SalesOrderId;
                Items = await _context.DateDébutFinAdminLine
                    .Where(x => x.SalesOrderId.Equals(salesOrderId))
                    .ToListAsync();
            }
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSalesOrderLineByInvoiceId()
        {
            var headers = Request.Headers["InvoiceId"];
            int invoiceId = Convert.ToInt32(headers);
            Message invoice = await _context.Message.SingleOrDefaultAsync(x => x.InvoiceId.Equals(invoiceId));
            List<DateDébutFinAdminLine> Items = new List<DateDébutFinAdminLine>();
            if (invoice != null)
            {
                int shipmentId = invoice.ShipmentId;
                InfosPublicationsAdmin shipment = await _context.InfosPublicationsAdmin.SingleOrDefaultAsync(x => x.ShipmentId.Equals(shipmentId));
                if (shipment != null)
                {
                    int salesOrderId = shipment.SalesOrderId;
                    Items = await _context.DateDébutFinAdminLine
                        .Where(x => x.SalesOrderId.Equals(salesOrderId))
                        .ToListAsync();
                }
            }
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        private DateDébutFinAdminLine Recalculate(DateDébutFinAdminLine salesOrderLine)
        {
            try
            {
                salesOrderLine.Amount = salesOrderLine.Quantity * salesOrderLine.Price;
                salesOrderLine.DiscountAmount = (salesOrderLine.DiscountPercentage * salesOrderLine.Amount) / 100.0;
                salesOrderLine.SubTotal = salesOrderLine.Amount - salesOrderLine.DiscountAmount;
                salesOrderLine.TaxAmount = (salesOrderLine.TaxPercentage * salesOrderLine.SubTotal) / 100.0;
                salesOrderLine.Total = salesOrderLine.SubTotal + salesOrderLine.TaxAmount;

            }
            catch (Exception)
            {

                throw;
            }

            return salesOrderLine;
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
        public IActionResult Insert([FromBody]CrudViewModel<DateDébutFinAdminLine> payload)
        {
            DateDébutFinAdminLine salesOrderLine = payload.value;
            salesOrderLine = this.Recalculate(salesOrderLine);
            _context.DateDébutFinAdminLine.Add(salesOrderLine);
            _context.SaveChanges();
            this.UpdateSalesOrder(salesOrderLine.SalesOrderId);
            return Ok(salesOrderLine);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<DateDébutFinAdminLine> payload)
        {
            DateDébutFinAdminLine salesOrderLine = payload.value;
            salesOrderLine = this.Recalculate(salesOrderLine);
            _context.DateDébutFinAdminLine.Update(salesOrderLine);
            _context.SaveChanges();
            this.UpdateSalesOrder(salesOrderLine.SalesOrderId);
            return Ok(salesOrderLine);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<DateDébutFinAdminLine> payload)
        {
            DateDébutFinAdminLine salesOrderLine = _context.DateDébutFinAdminLine
                .Where(x => x.SalesOrderLineId == (int)payload.key)
                .FirstOrDefault();
            _context.DateDébutFinAdminLine.Remove(salesOrderLine);
            _context.SaveChanges();
            this.UpdateSalesOrder(salesOrderLine.SalesOrderId);
            return Ok(salesOrderLine);

        }
    }
}