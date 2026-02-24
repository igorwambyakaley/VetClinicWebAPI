using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetClinicAPI.Models;

namespace VetClinicAPI.Controllers
{
    [Route("api/vetdoctors")]
    [ApiController]
    public class VetDoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VetDoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VetDoctor>>> GetVetDoctors()
        {
            var doctors = await _context.VetDoctors
                .Include(d => d.Pets)
                .ToListAsync();
            return Ok(doctors);
        }

        // GET: api/vetdoctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VetDoctor>> GetVetDoctor(int id)
        {
            var doctor = await _context.VetDoctors
                .Include(d => d.Pets)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<VetDoctor>> CreateVetDoctor(VetDoctor vetDoctor)
        {
            _context.VetDoctors.Add(vetDoctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVetDoctor), new { id = vetDoctor.Id }, vetDoctor);
        }

        // PUT 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVetDoctor(int id, VetDoctor vetDoctor)
        {
            if (id != vetDoctor.Id)
                return BadRequest();

            _context.Entry(vetDoctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.VetDoctors.Any(d => d.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVetDoctor(int id)
        {
            var doctor = await _context.VetDoctors.FindAsync(id);
            if (doctor == null)
                return NotFound();

            _context.VetDoctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
