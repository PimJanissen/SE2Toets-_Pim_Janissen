using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    public class Sportzaal : Verhuur
    {
        private BTWTarief btwTarief;
        private decimal prijsPerUur;

        public override BTWTarief BTWTarief { get { return this.btwTarief; } }
        public override decimal PrijsPerUur { get { return this.prijsPerUur; } }

        public Sportzaal(DateTime tijdstip, int urenVerhuurd)
            : base(tijdstip, urenVerhuurd)
        {
            this.btwTarief = BTWTarief.Laag;
            this.prijsPerUur = 40m;
        }

        public override string ToString()
        {
            return "Sportzaal || " + base.ToString();
        }
    }
}
