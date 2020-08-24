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
    [Route("api/InfoPublicationControleurQ")]
    public class InfoPublicationControleurQController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;

        public InfoPublicationControleurQController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/GoodsReceivedNote
        [HttpGet]
        public async Task<IActionResult> GetGoodsReceivedNote()
        {
            List<InfoPublicationControleurQ> Items = await _context.InfoPublicationControleurQ.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNotBilledYet()
        {
            List<InfoPublicationControleurQ> goodsReceivedNotes = new List<InfoPublicationControleurQ>();
            try
            {
                List<MessageControleurQualité> bills = new List<MessageControleurQualité>();
                bills = await _context.MessageControleurQualité.ToListAsync();
                List<int> ids = new List<int>();

                foreach (var item in bills)
                {
                    ids.Add(item.GoodsReceivedNoteId);
                }

                goodsReceivedNotes = await _context.InfoPublicationControleurQ
                    .Where(x => !ids.Contains(x.GoodsReceivedNoteId))
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(goodsReceivedNotes);
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<InfoPublicationControleurQ> payload)
        {
            InfoPublicationControleurQ goodsReceivedNote = payload.value;
            goodsReceivedNote.GoodsReceivedNoteName = _numberSequence.GetNumberSequence("GRN");
            _context.InfoPublicationControleurQ.Add(goodsReceivedNote);
            _context.SaveChanges();
            return Ok(goodsReceivedNote);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<InfoPublicationControleurQ> payload)
        {
            InfoPublicationControleurQ goodsReceivedNote = payload.value;
            _context.InfoPublicationControleurQ.Update(goodsReceivedNote);
            _context.SaveChanges();
            return Ok(goodsReceivedNote);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<InfoPublicationControleurQ> payload)
        {
            InfoPublicationControleurQ goodsReceivedNote = _context.InfoPublicationControleurQ
                .Where(x => x.GoodsReceivedNoteId == (int)payload.key)
                .FirstOrDefault();
            _context.InfoPublicationControleurQ.Remove(goodsReceivedNote);
            _context.SaveChanges();
            return Ok(goodsReceivedNote);

        }
    }
}