using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technicien_capteurs
{
    public class C_Capteur
    {
        public ushort Id { get; set; }
        public string IpArduino { get; set; }
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Model { get; set; }
        public byte Calibre { get; set; }
        public float A { get; set; }
        public float B { get; set; }

        /*public C_Capteur(ushort Id, string ipArduino, string nom, string marque, string modele, byte calibre, float a, float b)
        {
            id = Id;
            IpArduino = ipArduino;
            Nom = nom;
            Marque = marque;
            Modèle = modele;
            Calibre = calibre;
            A = a;
            B = b;
        }*/

        public C_Capteur()
        {
        }
    }
}
