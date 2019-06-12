using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
                btn_Envoi_Config.Enabled = false;
            }
            else
            {
                btn_Envoi_Config.Enabled = true;
            }

            tab_listeEnr.DataSource = entreeList;
            tab_listeEnr.Columns[1].HeaderText = "Entrée";
            tab_listeEnr.Columns[2].HeaderText = "Nom Entrée";
            tab_listeEnr.Columns[3].HeaderText = "Nom Capteur";

            tab_listeEnr.Columns[0].Visible = false;
            for(byte i=4;i<6;i++)
            {
                tab_listeEnr.Columns[i].Visible = false;
            }

            tab_listeEnr.Columns[1].Width = 50;
            for (byte i = 2; i < 4; i++)
            {
                tab_listeEnr.Columns[i].Width = 150;
            }

            for (byte i = 0; i < entreeList.Count; i++)
            {
                var Join = capteurList.Where(item => item.Id == entreeList[i].Capteur.Id);
                if(Join.Any() == false)
                {
                    entreeList.RemoveAt(i);
                }
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
            FormAjoutEntrees fAEnt = new FormAjoutEntrees(confIni,false,capteurList,entreeList);

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
                entreeToAdd.Capteur = capteurList.First(x => x.Nom == fAEnt.Tableau[2]);
                entreeList.Add(entreeToAdd);

                btn_Envoi_Config.Enabled = true;
            }
            else
            {
                btn_Envoi_Config.Enabled = false;
            }
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            FormAjoutEntrees fAEnt = new FormAjoutEntrees(confIni,true,capteurList,entreeList);
            fAEnt.cmbBox_input.Items.Add(entreeList[indexCapteur].Entree);
            fAEnt.id = entreeList[indexCapteur].Id;
            fAEnt.cmbBox_input.SelectedIndex = fAEnt.cmbBox_input.FindStringExact(entreeList[indexCapteur].Entree.ToString());
            fAEnt.cmbBox_capteur.SelectedIndex = fAEnt.cmbBox_capteur.FindStringExact(entreeList[indexCapteur].Capteur.Nom);
            fAEnt.txtBox_nom_entree.Text = entreeList[indexCapteur].Nom_Entree;

            fAEnt.ShowDialog();
            if(fAEnt.IsSendToServer == true)
            {
                entreeList[indexCapteur].Id = fAEnt.id;
                entreeList[indexCapteur].Entree = byte.Parse(fAEnt.Tableau[0]);
                entreeList[indexCapteur].Capteur.Nom = fAEnt.Tableau[1];
                entreeList[indexCapteur].Nom_Entree = fAEnt.Tableau[2];
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
            if(entreeList.Count == 0)
            {
                btn_Envoi_Config.Enabled = false;
            }
            else
            {
                btn_Envoi_Config.Enabled = true;
            }
            btn_delete.Enabled = false;
            btn_modifier.Enabled = false;
        }

        private void Btn_aide_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start($"http://{confIni.ip}/EDL/index.php?rubrique=4");
        }

        private void Btn_Envoi_Config_Click(object sender, EventArgs e)
        {
            C_EDL_Recorder Recorder = new C_EDL_Recorder(confIni.ipArduino);
            for (byte i = 0; i < entreeList.Count; i++)
            {
                var Join = entreeList[i].Capteur;
                var A = Join.A;
                var B = Join.B;
                ushort id = entreeList[i].Id;
                string Composition = $"EDL_TECH_SET_CONF_EDL_L{entreeList[i].Entree}_A_{A}_B_{B}_ID_{id}?";
                bool IsSendToArduino = Recorder.EnvoiConfiguration(Composition);
                if (IsSendToArduino == true && i < entreeList.Count - 1)
                {
                    Thread.Sleep(2000);//on sleep pour laisser le temps à l'arduino de répondre
                }
                else
                {
                    i = (byte)entreeList.Count;
                }
            }
        }
    }
}
