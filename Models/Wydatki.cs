using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Wydatki
    {
        public Wydatki()
        {
            Przeznaczenies = new HashSet<Przeznaczenie>();
        }

        public decimal WydId { get; set; }
        public decimal? PracId { get; set; }
        public decimal WydKwota { get; set; }
        public DateTime WydData { get; set; }

        public virtual Pracownicy Prac { get; set; }
        public virtual ICollection<Przeznaczenie> Przeznaczenies { get; set; }
    }
}
