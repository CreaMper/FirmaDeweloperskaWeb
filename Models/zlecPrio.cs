using System;
using System.Collections.Generic;

namespace FirmaDeweloperskaWeb.Pages
{
    public class zlecPrio
    {
        public decimal ZlecId { get; set; }
        public decimal? ZespId { get; set; }
        public decimal? PrioId { get; set; }
        public DateTime ZlecRozpoczecie { get; set; }
        public bool ZlecZakonczono { get; set; }
        public string ZlecOpis { get; set; }

        public string PrioNazwa { get; set; }
        public decimal PrioPremiaDlaZespolu { get; set; }

        public virtual ICollection<Zlecenium> Zlecenia { get; set; }

    }
}