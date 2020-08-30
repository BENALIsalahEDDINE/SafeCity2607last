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
    [Route("api/CommentairesdePublic")]
    public class CommentairesdePublicController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentairesdePublicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductType
        [HttpGet]
        public async Task<IActionResult> GetProductType()
        {
            List<CommentairesdePublic> Items = await _context.CommentairesdePublic.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<CommentairesdePublic> payload)
        {
            CommentairesdePublic productType = payload.value;
            _context.CommentairesdePublic.Add(productType);
            _context.SaveChanges();
            return Ok(productType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<CommentairesdePublic> payload)
        {
            CommentairesdePublic productType = payload.value;
            _context.CommentairesdePublic.Update(productType);
            _context.SaveChanges();
            return Ok(productType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<CommentairesdePublic> payload)
        {
            CommentairesdePublic productType = _context.CommentairesdePublic
                .Where(x => x.CommentaireId == (int)payload.key)
                .FirstOrDefault();
            _context.CommentairesdePublic.Remove(productType);
            _context.SaveChanges();
            return Ok(productType);

        }
    }
}