﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technicien_capteurs
{
    public partial class FormAccueil : Form
    { 
        private C_Config ConfigIni = new C_Config();

        private C_BDD BDD;

        private BindingList<C_Capteur> capteurList = new BindingList<C_Capteur>();
        private BindingList<C_Entree> entreeList = new BindingList<C_Entree>();

        private bool TesterConnexionArduino = false;
        private bool TesterConnexionBDD = false;

        private bool flagBDD = false;
        private bool flagArduino = false;

        public FormAccueil()
        {
            InitializeComponent();

            if (File.Exists("Paramètres.ini"))
            {
                ConfigIni.LoadConfig();
            }

            if (ConfigIni.ipArduino != "")
            {
                C_EDL_Recorder Enregistreur = new C_EDL_Recorder(ConfigIni.ipArduino);

                TesterConnexionArduino = Enregistreur.TesterConnexion();

                if(TesterConnexionArduino == true)
                {
                    lbl_etat_enr.Text = "Connecté";
                    lbl_etat_enr.ForeColor = Color.Green;
                    flagArduino = true;
                }
                else
                {
                    ConfigIni.ipArduino = "";
                }
            }

            if (ConfigIni.ip != "" && ConfigIni.username != "" /*&& ConfigIni.txtBox_password != ""*/ && ConfigIni.dbn != "")
            {
                BDD = new C_BDD(ConfigIni.ip, ConfigIni.dbn, ConfigIni.username, ConfigIni.password);

                TesterConnexionBDD = BDD.TesterConnexion();

                if(TesterConnexionBDD == true)
                {
                    lbl_etat_bdd.Text = "Connecté";
                    lbl_etat_bdd.ForeColor = Color.Green;
                    btn_connexion.Enabled = true;
                    flagBDD = true;
                }
            }

            if (TesterConnexionArduino == true && TesterConnexionBDD == true)
            {
                btn_configRes.Enabled = false;
            }
        }

        private void btn_mesurer_Click(object sender, EventArgs e)
        {
            FormMesures fMesurer = new FormMesures(ConfigIni, entreeList);
            fMesurer.ShowDialog();
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_aide_Click(object sender, EventArgs e)
        {
            if(ConfigIni.ip != "")
            {
                System.Diagnostics.Process.Start($"http://{ConfigIni.ip}/EDL/index.php?rubrique=1");
            }
            else
            {
                MessageBox.Show("Pour vous connecter à l'enregisteur, il vous suffira de cliquer sur le bouton 'Configurartion Réseau'. Une fois la connexion établie avec la base de données et l'enregistreur, vous pourrez vous connecter avec votre compte Client pour accéder à la suite de l'application en cliquant sur le bouton 'Se Connecter'.", "Aide", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_configEnr_Click(object sender, EventArgs e)
        {
            FormConfigEnregistreur fEnr = new FormConfigEnregistreur(ConfigIni, entreeList, capteurList);
            fEnr.ShowDialog();

            if (entreeList.Count != 0)
            {
                btn_mesurer.Enabled = true;
            }
            else
            {
                btn_mesurer.Enabled = false;
            }
        }

        private void btn_configRes_Click(object sender, EventArgs e)
        {
            FormConfigReseau fConfRes = new FormConfigReseau(ConfigIni);

            if(TesterConnexionBDD == true || flagBDD == true)
            {
                fConfRes.lbl_ip.Text = "Adresse IP : OK";
                fConfRes.lbl_username.Text = "Nom d'utilisateur : OK";
                fConfRes.lbl_password.Text = "Mot de passe : OK";
                fConfRes.lbl_dbn.Text = "Nom de la base de données : OK";

                fConfRes.txtBox_ip.Visible = false;
                fConfRes.txtBox_username.Visible = false;
                fConfRes.txtBox_password.Visible = false;
                fConfRes.txtBox_dbn.Visible = false;
            }

            if(TesterConnexionArduino == true || flagArduino == true)
            {
                fConfRes.lbl_ipArduino.Text = "Adresse IP : OK";

                fConfRes.txtBox_ipArduino.Visible = false;
            }
            fConfRes.ShowDialog();

            if(fConfRes.IsConnectionDoneBDD == true && TesterConnexionBDD == false)
            {
                lbl_etat_bdd.Text = "Connecté";
                lbl_etat_bdd.ForeColor = Color.Green;
                btn_connexion.Enabled = true;
            }

            if(fConfRes.IsConnectionDoneArduino == true && TesterConnexionArduino == false)
            {
                lbl_etat_enr.Text = "Connecté";
                lbl_etat_enr.ForeColor = Color.Green;
            }

            if (fConfRes.IsFullConnected == true)
            {
                btn_configRes.Enabled = false;
                btn_gestCapteur.Enabled = true;
                if(capteurList.Count != 0)
                {
                    btn_configEnr.Enabled = true;
                }
                else
                {
                    btn_configEnr.Enabled = true;
                }

                if(entreeList.Count != 0)
                {
                    btn_mesurer.Enabled = true;
                }
                else
                {
                    btn_mesurer.Enabled = false;
                }
            }
            else
            {
                btn_configRes.Enabled = true;
                btn_gestCapteur.Enabled = false;
            }
        }

        private void btn_gestCapteur_Click(object sender, EventArgs e)
        {
            FormGestionCapteurs fGestCapt = new FormGestionCapteurs(ConfigIni, capteurList);

            fGestCapt.ShowDialog();

            if(capteurList.Count == 0)
            {
                btn_configEnr.Enabled = false;
            }
            else
            {
                btn_configEnr.Enabled = true;
            }
        }

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            FormConnexion fConn = new FormConnexion(ConfigIni);
            fConn.ShowDialog();

            if(fConn.IsConnexionDone == true)
            {
                btn_connexion.Enabled = false;

                var rdr = BDD.RequeteSelectCapteurs(ConfigIni.ipArduino);
                string stockage = "";
                C_Capteur capteurToAdd = new C_Capteur();

                while (rdr.Read())
                {
                    for (byte i = 0; i < 7; i++)
                    {
                        stockage = rdr[i].ToString();
                        switch (i)
                        {
                            case 0:
                                capteurToAdd.Id = ushort.Parse(stockage);
                                break;
                            case 1:
                                capteurToAdd.Nom = stockage;
                                break;
                            case 2:
                                capteurToAdd.Marque = stockage;
                                break;
                            case 3:
                                capteurToAdd.Model = stockage;
                                break;
                            case 4:
                                capteurToAdd.Calibre = byte.Parse(stockage);
                                break;
                            case 5:
                                capteurToAdd.A = stockage.Replace(',', '.');
                                break;
                            case 6:
                                capteurToAdd.B = stockage.Replace(',', '.');
                                break;
                            default:

                                break;
                        }
                    }
                    capteurList.Add(capteurToAdd);
                }
                rdr.Close();
                BDD.connection.Close();

                if (capteurList.Count == 0 || TesterConnexionArduino == false)
                {
                    btn_configEnr.Enabled = false;
                    btn_mesurer.Enabled = false;
                }
                else
                {
                    btn_configEnr.Enabled = true;
                }

                var reader = BDD.RequeteSelectEntrees(ConfigIni.ipArduino);
                string stock = "";
                C_Entree entreeToAdd = new C_Entree();

                while (reader.Read())
                {
                    for (byte i = 0; i < 4; i++)
                    {
                        stock = reader[i].ToString();
                        switch (i)
                        {
                            case 0:
                                entreeToAdd.Id = ushort.Parse(stock);
                                break;
                            case 1:
                                entreeToAdd.Entree = byte.Parse(stock);
                                break;
                            case 2:
                                entreeToAdd.Nom_Entree = stock;
                                break;
                            case 3:
                                entreeToAdd.Capteur = capteurList.First(x => x.Nom == stock);
                                break;
                            default:

                                break;
                        }
                    }
                    entreeList.Add(entreeToAdd);
                }
                reader.Close();
                BDD.connection.Close();

                if (entreeList.Count == 0 || TesterConnexionArduino == false)
                {
                    btn_mesurer.Enabled = false;
                }
                else
                {
                    btn_mesurer.Enabled = true;
                    btn_gestCapteur.Enabled = true;
                    btn_configEnr.Enabled = true;
                }

                if(ConfigIni.ipArduino == "")
                {
                    MessageBox.Show("Vous devez vous connecter à l'enregistreur en rentrant son adresse IP dans la partie 'Configuration Réseau' pour pouvoir utiliser les autres fonctionnalitées !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
