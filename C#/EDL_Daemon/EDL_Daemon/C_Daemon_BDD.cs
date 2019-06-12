using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDL_Daemon
{
    class C_Daemon_BDD
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uname;
        private string password;

        public C_Daemon_BDD()
        {
            server = "localhost";
            database = "edl";
            uname = "root";
            password = "";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uname + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        private bool NonQuery(string requete)
        {
            try
            {
                connection.Open();
                MySqlCommand sqlcomMain = new MySqlCommand(requete, connection);
                MySqlDataReader rdr = sqlcomMain.ExecuteReader();
                connection.Close();
                return true;
            }
            catch
            {
                Console.WriteLine("Problème de connexion ou de requête !");
                connection.Close();
                return false;
            }
        }

        public bool RequeteInsertMesuresInstant(string intensite, string puissance, ushort id_config)
        {
            string requete = $"INSERT INTO `mesures_conso_instant`(`Intensite`,`Puissance`,`ID_config_enregistrement`)VALUES({intensite},{puissance},{id_config});";
            return NonQuery(requete);
        }

    }
}
