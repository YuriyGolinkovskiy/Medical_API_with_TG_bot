using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMedicalSystem.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double BMI { get; set; }
    }
}
