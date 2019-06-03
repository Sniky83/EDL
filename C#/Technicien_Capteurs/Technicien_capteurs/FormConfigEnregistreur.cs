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
    public partial class FormConfigEnregistreur : Form
    {
        private C_BDD BDD;

        private C_Config confIni;

        private BindingList<C_Entree> entreeList = new BindingList<C_Entree>();

        private BindingList<C_Capteur> capteurList = new BindingList<C_Capteur>();

        private byte indexCapteur;

        public FormConfigEnregistreur(C_Config configIni, BindingList<C_Entree> entrList, BindingList<C_Capteur> cptList)
        {
            InitializeComponent();

            capteurList = cptList;

            entreeList = entrList;

            confIni = configIni;

            BDD = new C_BDD(configIni.ip, configIni.dbn, configIni.username, configIni.password);

            if (entreeList.Count == 0)
            {
                MessageBox.Show("Aucune entrée n'est présent dans la liste, vous pouvez en ajouter un !", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            tab_listeEnr.DataSource = entreeList;
            tab_listeEnr.Columns[1].HeaderText = "Entrée";
            tab_listeEnr.Columns[2].HeaderText = "Nom Entrée";
            tab_listeEnr.Columns[3].HeaderText = "Nom Capteur";

            tab_listeEnr.Columns[0].Visible = false;
            for(byte i=4;i<7;i++)
            {
                tab_listeEnr.Columns[i].Visible = false;
            }

            tab_listeEnr.Columns[1].Width = 50;
            for (byte i = 2; i < 4; i++)
            {
                tab_listeEnr.Columns[i].Width = 150;
            }
        }

        private void tab_listeEnr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tab_listeEnr.CurrentRow.Selected = true;
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
            /*byte Length = (byte)entreeList.Count;
            id = new byte[Length];
            for (byte i = 0; i < Length;i++)
            {
                id[i] = (byte)entreeList[i].Id;
            }*/
            FormAjoutEntrees fAEnt = new FormAjoutEntrees(confIni,false,capteurList);

            fAEnt.ShowDialog();
            if(fAEnt.IsSendToServer == true)
            {
                var rdr = BDD.RequeteSelectLastIdEntrees();

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

                C_Entree entreeToAdd = new C_Entree();
                entreeToAdd.Id = ushort.Parse(stockage);
                entreeToAdd.Entree = byte.Parse(fAEnt.Tableau[0]);
                entreeToAdd.Nom_Entree = fAEnt.Tableau[1];
                entreeToAdd.Nom_Capteur = fAEnt.Tableau[2];
                entreeToAdd.Index_Capteur = fAEnt.index;
                entreeList.Add(entreeToAdd);
            }
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            FormAjoutEntrees fAEnt = new FormAjoutEntrees(confIni,true,capteurList);

            fAEnt.id = entreeList[indexCapteur].Id;
            fAEnt.cmbBox_input.SelectedIndex = entreeList[indexCapteur].Entree-1;
            fAEnt.cmbBox_capteur.SelectedIndex = entreeList[indexCapteur].Index_Capteur;
            fAEnt.txtBox_nom_entree.Text = entreeList[indexCapteur].Nom_Entree;

            fAEnt.ShowDialog();
            if(fAEnt.IsSendToServer == true)
            {
                entreeList[indexCapteur].Id = fAEnt.id;
                entreeList[indexCapteur].Entree = byte.Parse(fAEnt.Tableau[0]);
                entreeList[indexCapteur].Nom_Capteur = fAEnt.Tableau[1];
                entreeList[indexCapteur].Nom_Entree = fAEnt.Tableau[2];
                entreeList[indexCapteur].Index_Capteur = fAEnt.index;
                tab_listeEnr.Refresh();
            }

            if(capteurList.Count == 0)
            {
                btn_add.Enabled = false;
            }
            else
            {
                btn_add.Enabled = true;
            }
        }

        private void tab_listeEnr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tab_listeEnr.CurrentRow.Selected = true;
                indexCapteur = (byte)e.RowIndex;
                btn_modifier.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez vous vraiment supprimer cette entrée ?", "Suppression", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ushort id = ushort.Parse(tab_listeEnr.Rows[indexCapteur].Cells[0].Value.ToString());
                bool result = BDD.RequeteDeleteEntree(id);
                if (result == true)
                {
                    entreeList.RemoveAt(indexCapteur);
                }
            }
            btn_delete.Enabled = false;
            btn_modifier.Enabled = false;
        }
    }
}
