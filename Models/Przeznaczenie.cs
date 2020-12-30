using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Przeznaczenie
    {
        public decimal PrzezId { get; set; }
        public decimal? WydId { get; set; }
        public string PrzezNazwa { get; set; }
        public decimal? PrzezNumerSeryjny { get; set; }
        public DateTime? PrzezAktywnaDo { get; set; }

        public virtual Wydatki Wyd { get; set; }
    }
}
