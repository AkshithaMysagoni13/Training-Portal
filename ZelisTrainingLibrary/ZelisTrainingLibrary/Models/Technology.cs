using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZelisTrainingLibrary.Models
{
    public class Technology
    {
        public int TechnologyId { get; set; }
        public string Name { get; set; }

        // Level: B = Basic, I = Intermediate, A = Advanced
        public char Level { get; set; }

        // Duration in days
        public int Duration { get; set; }
    }
}
