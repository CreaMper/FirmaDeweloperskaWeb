using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Zlecenium
    {
        public Zlecenium()
        {
            Przeplywgotowkis = new HashSet<Przeplywgotowki>();
        }

        public decimal ZlecId { get; set; }
        public decimal? ZespId { get; set; }
        public decimal? PrioId { get; set; }
        public DateTime ZlecRozpoczecie { get; set; }
        public bool ZlecZakonczono { get; set; }
        public string ZlecOpis { get; set; }

        public virtual Priorytety Prio { get; set; }
        public virtual Zespoly Zesp { get; set; }
        public virtual ICollection<Przeplywgotowki> Przeplywgotowkis { get; set; }
    }
}
