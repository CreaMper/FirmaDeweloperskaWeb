using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Order
    {
        public Order()
        {
            Requests = new HashSet<Request>();
        }

        public decimal OrderId { get; set; }
        public decimal StatusId { get; set; }
        public decimal UsrId { get; set; }
        public string OrderName { get; set; }
        public string OrderAccepted { get; set; }
        public string OrderDesc { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Status Status { get; set; }
        public virtual User Usr { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
