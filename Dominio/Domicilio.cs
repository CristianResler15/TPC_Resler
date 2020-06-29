using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Domicilio
    {
        public Domicilio()
        {
            Partido = "";
            provincia = "";
            calle = "";
            CodigoPostal= 0;
            piso= 0;
            altura= 0;
            Activo = 1;
        }

        public string Partido { get; set; }
        public string provincia { get; set; }
        public string calle { get; set; }
        public int CodigoPostal { get; set; }
        public int piso { get; set; }
        public int altura { get; set; }
        public int id { get; set; }
        public int Activo { get; set; }
    }
}
