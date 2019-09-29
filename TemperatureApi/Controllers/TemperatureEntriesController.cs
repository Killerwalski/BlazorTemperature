using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemperatureApi.Models;

namespace TemperatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureEntriesController : ControllerBase
    {
        private readonly TemperatureApiContext _context;

        // This is just a standard WebApi controller with EF template (Going to comment out all but the Gets
        public TemperatureEntriesController(TemperatureApiContext context)
        {
            _context = context;
        }

        // GET: api/TemperatureEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemperatureEntry>>> GetTemperatureEntry()
        {
            return await _context.TemperatureEntry.ToListAsync();
        }

        // GET: api/TemperatureEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemperatureEntry>> GetTemperatureEntry(int id)
        {
            var temperatureEntry = await _context.TemperatureEntry.FindAsync(id);

            if (temperatureEntry == null)
            {
                return NotFound();
            }

            return temperatureEntry;
        }

        // PUT: api/TemperatureEntries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        public async Task<IActionResult> PutTemperatureEntry(int id, TemperatureEntry temperatureEntry)
        {
            if (id != temperatureEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(temperatureEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperatureEntryExists(id))
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

        // POST: api/TemperatureEntries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        public async Task<ActionResult<TemperatureEntry>> PostTemperatureEntry(TemperatureEntry temperatureEntry)
        {
            _context.TemperatureEntry.Add(temperatureEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemperatureEntry", new { id = temperatureEntry.Id }, temperatureEntry);
        }

        // DELETE: api/TemperatureEntries/5
        //[HttpDelete("{id}")]
        public async Task<ActionResult<TemperatureEntry>> DeleteTemperatureEntry(int id)
        {
            var temperatureEntry = await _context.TemperatureEntry.FindAsync(id);
            if (temperatureEntry == null)
            {
                return NotFound();
            }

            _context.TemperatureEntry.Remove(temperatureEntry);
            await _context.SaveChangesAsync();

            return temperatureEntry;
        }

        private bool TemperatureEntryExists(int id)
        {
            return _context.TemperatureEntry.Any(e => e.Id == id);
        }
    }
}
