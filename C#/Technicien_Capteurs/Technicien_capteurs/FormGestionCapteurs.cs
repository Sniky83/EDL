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

            if (capteurList.Count == 0)
            {
                btn_delete.Enabled = false;
                btn_modifier.Enabled = false;
                MessageBox.Show("Aucun capteur n'est présent dans la liste, vous pouvez en ajouter un !", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            tab_listeCapteurs.DataSource = capteurList;

            tab_listeCapteurs.Columns[3].HeaderText = "Modèle";

            tab_listeCapteurs.Columns[0].Visible = false;

            tab_listeCapteurs.Columns[2].Width = 140;
            tab_listeCapteurs.Columns[4].Width = 60;
            tab_listeCapteurs.Columns[5].Width = 55;
            tab_listeCapteurs.Columns[6].Width = 55;
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
            FormAjoutCapteur fAddCpt = new FormAjoutCapteur(confIni,false);

            fAddCpt.ShowDialog();
            if (fAddCpt.IsSendToServer == true)
            {
                var rdr = BDD.RequeteSelectLastIdCapteurs();

                string stockage = "";
                while (rdr.Read())
                {
                    stockage = rdr[0].ToString();
                }
                if (stockage == "")
                {
                    stockage = "1";
                }
                rdr.Close();
                BDD.connection.Close();
                
                C_Capteur capteurToAdd = new C_Capteur();
                capteurToAdd.Id = ushort.Parse(stockage);
                capteurToAdd.Nom = fAddCpt.Tableau[0];
                capteurToAdd.Marque = fAddCpt.Tableau[1];
                capteurToAdd.Model = fAddCpt.Tableau[2];
                capteurToAdd.Calibre = byte.Parse(fAddCpt.Tableau[3]);
                capteurToAdd.A = fAddCpt.Tableau[4];
                capteurToAdd.B = fAddCpt.Tableau[5];
                capteurList.Add(capteurToAdd);
            }
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            FormAjoutCapteur fAddCpt = new FormAjoutCapteur(confIni,true);

            //Pré-rempli les champs
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
                //Modif d'un capteur et refresh
                capteurList[indexCapteur].Id = fAddCpt.id;
                capteurList[indexCapteur].Nom = fAddCpt.Tableau[0];
                capteurList[indexCapteur].Marque = fAddCpt.Tableau[1];
                capteurList[indexCapteur].Model = fAddCpt.Tableau[2];
                capteurList[indexCapteur].Calibre = byte.Parse(fAddCpt.Tableau[3]);
                capteurList[indexCapteur].A = fAddCpt.Tableau[4];
                capteurList[indexCapteur].B = fAddCpt.Tableau[5];
                tab_listeCapteurs.Refresh();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer ce capteur ?", "Suppression", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ushort id = ushort.Parse(tab_listeCapteurs.Rows[indexCapteur].Cells[0].Value.ToString());
                bool result = BDD.RequeteDeleteCapteur(id);
                BDD.RequeteDeleteEntreeFromGestionCapteurs(id);
                if (result == true)
                {
                    capteurList.RemoveAt(indexCapteur);
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

        private void Btn_aide_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"http://{confIni.ip}/EDL/index.php?rubrique=3");
        }
    }
}
