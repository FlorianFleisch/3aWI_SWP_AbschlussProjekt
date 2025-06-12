using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP_abschluss_projekt.Models;

namespace SWP_abschluss_projekt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FachController : ControllerBase
    {
        private readonly SchulDbContext _context;

        public FachController(SchulDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fach>>> GetAll()
        {
            return await _context.Faecher.Include(f => f.Lehrer).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Fach>> Create(Fach fach)
        {
            _context.Faecher.Add(fach);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = fach.Id }, fach);
        }
    }
}
