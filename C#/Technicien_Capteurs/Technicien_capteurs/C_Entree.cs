using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technicien_capteurs
{
    public class C_Entree
    {
        public ushort Id { get; set; }
        public byte Entree { get; set; }
        public string Nom_Entree { get; set; }
        public C_Capteur Capteur { get; set; }
        public float Intensite { get; set; }
        public float Puissance { get; set; }
    }
}
