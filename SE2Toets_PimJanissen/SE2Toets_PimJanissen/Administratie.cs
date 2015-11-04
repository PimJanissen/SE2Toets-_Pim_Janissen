using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    class Administratie
    {
        public List<Verkoop> Verkopen { get; private set; }

        public List<Verhuur> Verhuringen { get; private set; }

        public Administratie()
        {
            this.Verkopen = new List<Verkoop>();
            this.Verhuringen = new List<Verhuur>();
        }

        public void VoegToe(Verhuur verhuur)
        {
            throw new NotImplementedException();
        }

        public void Voegtoe(Verkoop verkoop)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("Er zijn momenteel {0} verkopen en {1} verhuringen", this.Verkopen.Count, this.Verhuringen.Count);
        }
    }
}
