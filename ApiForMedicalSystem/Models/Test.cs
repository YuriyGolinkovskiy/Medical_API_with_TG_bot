using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMedicalSystem.Models
{
    public class Test
    {
        public int Id { get; set; }
        public long UserId { get; set; }
    }
}
