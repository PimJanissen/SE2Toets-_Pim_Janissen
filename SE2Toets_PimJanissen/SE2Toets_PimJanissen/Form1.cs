using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE2Toets_PimJanissen
{
    public partial class Form1 : Form
    {
        private Administratie administratie;

        public Form1()
        {
            InitializeComponent();

            this.administratie = new Administratie();

            cbNieuweVerhuring.DataSource = this.GetCBVerhuringValues();
            cbNieuweVerkoop.DataSource = this.GetCBVerkoopValues();

            cbOverzichtBTW.DataSource = Enum.GetValues(typeof(BTWTarief));
        }

        private List<string> GetCBVerhuringValues()
        {
            return new List<string>
            {
                typeof(Feestzaal).Name,
                typeof(Sportzaal).Name,
                typeof(Theaterzaal).Name
            };
        }

        private List<string> GetCBVerkoopValues()
        {
            return new List<string>
            {
                typeof(SterkeDrank).Name,
                typeof(Pringles).Name,
                typeof(Frisdrank).Name
            };
        }

        private void btnNieuweVerhuringToevoegen_Click(object sender, EventArgs e)
        {
            Verhuur verhuur = null;
            DateTime tijdstip = dtpNieuweVerhuringTijdstip.Value;
            int aantalUren = (int)nudNieuweVerhuringUren.Value;

            switch (cbNieuweVerhuring.SelectedValue.ToString())
            {
                case "Feestzaal":
                    verhuur = new Feestzaal(tijdstip, aantalUren);
                    break;
                case "Sportzaal":
                    verhuur = new Sportzaal(tijdstip, aantalUren);                    break;
                case "Theaterzaal":
                    verhuur = new Theaterzaal(tijdstip, aantalUren);
                    break;
            }

            this.administratie.VoegToe(verhuur);
            this.UpdateVerhuurListBox();
        }

        private void btnNieuweVerkoopToevoegen_Click(object sender, EventArgs e)
        {
            Verkoop verkoop = null;
            int aantal = (int)nudNieuweVerkoopAantal.Value;

            switch (cbNieuweVerkoop.SelectedValue.ToString())
            {
                case "SterkeDrank":
                    verkoop = new SterkeDrank(aantal);
                    break;
                case "Pringles":
                    verkoop = new Pringles(aantal); break;
                case "Frisdrank":
                    verkoop = new Frisdrank(aantal);
                    break;
            }

            this.administratie.VoegToe(verkoop);
            this.UpdateVerkoopListBox();
        }

        private void UpdateVerhuurListBox()
        {
            this.lbVerhuringen.DataSource = null;
            this.lbVerhuringen.DataSource = this.administratie.Verhuringen;
        }

        private void UpdateVerkoopListBox()
        {
            this.lbVerkopen.DataSource = null;
            this.lbVerkopen.DataSource = this.administratie.Verkopen;
        }

        private void btnOverzichtDatumbereik_Click(object sender, EventArgs e)
        {
            DateTime van = dtpOverzichtVan.Value;
            DateTime tot = dtpOverzichtTot.Value;

            List<IInkomsten> overzicht = this.administratie.Overzicht(van, tot);
            
            MessageBox.Show(string.Join(System.Environment.NewLine, overzicht));
        }
    }
}
