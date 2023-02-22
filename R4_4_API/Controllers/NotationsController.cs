using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R4_4_API.Models.EntityFramework;

namespace R4_4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotationsController : ControllerBase
    {
        private readonly LequmaContext _context;

        public NotationsController(LequmaContext context)
        {
            _context = context;
        }

        // GET: api/Notations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notation>>> GetAvis()
        {
            return await _context.Avis.ToListAsync();
        }

        // GET: api/Notations/5
        [HttpGet("byId/{id}")]
        public async Task<ActionResult<Notation>> GetNotationById(int id)
        {
            var notation = await _context.Avis.FindAsync(id);

            if (notation == null)
            {
                return NotFound();
            }

            return notation;
        }

        // PUT: api/Notations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotation(int id, Notation notation)
        {
            if (id != notation.Utl_id)
            {
                return BadRequest();
            }

            _context.Entry(notation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Notation>> PostNotation(Notation notation)
        {
            _context.Avis.Add(notation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotation", new { id = notation.Utl_id }, notation);
        }

        // DELETE: api/Notations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotation(int id)
        {
            var notation = await _context.Avis.FindAsync(id);
            if (notation == null)
            {
                return NotFound();
            }

            _context.Avis.Remove(notation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotationExists(int id)
        {
            return _context.Avis.Any(e => e.Utl_id == id);
        }
    }
}
