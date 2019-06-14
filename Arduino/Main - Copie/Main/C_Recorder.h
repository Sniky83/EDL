#ifndef ___C_Recorder_h
#define ___C_Recorder_h

#include "Arduino.h" //Pour pouvoir utiliser les méthodes de l'Arduino

class C_Recorder
{
	public:
	byte val;
	byte reset;
	byte Entree[9];
	String A[9];
	String B[9];
	uint16_t ID[9];
	String Emettre();

	private:
	float Mesurer();
	String ComposerTrame();
};
#endif
