using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentAPI.Data;
using CarRentAPI.Models;

namespace CarRentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VansController : ControllerBase
    {
        private readonly carrentalshopContext _context;

        public VansController(carrentalshopContext context)
        {
            _context = context;
        }

        // GET: api/Vans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Van>>> GetVans()
        {
            return await _context.Vans.ToListAsync();
        }

        // GET: api/Vans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Van>> GetVan(string id)
        {
            var van = await _context.Vans.FindAsync(id);

            if (van == null)
            {
                return NotFound();
            }

            return van;
        }

        // PUT: api/Vans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVan(string id, Van van)
        {
            if (id != van.PlateNo)
            {
                return BadRequest();
            }

            _context.Entry(van).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VanExists(id))
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

        // POST: api/Vans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Van>> PostVan(Van van)
        {
            _context.Vans.Add(van);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VanExists(van.PlateNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVan", new { id = van.PlateNo }, van);
        }

        // DELETE: api/Vans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVan(string id)
        {
            var van = await _context.Vans.FindAsync(id);
            if (van == null)
            {
                return NotFound();
            }

            _context.Vans.Remove(van);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VanExists(string id)
        {
            return _context.Vans.Any(e => e.PlateNo == id);
        }
    }
}
