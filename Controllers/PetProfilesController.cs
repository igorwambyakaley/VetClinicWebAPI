using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetClinicAPI.Models;

namespace VetClinicAPI.Controllers
{
    [Route("api/petprofiles")]
    [ApiController]
    public class PetProfilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

     
        [HttpGet("{petId}")]
        public async Task<ActionResult<PetProfile>> GetPetProfile(int petId)
        {
            var profile = await _context.PetProfiles
                .Include(p => p.Pet)
                .FirstOrDefaultAsync(p => p.PetId == petId);

            if (profile == null)
                return NotFound();

            return Ok(profile);
        }

       
        [HttpPost]
        public async Task<ActionResult<PetProfile>> CreateOrOverwritePetProfile(PetProfile petProfile)
        {
            var existing = await _context.PetProfiles
                .FirstOrDefaultAsync(p => p.PetId == petProfile.PetId);

            if (existing != null)
            {
                // Overwrite
                existing.VetNotes = petProfile.VetNotes;
            }
            else
            {
                _context.PetProfiles.Add(petProfile);
            }

            await _context.SaveChangesAsync();
            return Ok(petProfile);
        }

     
        [HttpPut("{petId}")]
        public async Task<IActionResult> UpdatePetProfile(int petId, PetProfile petProfile)
        {
            var existing = await _context.PetProfiles
                .FirstOrDefaultAsync(p => p.PetId == petId);

            if (existing == null)
                return NotFound();

            existing.VetNotes = petProfile.VetNotes;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PetProfiles.Any(p => p.PetId == petId))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

       
        [HttpDelete("{petId}")]
        public async Task<IActionResult> DeletePetProfile(int petId)
        {
            var profile = await _context.PetProfiles
                .FirstOrDefaultAsync(p => p.PetId == petId);

            if (profile == null)
                return NotFound();

            _context.PetProfiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
