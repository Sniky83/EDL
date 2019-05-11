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
    public partial class FormAjoutCapteur : Form
    {
        C_BDD BDD;

        private FormGestionCapteurs fGest;

        public FormAjoutCapteur(FormGestionCapteurs fGest)
        {
            InitializeComponent();
            this.fGest = fGest;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            FormConfigReseau fConfRes = new FormConfigReseau();

            BDD = new C_BDD(fConfRes.txtBox_ip, fConfRes.txtBox_dbn, fConfRes.txtBox_username, fConfRes.txtBox_password);
            if (txtBox_name.Text != "" && txtBox_marque.Text != "" && txtBox_model.Text != "" && numUpDown_calibre.Value != 0 && txtBox_a.Text != "" && txtBox_b.Text != "")
            {
                bool result = BDD.RequeteInsertCapteur(txtBox_name, txtBox_marque, txtBox_model, numUpDown_calibre, txtBox_a, txtBox_b);
                if(result == true)
                {
                    //On envoi la ligne dans le tableau si on a reussi
                    FormGestionCapteurs fGestCapt = new FormGestionCapteurs();
                    DataGridViewRow row = (DataGridViewRow)fGestCapt.tab_listeCapteurs.Rows[0].Clone();
                    row.Cells[0].Value = txtBox_name.Text;
                    row.Cells[1].Value = txtBox_marque.Text;
                    row.Cells[2].Value = txtBox_model.Text;
                    row.Cells[3].Value = numUpDown_calibre.Value;
                    row.Cells[4].Value = txtBox_a.Text;
                    row.Cells[5].Value = txtBox_b.Text;
                    fGest.tab_listeCapteurs.Rows.Add(row);
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
            if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^,]"))
            {
                e.Handled = true;
            }
        }

        private void txtBox_b_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^,]"))
            {
                e.Handled = true;
            }
        }
    }
}
