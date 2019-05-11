#ifndef ___C_Capteur_h
#define ___C_Capteur_h

#include "Arduino.h" //Pour pouvoir utiliser les méthodes de l'Arduino

class C_Capteur
{
	//int Position;
	public:
	float val;
	float ConvertirValeur(void);
  
	private:
	float LireValeur(void);
};
#endif
