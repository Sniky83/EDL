using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technicien_capteurs
{
    class C_EDL_Recorder
    {
        //Class chargée de communiquer avec l'arduino afin de réucpérer les mesures effectuées en instantanné.

        private string IpArduino;

        public C_EDL_Recorder(string ip)
        {
            IpArduino = ip;
        }

        private bool EnvoiEtReception(byte nbBytesRec, string msgEnvoi, string msgReception, bool testerConnexion)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(IpArduino);
                //IPEndPoint remoteEP = new IPEndPoint(ipAddress, 2000);
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                byte[] bytes = new byte[nbBytesRec]; //nb de chars qu'on recoit
                sender.BeginConnect(ipAddress, 2000, null, null);
                //sender.ReceiveTimeout = 3000; //si il se connecte sur la bonne ip, port mais qu'il ne reçoit rien

                byte i = 0;
                bool isConnected = false;

                while (i < 3 && isConnected == false)
                {
                    if(sender.Connected)//connected == true quand on ping une ip sur le port 2000 (serveur)
                    {
                        byte[] msg = Encoding.ASCII.GetBytes(msgEnvoi);

                        int bytesSent = sender.Send(msg);//count le nb de bytes envoyées
                        
                        int bytesRec = sender.Receive(bytes);//count le nb de bytes reçus

                        string reception = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                        if(reception == msgReception)
                        {
                            isConnected = true;
                        }

                        reception = "";
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }

                    i++;
                }

                if (testerConnexion == true && isConnected == true)
                {
                    MessageBox.Show("Connexion réussie avec l'enregistreur !", "Succès !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (isConnected == false)
                {
                    MessageBox.Show("Problème de connexion avec l'enregistreur !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de saisie dans l'adresse IP de l'enregistreur !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public bool TesterConnexion()
        {
            bool resultat = EnvoiEtReception(9, "EDL_TEST?","EDL_TEST!",true);
            return resultat;
        }

        public bool EnvoiConfiguration(string msgEnvoi)
        {
            bool resultat = EnvoiEtReception(20, msgEnvoi, "EDL_ENR_GET_CONF_OK!", false);
            return resultat;
        }
        private string EnvoiMessageMesureInstant()
        {
            /*On va envoyer Allo?
              Tant que rep == "" -> on continue dès qu'on a la réponse alors on sort du while faire un sleep de 200ms
              et au bout de 5 essays on sort de la boucle et on dit que y'a personne au bout du fil.*/
            string message = "";
            try
            {
                return message;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void LectureMesureInstant()
        {
            //Utilisation de la méthode Envoi 
            string message = EnvoiMessageMesureInstant();

            if(message != null)
            {

            }
            else
            {
                MessageBox.Show("Problème de connexion avec l'enregistreur !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
