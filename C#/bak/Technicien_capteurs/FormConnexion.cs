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
        public FormConnexion()
        {
            InitializeComponent();
        }

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            if(txtBox_username.Text == "Technicien" && txtBox_password.Text == "TechConfig")
            {
                FormAccueil fAcc = new FormAccueil();
                fAcc.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mot de passe ou nom d'utilisateur incorrect !","Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
