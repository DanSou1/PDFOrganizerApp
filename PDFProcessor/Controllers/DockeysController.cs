using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDFProcessor.Models;

namespace PDFProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DockeysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DockeysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Dockeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dockey>>> GetDockeys()
        {
            return await _context.Dockeys.ToListAsync();
        }

        // GET: api/Dockeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dockey>> GetDockey(int id)
        {
            var dockey = await _context.Dockeys.FindAsync(id);

            if (dockey == null)
            {
                return NotFound();
            }

            return dockey;
        }

        // POST: api/Dockeys
        [HttpPost]
        public async Task<ActionResult<Dockey>> PostDockey(Dockey dockey)
        {
            _context.Dockeys.Add(dockey);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDockey), new { id = dockey.Id }, dockey);
        }

        // PUT: api/Dockeys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDockey(int id, Dockey dockey)
        {
            if (id != dockey.Id)
            {
                return BadRequest();
            }

            _context.Entry(dockey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DockeyExists(id))
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

        // DELETE: api/Dockeys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDockey(int id)
        {
            var dockey = await _context.Dockeys.FindAsync(id);
            if (dockey == null)
            {
                return NotFound();
            }

            _context.Dockeys.Remove(dockey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DockeyExists(int id)
        {
            return _context.Dockeys.Any(e => e.Id == id);
        }
    }
}
