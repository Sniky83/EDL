#include "C_Capteur.h"
#include "C_BDD.h"

#include <SPI.h>
#include <Ethernet.h>

C_Capteur capteurIntensite;
C_BDD BDD;

byte mac[] = { 0x90, 0xA2, 0xDA, 0x11, 0x1B, 0xE3 };
IPAddress ip(10,73,8,62);
//IPAddress gateway(10,73,8,112);
//IPAddress subnet(255,255,255,128);
//byte serv[] = {10,73,8,63};

EthernetClient client;
EthernetServer server(2000);

int led1 = 2; //led droite
int led2 = 3; //led gauche
int bouton1 = 4; //bouton droite
int bouton2 = 5; //bouton gauche

float val;
int buttonState = 0;
String msg = "";
bool flag = false;

void ConnexionApplication()
{
  if(msg == "EDL_TEST?$")
  {
    server.write("EDL_TEST!$");
  }
}

void EnvoiMesureInstant()
{
  if(msg == "a")
  {
    val = capteurIntensite.ConvertirValeur();
    server.write(val);
  }
}

void setup() {
  Serial.begin(9600);
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(bouton1, INPUT);
  pinMode(bouton2, INPUT);
  Ethernet.begin(mac, ip);
  Serial.print("Mon IP : ");
  Serial.println(Ethernet.localIP());
  server.begin();
}

void loop() {
  EthernetClient client = server.available();
  buttonState = digitalRead(bouton1);
  digitalWrite(led1, HIGH);

  if (client) {
    while(client.connected()) {
      // si le client nous envoie quelque chose
      if (client.available() > 0){
        char reception = client.read(); //on lit ce qu'il raconte
        msg = msg + reception; // Remise à zero de la variable de réception
          if(reception == '$'){
            // interpretation d'une commande
            Serial.println("Message Reçu : "+ msg);
            ConnexionApplication();
            EnvoiMesureInstant();
            // fin d'interprétation des messages
            msg = "";
          } // fermeture du if(reception)
        } // fermeture if (client.available)
      } // fermeture while
  } // fermeture if(client)

  /*if (client.connect(serv, 80))
  {
    Serial.println("Connecté !");
  }
  else
  {
    Serial.println("Erreur !");
  }*/

  if(buttonState == HIGH)
  {
    capteurIntensite.ConvertirValeur();
  }
  //BDD.ConnexionBDD();
}
