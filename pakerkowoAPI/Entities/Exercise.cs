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
        public bool IsDefault { get; set; }
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public List<BodyPart> BodyParts { get; set; }
    }
}
