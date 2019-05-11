using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technicien_capteurs
{
    public partial class FormConfigReseau : Form
    {
        C_BDD BDD;

        FormAccueil fAccueil;

        public FormConfigReseau(FormAccueil fAcc)
        {
            InitializeComponent();

            fAccueil = fAcc;
        }

        public FormConfigReseau() { InitializeComponent(); }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //On fait le test pour éviter de refaire le test si on est déja connecté
            if (txtBox_ip.Visible == true)
            {
                BDD = new C_BDD(txtBox_ip, txtBox_dbn, txtBox_username, txtBox_password);
                bool TestConn = BDD.TesterConnexion();
                if (TestConn == true)
                {
                    fAccueil.lbl_etat.Text = "Connecté";
                    fAccueil.lbl_etat.ForeColor = Color.Green;
                    fAccueil.btn_connexion.Enabled = true;

                    lbl_ip.Text = "Adresse IP : OK";
                    lbl_username.Text = "N'om d'utilisateur : OK";
                    lbl_password.Text = "Mot de passe : OK";
                    lbl_dbn.Text = "Nom de la base de données : OK";

                    txtBox_ip.Visible = false;
                    txtBox_username.Visible = false;
                    txtBox_password.Visible = false;
                    txtBox_dbn.Visible = false;

                    C_Config ConfigIni;

                    ConfigIni = new C_Config(new FormConfigReseau());

                    ConfigIni.SaveConfig();

                    Close();
                }
            }
            //Code pour la socket arduino
        }

        private void TxtBox_ip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
                return;

            if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^.]"))
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
    }
}
