﻿using System;
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
    [Route("api/MessageRecu")]
    public class MessageRecuController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public MessageRecuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ShipmentType
        [HttpGet]
        public async Task<IActionResult> GetShipmentType()
        {
            List<MessageRecu> Items = await _context.MessageRecu.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<MessageRecu> payload)
        {
            MessageRecu shipmentType = payload.value;
            _context.MessageRecu.Add(shipmentType);
            _context.SaveChanges();
            return Ok(shipmentType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<MessageRecu> payload)
        {
            MessageRecu shipmentType = payload.value;
            _context.MessageRecu.Update(shipmentType);
            _context.SaveChanges();
            return Ok(shipmentType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<MessageRecu> payload)
        {
            MessageRecu shipmentType = _context.MessageRecu
                .Where(x => x.Id_Mes == (int)payload.key)
                .FirstOrDefault();
            _context.MessageRecu.Remove(shipmentType);
            _context.SaveChanges();
            return Ok(shipmentType);

        }
    }
}