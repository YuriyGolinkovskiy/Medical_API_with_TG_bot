using ApiForMedicalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMedicalSystem.ExpertSystem
{
    public class ComparePriorProbability : IComparer<Disease>
    {
        public int Compare(Disease p1, Disease p2)
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