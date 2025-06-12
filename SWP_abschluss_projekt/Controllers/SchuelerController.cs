using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP_abschluss_projekt.Models;

namespace SWP_abschluss_projekt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchuelerController : ControllerBase
    {
        private readonly SchulDbContext _context;

        public SchuelerController(SchulDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schueler>>> GetAll()
        {
            return await _context.Schueler.Include(s => s.Klasse).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schueler>> GetById(int id)
        {
            var schueler = await _context.Schueler.Include(s => s.Klasse).FirstOrDefaultAsync(s => s.Id == id);
            if (schueler == null)
                return NotFound();
            return schueler;
        }

        [HttpPost]
        public async Task<ActionResult<Schueler>> Create(Schueler schueler)
        {
            _context.Schueler.Add(schueler);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = schueler.Id }, schueler);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Schueler updated)
        {
            if (id != updated.Id) return BadRequest();

            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var schueler = await _context.Schueler.FindAsync(id);
            if (schueler == null) return NotFound();

            _context.Schueler.Remove(schueler);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
