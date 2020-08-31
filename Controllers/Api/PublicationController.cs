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
    [Route("api/Publication")]
    public class PublicationController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicationController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<IActionResult> GetPublication()
        {
            List<Publication> Items = await _context.Publication.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Publication> publication)
        {
            Publication pub = publication.value;
            _context.Publication.Add(pub);
            _context.SaveChanges();
            return Ok(pub);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Publication> publication)
        {
            Publication pub = publication.value;
            _context.Publication.Update(pub);
            _context.SaveChanges();
            return Ok(pub);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Publication> publication)
        {
            Publication pub = _context.Publication
                .Where(x => x.id_pub == (int)publication.key)
                .FirstOrDefault();
            _context.Publication.Remove(pub);
            _context.SaveChanges();
            return Ok(pub);

        }
    }
}