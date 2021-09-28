using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pakerkowo.Entities
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
    }
}
