using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiForMedicalSystem.Models;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace ApiForMedicalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TestsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Tests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetTest()
        {
            return await _context.TestItem.ToListAsync();
        }

        // GET: api/Tests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTest(long id)
        {
            var test = await _context.TestItem.FindAsync(id);

            if (test == null)
            {
                return NotFound();
            }

            return test;
        }

        // PUT: api/Tests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest(long id, Test test)
        {
            if (id != test.Id)
            {
                return BadRequest();
            }

            _context.Entry(test).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
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

        // POST: api/Tests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Test>> PostTest(Test test)
        {
            _context.TestItem.Add(test);
           
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetTest), new { id = test.Id }, test);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(long id)
        {
            var test = await _context.TestItem.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.TestItem.Remove(test);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestExists(long id)
        {
            return _context.TestItem.Any(e => e.Id == id);
        }
    }
}
