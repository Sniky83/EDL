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
    public partial class FormMesures : Form
    {
        public FormMesures()
        {
            InitializeComponent();
        }

        private void tbl_Mesures_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tab_Mesures.CurrentRow.Selected = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
