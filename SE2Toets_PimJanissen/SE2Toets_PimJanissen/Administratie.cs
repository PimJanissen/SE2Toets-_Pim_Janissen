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
        private List<IInkomsten> iInkomsten;

        public List<Verkoop> Verkopen { get { return iInkomsten.Where(i => i.GetType() == typeof(Verkoop)).Cast<Verkoop>().ToList(); } }

        public List<Verhuur> Verhuringen { get { return iInkomsten.Where(i => i.GetType() == typeof(Verhuur)).Cast<Verhuur>().ToList(); } }

        public Administratie()
        {
            this.iInkomsten = new List<IInkomsten>();
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
            if (DateTime.Compare(van, tot) != 1)
            {
                // checken op geldige datum, beter hier?
                List<IInkomsten> overzicht = new List<IInkomsten>();
                overzicht.AddRange(this.Verhuringen);
                overzicht.AddRange(this.Verkopen);

                overzicht = overzicht.Where(i => i.Tijdstip.CompareTo(tot) <= 0 && i.Tijdstip.CompareTo(van) >= 0).ToList();
                overzicht.Sort(new CompareIInkomstenByDateDescending());

                return overzicht;
            }

            throw new ArgumentException("De datum 'van' dient eerder te zijn als de datum 'tot'.");
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

                decimal totaal = 0;
                decimal totaalHoog = 0;
                decimal totaalLaag = 0;

                foreach (IInkomsten iInkomst in overzicht)
                {
                    writer.WriteLine(string.Format("{0} - {1} - EUR {2}", iInkomst.Tijdstip.ToString(), iInkomst.BTWTarief, iInkomst.Bedrag.ToString()));
                    totaal += iInkomst.Bedrag;

                    if (iInkomst.BTWTarief == BTWTarief.Hoog)
                    {
                        totaalHoog += iInkomst.Bedrag;
                    }

                    if (iInkomst.BTWTarief == BTWTarief.Laag)
                    {
                        totaalLaag += iInkomst.Bedrag;
                    }
                }

                if (tarief == BTWTarief.Ongespecificeerd)
                {
                    writer.WriteLine("Totaal laag = EUR " + totaalLaag.ToString());
                    writer.WriteLine("Totaal hoog = EUR " + totaalHoog.ToString());
                }

                writer.WriteLine("Totaal = EUR " + totaal.ToString());
            }
        }
    }
}
