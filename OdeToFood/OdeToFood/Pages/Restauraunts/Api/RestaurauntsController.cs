using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restauraunts.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurauntsController : ControllerBase
    {
        private readonly OdeToFoodDbContext _context;

        public RestaurauntsController(OdeToFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Restauraunts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restauraunt>>> GetRestauraunts()
        {
            return await _context.Restauraunts.ToListAsync();
        }

        // GET: api/Restauraunts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restauraunt>> GetRestauraunt(int id)
        {
            var restauraunt = await _context.Restauraunts.FindAsync(id);

            if (restauraunt == null)
            {
                return NotFound();
            }

            return restauraunt;
        }

        // PUT: api/Restauraunts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestauraunt(int id, Restauraunt restauraunt)
        {
            if (id != restauraunt.Id)
            {
                return BadRequest();
            }

            _context.Entry(restauraunt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurauntExists(id))
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

        // POST: api/Restauraunts
        [HttpPost]
        public async Task<ActionResult<Restauraunt>> PostRestauraunt(Restauraunt restauraunt)
        {
            _context.Restauraunts.Add(restauraunt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestauraunt", new { id = restauraunt.Id }, restauraunt);
        }

        // DELETE: api/Restauraunts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restauraunt>> DeleteRestauraunt(int id)
        {
            var restauraunt = await _context.Restauraunts.FindAsync(id);
            if (restauraunt == null)
            {
                return NotFound();
            }

            _context.Restauraunts.Remove(restauraunt);
            await _context.SaveChangesAsync();

            return restauraunt;
        }

        private bool RestaurauntExists(int id)
        {
            return _context.Restauraunts.Any(e => e.Id == id);
        }
    }
}
