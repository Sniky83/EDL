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
    public partial class FormMesures : Form
    {
        private C_Config ConfigIni;

        private C_BDD BDD;

        private BindingList<C_Entree> entreeList = new BindingList<C_Entree>();
        public FormMesures(C_Config _configIni, BindingList<C_Entree> _entreeList)
        {
            InitializeComponent();

            ConfigIni = _configIni;

            entreeList = _entreeList;

            BDD = new C_BDD(ConfigIni.ip, ConfigIni.dbn, ConfigIni.username, ConfigIni.password);

            tab_Mesures.DataSource = _entreeList;
            tab_Mesures.Columns[0].Visible = false;
            tab_Mesures.Columns[2].HeaderText = "Nom Entrée";

            tab_Mesures.Columns[1].Width = 50;
            tab_Mesures.Columns[2].Width = 130;
            tab_Mesures.Columns[3].Width = 130;
            tab_Mesures.Columns[4].Width = 50;
            tab_Mesures.Columns[5].Width = 60;

            Mesurer();
        }

        private void Mesurer()
        {
            byte count = (byte)entreeList.Count;

            for (byte i = 0; i < count; i++)
            {
                var rdr = BDD.RequeteSelectMesuresInstant(entreeList[i].Id);
                string stockage = "";

                while (rdr.Read())
                {
                    for (byte z = 0; z < 3; z++)
                    {
                        stockage = rdr[z].ToString();
                        switch (z)
                        {
                            case 0:
                                entreeList[i].Intensite = float.Parse(stockage);
                                break;
                            case 1:
                                entreeList[i].Puissance = float.Parse(stockage);
                                break;
                            case 2:
                                entreeList[i].Id = ushort.Parse(stockage);
                                break;
                            default:
                                break;
                        }
                    }
                }
                rdr.Close();
                BDD.connection.Close();
            }
            tab_Mesures.Refresh();
        }

        private void Btn_aide_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"http://{ConfigIni.ip}/EDL/index.php?rubrique=5");
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbl_Mesures_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tab_Mesures.CurrentRow.Selected = false;
        }

        private void Tab_Mesures_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tab_Mesures.CurrentRow.Selected = false;
        }

        private void Timer_Refresh_Tab_Tick(object sender, EventArgs e)
        {
            Mesurer();
        }
    }
}
