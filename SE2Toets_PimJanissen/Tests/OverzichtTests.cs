﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE2Toets_PimJanissen;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class OverzichtTests
    {

        // Zet je test data als statische variabelen om asserts gemakkelijker te maken

        // Test of de teruggegeven aantallen ook kloppen, en niet alleen de eigenschappen
        // van elk teruggegeven resultaat.

        Administratie administratie;
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

            // Wat als de waarden bij benadering oke moeten zijn?
            // Assert.AreEqual(0.2, 0.5, 0.2);

            // OF
            // Assert.IsTrue( verschil < delta );
        }
        [TestMethod]
        public void TestOverzichtMetAlleenLageBTWTarieven()
        { // Goed: elke test slechts 1 deel laten testen.

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

            // testen dat het aantal gelijk is aan alles dat je erin gestoken hebt.

            Assert.AreEqual((overzicht.Find(i => i.BTWTarief == BTWTarief.Hoog) != null) && (overzicht.Find(i => i.BTWTarief == BTWTarief.Laag) != null), true);
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

            Assert.AreEqual(this.OverzichtOmgekeerdChronologisch(overzicht), true);
        }

        [TestMethod]
        public void TestOverzichtGesorteerdOpOmgekeerdChronologischeVolgordeMetStartEnEinddatum()
        {
            DateTime start = DateTime.Now.Subtract(new TimeSpan(4, 2, 0));
            DateTime end = DateTime.Now;
            List<IInkomsten> overzicht = administratie.Overzicht(start, end);

            Assert.AreEqual(this.OverzichtOmgekeerdChronologisch(overzicht), true);
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
