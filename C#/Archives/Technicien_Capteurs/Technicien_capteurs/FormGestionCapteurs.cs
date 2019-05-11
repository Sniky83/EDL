using MySql.Data.MySqlClient;
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
        C_BDD BDD;

        //FormAjoutCapteur fAddCpt;

        FormConfigReseau fConfRes;

        public List<Capteur> CapteurList { get; set; } = new List<Capteur>();

        public FormGestionCapteurs(FormConfigReseau fConfRes)
        {
            InitializeComponent();

            //tab_listeCapteurs.DataSource = CapteurList;

            /*FormAjoutCapteur form2 = new FormAjoutCapteur(fConfRes,(DataGridViewRow)tab_listeCapteurs.Rows[0].Clone());

            var res = form2.ShowDialog();
            if (res != DialogResult.OK)
                return;

            tab_listeCapteurs.Rows.Add(form2.newrow);*/

            //Timer.Enabled = true;

            this.fConfRes = fConfRes;

            //this.fAddCpt = fAddCpt;

            BDD = new C_BDD(fConfRes.txtBox_ip, fConfRes.txtBox_dbn, fConfRes.txtBox_username, fConfRes.txtBox_password);

            /*string[,] Liste = BDD.RequeteSelectCapteur();

            int sizeOfListe = Liste.GetLength(0);

            if (sizeOfListe != 0)
            {
                short ligne = 0;

                while (sizeOfListe != ligne)
                {
                    DataGridViewRow row = (DataGridViewRow)tab_listeCapteurs.Rows[ligne].Clone();
                    row.Cells[0].Value = Liste[ligne, 0];
                    row.Cells[1].Value = Liste[ligne, 1];
                    row.Cells[2].Value = Liste[ligne, 2];
                    row.Cells[3].Value = Liste[ligne, 3];
                    row.Cells[4].Value = Liste[ligne, 4];
                    row.Cells[5].Value = Liste[ligne, 5];
                    tab_listeCapteurs.Rows.Add(row);
                    ligne++;
                }
                tab_listeCapteurs.AllowUserToAddRows = false;
            }
            else
            {
                btn_delete.Enabled = false;
                btn_modifier.Enabled = false;
                tab_listeCapteurs.AllowUserToAddRows = false;
                MessageBox.Show("Aucun capteur n'est présent dans la liste, vous pouvez en ajouter un !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/

            MySqlDataReader rdr = BDD.RequeteSelectCapteurs();
            short j = 0;
            string stockage = "";
            while (rdr.Read())
            {
                DataGridViewRow row = (DataGridViewRow)tab_listeCapteurs.Rows[j].Clone();
                for (short i = 0; i < 7; i++)
                {
                    stockage = rdr[i].ToString();
                    row.Cells[i].Value = stockage;
                }
                if (stockage == "")
                {
                    btn_delete.Enabled = false;
                    btn_modifier.Enabled = false;
                    tab_listeCapteurs.AllowUserToAddRows = false;
                    MessageBox.Show("Aucun capteur n'est présent dans la liste, vous pouvez en ajouter un !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    tab_listeCapteurs.Rows.Add(row);
                    j++;
                }
            }
            tab_listeCapteurs.AllowUserToAddRows = false;
            rdr.Close();
            BDD.connection.Close();

            ///*MySqlDataReader rdr = BDD.RequeteSelectCapteurs();
            //short j = 0;
            //string stockage = "";
            //while (rdr.Read())
            //{
            //    //DataGridViewRow row = (DataGridViewRow)tab_listeCapteurs.Rows[j].Clone();
            //    Capteur capteurToAdd = new Capteur();
            //    for (short i = 0; i < 7; i++)
            //    {
            //        stockage = rdr[i].ToString();
            //        //row.Cells[i].Value = stockage;
            //        switch (i)
            //        {
            //            case 0:
            //                capteurToAdd.Id = int.Parse(stockage);
            //                break;
            //            case 1:
            //                capteurToAdd.Nom = stockage;
            //                break;
            //            case 2:
            //                capteurToAdd.Marque = stockage;
            //                break;
            //            case 3:
            //                capteurToAdd.Modele = stockage;
            //                break;
            //            case 4:
            //                capteurToAdd.Calibre = int.Parse(stockage);
            //                break;
            //            case 5:
            //                capteurToAdd.A = float.Parse(stockage);
            //                break;
            //            case 6:
            //                capteurToAdd.B = float.Parse(stockage);
            //                break;
            //            default:

            //                break;
            //        }
            //    }
            //    if(capteurToAdd.Id != -1)
            //        CapteurList.Add(capteurToAdd);
            //    if (CapteurList.Count == 0)
            //    {
            //        btn_delete.Enabled = false;
            //        btn_modifier.Enabled = false;
            //        tab_listeCapteurs.AllowUserToAddRows = false;
            //        MessageBox.Show("Aucun capteur n'est présent dans la liste, vous pouvez en ajouter un !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //tab_listeCapteurs.DataSource = CapteurList;
            //tab_listeCapteurs.Refresh();*/
            //tab_listeCapteurs.AllowUserToAddRows = false;
            //rdr.Close();
            //BDD.connection.Close();
        }

            /*public void onReceiveData(string myData)
            {
                Console.WriteLine(myData[1]+"----ICI");
            }
            public FormGestionCapteurs()
            {
                InitializeComponent();
            }*/

            private void tab_listeCapteurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tab_listeCapteurs.CurrentRow.Selected = true;
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
            FormAjoutCapteur fAddCpt = new FormAjoutCapteur(fConfRes);
            if (fAddCpt.txtBox_name.Text != "")
            {
                fAddCpt.txtBox_name.Text = "";
                fAddCpt.txtBox_marque.Text = "";
                fAddCpt.txtBox_model.Text = "";
                fAddCpt.numUpDown_calibre.Value = 0;
                fAddCpt.txtBox_a.Text = "";
                fAddCpt.txtBox_b.Text = "";
            }
            //Timer.Enabled = true;

            fAddCpt.ShowDialog();
            if (fAddCpt.IsSendToServer == true)
            {
                DataGridViewRow row = (DataGridViewRow)tab_listeCapteurs.Rows[0].Clone();
                row.Cells[1].Value = fAddCpt.InfosCap[0];
                row.Cells[2].Value = fAddCpt.InfosCap[1];
                row.Cells[3].Value = fAddCpt.InfosCap[2];
                row.Cells[4].Value = fAddCpt.InfosCap[3];
                row.Cells[5].Value = fAddCpt.InfosCap[4];
                row.Cells[6].Value = fAddCpt.InfosCap[5];
                tab_listeCapteurs.Rows.Add(row);
            }
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            FormAjoutCapteur fAddCpt = new FormAjoutCapteur(fConfRes);
            string[,] Datavalue = new string[tab_listeCapteurs.Rows.Count, tab_listeCapteurs.Columns.Count];
            foreach (DataGridViewRow row in tab_listeCapteurs.SelectedRows)
            {
                foreach (DataGridViewColumn col in tab_listeCapteurs.Columns)
                {
                    Datavalue[row.Index, col.Index] = tab_listeCapteurs.Rows[row.Index].Cells[col.Index].Value.ToString();
                }
                fAddCpt.lbl_id.Text = Datavalue[row.Index, 0];
                fAddCpt.txtBox_name.Text = Datavalue[row.Index, 1];
                fAddCpt.txtBox_marque.Text = Datavalue[row.Index, 2];
                fAddCpt.txtBox_model.Text = Datavalue[row.Index, 3];
                fAddCpt.numUpDown_calibre.Value = Int16.Parse(Datavalue[row.Index, 4]);
                fAddCpt.txtBox_a.Text = Datavalue[row.Index, 5];
                fAddCpt.txtBox_b.Text = Datavalue[row.Index, 6];
            }
            btn_modifier.Enabled = false;
            //Timer.Enabled = true;
            fAddCpt.ShowDialog();
            if (fAddCpt.IsSendToServer == true)
            {
                var rowToModify = tab_listeCapteurs.SelectedRows;
                if (rowToModify.Count > 0)
                {
                    rowToModify[0].Cells[1].Value = fAddCpt.InfosCap[0];
                    rowToModify[0].Cells[2].Value = fAddCpt.InfosCap[1];
                    rowToModify[0].Cells[3].Value = fAddCpt.InfosCap[2];
                    rowToModify[0].Cells[4].Value = fAddCpt.InfosCap[3];
                    rowToModify[0].Cells[5].Value = fAddCpt.InfosCap[4];
                    rowToModify[0].Cells[6].Value = fAddCpt.InfosCap[5];
                }
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer ce capteur ?", "Suppression", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string[,] Datavalue = new string[tab_listeCapteurs.Rows.Count, tab_listeCapteurs.Columns.Count];
                foreach (DataGridViewRow row in tab_listeCapteurs.SelectedRows)
                {
                    foreach (DataGridViewColumn col in tab_listeCapteurs.Columns)
                    {
                        Datavalue[row.Index, col.Index] = tab_listeCapteurs.Rows[row.Index].Cells[col.Index].Value.ToString();
                    }
                    bool result = BDD.RequeteDeleteCapteur(Datavalue[row.Index, 1], Datavalue[row.Index, 2], Datavalue[row.Index, 3]);
                    if(result == true)
                    {
                        tab_listeCapteurs.Rows.RemoveAt(row.Index);
                    }
                }
            }
            btn_delete.Enabled = false;
            btn_modifier.Enabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //bool resInsert = fAddCpt.ResInsert;
            //bool resUpdate = fAddCpt.ResUpdate;

            /*if(resInsert == true)
            {
                //On insert la row (Ajout)
                DataGridViewRow row = (DataGridViewRow)tab_listeCapteurs.Rows[0].Clone();
                row.Cells[0].Value = fAddCpt.InfosCap[0];
                row.Cells[1].Value = fAddCpt.InfosCap[1];
                row.Cells[2].Value = fAddCpt.InfosCap[2];
                row.Cells[3].Value = fAddCpt.InfosCap[3];
                row.Cells[4].Value = fAddCpt.InfosCap[4];
                row.Cells[5].Value = fAddCpt.InfosCap[5];
                tab_listeCapteurs.Rows.Add(row);
                Timer.Enabled = false;
            }*/

            /*if(resUpdate == true)
            {
                //On update la row (Modif)
                Timer.Enabled = false;
            }*/

            //if (fAddCpt.DialogResult == DialogResult.OK && fAddCpt.lbl_id.Text == "")
            //{
            //    //DataGridViewRow row = (DataGridViewRow)tab_listeCapteurs.Rows[0].Clone();
            //    //row.Cells[1].Value = fAddCpt.InfosCap[0];
            //    //row.Cells[2].Value = fAddCpt.InfosCap[1];
            //    //row.Cells[3].Value = fAddCpt.InfosCap[2];
            //    //row.Cells[4].Value = fAddCpt.InfosCap[3];
            //    //row.Cells[5].Value = fAddCpt.InfosCap[4];
            //    //row.Cells[6].Value = fAddCpt.InfosCap[5];
            //    //tab_listeCapteurs.Rows.Add(row);
            //    //Timer.Enabled = false;
            //}
            //else
            //{
            //    //DataGridViewRow newDataRow = tab_listeCapteurs.Rows[indexRow];
            //    //foreach (DataGridViewRow row in tab_listeCapteurs.SelectedRows)
            //    //{
            //    //    if (row.Rows == 10)
            //    //    {

            //    //    }
            //    //    foreach (DataRow dr in tab_listeCapteurs.Rows) // search whole table
            //    //    {
            //    //        if (dr["id"] == 10) // if id==2
            //    //        {
            //    //            dr["Product_name"] = "cde";
            //    //        }
            //    //    }
            //    //}
            //}
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
