#include "C_Recorder.h"

#include <SPI.h>
#include <Ethernet.h>

C_Recorder Enregistreur;

byte mac[] = { 0x90, 0xA2, 0xDA, 0x11, 0x1B, 0xE3 };
//IPAddress ip(10,73,8,62);
IPAddress ip(192,168,1,42);
//IPAddress gateway(10,73,8,112);
//IPAddress subnet(255,255,255,128);
//byte serv[] = {10,73,8,63};

EthernetServer server(2000);

int led1 = 2; //led droite
int led2 = 3; //led gauche
int bouton1 = 4; //bouton droite
int bouton2 = 5; //bouton gauche

String msg = "";
bool flag = false;
//byte val = 0;

void ConnexionApplication()
{
  if(msg == "EDL_TEST?")
  {
    server.write("EDL_TEST!");
  }
}

void GetConfiguration(String msg)
{
  //"EDL_TECH_SET_CONF_EDL_L1_A_2_B_3_ID_12?"L=22
  if(msg[0] == 'E' && msg[9] == 'S' && msg[18] == 'E')
  {
    byte countMsg = msg.length() - 1;
    bool flag = false;
    String A = "";
    String B = "";
    String ID = "";

    for(byte i = 27; i<countMsg; i++)
    {
      if(msg[i] != '_' && flag == false)
      {
        flag = true;
        A = A + msg[i];
      }
      else if(msg[i] != '_' && msg[i] != 'B' && flag == true)
      {
        B = B + msg[i];
      }

      if(msg[i] == 'D' && msg[i+1] == '_')
      {
        i = i+2;
        for(i;i<countMsg;i++)
        {
          ID = ID + msg[i];
        }
      }
    }
    Enregistreur.A[Enregistreur.val] = A.toFloat();
    Enregistreur.B[Enregistreur.val] = B.toFloat();
    Enregistreur.ID[Enregistreur.val] = ID.toInt();

    Enregistreur.Entree[Enregistreur.val] = msg[23] - 49;
    Enregistreur.val++;
    server.write("EDL_ENR_GET_CONF_OK!");
  }
}

void Emettre()
{
  Serial.println("Lancement des mesures en instantané ...");
  digitalWrite(led2,HIGH);
  bool flagStop = false;

  while(flagStop == false)
  {
      String trame = Enregistreur.ComposerTrame();
      server.print(trame);
      if(digitalRead(bouton2) == HIGH)
      {
        flagStop = true;
        digitalWrite(led2,LOW);
        Serial.println("Arrêt des mesures en instantané ...");
      }
  }
}

void setup(){
  Serial.begin(9600);
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(bouton1, INPUT);
  pinMode(bouton2, INPUT);
  digitalWrite(led1, HIGH);
  digitalWrite(led2, HIGH);
  Ethernet.begin(mac,ip);
  Serial.print("Mon IP : ");
  Serial.println(Ethernet.localIP());
  server.begin();
}

void loop(){
  EthernetClient client = server.available();
  if (client) {
    while(client.connected()) {
      // si le client nous envoie quelque chose
      if (client.available() > 0){
        char reception = client.read(); //on lit ce qu'il raconte
        msg = msg + reception; // Remise à zero de la variable de réception
          if(reception == '?'){
            // interpretation d'une commande
            Serial.println("Message Reçu : "+ msg);
            ConnexionApplication();
            GetConfiguration(msg);
            // fin d'interprétation des messages
            msg = "";
          } // fermeture du if(reception)
        } // fermeture if (client.available)
      } // fermeture while
  } // fermeture if(client)
  if(digitalRead(bouton1) == HIGH)
  {
    Emettre();
  }
}
