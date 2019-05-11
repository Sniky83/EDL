﻿using System;
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

        public C_BDD(TextBox addrip, TextBox db, TextBox username, TextBox pass)
        {
            server = addrip.Text;
            database = db.Text;
            uname = username.Text;
            password = pass.Text;
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
                return true;
            }
            catch (Exception)
            {
                FermerConnexion();
                MessageBox.Show("Problème de connexion, vérifiez les champs saisis ou vérifiez que votre serveur soit actif !","Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public string[,] SeConnecter(TextBox username, TextBox password)
        {
            string requeteCount = "SELECT COUNT(*) FROM `membres` WHERE `Pseudo`='" + username.Text + "' AND `MDP`='" + password.Text + "';";
            string requeteMain = "SELECT `Pseudo`,`MDP` FROM `membres` WHERE `Pseudo`='" + username.Text + "' AND `MDP`='" + password.Text + "';";
            return null;//Query(requeteCount, requeteMain, 2);
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
                MessageBox.Show("Problème lors de l'envoi des informations à la base de données !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private MySqlDataReader Query(string requete)
        {
            try
            {
                OuvrirConnexion();
                MySqlCommand sqlcomMain = new MySqlCommand(requete, connection);
                MySqlDataReader rdrMain = sqlcomMain.ExecuteReader();
                return rdrMain;
            }
            catch
            {
                MessageBox.Show("Erreur de connexion ou de requête !", "Succès !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        /*private string[,] Query(string requeteCount, string requeteMain, short nbChamps)
        {
            try
            {
                OuvrirConnexion();

                MySqlCommand sqlcomCount = new MySqlCommand(requeteCount, connection);
                MySqlDataReader rdrCount = sqlcomCount.ExecuteReader();

                short ligne = 0;
                short colonne = 0;
                ushort nbEntrees = 0;

                while (rdrCount.Read())
                {
                    nbEntrees = rdrCount.GetUInt16(0);
                }
                rdrCount.Close();

                string[,] stockage = new string[nbEntrees, nbChamps];

                MySqlCommand sqlcomMain = new MySqlCommand(requeteMain, connection);
                MySqlDataReader rdrMain = sqlcomMain.ExecuteReader();

                while (rdrMain.Read())
                {
                    while(colonne < nbChamps)
                    {
                        stockage[ligne, colonne] = rdrMain.GetValue(colonne).ToString();
                        colonne++;
                    }
                    ligne++;
                    colonne = 0;
                }
                rdrMain.Close();
                MessageBox.Show("Récup !", "Succès !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FermerConnexion();
                return stockage;
            }
            catch (Exception)
            {
                MessageBox.Show("Problème lors de la récupération des informations !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }*/
        #endregion

        #region Capteur
        public bool RequeteInsertCapteur(TextBox nom, TextBox marque, TextBox model, NumericUpDown calibre, TextBox a, TextBox b)
        {
            string requete = "INSERT INTO `capteurs`(`Nom`,`Type`,`Grandeur`,`Calibre_Max`,`A`,`B`,`Nom_Config`,`Model`,`Marque`)VALUES('"+nom.Text+"','Intensite','Alternatif','"+calibre.Value+"','"+a.Text+"','"+b.Text+"','test','"+model.Text+"','"+marque.Text+"')";
            return NonQuery(requete);
        }

        public bool RequeteDeleteCapteur(string nom, string marque, string model)
        {
            string requete = "DELETE FROM `capteurs` WHERE `Nom` = '"+ nom +"' AND `Marque` = '"+ marque +"' AND `Model` = '"+ model +"';";
            return NonQuery(requete);
        }

        public bool RequeteUpdateCapteur(TextBox nom, TextBox marque, TextBox model, NumericUpDown calibre, TextBox a, TextBox b, Label id)
        {
            string requete = "UPDATE `capteurs` SET `Nom` = '"+nom.Text+"', `Calibre_MAX` = '"+calibre.Text+"', `A` = '"+a.Text+"', `B` = '"+b.Text+"', `Nom_Config` = 'test', `Model` = '"+model.Text+"', `Marque` = '"+marque.Text+"' WHERE id = '"+id.Text+"';";
            return NonQuery(requete);
        }

        public MySqlDataReader RequeteSelectCapteurs()
        {
            string requete = "SELECT `id`,`Nom`,`Marque`,`Model`,`Calibre_Max`,`A`,`B` FROM `capteurs` WHERE `Type` = 'Intensite';";
            MySqlDataReader rdr = Query(requete);
            return rdr;
        }

        /*public string[,] RequeteSelectCapteur()
        {
            string requeteCount = "SELECT COUNT(*) FROM `capteurs` WHERE `Type` = 'Intensite';";
            string requeteMain = "SELECT `Nom`,`Marque`,`Model`,`Calibre_Max`,`A`,`B` FROM `capteurs` WHERE `Type` = 'Intensite';";
            return Query(requeteCount, requeteMain, 6);
        }*/
        #endregion

        #region Entrées
        public void RequeteInsertEntree()
        {

        }

        public void RequeteUpdateEntree()
        {

        }

        public void RequeteDeleteEntree()
        {

        }

        public void RequeteSelectEntree()
        {

        }
        #endregion
    }
}