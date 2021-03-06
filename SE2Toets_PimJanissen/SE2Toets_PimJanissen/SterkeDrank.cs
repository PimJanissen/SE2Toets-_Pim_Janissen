﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    public class SterkeDrank : Verkoop
    {
        private BTWTarief btwTarief;
        private decimal prijs;

        public override BTWTarief BTWTarief { get { return this.btwTarief; } }
        public override decimal Prijs { get { return this.prijs; } }

        public SterkeDrank(int aantal) :base(aantal)
        {
            this.btwTarief = BTWTarief.Hoog;
            this.prijs = 3.00M;
        }

        public override string ToString()
        {
            return "Sterke drank || " + base.ToString();
        }
    }
}
