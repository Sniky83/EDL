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
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Model { get; set; }
        public byte Calibre { get; set; }
        public string A { get; set; }
        public string B { get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }
}
