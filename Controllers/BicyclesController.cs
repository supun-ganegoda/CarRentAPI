using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentAPI.Data;
using CarRentAPI.Models;

namespace CarRentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicyclesController : ControllerBase
    {
        private readonly carrentalshopContext _context;

        public BicyclesController(carrentalshopContext context)
        {
            _context = context;
        }

        // GET: api/Bicycles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicycle>>> GetBicycles()
        {
            return await _context.Bicycles.ToListAsync();
        }

        // GET: api/Bicycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bicycle>> GetBicycle(string id)
        {
            var bicycle = await _context.Bicycles.FindAsync(id);

            if (bicycle == null)
            {
                return NotFound();
            }

            return bicycle;
        }

        // PUT: api/Bicycles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBicycle(string id, Bicycle bicycle)
        {
            if (id != bicycle.PlateNo)
            {
                return BadRequest();
            }

            _context.Entry(bicycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BicycleExists(id))
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

        // POST: api/Bicycles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bicycle>> PostBicycle(Bicycle bicycle)
        {
            _context.Bicycles.Add(bicycle);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BicycleExists(bicycle.PlateNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBicycle", new { id = bicycle.PlateNo }, bicycle);
        }

        // DELETE: api/Bicycles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBicycle(string id)
        {
            var bicycle = await _context.Bicycles.FindAsync(id);
            if (bicycle == null)
            {
                return NotFound();
            }

            _context.Bicycles.Remove(bicycle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BicycleExists(string id)
        {
            return _context.Bicycles.Any(e => e.PlateNo == id);
        }
    }
}
