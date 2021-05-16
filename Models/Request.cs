using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Request
    {
        public decimal ReqId { get; set; }
        public decimal OrderId { get; set; }
        public decimal PartId { get; set; }
        public int ReqAmount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Part Part { get; set; }
    }
}
