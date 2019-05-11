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
        C_BDD BDD;

        //FormGestionCapteurs fGest;

        FormConfigReseau fConfRes;

        /*public Thread thread2 = null;

        public delegate void sentIt(string dataToSend);
        public event callback_data sentIt;

        public DataGridViewRow newrow;*/

        //public DialogResult;

        private string[] Tableau;
        public bool IsSendToServer { get; set; } = false;

        //private bool Res;

        public FormAjoutCapteur(FormConfigReseau fConfRes/*, FormGestionCapteurs fGest DataGridViewRow newRow*/)
        {
            InitializeComponent();

            /*fGest = new FormGestionCapteurs(fConfRes, this);

            FormAjoutCapteur current = this;

            current.fGest = fGest;*/

            //newrow = newRow;

            this.fConfRes = fConfRes;

            //this.fGest = fGest;

            BDD = new C_BDD(fConfRes.txtBox_ip, fConfRes.txtBox_dbn, fConfRes.txtBox_username, fConfRes.txtBox_password);

            //this.fGest = new FormGestionCapteurs(fConfRes, this);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void btn_ok_Click(object sender, EventArgs e)
        {
            if (txtBox_name.Text != "" && txtBox_marque.Text != "" && txtBox_model.Text != "" && numUpDown_calibre.Value != 0 && txtBox_a.Text != "" && txtBox_b.Text != "")
            {
                if (lbl_id.Text != "")
                {
                    bool result = BDD.RequeteUpdateCapteur(txtBox_name, txtBox_marque, txtBox_model, numUpDown_calibre, txtBox_a, txtBox_b, lbl_id);
                    IsSendToServer = result;
                    if (result == true)
                    {
                        Tableau = new string[]
                        {
                            txtBox_name.Text,txtBox_marque.Text,txtBox_model.Text,numUpDown_calibre.Value.ToString(),txtBox_a.Text,txtBox_b.Text
                        };
                        InfosCap = Tableau;
                    }
                }
                else
                {
                    bool result = BDD.RequeteInsertCapteur(txtBox_name, txtBox_marque, txtBox_model, numUpDown_calibre, txtBox_a, txtBox_b);
                    IsSendToServer = result;
                    if (result == true)
                    {
                        //On envoi la ligne dans le tableau si on a reussi
                        Tableau = new string[]
                        {
                            txtBox_name.Text,txtBox_marque.Text,txtBox_model.Text,numUpDown_calibre.Value.ToString(),txtBox_a.Text,txtBox_b.Text
                        };
                        InfosCap = Tableau;
                        /*thread2 = new Thread(new ThreadStart(SetText));
                        thread2.Start();
                        Thread.Sleep(1000);*/

                        /*DataGridViewRow row = (DataGridViewRow)fGest.tab_listeCapteurs.Rows[0].Clone();
                        row.Cells[0].Value = txtBox_name.Text;
                        row.Cells[1].Value = txtBox_marque.Text;
                        row.Cells[2].Value = txtBox_model.Text;
                        row.Cells[3].Value = numUpDown_calibre.Value;
                        row.Cells[4].Value = txtBox_a.Text;
                        row.Cells[5].Value = txtBox_b.Text;
                        fGest.tab_listeCapteurs.Rows.Add(row);*/
                        //DialogResult = DialogResult.OK;
                    }
                    //Res = true;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez rentrer une valeur correcte pour tous les champs !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Res = false;
            }
        }

        /*public bool ResInsert
        {
            get { return Res; }
            set { Res = value; }
        }*/

        public string[] InfosCap
        {
            get { return Tableau; }
            set { Tableau = value; }
        }

        /*public void SetText()
        {
            string test = "testeux";
            WriteTextSafe(test);
        }
        public void WriteTextSafe(string data)
        {
            var d = new sentIt(WriteTextSafe);
            Invoke(d, new object[] { data });
        }*/

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
