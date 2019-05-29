using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technicien_capteurs
{
    public partial class FormAccueil : Form
    {
        C_BDD BDD;

        FormConfigReseau fConfRes = new FormConfigReseau();

        public FormAccueil()
        {
            InitializeComponent();
        }

        private void btn_mesurer_Click(object sender, EventArgs e)
        {
            FormMesures fMesurer = new FormMesures();
            fMesurer.ShowDialog();
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_aide_Click(object sender, EventArgs e)
        {
            /*FormAide fAide = new FormAide();
            fAide.ShowDialog();*/
            System.Diagnostics.Process.Start("http://localhost/EDL/index.php?rubrique=1");
        }

        private void btn_configEnr_Click(object sender, EventArgs e)
        {
            FormConfigEnregistreur fEnr = new FormConfigEnregistreur();
            fEnr.ShowDialog();
        }

        private void btn_configRes_Click(object sender, EventArgs e)
        {
            fConfRes.ShowDialog();
        }

        private void btn_gestCapteur_Click(object sender, EventArgs e)
        {
            FormGestionCapteurs fca = new FormGestionCapteurs();
            fca.ShowDialog();
        }

        private void FormAccueil_Shown(object sender, EventArgs e)
        {
            if (fConfRes.txtBox_ip.Text != "" && fConfRes.txtBox_dbn.Text != "" && fConfRes.txtBox_username.Text != "" /*&& fConfRes.txtBox_password.Text != ""*/)
            {
                BDD = new C_BDD(fConfRes.txtBox_ip, fConfRes.txtBox_dbn, fConfRes.txtBox_username, fConfRes.txtBox_password);
                bool TestConn = BDD.TesterConnexion();
                if (TestConn == true)
                {
                    lbl_etat.Text = "Connecté";
                    lbl_etat.ForeColor = Color.Green;
                    btn_gestCapteur.Enabled = true;
                    btn_configEnr.Enabled = true;
                }
            }
        }
    }
}
