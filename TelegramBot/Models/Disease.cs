using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMedicalSystem.Models
{
    public class Disease
    {
        public int Id { get; set; }       
        public double PriorProbability { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Link { get; set; }
    }
}
