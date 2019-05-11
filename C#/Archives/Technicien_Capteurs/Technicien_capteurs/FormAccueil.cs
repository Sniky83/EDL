using MySql.Data.MySqlClient;
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
        FormConfigReseau fConfRes;

        public FormAccueil()
        {
            InitializeComponent();

            fConfRes = new FormConfigReseau(this);

            C_Config ConfigIni;
            ConfigIni = new C_Config(fConfRes);

            bool result = ConfigIni.LoadConfig();

            if(result == true)
            {
                fConfRes.txtBox_ip.Text = ConfigIni.ip;
                fConfRes.txtBox_username.Text = ConfigIni.username;
                fConfRes.txtBox_password.Text = ConfigIni.password;
                fConfRes.txtBox_dbn.Text = ConfigIni.dbn;
            }

            /*C_BDD BDD;
            BDD = new C_BDD(fConfRes.txtBox_ip, fConfRes.txtBox_dbn, fConfRes.txtBox_username, fConfRes.txtBox_password);

            MySqlDataReader rdr = BDD.test();
            short i = 0;
            string stockage;
            while (rdr.Read())
            {
                stockage = rdr[1].ToString();
                i++;
                Console.WriteLine(stockage);
            }
            rdr.Close();
            BDD.connection.Close();*/

            if (fConfRes.txtBox_ip.Text != "" && fConfRes.txtBox_dbn.Text != "" && fConfRes.txtBox_username.Text != "" /*&& fConfRes.txtBox_password.Text != ""*/)
            {
                C_BDD BDD;
                BDD = new C_BDD(fConfRes.txtBox_ip, fConfRes.txtBox_dbn, fConfRes.txtBox_username, fConfRes.txtBox_password);

                bool TestConn = BDD.TesterConnexion();

                if (TestConn == true)
                {
                    lbl_etat.Text = "Connecté";
                    lbl_etat.ForeColor = Color.Green;
                    btn_connexion.Enabled = true;

                    fConfRes.lbl_ip.Text = "Adresse IP : OK";
                    fConfRes.lbl_username.Text = "N'om d'utilisateur : OK";
                    fConfRes.lbl_password.Text = "Mot de passe : OK";
                    fConfRes.lbl_dbn.Text = "Nom de la base de données : OK";

                    fConfRes.txtBox_ip.Visible = false;
                    fConfRes.txtBox_username.Visible = false;
                    fConfRes.txtBox_password.Visible = false;
                    fConfRes.txtBox_dbn.Visible = false;
                }
            }
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
            /*FormGestionCapteurs fGesCapt;
            fGesCapt = new FormGestionCapteurs();*/
            FormAjoutCapteur fAddCpt;
            fAddCpt = new FormAjoutCapteur(fConfRes);

            FormGestionCapteurs fGestCapt;
            //fGestCapt = new FormGestionCapteurs(fConfRes, fAddCpt);
            fGestCapt = new FormGestionCapteurs(fConfRes);

            //FormGestionCapteurs fGestCapt1 = new FormGestionCapteurs(fConfRes, new FormAjoutCapteur(fGestCapt));
            fGestCapt.ShowDialog();
        }

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            FormConnexion fConn = new FormConnexion(this, fConfRes);
            fConn.ShowDialog();
        }
    }
}
