using System;
using System.Collections.Generic;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class Przeplywgotowki
    {
        public decimal PrzepId { get; set; }
        public decimal? ZlecId { get; set; }
        public decimal PrzepKwota { get; set; }
        public string PrzepOpis { get; set; }

        public virtual Zlecenium Zlec { get; set; }
    }
}
