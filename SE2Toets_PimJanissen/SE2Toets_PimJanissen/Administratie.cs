using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2Toets_PimJanissen
{
    public class Administratie
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
            this.Verhuringen.Add(verhuur);
        }

        public void VoegToe(Verkoop verkoop)
        {
            this.Verkopen.Add(verkoop);
        }

        public List<IInkomsten> Overzicht(DateTime van, DateTime tot)
        {
            List<IInkomsten> overzicht = new List<IInkomsten>();
            overzicht.AddRange(this.Verhuringen);
            overzicht.AddRange(this.Verkopen);

            overzicht = overzicht.Where(i => i.Tijdstip.CompareTo(tot) <= 0 && i.Tijdstip.CompareTo(van) >= 0).ToList();
            overzicht.Sort(new CompareIInkomstenByDateDescending());

            return overzicht;
        }

        public List<IInkomsten> Overzicht(BTWTarief tarief)
        {
            List<IInkomsten> overzicht = new List<IInkomsten>();
            overzicht.AddRange(this.Verhuringen);
            overzicht.AddRange(this.Verkopen);

            if (tarief != BTWTarief.Ongespecificeerd)
            {
                overzicht = overzicht.Where(i => i.BTWTarief == tarief).ToList();
            }

            overzicht.Sort(new CompareIInkomstenByDateDescending());

            return overzicht;
        }

        public override string ToString()
        {
            return string.Format("Er zijn momenteel {0} verkopen en {1} verhuringen", this.Verkopen.Count, this.Verhuringen.Count);
        }

        public void Exporteer(string path, BTWTarief tarief)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                List<IInkomsten> overzicht = this.Overzicht(tarief);

                writer.Write(string.Join(Environment.NewLine, overzicht));
            }
        }
    }
}
