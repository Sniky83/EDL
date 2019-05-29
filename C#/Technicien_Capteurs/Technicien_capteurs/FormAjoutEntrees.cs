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

        private byte[] id;
        //private List<byte> id = new List<byte>();
        public FormAjoutEntrees(C_Config configIni)
        {
            InitializeComponent();

            //Dictionary<int, C_Capteur> dico = new Dictionary<int, C_Capteur>();
            /*dico.Add("a", new C_Capteur());
            dico.Add("b", new C_Capteur());

            dico["b"];*/

            confIni = configIni;

            BDD = new C_BDD(configIni.ip, configIni.dbn, configIni.username, configIni.password);

            byte nbEntrees = 0;
            var rdr = BDD.RequeteCountCapteurs();

            while (rdr.Read())
            {
                nbEntrees = byte.Parse(rdr[0].ToString());//Nombre d'entrées
            }
            rdr.Close();
            BDD.connection.Close();

            id = new byte[nbEntrees];

            rdr = BDD.RequeteSelectIdNomCapteurs();
            byte j = 0;
            string stockage = "";

            while (rdr.Read())
            {
                id[j] = byte.Parse(rdr[0].ToString());//id
                //id.Add(byte.Parse(rdr[0].ToString()));//id
                stockage = rdr[1].ToString();//nom

                cmbBox_capteur.Items.Add(stockage);
                j++;
            }
            rdr.Close();
            BDD.connection.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            int id_capteur = cmbBox_capteur.SelectedIndex;
            /*C_Capteur capteur = cmbBox_capteur.SelectedItem as C_Capteur;
            int id_capteur = capteur.Id;*/
            BDD.RequeteInsertEntree(txtBox_nom_entree.Text, byte.Parse(cmbBox_input.Text), id[id_capteur]);

            Close();
        }
    }
}
