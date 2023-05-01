using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdproApi.Context;
using AdproApi.Models;

namespace AdproApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PmediasController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public PmediasController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Pmedias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pmedia>>> GetPmedias()
        {
          if (_context.Pmedias == null)
          {
              return NotFound();
          }
            return await _context.Pmedias.ToListAsync();
        }

        // GET: api/Pmedias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pmedia>> GetPmedia(int id)
        {
          if (_context.Pmedias == null)
          {
              return NotFound();
          }
            var pmedia = await _context.Pmedias.FindAsync(id);

            if (pmedia == null)
            {
                return NotFound();
            }

            return pmedia;
        }

        // PUT: api/Pmedias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPmedia(int id, Pmedia pmedia)
        {
            if (id != pmedia.Id)
            {
                return BadRequest();
            }

            _context.Entry(pmedia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PmediaExists(id))
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

        // POST: api/Pmedias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pmedia>> PostPmedia(Pmedia pmedia)
        {
          if (_context.Pmedias == null)
          {
              return Problem("Entity set 'DataBaseContext.Pmedias'  is null.");
          }
            _context.Pmedias.Add(pmedia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPmedia", new { id = pmedia.Id }, pmedia);
        }

        // DELETE: api/Pmedias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePmedia(int id)
        {
            if (_context.Pmedias == null)
            {
                return NotFound();
            }
            var pmedia = await _context.Pmedias.FindAsync(id);
            if (pmedia == null)
            {
                return NotFound();
            }

            _context.Pmedias.Remove(pmedia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PmediaExists(int id)
        {
            return (_context.Pmedias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
