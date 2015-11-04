using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    public interface IInkomsten
    {
        decimal Bedrag { get; }
        BTWTarief BTWTarief { get; }
        DateTime Tijdstip { get; }
    }
}
