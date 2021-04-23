using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiForMedicalSystem.Models;

namespace ApiForMedicalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SymptomsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Symptoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Symptom>>> GetSymptom()
        {
            return await _context.SymptomItem.ToListAsync();
        }

        // GET: api/Symptoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Symptom>> GetSymptom(int id)
        {
            var symptom = await _context.SymptomItem.FindAsync(id);

            if (symptom == null)
            {
                return NotFound();
            }

            return symptom;
        }

        // PUT: api/Symptoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSymptom(int id, Symptom symptom)
        {
            if (id != symptom.Id)
            {
                return BadRequest();
            }

            _context.Entry(symptom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SymptomExists(id))
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

        // POST: api/Symptoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Symptom>> PostSymptom(Symptom symptom)
        {
            _context.SymptomItem.Add(symptom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSymptom), new { id = symptom.Id }, symptom);
        }

        // DELETE: api/Symptoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSymptom(int id)
        {
            var symptom = await _context.SymptomItem.FindAsync(id);
            if (symptom == null)
            {
                return NotFound();
            }

            _context.SymptomItem.Remove(symptom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SymptomExists(int id)
        {
            return _context.SymptomItem.Any(e => e.Id == id);
        }
    }
}
