#include "Arduino.h"
#include "C_Capteur.h"
#include "C_BDD.h"

#include <Ethernet.h>

void setup();
void loop();

C_Capteur capteurIntensite;
C_BDD BDD;


int led1 = 2; //led droite
int led2 = 3; //led gauche
int bouton1 = 4; //bouton droite
int bouton2 = 5; //bouton gauche

int val;
int buttonState = 0;
String msg = "";
bool flag = false;

void setup() {
  Serial.begin(9600);
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(bouton1, INPUT);
  pinMode(bouton2, INPUT);
  Serial.print("test");
  // Donne une seconde au shield pour s'initialiser
  delay(1000);
}

void loop() {
  buttonState = digitalRead(bouton1);

  if(buttonState == HIGH)
  {
    Serial.print("ICI");
    //capteurIntensite.ConvertirValeur();
  }
}
