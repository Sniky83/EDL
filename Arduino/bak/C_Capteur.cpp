#include "C_Capteur.h"

int C_Capteur::LireValeur()
{
  int val;
  val = analogRead(A0);
  delay(500);
  return val;
}

void C_Capteur::ConvertirValeur()
{
  int val = LireValeur();
  Serial.print("Intensite = ");
  Serial.println(val);
}
