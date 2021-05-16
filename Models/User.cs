using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public decimal UsrId { get; set; }
        public decimal RoleId { get; set; }
        public string UsrName { get; set; }
        public string UsrLastName { get; set; }
        public int? UsrPesel { get; set; }
        public string UsrAddress { get; set; }
        public string UsrLogin { get; set; }
        public string UsrPasswd { get; set; }
        public string UsrEmail { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
