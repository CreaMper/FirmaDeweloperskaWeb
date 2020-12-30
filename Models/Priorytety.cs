using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Priorytety
    {
        public Priorytety()
        {
            Zlecenia = new HashSet<Zlecenium>();
        }

        public decimal PrioId { get; set; }
        public string PrioNazwa { get; set; }
        public decimal PrioPremiaDlaZespolu { get; set; }

        public virtual ICollection<Zlecenium> Zlecenia { get; set; }
    }
}
