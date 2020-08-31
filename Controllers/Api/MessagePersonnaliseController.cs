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
    [Route("api/MessagePersonnalise")]
    public class MessagePersonnaliseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagePersonnaliseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ShipmentType
        [HttpGet]
        public async Task<IActionResult> GetMessagePersonnalise()
        {
            List<MessagePersonnalise> Items = await _context.MessagePersonnalise.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<MessagePersonnalise> message)
        {
            MessagePersonnalise mess = message.value;
            _context.MessagePersonnalise.Add(mess);
            _context.SaveChanges();
            return Ok(mess);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<MessagePersonnalise> message)
        {
            MessagePersonnalise shipmentType = message.value;
            _context.MessagePersonnalise.Update(shipmentType);
            _context.SaveChanges();
            return Ok(shipmentType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<MessagePersonnalise> message)
        {
            MessagePersonnalise mess = _context.MessagePersonnalise
                .Where(x => x.Id_Mes == (int)message.key)
                .FirstOrDefault();
            _context.MessagePersonnalise.Remove(mess);
            _context.SaveChanges();
            return Ok(mess);

        }
    }
}