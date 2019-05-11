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

        //FormAjoutCapteur fAddCpt = new FormAjoutCapteur();

        public FormGestionCapteurs()
        {
            InitializeComponent();

            FormConfigReseau fConfRes = new FormConfigReseau();

            BDD = new C_BDD(fConfRes.txtBox_ip, fConfRes.txtBox_dbn, fConfRes.txtBox_username, fConfRes.txtBox_password);

            string[,] Liste = BDD.RequeteSelectCapteur();

            if (Liste[0,0] != "")
            {
                int sizeOfListe = Liste.GetLength(0);
                Console.WriteLine(Liste[5,0]);
                short ligne = 0;

                /*while (sizeOfListe != ligne)
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
                tab_listeCapteurs.AllowUserToAddRows = false;*/
            }
            else
            {
                btn_add.Enabled = false;
                btn_delete.Enabled = false;
                btn_modifier.Enabled = false;
            }
            /*DataTable table = new DataTable();
            MySqlDataReader rdr = BDD.RequeteSelectCapteur();
            short j = 0;
            string stockage;
            while (rdr.Read())
            {
                for (short i = 0; i < 5; i++)
                {
                    stockage = rdr[i].ToString();
                    // A inserer dans table[j][i]
                }
                j++;
            }
            rdr.Close();*/
        }

        private void tab_listeCapteurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tab_listeCapteurs.CurrentRow.Selected = true;
            btn_modifier.Enabled = true;
            btn_delete.Enabled = true;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            FormAjoutCapteur fAddCpt = new FormAjoutCapteur(this);

            fAddCpt.ShowDialog();
        }

        private void tab_listeCapteurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            FormAjoutCapteur fAddCpt = new FormAjoutCapteur(this);

            fAddCpt.ShowDialog();
        }
    }
}
