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

        private byte[] id;

        private C_Config confIni;

        private BindingList<C_Entree> entreeList { get; set; } = new BindingList<C_Entree>();

        private C_Entree entreeToAdd;

        //private byte indexCapteur;

        public FormConfigEnregistreur(C_Config configIni)
        {
            InitializeComponent();

            confIni = configIni;

            BDD = new C_BDD(confIni.ip, confIni.dbn, confIni.username, confIni.password);

            var rdr = BDD.RequeteSelectEntrees(confIni.ipArduino);
            string stockage = "";
            while (rdr.Read())
            {
                entreeToAdd = new C_Entree();
                for (byte i = 0; i < 4; i++)
                {
                    stockage = rdr[i].ToString();
                    switch (i)
                    {
                        case 0:
                            entreeToAdd.Id = ushort.Parse(stockage);
                            break;
                        case 1:
                            entreeToAdd.Nom_Capteur = stockage;
                            break;
                        case 2:
                            entreeToAdd.Entree = byte.Parse(stockage);
                            break;
                        case 3:
                            entreeToAdd.Nom_Entree = stockage;
                            break;
                        default:

                            break;
                    }
                }
                if (entreeToAdd.Entree != 0)
                {
                    entreeList.Add(entreeToAdd);
                    entreeToAdd.IpArduino = confIni.ipArduino;
                }
            }

            if (entreeList.Count == 0)
            {
                btn_delete.Enabled = false;
                btn_modifier.Enabled = false;
                MessageBox.Show("Aucune entrée n'est présent dans la liste, vous pouvez en ajouter un !", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            tab_listeEnr.DataSource = entreeList;
            tab_listeEnr.Columns[2].HeaderText = "Entrée";
            tab_listeEnr.Columns[3].HeaderText = "Nom Entrée";
            tab_listeEnr.Columns[4].HeaderText = "Nom Capteur";

            for (byte i = 0; i < 2; i++)
            {
                tab_listeEnr.Columns[i].Visible = false;
            }

            tab_listeEnr.Columns[2].Width = 50;
            tab_listeEnr.Columns[3].Width = 150;
            tab_listeEnr.Columns[4].Width = 150;
            

            rdr.Close();
            BDD.connection.Close();
        }

        private void tab_listeEnr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tab_listeEnr.CurrentRow.Selected = true;
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
            FormAjoutEntrees fAEnt = new FormAjoutEntrees(confIni);
            fAEnt.ShowDialog();
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            FormAjoutEntrees fAEnt = new FormAjoutEntrees(confIni);
            fAEnt.ShowDialog();
        }
    }
}
