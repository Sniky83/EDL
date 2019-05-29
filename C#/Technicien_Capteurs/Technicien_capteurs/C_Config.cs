using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Technicien_capteurs
{
    public class C_Config
    {
        //Class chargée de sauvegarder la config réseau dans un fichier en .ini et de l'encrypter.

        //Variable globale configuré depuis la formConfigReseau
        public string ip = "";
        public string username = "";
        public string password = "";
        public string dbn = "";
        public string ipArduino = "";

        private static string file = "Paramètres.ini";

        public void SaveConfig()
        {
            var MyIni = new IniFile(file);

            if(File.Exists(file))
            {
                //On vide le fichier pour re-save
                File.WriteAllText(file, string.Empty);
            }

            if(ip != "")
            {
                MyIni.Write("IP", ip);
                MyIni.Write("USERNAME", username);
                MyIni.Write("PASSWORD", password);
                MyIni.Write("DBN", dbn);
            }

            if(ipArduino != "")
            {
                MyIni.Write("IP_ARDUINO", ipArduino);
            }

            EncryptFile();
        }

        public void LoadConfig()
        {
            DecryptFile();

            var MyIni = new IniFile(file);
            var IP = MyIni.Read("IP");
            var UNAME = MyIni.Read("USERNAME");
            var PASS = MyIni.Read("PASSWORD");
            var DBN = MyIni.Read("DBN");
            var IP_ARDUINO = MyIni.Read("IP_ARDUINO");

            if(IP != "")
            {
                ip = IP;
                username = UNAME;
                password = PASS;
                dbn = DBN;
            }

            if(IP_ARDUINO != "")
            {
                ipArduino = IP_ARDUINO;
            }

            EncryptFile();
        }

        private byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 10, 22, 34, 46, 58, 69, 74, 82 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        private byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 10, 22, 34, 46, 58, 69, 74, 82 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        private void EncryptFile()
        {
            byte[] bytesOfFile = File.ReadAllBytes(file);
            string pass = "?,A82:3X2§!^*ù";
            byte[] passwordBytes = Encoding.UTF8.GetBytes(pass);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesOfFile, passwordBytes);

            File.WriteAllBytes(file, bytesEncrypted);
        }

        private void DecryptFile()
        {
            byte[] bytesOfFile = File.ReadAllBytes(file);
            string pass = "?,A82:3X2§!^*ù";
            byte[] passwordBytes = Encoding.UTF8.GetBytes(pass);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesOfFile, passwordBytes);

            File.WriteAllBytes(file, bytesDecrypted);
        }
    }
}
