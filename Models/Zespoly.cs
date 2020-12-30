using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Zespoly
    {
        public Zespoly()
        {
            Pracownicies = new HashSet<Pracownicy>();
            Sprzets = new HashSet<Sprzet>();
            Zlecenia = new HashSet<Zlecenium>();
        }

        public decimal ZespId { get; set; }
        public string ZespNazwa { get; set; }

        public virtual ICollection<Pracownicy> Pracownicies { get; set; }
        public virtual ICollection<Sprzet> Sprzets { get; set; }
        public virtual ICollection<Zlecenium> Zlecenia { get; set; }
    }
}
