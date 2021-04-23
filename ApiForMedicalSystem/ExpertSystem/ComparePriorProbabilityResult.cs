using ApiForMedicalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMedicalSystem.ExpertSystem
{
    public class ComparePriorProbabilityResult : IComparer<Result>
    {
        public int Compare(Result p1, Result p2)
        {
            if (p1.PriorProbability > p2.PriorProbability)
            {
                return -1;
            }
            else if (p1.PriorProbability < p2.PriorProbability)
            {
                return 1;
            }
            return 0;
        }
    }
}
