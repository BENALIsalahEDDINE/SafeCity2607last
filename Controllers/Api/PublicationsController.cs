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
    [Route("api/Publications")]
    public class PublicationsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<IActionResult> GetPaymentType()
        {
            List<Publications> Items = await _context.Publications.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Publications> payload)
        {
            Publications paymentType = payload.value;
            _context.Publications.Add(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Publications> payload)
        {
            Publications paymentType = payload.value;
            _context.Publications.Update(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Publications> payload)
        {
            Publications paymentType = _context.Publications
                .Where(x => x.id_pub == (int)payload.key)
                .FirstOrDefault();
            _context.Publications.Remove(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);

        }
    }
}