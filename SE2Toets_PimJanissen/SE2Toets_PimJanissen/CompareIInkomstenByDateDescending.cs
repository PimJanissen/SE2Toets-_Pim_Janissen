using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    public class CompareIInkomstenByDateDescending : IComparer<IInkomsten>
    {
        public int Compare(IInkomsten first, IInkomsten second)
        {
            return -1 * first.Tijdstip.CompareTo(second.Tijdstip);
        }
    }
}
