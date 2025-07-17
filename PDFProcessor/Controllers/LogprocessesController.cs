using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDFProcessor.Models;

namespace PDFProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogprocessesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LogprocessesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Logprocesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Logprocess>>> GetLogprocesses()
        {
            return await _context.Logprocesses.ToListAsync();
        }

        // GET: api/Logprocesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Logprocess>> GetLogprocess(int id)
        {
            var logprocess = await _context.Logprocesses.FindAsync(id);

            if (logprocess == null)
            {
                return NotFound();
            }

            return logprocess;
        }

        // POST: api/Logprocesses
        [HttpPost]
        public async Task<ActionResult<Logprocess>> PostLogprocess(Logprocess logprocess)
        {
            _context.Logprocesses.Add(logprocess);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLogprocess), new { id = logprocess.Id }, logprocess);
        }

        // PUT: api/Logprocesses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogprocess(int id, Logprocess logprocess)
        {
            if (id != logprocess.Id)
            {
                return BadRequest();
            }

            _context.Entry(logprocess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogprocessExists(id))
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

        // DELETE: api/Logprocesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogprocess(int id)
        {
            var logprocess = await _context.Logprocesses.FindAsync(id);
            if (logprocess == null)
            {
                return NotFound();
            }

            _context.Logprocesses.Remove(logprocess);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogprocessExists(int id)
        {
            return _context.Logprocesses.Any(e => e.Id == id);
        }
    }
}
