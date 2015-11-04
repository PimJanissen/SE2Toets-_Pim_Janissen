using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    abstract class Verhuur : IInkomsten
    {
        public int UrenVerhuurd { get; set; }
        public decimal Bedrag { get { return this.UrenVerhuurd * this.PrijsPerUur; } }
        public DateTime Tijdstip { get; set; }
        public abstract BTWTarief BTWTarief { get; }
        public abstract decimal PrijsPerUur { get; }

        public Verhuur(DateTime tijdstip, int urenVerhuurd)
        {
            this.Tijdstip = tijdstip;
            this.UrenVerhuurd = urenVerhuurd;
        }

        public override string ToString()
        {
            return string.Format("Tijdstip: {0} || Duur: {1} uren || Prijs per uur: {2} || Bedrag: {3}", this.Tijdstip.ToString(), this.PrijsPerUur.ToString(), this.UrenVerhuurd.ToString(), this.Bedrag.ToString());
        }
    }
}
