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
    public class CoefficientsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CoefficientsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Coefficients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coefficient>>> GetCoefficient()
        {
            return await _context.CoefficientItem.ToListAsync();
        }

        // GET: api/Coefficients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coefficient>> GetCoefficient(long id)
        {
            var coefficient = await _context.CoefficientItem.FindAsync(id);

            if (coefficient == null)
            {
                return NotFound();
            }

            return coefficient;
        }

        // PUT: api/Coefficients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoefficient(long id, Coefficient coefficient)
        {
            if (id != coefficient.Id)
            {
                return BadRequest();
            }

            _context.Entry(coefficient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoefficientExists(id))
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

        // POST: api/Coefficients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coefficient>> PostCoefficient(Coefficient coefficient)
        {
            _context.CoefficientItem.Add(coefficient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCoefficient), new { id = coefficient.Id }, coefficient);
        }

        // DELETE: api/Coefficients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoefficient(long id)
        {
            var coefficient = await _context.CoefficientItem.FindAsync(id);
            if (coefficient == null)
            {
                return NotFound();
            }

            _context.CoefficientItem.Remove(coefficient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoefficientExists(long id)
        {
            return _context.CoefficientItem.Any(e => e.Id == id);
        }
    }
}
