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
    [Route("api/MessageAuPublic")]
    public class MessageAuPublicController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public MessageAuPublicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ShipmentType
        [HttpGet]
        public async Task<IActionResult> GetShipmentType()
        {
            List<MessageAuPublic> Items = await _context.MessageAuPublic.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<MessageAuPublic> payload)
        {
            MessageAuPublic shipmentType = payload.value;
            _context.MessageAuPublic.Add(shipmentType);
            _context.SaveChanges();
            return Ok(shipmentType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<MessageAuPublic> payload)
        {
            MessageAuPublic shipmentType = payload.value;
            _context.MessageAuPublic.Update(shipmentType);
            _context.SaveChanges();
            return Ok(shipmentType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<MessageAuPublic> payload)
        {
            MessageAuPublic shipmentType = _context.MessageAuPublic
                .Where(x => x.Id_Mes == (int)payload.key)
                .FirstOrDefault();
            _context.MessageAuPublic.Remove(shipmentType);
            _context.SaveChanges();
            return Ok(shipmentType);

        }
    }
}