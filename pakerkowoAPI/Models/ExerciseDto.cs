using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI.Models
{
    public class ExerciseDto
    {
        public string Name { get; set; }
        public IEnumerable<string> BodyParts { get; set; }
    }
}
