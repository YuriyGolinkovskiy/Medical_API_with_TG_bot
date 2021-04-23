using ApiForMedicalSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiForMedicalSystem.ExpertSystem;

namespace ApiForMedicalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertSystemController : ControllerBase
    {        
        private readonly DatabaseContext _context;
        public ExpertSystem.ExpertSystem expertSystem;

        public ExpertSystemController(DatabaseContext context)
        {
            _context = context;
            expertSystem = new ExpertSystem.ExpertSystem(context);
        }

       
        //[HttpGet("{chatId}/{testId}")]
        //public async Task<IEnumerable<AnswerUser>> GetRuleValues(int chatId, int testId)
        //{
        //    var user = await _context.UserItem.FindAsync(chatId);
        //    var test = await _context.TestItem.FindAsync(testId);
        //    var answer = await _context.AnswerUserItem.Where(a => a.TestId == test.Id && user.Id == test.UserId).ToListAsync();
        //    ExpertSystem.ExpertSystem expertSystem = new ExpertSystem.ExpertSystem(_context);
        //    expertSystem.countTheRules(testId);
        //    Dictionary<int, double> RuleValue = expertSystem.RuleValue;
        //    return answer;
        //}
        [HttpGet("GetQuestion/{testId}")]
        public Symptom GetQuestion(int testId)
        {           
             var question = expertSystem.takeQuestion(testId);          
            return question;
        }
        [HttpGet("CallbackYes/{testId}/{answerId}/{diseaseId}")]
        public double PostCallbackYes(int testId, int answerId, int diseaseId)
        {
            ExpertSystem.ExpertSystem expertSystem = new ExpertSystem.ExpertSystem(_context);
            double result = expertSystem.hypothesisIsTrue(testId, answerId, diseaseId);

            return result;
        }
        [HttpGet("CallbackNo/{testId}/{answerId}/{diseaseId}")]
        public double PostCallbackNo(int testId, int answerId, int diseaseId)
        {
            ExpertSystem.ExpertSystem expertSystem = new ExpertSystem.ExpertSystem(_context);
            double result = expertSystem.hypothesisIsFalse(testId, answerId, diseaseId);

            return result;
        }
        [HttpGet("CallbackNothing/{testId}/{answerId}/{diseaseId}")]
        public double PostCallbackNothing(int testId, int answerId, int diseaseId)
        {
            ExpertSystem.ExpertSystem expertSystem = new ExpertSystem.ExpertSystem(_context);
            double result = expertSystem.hypothesisIsNothing(testId, answerId, diseaseId);

            return result;
        }
    }
}
