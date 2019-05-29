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

        public bool TesterConnexion(string ip)
        {
            try
            {
                byte[] bytes = new byte[8];
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 2000);
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.BeginConnect(ipAddress, 2000, null, null);
                sender.ReceiveTimeout = 2000; //si il se connecte sur la bonne ip, port mais qu'il ne reçoit rien

                string reception = "";
                bool isConnected = false;
                byte i = 0;
                int bytesRec = 0;

                while (i < 3 && isConnected == false)
                {
                    if(sender.Connected)//connected == true quand on ping une ip sur le port 2000 (serveur)
                    {
                        byte[] msg = Encoding.ASCII.GetBytes("EDL_TEST?$");

                        int bytesSent = sender.Send(msg);//count le nb de bytes envoyées
                        
                        bytesRec = sender.Receive(bytes);//count le nb de bytes reçus

                        reception = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                        if(reception == "EDL_TEST!$")
                        {
                            isConnected = true;
                        }

                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }

                    i++;
                }

                if (isConnected == false)
                {
                    MessageBox.Show("Problème de connexion avec l'enregistreur !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    MessageBox.Show("Connexion réussie avec l'enregistreur !", "Succès !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de saisie dans l'adresse IP de l'enregistreur !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
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
