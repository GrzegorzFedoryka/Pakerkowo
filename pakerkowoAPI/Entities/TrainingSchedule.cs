using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI.Entities
{
    public class TrainingSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
    }
}
