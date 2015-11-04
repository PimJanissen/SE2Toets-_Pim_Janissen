using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    class Feestzaal : Verhuur
    {
        private BTWTarief btwTarief;
        private decimal prijsPerUur;

        public override BTWTarief BTWTarief { get { return this.btwTarief; } }
        public override decimal PrijsPerUur { get { return this.prijsPerUur; } }

        public Feestzaal(DateTime tijdstip, int urenVerhuurd) :base(tijdstip, urenVerhuurd)
        {
            this.btwTarief = BTWTarief.Hoog;
            this.prijsPerUur = 80m;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
