#ifndef ___C_Recorder_h
#define ___C_Recorder_h

#include "Arduino.h" //Pour pouvoir utiliser les méthodes de l'Arduino

class C_Recorder
{
	public:
	byte val;
	byte Entree[];
	float A[];
	float B[];
	uint16_t ID[];

	float Mesurer();
	String ComposerTrame();
  
	//private:
};
#endif
