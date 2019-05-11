using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technicien_capteurs
{
    public class Capteur
    {
        public int Id { get; set; } = -1;
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Calibre { get; set; }
        public float A { get; set; }
        public float B { get; set; }

        /// <summary>
        /// Détermine un capteur
        /// </summary>
        /// <param name="id">id capteur</param>
        /// <param name="nom"></param>
        /// <param name="marque"></param>
        /// <param name="modele"></param>
        /// <param name="calibre"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Capteur(int id, string nom, string marque, string modele, int calibre, float a, float b)
        {
            Id = id;
            Nom = nom;
            Marque = marque;
            Modele = modele;
            Calibre = calibre;
            A = a;
            B = b;
        }

        public Capteur()
        {
        }
    }
}
