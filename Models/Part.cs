using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Part
    {
        public Part()
        {
            Requests = new HashSet<Request>();
        }

        public decimal PartId { get; set; }
        public decimal TypeId { get; set; }
        public decimal VehId { get; set; }
        public string PartName { get; set; }
        public int PartAmount { get; set; }
        public decimal PartPrice { get; set; }
        public string PartDesc { get; set; }

        public virtual Type Type { get; set; }
        public virtual Vehicle Veh { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
