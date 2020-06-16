using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Domicilio
    {
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string calle { get; set; }
        public int CodigoPostal { get; set; }
        public int piso { get; set; }
        public int altura { get; set; }
    }
}
