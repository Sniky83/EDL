#include "C_Recorder.h"

float C_Recorder::Mesurer()
{
  //((2.91/255)*(val)-5.7629);
  uint16_t LectureVal = analogRead(Entree[val]);
  float intensite = ((A[val]*LectureVal)-B[val]);
  return intensite;
}

String C_Recorder::ComposerTrame()
{
  byte countVal = sizeof(val);
  //Serial.println(countVal);
  val = 0;
  String trame = "";
  /*while()
  {
    String ligne = (String)Entree[val];
    float Calcul_Puissance = 230*Mesurer();
    String puissance = String(Calcul_Puissance);
    trame = "EDL_L"+ligne+"_P_"+puissance+"_ID_"+ID[val]+"!";
    val++;
  }*/
  return trame;
}