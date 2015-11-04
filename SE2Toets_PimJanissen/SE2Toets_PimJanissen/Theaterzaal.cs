using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    class Theaterzaal : Verhuur
    {
        private BTWTarief btwTarief;
        private decimal prijsPerUur;

        public override BTWTarief BTWTarief { get { return this.btwTarief; } }
        public override decimal PrijsPerUur { get { return this.prijsPerUur; } }

        public Theaterzaal(DateTime tijdstip, int urenVerhuurd)
            : base(tijdstip, urenVerhuurd)
        {
            this.btwTarief = BTWTarief.Laag;
            this.prijsPerUur = 250m;
        }

        public override string ToString()
        {
            return "Theaterzaal || " + base.ToString();
        }
    }
}
