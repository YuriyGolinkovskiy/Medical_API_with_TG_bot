using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMedicalSystem.Models
{
    public class AnswerUser
    {
        public int Id { get; set; }
        public int SymptomId { get; set; }
        public bool Answer { get; set; }
        public long TestId { get; set; }
    }
}
