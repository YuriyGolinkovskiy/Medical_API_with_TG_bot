using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMedicalSystem.Models
{
    public class Coefficient
    {
        public int Id { get; set; }
        public int DiseaseId { get; set; }
        public int SymptomId { get; set; }
        public double ExodusIsTrue { get; set; }
        public double ExodusIsFalse { get; set; }
    }
}
