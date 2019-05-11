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
    public partial class FormConnexion : Form
    {
        C_BDD BDD;

        FormAccueil fAccueil;

        FormConfigReseau fConfRes;

        public FormConnexion(FormAccueil fAccueil, FormConfigReseau fConfRes)
        {
            InitializeComponent();
            this.fAccueil = fAccueil;
            this.fConfRes = fConfRes;

            BDD = new C_BDD(fConfRes.txtBox_ip, fConfRes.txtBox_dbn, fConfRes.txtBox_username, fConfRes.txtBox_password);
        }

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            string[,] Connexion = BDD.SeConnecter(txtBox_username, txtBox_password);

            int sizeOfConnexion = Connexion.GetLength(0);

            if(sizeOfConnexion == 1)
            {
                MessageBox.Show("Connexion réussie !", "Succès !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fAccueil.btn_connexion.Enabled = false;
                fAccueil.btn_gestCapteur.Enabled = true;
                fAccueil.btn_configEnr.Enabled = true;
                Close();
            }
            else
            {
                MessageBox.Show("Mot de passe ou nom d'utilisateur incorrect !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            /*if(txtBox_username.Text == "Technicien" && txtBox_password.Text == "TechConfig")
            {
                FormAccueil fAcc = new FormAccueil();
                fAcc.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mot de passe ou nom d'utilisateur incorrect !","Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
