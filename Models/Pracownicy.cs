using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Pracownicy
    {
        public Pracownicy()
        {
            Umowies = new HashSet<Umowy>();
            Wydatkis = new HashSet<Wydatki>();
        }

        public decimal PracId { get; set; }
        public decimal? ZespId { get; set; }
        public string PracImie { get; set; }
        public string PracNazwisko { get; set; }
        public string PracPesel { get; set; }
        public string PracAdres { get; set; }
        public string PracEmail { get; set; }
        public string PracTelefon { get; set; }
        public string PracStanowsko { get; set; }

        public virtual Zespoly Zesp { get; set; }
        public virtual ICollection<Umowy> Umowies { get; set; }
        public virtual ICollection<Wydatki> Wydatkis { get; set; }
    }
}
