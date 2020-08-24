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
    [Route("api/MessagePublic")]
    public class MessagePublicController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagePublicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ShipmentType
        [HttpGet]
        public async Task<IActionResult> GetShipmentType()
        {
            List<MessagePublic> Items = await _context.MessagePublic.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<MessagePublic> payload)
        {
            MessagePublic shipmentType = payload.value;
            _context.MessagePublic.Add(shipmentType);
            _context.SaveChanges();
            return Ok(shipmentType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<MessagePublic> payload)
        {
            MessagePublic shipmentType = payload.value;
            _context.MessagePublic.Update(shipmentType);
            _context.SaveChanges();
            return Ok(shipmentType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<MessagePublic> payload)
        {
            MessagePublic shipmentType = _context.MessagePublic
                .Where(x => x.ShipmentTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.MessagePublic.Remove(shipmentType);
            _context.SaveChanges();
            return Ok(shipmentType);

        }
    }
}