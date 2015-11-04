using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    class Frisdrank : Verkoop
    {
        private BTWTarief btwTarief;
        private decimal prijs;

        public override BTWTarief BTWTarief { get { return this.btwTarief; } }
        public override decimal Prijs { get { return this.prijs; } }

        public Frisdrank(int aantal)
            : base(aantal)
        {
            this.btwTarief = BTWTarief.Laag;
            this.prijs = 2.00M;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
