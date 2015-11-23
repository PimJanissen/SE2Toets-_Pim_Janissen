using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE2Toets_PimJanissen;
using System.Collections.Generic;

namespace Tests
{
    [TestClass] 
    public class OverzichtTests
    {
        static Administratie administratie;

        [TestInitialize]
        public void CreateOverzichtTests()
        {
            administratie = new Administratie();

            administratie.VoegToe(new Feestzaal(DateTime.Now, 4));
            administratie.VoegToe(new Feestzaal(DateTime.Now, 1));
            administratie.VoegToe(new Theaterzaal(new DateTime(2015, 9, 12, 12, 45, 00), 2));
            administratie.VoegToe(new Sportzaal(DateTime.Now, 8));
            administratie.VoegToe(new Theaterzaal(new DateTime(2015, 9, 12, 12, 45, 00), 4));
            administratie.VoegToe(new Pringles(1));
            administratie.VoegToe(new Pringles(2));
            administratie.VoegToe(new SterkeDrank(4));
            administratie.VoegToe(new SterkeDrank(2));
            administratie.VoegToe(new SterkeDrank(3));
        }

        [TestMethod]
        public void TestOverzichtMetAlleenLageBTWTarieven()
        { 
            List<IInkomsten> overzicht = administratie.Overzicht(BTWTarief.Laag);

            Assert.AreEqual(overzicht.Find(i => i.BTWTarief != BTWTarief.Laag), null);
        }

        [TestMethod]
        public void TestOverzichtMetAlleenHogeBTWTarieven()
        {
            List<IInkomsten> overzicht = administratie.Overzicht(BTWTarief.Hoog);

            Assert.AreEqual(overzicht.Find(i => i.BTWTarief != BTWTarief.Hoog), null);
        }

        [TestMethod]
        public void TestOverzichtMetAlleBTWTarieven()
        {
            List<IInkomsten> overzicht = administratie.Overzicht(BTWTarief.Ongespecificeerd);

            Assert.AreEqual(overzicht.Count, administratie.Verhuringen.Count + administratie.Verkopen.Count);
        }

        [TestMethod]
        public void TestOverzichtBinnenGegevenStartEnEindData()
        {
            DateTime start = DateTime.Now.Subtract(new TimeSpan(4, 2, 0));
            DateTime end = DateTime.Now;
            List<IInkomsten> overzicht = administratie.Overzicht(start, end);

            Assert.AreEqual(overzicht.Find(i => i.Tijdstip.CompareTo(start) <= 0 && i.Tijdstip.CompareTo(end) >= 0), null);
        }

        [TestMethod]
        public void TestOverzichtGesorteerdOpOmgekeerdChronologischeVolgordeMetBTWTarieven()
        {
            List<IInkomsten> overzicht = administratie.Overzicht(BTWTarief.Laag);

            Assert.IsTrue(this.OverzichtOmgekeerdChronologisch(overzicht));
        }

        [TestMethod]
        public void TestOverzichtGesorteerdOpOmgekeerdChronologischeVolgordeMetStartEnEinddatum()
        {
            DateTime start = DateTime.Now.Subtract(new TimeSpan(4, 2, 0));
            DateTime end = DateTime.Now;
            List<IInkomsten> overzicht = administratie.Overzicht(start, end);

            Assert.IsTrue(this.OverzichtOmgekeerdChronologisch(overzicht));
        }

        private bool OverzichtOmgekeerdChronologisch(List<IInkomsten> overzicht)
        {
            foreach (IInkomsten iInkomst in overzicht)
            {
                int indexVanVorige = overzicht.IndexOf(iInkomst) - 1;
                if (indexVanVorige > -1)
                {
                    IInkomsten vorigeIInkomst = overzicht[indexVanVorige];

                    if (iInkomst.Tijdstip.CompareTo(vorigeIInkomst.Tijdstip) == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
