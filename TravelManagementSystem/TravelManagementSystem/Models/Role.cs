using System;
using System.Collections.Generic;

namespace TravelManagementSystem.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string Role1 { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
