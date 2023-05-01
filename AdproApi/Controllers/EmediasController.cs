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
    public class EmediasController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public EmediasController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Emedias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emedia>>> GetEmedias()
        {
          if (_context.Emedias == null)
          {
              return NotFound();
          }
            return await _context.Emedias.ToListAsync();
        }

        // GET: api/Emedias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emedia>> GetEmedia(int id)
        {
          if (_context.Emedias == null)
          {
              return NotFound();
          }
            var emedia = await _context.Emedias.FindAsync(id);

            if (emedia == null)
            {
                return NotFound();
            }

            return emedia;
        }

        // PUT: api/Emedias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmedia(int id, Emedia emedia)
        {
            if (id != emedia.Id)
            {
                return BadRequest();
            }

            _context.Entry(emedia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmediaExists(id))
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

        // POST: api/Emedias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emedia>> PostEmedia(Emedia emedia)
        {
          if (_context.Emedias == null)
          {
              return Problem("Entity set 'DataBaseContext.Emedias'  is null.");
          }
            _context.Emedias.Add(emedia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmedia", new { id = emedia.Id }, emedia);
        }

        // DELETE: api/Emedias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmedia(int id)
        {
            if (_context.Emedias == null)
            {
                return NotFound();
            }
            var emedia = await _context.Emedias.FindAsync(id);
            if (emedia == null)
            {
                return NotFound();
            }

            _context.Emedias.Remove(emedia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmediaExists(int id)
        {
            return (_context.Emedias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
