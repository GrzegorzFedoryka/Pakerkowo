using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }     //Is exercise seeded or user created 
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual List<BodyPart> BodyParts { get; set; }   //Which body parts are exercised
        public virtual List<TrainingSchedule> TrainingSchedules { get; set; }
        public virtual List<User> UsersLiked { get; set; }
        
    }
}
