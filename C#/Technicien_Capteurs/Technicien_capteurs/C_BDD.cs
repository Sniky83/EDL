using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Technicien_capteurs
{
    //Class chargée de se connecter à la base de données et d'effectuer des requêtes (insert, select, delete).
    class C_BDD
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uname;
        private string password;

        public C_BDD(string addrip, string db, string username, string pass)
        {
            server = addrip;
            database = db;
            uname = username;
            password = pass;
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uname + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        #region ConnexionBDD
        public bool TesterConnexion()
        {
            try
            {
                OuvrirConnexion();
                MessageBox.Show("Connexion réussie à la base de données !","Succès !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FermerConnexion();
                return true;
            }
            catch (Exception)
            {
                FermerConnexion();
                MessageBox.Show("Problème de connexion, vérifiez que votre serveur de la base de données soit actif !","Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public MySqlDataReader SeConnecter(string nom, string password)
        {
            string requete = "SELECT `Nom`,`MDP` FROM `membres` WHERE `Nom`='" + nom + "' AND `MDP`='" + password + "';";
            MySqlDataReader rdr = Query(requete);
            return rdr;
        }

        private void OuvrirConnexion()
        {
            connection.Open();
        }

        private void FermerConnexion()
        {
            connection.Close();
        }
        #endregion

        #region Requetes Génériques
        private bool NonQuery(string requete)
        {
            try
            {
                OuvrirConnexion();
                MySqlCommand sqlcom = new MySqlCommand(requete, connection);
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("Les informations ont été envoyées à la base de données !", "Succès !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FermerConnexion();
                return true;
            }
            catch (Exception)
            {
                FermerConnexion();
                MessageBox.Show("Problème de connexion ou de requête !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private MySqlDataReader Query(string requete)
        {
            try
            {
                OuvrirConnexion();
                MySqlCommand sqlcomMain = new MySqlCommand(requete, connection);
                MySqlDataReader rdr = sqlcomMain.ExecuteReader();
                return rdr;
            }
            catch
            {
                FermerConnexion();
                MessageBox.Show("Problème de connexion ou de requête !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region Capteur
        public bool RequeteInsertCapteur(string nom, string adresseIp, string marque, string model, byte calibre, string a, string b)
        {
            string nom_config = $"INT_ALT_A:{a}_B:{b}";
            string requete = "INSERT INTO `capteurs`(`Nom`,`Adresse_IP`,`Calibre_Max`,`Type_Courant`,`A`,`B`,`Nom_Config`,`Model`,`Marque`)VALUES('"+ nom+"','"+adresseIp+"','"+calibre+ "','Alternatif','"+a+"','"+b+"','"+nom_config+"','"+model+"','"+marque+"')";
            return NonQuery(requete);
        }

        public bool RequeteDeleteCapteur(int id)
        {
            string requete = "DELETE FROM `capteurs` WHERE `id` = '"+id+"';";
            return NonQuery(requete);
        }

        public bool RequeteUpdateCapteur(string nom, string ipArduino, string marque, string model, byte calibre, string a, string b, ushort id)
        {
            string nom_config = $"INT_ALT_A:{a}_B:{b}";
            string requete = $"UPDATE `capteurs` SET `Nom` = '{nom}', `Adresse_IP` = '{ipArduino}',`Calibre_MAX` = '{calibre}', `A` = '{a}', `B` = '{b}', `Nom_Config` = '{nom_config}', `Model` = '{model}', `Marque` = '{marque}' WHERE id = {id};";
            return NonQuery(requete);
        }

        public MySqlDataReader RequeteSelectCapteurs(string ip)
        {
            string requete = $"SELECT `id`,`Nom`,`Marque`,`Model`,`Calibre_Max`,`A`,`B` FROM `capteurs` WHERE `Adresse_IP` = '{ip}';";
            MySqlDataReader rdr = Query(requete);
            return rdr;
        }

        public MySqlDataReader RequeteSelectIdNomCapteurs()
        {
            string requete = "SELECT `id`,`Nom` FROM `capteurs`;";
            MySqlDataReader rdr = Query(requete);
            return rdr;
        }

        public MySqlDataReader RequeteCountCapteurs()
        {
            string requete = "SELECT COUNT(`Nom`) FROM `capteurs`;";
            MySqlDataReader rdr = Query(requete);
            return rdr;
        }

        public MySqlDataReader RequeteSelectLastIdCapteurs()
        {
            string requete = "SELECT MAX(`id`) FROM `capteurs`;";
            MySqlDataReader rdr = Query(requete);
            return rdr;
        }
        #endregion

        #region Entrées

        public MySqlDataReader RequeteSelectEntrees(string ip)
        {
            string requete = $"SELECT `conf`.`ID`,`Ligne`,`Nom_Ligne`,`cpt`.`Nom` FROM `capteurs` cpt INNER JOIN `config_enregistrement` conf ON `conf`.`ID_Capteur` = `cpt`.`ID` WHERE `cpt`.`Adresse_IP` = '{ip}';";
            MySqlDataReader rdr = Query(requete);
            return rdr;
        }
        public bool RequeteInsertEntree(string nom, byte ligne, ushort id_capteur)
        {
            string requete = $"INSERT INTO `config_enregistrement`(`Ligne`,`ID_Capteur`,`Nom_Ligne`)VALUES({ligne},{id_capteur},'{nom}');";
            return NonQuery(requete);
        }

        public bool RequeteUpdateEntree(string nom, byte ligne, ushort id_capteur, ushort id)
        {
            string requete = $"UPDATE `config_enregistrement` SET `Nom_Ligne` = '{nom}',`Ligne` = {ligne},`ID_Capteur` = {id_capteur} WHERE `ID` = {id};";
            return NonQuery(requete);
        }

        public bool RequeteDeleteEntree(ushort id)
        {
            string requete = $"DELETE FROM `config_enregistrement` WHERE `id` = {id};";
            return NonQuery(requete);
        }

        public bool RequeteDeleteEntreeFromGestionCapteurs(ushort id_capteur)
        {
            string requete = $"DELETE FROM `config_enregistrement` WHERE `ID_Capteur` = {id_capteur};";
            try
            {
                OuvrirConnexion();
                MySqlCommand sqlcom = new MySqlCommand(requete, connection);
                sqlcom.ExecuteNonQuery();
                FermerConnexion();
                return true;
            }
            catch (Exception)
            {
                FermerConnexion();
                MessageBox.Show("Problème de connexion ou de requête !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public MySqlDataReader RequeteSelectLastIdEntrees()
        {
            string requete = "SELECT MAX(`id`) FROM `config_enregistrement`;";
            MySqlDataReader rdr = Query(requete);
            return rdr;
        }

        public MySqlDataReader RequeteSelectMesuresInstant(ushort id)
        {
            string requete = $"SELECT `Intensite`,`Puissance`,`ID_config_enregistrement` FROM `mesures_conso_instant` WHERE `ID_config_enregistrement` = {id} ORDER BY `ID` DESC Limit 0,1;";
            MySqlDataReader rdr = Query(requete);
            return rdr;
        }
        #endregion
    }
}
