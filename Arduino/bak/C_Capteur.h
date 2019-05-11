#ifndef C_Capteur_h
#define C_Capteur_h

#include "Arduino.h" //Pour pouvoir utiliser les méthodes de l'Arduino

class C_Capteur
{
	//int Position;
	public:
	void ConvertirValeur(void);
  
	private:
	int LireValeur(void);
};
#endif
