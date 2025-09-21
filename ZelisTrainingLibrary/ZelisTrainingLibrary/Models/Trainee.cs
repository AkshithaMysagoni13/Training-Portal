using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZelisTrainingLibrary.Models
{
    public class Trainee
    {
        public int TrainingId { get; set; }
        public int EmpId { get; set; }

        // Status: C = Completed, N = Not completed
        public char Status { get; set; }
    }
}
