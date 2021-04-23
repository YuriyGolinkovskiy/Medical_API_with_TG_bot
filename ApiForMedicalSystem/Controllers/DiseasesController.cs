using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiForMedicalSystem.Models;

namespace ApiForMedicalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DiseasesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Diseases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disease>>> GetDisease()
        {
            return await _context.DiseaseItem.ToListAsync();
        }
        // GET: api/Diseases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Disease>> GetDisease(long id)
        {
            var disease = await _context.DiseaseItem.FindAsync(id);

            if (disease == null)
            {
                return NotFound();
            }

            return disease;
        }

        // PUT: api/Diseases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisease(long id, Disease disease)
        {
            if (id != disease.Id)
            {
                return BadRequest();
            }

            _context.Entry(disease).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiseaseExists(id))
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

        // POST: api/Diseases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Disease>> PostDisease(Disease disease)
        {
            _context.DiseaseItem.Add(disease);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDisease), new { id = disease.Id }, disease);
        }

        // DELETE: api/Diseases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisease(long id)
        {
            var disease = await _context.DiseaseItem.FindAsync(id);
            if (disease == null)
            {
                return NotFound();
            }

            _context.DiseaseItem.Remove(disease);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiseaseExists(long id)
        {
            return _context.DiseaseItem.Any(e => e.Id == id);
        }
    }
}
