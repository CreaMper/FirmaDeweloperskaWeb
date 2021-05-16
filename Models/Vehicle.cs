using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Parts = new HashSet<Part>();
        }

        public decimal VehId { get; set; }
        public string VehName { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
