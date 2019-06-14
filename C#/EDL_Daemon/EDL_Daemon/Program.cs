using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EDL_Daemon
{
    class Program
    {
        private static IPAddress ipAddress = IPAddress.Parse("10.73.8.25");
        public static Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] bytes = new byte[37]; //nb de chars qu'on recoit

        static void Main()
        {
            Console.WriteLine("Bienvenu sur l'application du démon servant de passerelle pour envoyer les mesures au technicien et a la base de données.");
            bool resultat = EnvoiMessageMesuresInstant();
            sender.BeginConnect(ipAddress, 2000, null, null);
            C_Daemon_BDD BDD = new C_Daemon_BDD();
            bool flag = false;
            string intensite = "";
            string puissance = "";
            string id = "";

            while (true)
            {
                if(resultat == true)
                {
                    string mesures = LectureMesuresInstant();

                    if(mesures != "Rien")
                    {
                        //EDL_ENR_L0_I_0.00_P_0.00_ID_0!
                        byte countMessage = (byte)(mesures.Length - 1);
                        for(byte i = 13; i<countMessage; i++)
                        {
                            if(mesures[i] != '_' && flag == false)
                            {
                                intensite = intensite + mesures[i];
                            }
                            else
                            {
                                flag = true;
                            }

                            if(mesures[i] == 'P')
                            {
                                i = (byte)(i + 2);
                                while(mesures[i] != '_')
                                {
                                    puissance = puissance + mesures[i];
                                    i++;
                                }
                            }

                            if(mesures[i] == 'D')
                            {
                                i = (byte)(i + 2);
                                while(mesures[i] != '!')
                                {
                                    id = id + mesures[i];
                                    i++;
                                }
                            }
                        }
                        BDD.RequeteInsertMesuresInstant(intensite, puissance, ushort.Parse(id));
                        puissance = "";
                        id = "";
                        Console.WriteLine("Reception: " + mesures);
                    }
                }
                else
                {
                    resultat = EnvoiMessageMesuresInstant();
                    Console.WriteLine("Demande des valeurs ...");
                }
            }
        }

        private static bool EnvoiMessageMesuresInstant()
        {
            try
            {
                Thread.Sleep(200);

                if (sender.Connected)//connected == true quand on ping une ip sur le port 2000 (serveur)
                {
                    byte[] msg = Encoding.ASCII.GetBytes("EDL_TECH_MESURES?");//bytes du message envoyé
                    int bytesSent = sender.Send(msg);//count le nb de bytes envoyées
                    sender.Send(msg);//count le nb de bytes envoyées

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Problème de communication avec l'enregistreur !");
                return false;
            }
        }

        private static string LectureMesuresInstant()
        {
            try
            {
                Thread.Sleep(200);

                if (sender.Connected)//connected == true quand on ping une ip sur le port 2000 (serveur)
                {
                    int bytesRec = sender.Receive(bytes);//count le nb de bytes reçu
                    string reception = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    //EDL_ENR_L1_I_2.00_P_460.00_ID_2!
                    if (reception[0] == 'E' && reception[2] == 'L' && reception[4] == 'E' && reception[8] == 'L')
                    {
                        return reception;
                    }
                    else
                    {
                        return "Rien";
                    }
                }
                else
                {
                    return "Rien";
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Problème de reception des valeurs !");
                return "Rien";
            }
        }
    }
}
