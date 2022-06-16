using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikingAPI.Data;
using HikingAPI.Models;

namespace HikingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HikesController : ControllerBase
    {
        private readonly HikingDbContext _context;

        public HikesController(HikingDbContext context)
        {
            _context = context;
        }

        // Function that returns a list of all the hike titles in the database
        [Route("api/Hike/gethikenames")]
        [Route("api/Hike/gethikenames/{userId:int}/{age:int}")]
        [HttpGet]
        public List<string> GetHikeNames()
        {
            List<string> output = new List<string>();
            foreach (var hike in _context.Hikes)
            {
                output.Add(hike.Title);
            }
            return output;
        }

        // GET: api/Hikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hiking>>> GetHikes()
        {
          if (_context.Hikes == null)
          {
              return NotFound();
          }
            return await _context.Hikes.ToListAsync();
        }

        // GET: api/Hikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hiking>> GetHiking(int id)
        {
          if (_context.Hikes == null)
          {
              return NotFound();
          }
            var hiking = await _context.Hikes.FindAsync(id);

            if (hiking == null)
            {
                return NotFound();
            }

            return hiking;
        }

        // PUT: api/Hikes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiking(int id, Hiking hiking)
        {
            if (id != hiking.ID)
            {
                return BadRequest();
            }

            _context.Entry(hiking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HikingExists(id))
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

        // POST: api/Hikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hiking>> PostHiking(Hiking hiking)
        {
          if (_context.Hikes == null)
          {
              return Problem("Entity set 'HikingDbContext.Hikes'  is null.");
          }
            _context.Hikes.Add(hiking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHiking", new { id = hiking.ID }, hiking);
        }

        // DELETE: api/Hikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiking(int id)
        {
            if (_context.Hikes == null)
            {
                return NotFound();
            }
            var hiking = await _context.Hikes.FindAsync(id);
            if (hiking == null)
            {
                return NotFound();
            }

            _context.Hikes.Remove(hiking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HikingExists(int id)
        {
            return (_context.Hikes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
