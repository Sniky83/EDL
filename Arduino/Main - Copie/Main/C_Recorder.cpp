#include "C_Recorder.h"

float C_Recorder::Mesurer()
{
  uint16_t LectureVal = analogRead(Entree[val]);
  float intensite = ((A[val].toFloat()*LectureVal)-B[val].toFloat());
  return intensite;
}

String C_Recorder::ComposerTrame()
{
  String trame = "";
  String ligne = (String)Entree[val];
  float intensite = Mesurer();
  float Calcul_Puissance = 230*intensite;
  String puissance = String(Calcul_Puissance);
  trame = "EDL_ENR_L"+ligne+"_I_"+intensite+"_P_"+puissance+"_ID_"+ID[val]+"!";
  return trame;
}

String C_Recorder::Emettre()
{
  if(val > 0)
  {
    val = val - 1;
    String trame = ComposerTrame();
    return trame;
  }
  else
  {
    val = reset;
    String trame = ComposerTrame();
    delay(2000);
    return trame;
  }
}