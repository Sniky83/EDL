using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technicien_capteurs
{
    public partial class FormAccueil : Form
    { 
        private C_Config ConfigIni = new C_Config();

        private bool TesterConnexionArduino = false;
        private bool TesterConnexionBDD = false;

        private bool flagBDD = false;
        private bool flagArduino = false;

        public FormAccueil()
        {
            InitializeComponent();

            if (File.Exists("Paramètres.ini"))
            {
                ConfigIni.LoadConfig();
            }

            /*if (ConfigIni.ipArduino != "")
            {
                C_EDL_Recorder Enregistreur;
                Enregistreur = new C_EDL_Recorder();

                TesterConnexionArduino = Enregistreur.TesterConnexion(ConfigIni.ipArduino);

                if(TesterConnexionArduino == true)
                {
                    lbl_etat_enr.Text = "Connecté";
                    lbl_etat_enr.ForeColor = Color.Green;
                    flagArduino = true;
                }
            }*/

            /*if (ConfigIni.ip != "" && ConfigIni.username != "" /*&& ConfigIni.txtBox_password != ""*/ /*&& ConfigIni.dbn != "")
            {
                C_BDD BDD;
                BDD = new C_BDD(ConfigIni.ip, ConfigIni.dbn, ConfigIni.username, ConfigIni.password);

                TesterConnexionBDD = BDD.TesterConnexion();

                if(TesterConnexionBDD == true)
                {
                    lbl_etat_bdd.Text = "Connecté";
                    lbl_etat_bdd.ForeColor = Color.Green;
                    btn_connexion.Enabled = true;
                    flagBDD = true;
                }
            }*/

            if (TesterConnexionArduino == true && TesterConnexionBDD == true)
            {
                btn_configRes.Enabled = false;
            }
            btn_gestCapteur.Enabled = true;
            btn_configEnr.Enabled = true;
            btn_mesurer.Enabled = true;
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
            if(ConfigIni.ip != "")
            {
                System.Diagnostics.Process.Start($"http://{ConfigIni.ip}/EDL/index.php?rubrique=1");
            }
            else
            {
                MessageBox.Show("Pour vous connecter à l'enregisteur, il vous suffira de clicker sur le bouton 'Configurartion Réseau', une fois la connexion établie, vous pourez vous connecter avec votre compte pour accéder au reste en cliquant sur le bouton 'Se Connecter'.", "Aide", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_configEnr_Click(object sender, EventArgs e)
        {
            FormConfigEnregistreur fEnr = new FormConfigEnregistreur(ConfigIni);
            fEnr.ShowDialog();
        }

        private void btn_configRes_Click(object sender, EventArgs e)
        {
            FormConfigReseau fConfRes = new FormConfigReseau(ConfigIni);

            if(TesterConnexionBDD == true || flagBDD == true)
            {
                fConfRes.lbl_ip.Text = "Adresse IP : OK";
                fConfRes.lbl_username.Text = "Nom d'utilisateur : OK";
                fConfRes.lbl_password.Text = "Mot de passe : OK";
                fConfRes.lbl_dbn.Text = "Nom de la base de données : OK";

                fConfRes.txtBox_ip.Visible = false;
                fConfRes.txtBox_username.Visible = false;
                fConfRes.txtBox_password.Visible = false;
                fConfRes.txtBox_dbn.Visible = false;
            }

            if(TesterConnexionArduino == true || flagArduino == true)
            {
                fConfRes.lbl_ipArduino.Text = "Adresse IP : OK";

                fConfRes.txtBox_ipArduino.Visible = false;
            }
            fConfRes.ShowDialog();

            if(fConfRes.IsConnectionDoneBDD == true && TesterConnexionBDD == false)
            {
                lbl_etat_bdd.Text = "Connecté";
                lbl_etat_bdd.ForeColor = Color.Green;
                btn_connexion.Enabled = true;
                flagBDD = true;
            }
            else
            {
                flagBDD = false;
            }

            if(fConfRes.IsConnectionDoneArduino == true && TesterConnexionArduino == false)
            {
                lbl_etat_enr.Text = "Connecté";
                lbl_etat_enr.ForeColor = Color.Green;
                flagArduino = true;
            }
            else
            {
                flagArduino = false;
            }

            if (fConfRes.IsFullConnected == true)
            {
                btn_configRes.Enabled = false;
            }
        }

        private void btn_gestCapteur_Click(object sender, EventArgs e)
        {
            FormGestionCapteurs fGestCapt;
            fGestCapt = new FormGestionCapteurs(ConfigIni);

            fGestCapt.ShowDialog();
        }

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            FormConnexion fConn = new FormConnexion(ConfigIni);
            fConn.ShowDialog();

            if(fConn.IsConnexionDone == true)
            {
                btn_connexion.Enabled = false;
            }

            if(ConfigIni.ipArduino != "" && ConfigIni.ip != "" && fConn.IsConnexionDone == true)
            {
                btn_gestCapteur.Enabled = true;
                btn_configEnr.Enabled = true;
                btn_mesurer.Enabled = true;
            }
            else
            {
                btn_configEnr.Enabled = true;
                Thread.Sleep(2000);
                MessageBox.Show("Vous devez vous connecter à l'enregistreur en rentrant son adresse IP dans la partie 'Configuration Réseau' pour pouvoir utiliser les autres fonctionnalitées !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
