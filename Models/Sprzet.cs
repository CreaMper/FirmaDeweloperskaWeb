using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Sprzet
    {
        public decimal SprzetId { get; set; }
        public decimal? ZespId { get; set; }
        public string SrzetNazwa { get; set; }
        public int SprzetIlosc { get; set; }

        public virtual Zespoly Zesp { get; set; }
    }
}
