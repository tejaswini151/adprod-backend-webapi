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
    public class GstsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public GstsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Gsts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gst>>> GetGsts()
        {
          if (_context.Gsts == null)
          {
              return NotFound();
          }
            return await _context.Gsts.ToListAsync();
        }

        // GET: api/Gsts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gst>> GetGst(int id)
        {
          if (_context.Gsts == null)
          {
              return NotFound();
          }
            var gst = await _context.Gsts.FindAsync(id);

            if (gst == null)
            {
                return NotFound();
            }

            return gst;
        }

        // PUT: api/Gsts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGst(int id, Gst gst)
        {
            if (id != gst.Id)
            {
                return BadRequest();
            }

            _context.Entry(gst).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GstExists(id))
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

        // POST: api/Gsts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gst>> PostGst(Gst gst)
        {
          if (_context.Gsts == null)
          {
              return Problem("Entity set 'DataBaseContext.Gsts'  is null.");
          }
            _context.Gsts.Add(gst);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGst", new { id = gst.Id }, gst);
        }

        // DELETE: api/Gsts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGst(int id)
        {
            if (_context.Gsts == null)
            {
                return NotFound();
            }
            var gst = await _context.Gsts.FindAsync(id);
            if (gst == null)
            {
                return NotFound();
            }

            _context.Gsts.Remove(gst);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GstExists(int id)
        {
            return (_context.Gsts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
