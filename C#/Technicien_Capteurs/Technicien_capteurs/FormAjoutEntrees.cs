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
    public partial class FormAjoutEntrees : Form
    {
        private C_BDD BDD;

        private ushort[] id_capteur;

        public ushort id;

        public int index;

        public string[] Tableau;

        public bool IsSendToServer = false;

        private BindingList<C_Capteur> capteurList = new BindingList<C_Capteur>();

        private C_Config confIni = new C_Config();

        private BindingList<C_Entree> entreeList = new BindingList<C_Entree>();
        public FormAjoutEntrees(C_Config configIni, bool modif, BindingList<C_Capteur> cptList, BindingList<C_Entree> entrList)
        {
            InitializeComponent();

            BDD = new C_BDD(configIni.ip, configIni.dbn, configIni.username, configIni.password);

            cmbBox_input.Sorted = true;

            if (modif == true)
            {
                this.Text = "Modification";
            }

            int countCapteurs = cptList.Count;

            id_capteur = new ushort[countCapteurs];

            for (byte i = 0; i < countCapteurs; i++)
            {
                id_capteur[i] = cptList[i].Id;
                cmbBox_capteur.Items.Add(cptList[i].Nom);
            }

            if (countCapteurs == 0)
            {
                MessageBox.Show("Aucun capteur n'est disponible, ils sont tous utilisés dans la liste, vous pouvez toujours les modifiers en cas de nécessité !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }

            if (entrList.Count != 0)
            {
                for (byte i = 0; i < entrList.Count; i++)
                {
                    byte entree = entrList[i].Entree;
                    cmbBox_input.Items.Remove($"{entree}");
                }
            }

            cptList = capteurList;

            configIni = confIni;

            entrList = entreeList;
            //Dictionary<int, C_Capteur> dico = new Dictionary<int, C_Capteur>();
            /*dico.Add("a", new C_Capteur());
            dico.Add("b", new C_Capteur());

            dico["b"];*/

            //confIni = configIni;

            /*byte nbEntrees = 0;
            var rdr = BDD.RequeteCountCapteurs();

            while (rdr.Read())
            {
                nbEntrees = byte.Parse(rdr[0].ToString());//Nombre d'entrées
            }
            rdr.Close();
            BDD.connection.Close();

            id_capteur = new byte[nbEntrees];

            rdr = BDD.RequeteSelectIdNomCapteurs();
            byte i = 0;
            string stockage = "";

            while (rdr.Read())
            {
                id_capteur[i] = byte.Parse(rdr[0].ToString());//id
                //id.Add(byte.Parse(rdr[0].ToString()));//id
                //stockage = rdr[1].ToString();//nom

                cmbBox_capteur.Items.Add(stockage);
                i++;
            }
            rdr.Close();
            BDD.connection.Close();*/
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if(cmbBox_input.SelectedIndex != -1 && cmbBox_capteur.SelectedIndex != -1 && txtBox_nom_entree.Text != "")
            {
                index = cmbBox_capteur.SelectedIndex;
                if (id != 0)
                {
                    bool result = BDD.RequeteUpdateEntree(txtBox_nom_entree.Text, byte.Parse(cmbBox_input.Text), id_capteur[index], id);
                    if (result == true)
                    {
                        IsSendToServer = result;
                        Tableau = new string[]
                        {
                            cmbBox_input.Text,cmbBox_capteur.Text,txtBox_nom_entree.Text
                        };
                        Set_Config_Arduino();
                    }
                }
                else
                {
                    bool result = BDD.RequeteInsertEntree(txtBox_nom_entree.Text, byte.Parse(cmbBox_input.Text), id_capteur[index]);
                    if (result == true)
                    {
                        IsSendToServer = result;
                        Tableau = new string[]
                        {
                            cmbBox_input.Text,txtBox_nom_entree.Text,cmbBox_capteur.Text,index.ToString()
                        };
                    }
                }
                /*C_Capteur capteur = cmbBox_capteur.SelectedItem as C_Capteur;
                int id_capteur = capteur.Id;*/
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Set_Config_Arduino()
        {
            C_EDL_Recorder Recorder = new C_EDL_Recorder(confIni.ipArduino);
            var Join = capteurList.Where(item => item.Nom == entreeList[index].Nom_Capteur);
            var A = Join.First().A;
            var B = Join.First().B;
            ushort id = entreeList[index].Id;
            string Composition = $"EDL_TECH_SET_CONF_EDL_L{entreeList[index].Entree}_A_{A}_B_{B}_ID_{id}?";
            Recorder.EnvoiConfiguration(Composition);
        }
    }
}
