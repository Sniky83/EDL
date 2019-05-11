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
    public partial class FormAjoutCapteur : Form
    {
        private C_BDD BDD;

        public string[] Tableau { get; set; }

        public ushort id { get; set; }

        public bool IsSendToServer { get; set; } = false;

        private C_Config configIni;

        public FormAjoutCapteur(C_Config confIni)
        {
            InitializeComponent();

            configIni = confIni;

            BDD = new C_BDD(confIni.ip, confIni.dbn, confIni.username, confIni.password);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void btn_ok_Click(object sender, EventArgs e)
        {
            if (txtBox_name.Text != "" && txtBox_marque.Text != "" && txtBox_model.Text != "" && numUpDown_calibre.Value != 0 && txtBox_a.Text != "" && txtBox_b.Text != "")
            {
                if (id != 0)
                {
                    bool result = BDD.RequeteUpdateCapteur(txtBox_name.Text, configIni.ipArduino,txtBox_marque.Text, txtBox_model.Text, (byte)numUpDown_calibre.Value, float.Parse(txtBox_a.Text), float.Parse(txtBox_b.Text), id);
                    IsSendToServer = result;
                    if (result == true)
                    {
                        Tableau = new string[]
                        {
                            id.ToString(),configIni.ipArduino,txtBox_name.Text,txtBox_marque.Text,txtBox_model.Text,numUpDown_calibre.Value.ToString(),txtBox_a.Text,txtBox_b.Text
                        };
                    }
                }
                else
                {
                    bool result = BDD.RequeteInsertCapteur(txtBox_name.Text, configIni.ipArduino, txtBox_marque.Text, txtBox_model.Text, (byte)numUpDown_calibre.Value, float.Parse(txtBox_a.Text), float.Parse(txtBox_b.Text));
                    if (result == true)
                    {
                        //On envoi la ligne dans le tableau si on a reussi
                        Tableau = new string[]
                        {
                            txtBox_name.Text,txtBox_marque.Text,txtBox_model.Text,numUpDown_calibre.Value.ToString(),txtBox_a.Text,txtBox_b.Text
                        };
                    }
                }
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez rentrer une valeur correcte pour tous les champs !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBox_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
                return;

            if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^.]"))
            {
                e.Handled = true;
            }
        }

        private void txtBox_b_KeyPress(object sender, KeyPressEventArgs e)
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
