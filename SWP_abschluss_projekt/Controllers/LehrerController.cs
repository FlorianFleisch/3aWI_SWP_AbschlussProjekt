using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP_abschluss_projekt.Models;

namespace SWP_abschluss_projekt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LehrerController : ControllerBase
    {
        private readonly SchulDbContext _context;

        public LehrerController(SchulDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lehrer>>> GetAll()
        {
            return await _context.Lehrer.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lehrer>> GetById(int id)
        {
            var lehrer = await _context.Lehrer.FindAsync(id);
            if (lehrer == null) return NotFound();
            return lehrer;
        }

        [HttpPost]
        public async Task<ActionResult<Lehrer>> Create(Lehrer lehrer)
        {
            _context.Lehrer.Add(lehrer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = lehrer.Id }, lehrer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Lehrer updated)
        {
            if (id != updated.Id) return BadRequest();
            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lehrer = await _context.Lehrer.FindAsync(id);
            if (lehrer == null) return NotFound();
            _context.Lehrer.Remove(lehrer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}