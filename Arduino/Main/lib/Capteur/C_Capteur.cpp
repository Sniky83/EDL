#include "C_Capteur.h"

float C_Capteur::LireValeur()
{
  val = analogRead(A0);
  delay(500);
  return val;
}

float C_Capteur::ConvertirValeur()
{
  val = LireValeur();
  val = ((2.91/255)*(val)-5.7629);
  Serial.print("Intensite = ");
  Serial.print(val);
  Serial.println(" A");
  return val;
}
