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
    public partial class FormGestionCapteurs : Form
    {
        private C_Config confIni;

        private C_BDD BDD;

        private BindingList<C_Capteur> capteurList;

        private byte indexCapteur;

        public FormGestionCapteurs(C_Config configIni, BindingList<C_Capteur> cptList)
        {
            InitializeComponent();

            confIni = configIni;

            capteurList = cptList;

            BDD = new C_BDD(confIni.ip, confIni.dbn, confIni.username, confIni.password);

            //var rdr = BDD.RequeteSelectCapteurs();

            //if (rdr != null)
            //{
            //    short j = 0;
            //    string stockage = "";
            //    while (rdr.Read())
            //    {
            //        DataGridViewRow row = (DataGridViewRow)tab_listeCapteurs.Rows[j].Clone();
            //        for (short i = 0; i < 7; i++)
            //        {
            //            stockage = rdr[i].ToString();
            //            row.Cells[i].Value = stockage;
            //        }
            //        if (stockage == "")
            //        {
            //            btn_delete.Enabled = false;
            //            btn_modifier.Enabled = false;
            //            tab_listeCapteurs.AllowUserToAddRows = false;
            //            MessageBox.Show("Aucun capteur n'est présent dans la liste, vous pouvez en ajouter un !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else
            //        {
            //            tab_listeCapteurs.Rows.Add(row);
            //            j++;
            //        }
            //    }
            //    tab_listeCapteurs.AllowUserToAddRows = false;
            //    rdr.Close();
            //    BDD.connection.Close();
            //}

            if (capteurList.Count == 0)
            {
                btn_delete.Enabled = false;
                btn_modifier.Enabled = false;
                MessageBox.Show("Aucun capteur n'est présent dans la liste, vous pouvez en ajouter un !", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                /*C_Capteur capteurToAdd = new C_Capteur();
                capteurToAdd.A;
                capteurToAdd.B;
                capteurToAdd.Calibre;
                capteurToAdd.*/
            }

            tab_listeCapteurs.DataSource = capteurList;
            tab_listeCapteurs.Columns[4].HeaderText = "Modèle";

            for (byte i = 0; i < 2; i++)
            {
                tab_listeCapteurs.Columns[i].Visible = false;
            }

            for (byte i = 6; i < 8; i++)
            {
                tab_listeCapteurs.Columns[i].Width = 60;
            }

            tab_listeCapteurs.Columns[2].Width = 140;
            tab_listeCapteurs.Columns[5].Width = 50;
        }

        private void tab_listeCapteurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tab_listeCapteurs.CurrentRow.Selected = true;
                indexCapteur = (byte)e.RowIndex;
                btn_modifier.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            FormAjoutCapteur fAddCpt = new FormAjoutCapteur(confIni);
            if (fAddCpt.txtBox_name.Text != "")
            {
                fAddCpt.txtBox_name.Text = "";
                fAddCpt.txtBox_marque.Text = "";
                fAddCpt.txtBox_model.Text = "";
                fAddCpt.numUpDown_calibre.Value = 0;
                fAddCpt.txtBox_a.Text = "";
                fAddCpt.txtBox_b.Text = "";
            }

            fAddCpt.ShowDialog();

            var rdr = BDD.RequeteSelectLastIdCapteur();

            string stockage = "";
            while (rdr.Read())
            {
                stockage = rdr[0].ToString();
            }
            if(stockage == "")
            {
                stockage = "1";
            }
            rdr.Close();
            BDD.connection.Close();

            C_Capteur capteurToAdd = new C_Capteur();
            capteurToAdd.Id = ushort.Parse(stockage);
            capteurToAdd.IpArduino = confIni.ipArduino;
            capteurToAdd.Nom = fAddCpt.Tableau[0];
            capteurToAdd.Marque = fAddCpt.Tableau[1];
            capteurToAdd.Model = fAddCpt.Tableau[2];
            capteurToAdd.Calibre = byte.Parse(fAddCpt.Tableau[3]);
            capteurToAdd.A = float.Parse(fAddCpt.Tableau[4]);
            capteurToAdd.B = float.Parse(fAddCpt.Tableau[5]);

            capteurList.Add(capteurToAdd);

            /*DataGridViewRow row = (DataGridViewRow)tab_listeCapteurs.Rows[0].Clone();

            row.Cells[0].Value = stockage;
            int i;
            for (i = 0; i < 8; i++)
            {
                row.Cells[i].Value = fAddCpt.Tableau[i];
            }
            tab_listeCapteurs.Rows.Add(row);*/
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            FormAjoutCapteur fAddCpt = new FormAjoutCapteur(confIni);
            /*string[,] Datavalue = new string[tab_listeCapteurs.Rows.Count, tab_listeCapteurs.Columns.Count];
            foreach (DataGridViewRow row in tab_listeCapteurs.SelectedRows)
            {
                foreach (DataGridViewColumn col in tab_listeCapteurs.Columns)
                {
                    Datavalue[row.Index, col.Index] = tab_listeCapteurs.Rows[row.Index].Cells[col.Index].Value.ToString();
                }
                fAddCpt.numUpDown_id.Value = UInt16.Parse(Datavalue[row.Index, 0]);
                fAddCpt.lbl_ipArduino.Text = "a";
                fAddCpt.txtBox_name.Text = Datavalue[row.Index, 1];
                fAddCpt.txtBox_marque.Text = Datavalue[row.Index, 2];
                fAddCpt.txtBox_model.Text = Datavalue[row.Index, 3];
                fAddCpt.numUpDown_calibre.Value = UInt16.Parse(Datavalue[row.Index, 4]);
                fAddCpt.txtBox_a.Text = Datavalue[row.Index, 5];
                fAddCpt.txtBox_b.Text = Datavalue[row.Index, 6];
            }*/
            //fAddCpt.numUpDown_id.Value = UInt16.Parse(tab_listeCapteurs.Rows[IndexCapteur].Cells[0].Value.ToString());
            //fAddCpt.lbl_ipArduino.Text = tab_listeCapteurs.Rows[IndexCapteur].Cells[1].Value.ToString();
            //fAddCpt.ipArduino = tab_listeCapteurs.Rows[IndexCapteur].Cells[1].Value.ToString();

            fAddCpt.id = capteurList[indexCapteur].Id;
            fAddCpt.txtBox_name.Text = capteurList[indexCapteur].Nom;
            fAddCpt.txtBox_marque.Text = capteurList[indexCapteur].Marque;
            fAddCpt.txtBox_model.Text = capteurList[indexCapteur].Model;
            fAddCpt.numUpDown_calibre.Value = capteurList[indexCapteur].Calibre;
            fAddCpt.txtBox_a.Text = capteurList[indexCapteur].A.ToString();
            fAddCpt.txtBox_b.Text = capteurList[indexCapteur].B.ToString();

            fAddCpt.ShowDialog();

            if (fAddCpt.IsSendToServer == true)
            {
                if (indexCapteur >= 0)
                {
                    capteurList[indexCapteur].Id = ushort.Parse(fAddCpt.Tableau[0]);
                    capteurList[indexCapteur].Nom = fAddCpt.Tableau[2];
                    capteurList[indexCapteur].Marque = fAddCpt.Tableau[3];
                    capteurList[indexCapteur].Model = fAddCpt.Tableau[4];
                    capteurList[indexCapteur].Calibre = byte.Parse(fAddCpt.Tableau[5]);
                    capteurList[indexCapteur].A = ushort.Parse(fAddCpt.Tableau[6]);
                    capteurList[indexCapteur].B = ushort.Parse(fAddCpt.Tableau[7]);
                    tab_listeCapteurs.Refresh();
                }
            }

            /*//Ancien code
            if (fAddCpt.IsSendToServer == true)
            {
                var row = tab_listeCapteurs.SelectedRows;
                if (row.Count >= 0)
                {
                    for (byte i = 0; i < 8; i++)
                    {
                        if (i == 1)
                        {
                            i++;
                        }
                        row[0].Cells[i].Value = fAddCpt.Tableau[i];
                    }
                }
            }*/
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer ce capteur ?", "Suppression", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                /*string[,] Datavalue = new string[tab_listeCapteurs.Rows.Count, tab_listeCapteurs.Columns.Count];
                foreach (DataGridViewRow row in tab_listeCapteurs.SelectedRows)
                {
                    foreach (DataGridViewColumn col in tab_listeCapteurs.Columns)
                    {
                        Datavalue[row.Index, col.Index] = tab_listeCapteurs.Rows[row.Index].Cells[col.Index].Value.ToString();
                    }

                }*/

                ushort id = ushort.Parse(tab_listeCapteurs.Rows[indexCapteur].Cells[0].Value.ToString());
                bool result = BDD.RequeteDeleteCapteur(id);
                if (result == true)
                {
                    capteurList.RemoveAt(indexCapteur);
                    //tab_listeCapteurs.Rows.RemoveAt(IndexCapteur);
                    //tab_listeCapteurs.Refresh();
                    //CapteurList.Remove(capteurToAdd);
                    //tab_listeCapteurs.Rows.RemoveAt(IndexCapteur);
                }
            }
            btn_delete.Enabled = false;
            btn_modifier.Enabled = false;
        }

        private void tab_listeCapteurs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tab_listeCapteurs.CurrentRow.Selected = true;
                btn_modifier.Enabled = true;
                btn_delete.Enabled = true;
            }
        }
    }
}
