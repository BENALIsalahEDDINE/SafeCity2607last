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
    [Route("api/Message")]
    public class MessageController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public MessageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ShipmentType
        [HttpGet]
        public async Task<IActionResult> GetMessage()
        {
            List<Message> Items = await _context.Message.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Message> message)
        {
            Message mess = message.value;
            _context.Message.Add(mess);
            _context.SaveChanges();
            return Ok(mess);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Message> message)
        {
            Message mess = message.value;
            _context.Message.Update(mess);
            _context.SaveChanges();
            return Ok(mess);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Message> message)
        {
            Message mess = _context.Message
                .Where(x => x.Id_Mes == (int)message.key)
                .FirstOrDefault();
            _context.Message.Remove(mess);
            _context.SaveChanges();
            return Ok(mess);

        }
    }
}