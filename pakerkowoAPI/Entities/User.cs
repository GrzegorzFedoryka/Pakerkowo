using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Exercise> LikedExercises { get; set; }
        public virtual List<TrainingSchedule> Schedules { get; set; }
    }
}
