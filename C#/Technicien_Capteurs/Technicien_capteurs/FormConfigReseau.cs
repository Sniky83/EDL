using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technicien_capteurs
{
    public partial class FormConfigReseau : Form
    {
        private C_BDD BDD;

        private C_Config ConfigIni;

        private C_EDL_Recorder Enregistreur;

        private bool TesterConnexionBDD = false;

        private bool TesterConnexionEnregistreur = false;

        public bool IsConnectionDoneBDD { get; set; }

        public bool IsConnectionDoneArduino { get; set; }

        public bool IsFullConnected { get; set; }

        public FormConfigReseau(C_Config configIni)
        {
            InitializeComponent();
            ConfigIni = configIni;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //On fait le test pour éviter de refaire le test si on est déja connecté
            if(txtBox_ip.Visible == true)
            {
                if(txtBox_ip.Text != "" && txtBox_username.Text != "" /*&& txtBox_password.Text != ""*/ && txtBox_dbn.Text != "")
                {
                    BDD = new C_BDD(txtBox_ip.Text, txtBox_dbn.Text, txtBox_username.Text, txtBox_password.Text);
                    TesterConnexionBDD = BDD.TesterConnexion();

                    if(TesterConnexionBDD == true)
                    {
                        IsConnectionDoneBDD = true;

                        lbl_ip.Text = "Adresse IP : OK";
                        lbl_username.Text = "Nom d'utilisateur : OK";
                        lbl_password.Text = "Mot de passe : OK";
                        lbl_dbn.Text = "Nom de la base de données : OK";

                        txtBox_ip.Visible = false;
                        txtBox_username.Visible = false;
                        txtBox_password.Visible = false;
                        txtBox_dbn.Visible = false;

                        ConfigIni.ip = txtBox_ip.Text;
                        ConfigIni.username = txtBox_username.Text;
                        ConfigIni.password = txtBox_password.Text;
                        ConfigIni.dbn = txtBox_dbn.Text;
                        ConfigIni.SaveConfig();
                    }
                }
            }

            if (txtBox_ipArduino.Text != "")
            {
                Enregistreur = new C_EDL_Recorder(txtBox_ipArduino.Text);
                TesterConnexionEnregistreur = Enregistreur.TesterConnexion();

                if(TesterConnexionEnregistreur == true)
                {
                    lbl_ipArduino.Text = "Adresse IP : OK";

                    txtBox_ipArduino.Visible = false;

                    IsConnectionDoneArduino = true;
                    ConfigIni.ipArduino = txtBox_ipArduino.Text;
                    ConfigIni.SaveConfig();
                }
            }
            else if(txtBox_ipArduino.Text == "" && txtBox_ipArduino.Visible == true)
            {
                Thread.Sleep(1000);
                MessageBox.Show("Il est préférable de rentrer une adresse IP pour l'enregistreur si vous souhaitez le configurer par la suite !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (txtBox_ip.Visible == false && txtBox_ipArduino.Visible == false)
            {
                IsFullConnected = true;
                Close();
            }
        }

        private void TxtBox_ip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)8)
                return;

            if(Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^.]"))
            {
                e.Handled = true;
            }
        }

        private void TxtBox_ipArduino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
                return;

            if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^.]"))
            {
                e.Handled = true;
            }
        }

        private void Btn_aide_Click(object sender, EventArgs e)
        {
            if (ConfigIni.ip != "")
            {
                System.Diagnostics.Process.Start($"http://{ConfigIni.ip}/EDL/index.php?rubrique=2");
            }
            else
            {
                MessageBox.Show("Ici, vous pouvez rentrer les informations concernant la base de données ainsi que l'adresse IP de l'enregistreur. Il est important de tout rentrer si vous souhaitez accéder au reste de l'application.", "Aide", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
