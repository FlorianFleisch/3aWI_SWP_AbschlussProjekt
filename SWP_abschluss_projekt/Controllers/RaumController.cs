using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP_abschluss_projekt.Models;

namespace SWP_abschluss_projekt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaumController : ControllerBase
    {
        private readonly SchulDbContext _context;

        public RaumController(SchulDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Raum>>> GetAll()
        {
            return await _context.Raeume.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Raum>> Create(Raum raum)
        {
            _context.Raeume.Add(raum);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = raum.Id }, raum);
        }
    }
}