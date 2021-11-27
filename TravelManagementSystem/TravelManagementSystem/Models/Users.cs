using System;
using System.Collections.Generic;

namespace TravelManagementSystem.Models
{
    public partial class Users
    {
        public Users()
        {
            EmployeeRegistration = new HashSet<EmployeeRegistration>();
        }

        public int LId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<EmployeeRegistration> EmployeeRegistration { get; set; }
    }
}
