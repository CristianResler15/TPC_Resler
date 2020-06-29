using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public Persona()
        {
            Nombre = "";
            Apellido = "";
            Edad = 0;
            DNI = 0;
            idDomicilio = new Domicilio();
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int DNI { get; set; }
        public Domicilio idDomicilio { get; set; }      
    }
}
