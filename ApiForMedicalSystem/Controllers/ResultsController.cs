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
    public class ResultsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ResultsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Results
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetResult()
        {
            return await _context.ResultItem.ToListAsync();
        }

        [HttpGet("ResultPredict/{answerId}")]
        public async Task<ActionResult<IEnumerable<Result>>> GetPredict(int answerId)
        {
            List<Result> res = new List<Result>();
            res = await _context.ResultItem.Where(r => r.AnswerUserId == answerId).ToListAsync();
            return res;
        }
        // GET: api/Results/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetResult(long id)
        {
            var result = await _context.ResultItem.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Results/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResult(long id, Result result)
        {
            if (id != result.Id)
            {
                return BadRequest();
            }

            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(id))
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

        // POST: api/Results
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Result>> PostResult(Result result)
        {
            _context.ResultItem.Add(result);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetResult), new { id = result.Id }, result);
        }

        // DELETE: api/Results/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResult(long id)
        {
            var result = await _context.ResultItem.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.ResultItem.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultExists(long id)
        {
            return _context.ResultItem.Any(e => e.Id == id);
        }
    }
}
