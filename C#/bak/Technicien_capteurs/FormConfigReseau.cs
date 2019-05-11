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
    public partial class FormConfigReseau : Form
    {
        C_BDD BDD;

        public FormConfigReseau()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            FormAccueil fAccueil = new FormAccueil();
            BDD = new C_BDD(txtBox_ip, txtBox_dbn, txtBox_username, txtBox_password);
            bool TestConn = BDD.TesterConnexion();
            if (TestConn == true)
            {
                fAccueil.lbl_etat.Text = "Connecté";
                fAccueil.lbl_etat.ForeColor = Color.Green;
                fAccueil.btn_gestCapteur.Enabled = true;
                fAccueil.btn_configEnr.Enabled = true;
                Close();
            }
        }
    }
}
