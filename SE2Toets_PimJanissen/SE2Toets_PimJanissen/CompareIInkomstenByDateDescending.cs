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
            int returnValue = -1 * first.Tijdstip.CompareTo(second.Tijdstip);

            if (returnValue == 0)
            {
                returnValue = -1 * first.Bedrag.CompareTo(second.Bedrag);
                
                if (returnValue == 0)
                {
                    returnValue = -1 * first.BTWTarief.CompareTo(second.BTWTarief);
                }
            }

            return returnValue;

            // belangrijke opmerking: implementatie is niet volledig.
            // Op dit moment zijn 2 inkomsten gelijk als ze hetzelfde tijdstip hebben...
            // ze kunnen maar gelijk zijn als alle andere eigenschappen ook gelijk zijn.
            // if( tijdstip == 0)
             //   return 
             // anders problemen met uniciteit: voor treeset en gelijkaardige collecties.
        }
    }
}
