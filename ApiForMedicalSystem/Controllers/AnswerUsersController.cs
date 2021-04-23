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
    public class AnswerUsersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AnswerUsersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AnswerUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerUser>>> GetAnswerUserItem()
        {
            return await _context.AnswerUserItem.ToListAsync();
        }
        [HttpGet("IndexAnswer/{testId}")]
        public int GetIndexAnswer(int testId)
        {
            int index = 0;
            var answer = _context.AnswerUserItem.Where(a => a.TestId == testId).ToList();
            index = answer.Count;
            return index;
        }

        // GET: api/AnswerUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerUser>> GetAnswerUser(long id)
        {
            var answerUser = await _context.AnswerUserItem.FindAsync(id);

            if (answerUser == null)
            {
                return NotFound();
            }

            return answerUser;
        }

        // PUT: api/AnswerUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerUser(long id, AnswerUser answerUser)
        {
            if (id != answerUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(answerUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerUserExists(id))
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

        // POST: api/AnswerUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnswerUser>> PostAnswerUser(AnswerUser answerUser)
        {
            _context.AnswerUserItem.Add(answerUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswerUser", new { id = answerUser.Id }, answerUser);
        }

        // DELETE: api/AnswerUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerUser(long id)
        {
            var answerUser = await _context.AnswerUserItem.FindAsync(id);
            if (answerUser == null)
            {
                return NotFound();
            }

            _context.AnswerUserItem.Remove(answerUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnswerUserExists(long id)
        {
            return _context.AnswerUserItem.Any(e => e.Id == id);
        }
    }
}
