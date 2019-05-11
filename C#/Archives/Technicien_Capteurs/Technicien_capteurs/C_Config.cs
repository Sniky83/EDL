using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technicien_capteurs
{
    class C_Config
    {
        //Class chargée de sauvegarder la config réseau dans un fichier en .ini et de l'encrypter.

        //Permet la lecture des données d'une Form
        private System.Windows.Forms.Form fConfRes = System.Windows.Forms.Application.OpenForms["FormConfigReseau"];
        public FormConfigReseau formConfigReseau;

        public string ip = "";
        public string username = "";
        public string password = "";
        public string dbn = "";

        public C_Config(FormConfigReseau fConfigR)
        {
            formConfigReseau = fConfigR;
        }

        public void SaveConfig()
        {
            var MyIni = new IniFile("Paramètres.ini");
            MyIni.Write("IP", ((FormConfigReseau)fConfRes).txtBox_ip.Text);
            MyIni.Write("USERNAME", ((FormConfigReseau)fConfRes).txtBox_username.Text);
            MyIni.Write("PASSWORD", ((FormConfigReseau)fConfRes).txtBox_password.Text);
            MyIni.Write("DBN", ((FormConfigReseau)fConfRes).txtBox_dbn.Text);
        }

        public bool LoadConfig()
        {
            var MyIni = new IniFile("Paramètres.ini");
            var IP = MyIni.Read("IP");
            var UNAME = MyIni.Read("USERNAME");
            var PASS = MyIni.Read("PASSWORD");
            var DBN = MyIni.Read("DBN");

            if (IP != "")
            {
                ip = IP;
                username = UNAME;
                password = PASS;
                dbn = DBN;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EncryptFile()
        {

        }

        public void DecryptFile()
        {

        }
    }
}
