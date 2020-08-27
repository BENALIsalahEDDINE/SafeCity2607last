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
    [Route("api/Admin")]
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: api/Customer
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            List<UserProfile> Items = await _context.UserProfile.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }





        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<UserProfile> payload)
        {
            UserProfile customer = payload.value;
            _context.UserProfile.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }




        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<UserProfile> payload)
        {
            UserProfile customer = payload.value;
            _context.UserProfile.Update(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<UserProfile> payload)
        {
            UserProfile customer = _context.UserProfile
                .Where(x => x.UserProfileId == (int)payload.key)
                .FirstOrDefault();
            _context.UserProfile.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);

        }
    }
}