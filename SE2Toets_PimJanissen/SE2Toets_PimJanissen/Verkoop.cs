using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    abstract class Verkoop : IInkomsten
    {
        public int Aantal { get; set; }
        public decimal Bedrag { get { return this.Prijs * this.Aantal;} }
        public DateTime Tijdstip { get; set; }
        public abstract BTWTarief BTWTarief { get; }
        public abstract decimal Prijs { get; }

        public Verkoop(int aantal)
        {
            this.Aantal = aantal;
        }

        public override string ToString()
        {
            return string.Format("Prijs: {0} || Aantal: {1} || Bedrag: {2} || BTW tarief: {3} ||", this.Prijs.ToString(), this.Aantal.ToString(), this.Bedrag.ToString(), this.BTWTarief.ToString());
        }
    }
}
