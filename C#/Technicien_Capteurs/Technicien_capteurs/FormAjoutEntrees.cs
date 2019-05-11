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
    public partial class FormAjoutEntrees : Form
    {
        private C_Config confIni;

        private C_BDD BDD;

        //private byte[] id;
        private List<byte> id = new List<byte>();
        public FormAjoutEntrees(C_Config configIni)
        {
            InitializeComponent();

            Dictionary<string, C_Capteur> dico = new Dictionary<int, C_Capteur>();
            dico.Add("a", new C_Capteur());
            dico.Add("b", new C_Capteur());

            dico["b"].

            confIni = configIni;

            BDD = new C_BDD(confIni.ip, confIni.dbn, confIni.username, confIni.password);
            byte nbEntrees = 0;
            var rdrCount = BDD.RequeteCountCapteurs();

            while (rdrCount.Read())
            {
                nbEntrees = byte.Parse(rdrCount[0].ToString());//Nombre d'entrées
            }

            //id = new byte[nbEntrees];

            BDD = new C_BDD(confIni.ip, confIni.dbn, confIni.username, confIni.password);

            var rdr = BDD.RequeteSelectIdNomCapteurs();
            byte j = 0;
            string stockage = "";

            while (rdr.Read())
            {
                //id[j] = byte.Parse(rdr[0].ToString());//id
                id.Add(byte.Parse(rdr[0].ToString()));//id
                stockage = rdr[1].ToString();//nom/

                cmbBox_capteur.Items.Add(stockage);
                //j++;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            int id_capteur = cmbBox_capteur.SelectedIndex;
            BDD.RequeteInsertEntree(txtBox_nom_entree.Text, byte.Parse(cmbBox_input.Text), id[id_capteur]);
        }
    }
}
