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
    [Route("api/Shipment")]
    public class InfosPublicationsAdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;

        public InfosPublicationsAdminController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/Shipment
        [HttpGet]
        public async Task<IActionResult> GetShipment()
        {
            List<InfosPublicationsAdmin> Items = await _context.InfosPublicationsAdmin.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNotInvoicedYet()
        {
            List<InfosPublicationsAdmin> shipments = new List<InfosPublicationsAdmin>();
            try
            {
                List<Message> invoices = new List<Message>();
                invoices = await _context.Message.ToListAsync();
                List<int> ids = new List<int>();

                foreach (var item in invoices)
                {
                    ids.Add(item.ShipmentId);
                }

                shipments = await _context.InfosPublicationsAdmin
                    .Where(x => !ids.Contains(x.ShipmentId))
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(shipments);
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<InfosPublicationsAdmin> payload)
        {
            InfosPublicationsAdmin shipment = payload.value;
            shipment.ShipmentName = _numberSequence.GetNumberSequence("DO");
            _context.InfosPublicationsAdmin.Add(shipment);
            _context.SaveChanges();
            return Ok(shipment);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<InfosPublicationsAdmin> payload)
        {
            InfosPublicationsAdmin shipment = payload.value;
            _context.InfosPublicationsAdmin.Update(shipment);
            _context.SaveChanges();
            return Ok(shipment);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<InfosPublicationsAdmin> payload)
        {
            InfosPublicationsAdmin shipment = _context.InfosPublicationsAdmin
                .Where(x => x.ShipmentId == (int)payload.key)
                .FirstOrDefault();
            _context.InfosPublicationsAdmin.Remove(shipment);
            _context.SaveChanges();
            return Ok(shipment);

        }
    }
}