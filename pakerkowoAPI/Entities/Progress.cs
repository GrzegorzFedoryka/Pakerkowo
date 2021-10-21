using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI.Entities
{
    public class Progress
    {
        public int Id { get; set; }
        public int? TrainingScheduleId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int? Rep { get; set; }
        public float? Weight { get; set; }
        public string Notes { get; set; }
        public virtual TrainingSchedule TrainingSchedule { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
