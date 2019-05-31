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

        public bool IsConnexionDone { get; set; } = false;

        public FormConnexion(C_Config confIni)
        {
            InitializeComponent();

            BDD = new C_BDD(confIni.ip, confIni.dbn, confIni.username, confIni.password);
        }

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            var rdr = BDD.SeConnecter(txtBox_nom.Text, txtBox_password.Text);

            string nom = "";
            string password = "";

            while (rdr.Read())
            {
                nom = rdr[0].ToString();
                password = rdr[1].ToString();
                if (nom == txtBox_nom.Text && password == txtBox_password.Text)
                {
                    IsConnexionDone = true;
                    MessageBox.Show("Connexion réussie !", "Succès !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }

            if (nom == "")
            {
                MessageBox.Show("Mot de passe ou nom d'utilisateur incorrect !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            rdr.Close();
            BDD.connection.Close();
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
