using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Type
    {
        public Type()
        {
            Parts = new HashSet<Part>();
        }

        public decimal TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
