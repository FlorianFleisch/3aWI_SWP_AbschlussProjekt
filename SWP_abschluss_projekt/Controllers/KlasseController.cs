using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP_abschluss_projekt.Models;

namespace SWP_abschluss_projekt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KlasseController : ControllerBase
    {
        private readonly SchulDbContext _context;

        public KlasseController(SchulDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Klasse>>> GetAll()
        {
            return await _context.Klassen.Include(k => k.Klassenvorstand).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Klasse>> Create(Klasse klasse)
        {
            _context.Klassen.Add(klasse);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = klasse.Id }, klasse);
        }
    }
}