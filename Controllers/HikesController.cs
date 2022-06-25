using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikingAPI.Data;
using HikingAPI.Models;
using HikingAPI.DTOs;

namespace HikingAPI.Controllers
{
    [ApiController]
    [Route("hikes")]
    public class HikesController : ControllerBase
    {
        private readonly HikingDbContext _context;

        public HikesController(HikingDbContext context)
        {
            _context = context;
        }

        // GET /items
        // Function that returns all the hikes or a list of hikes near to a given city 
        // Should improve performance through resource filtering IActionFilter, IFilter --> https://www.youtube.com/watch?v=Zc9xyOgl8k4&ab_channel=NickChapsas / https://www.youtube.com/watch?v=mKM6FbxMGI8&ab_channel=RahulNath
        [HttpGet]
        public async Task<IEnumerable<Hiking>> GetItemsAsync([FromQuery] string? city = null)
        {
            var hikes = await _context.Hikes.ToListAsync();

            if (!string.IsNullOrWhiteSpace(city))
            {
                hikes = hikes.Where(hikes => hikes.City.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return hikes;
        }

        // Function that returns a single hike based on its Id
        // GET: /hikes/{id}
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

        // PUT: /hikes/{id}
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

        // POST: /hikes
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

        // DELETE: /hikes/{id}
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
