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
        public string IpArduino { get; set; }
        public byte Entree { get; set; }
        public string Nom_Entree { get; set; }
        public string Nom_Capteur { get; set; }

        public C_Entree()
        {

        }
    }
}
