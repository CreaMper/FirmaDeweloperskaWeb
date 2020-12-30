using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Umowy
    {
        public decimal UmowaId { get; set; }
        public decimal? PracId { get; set; }
        public decimal UmowaPensja { get; set; }
        public DateTime UmowaDoKiedy { get; set; }
        public DateTime UmowaOdKiedy { get; set; }

        public virtual Pracownicy Prac { get; set; }
    }
}
