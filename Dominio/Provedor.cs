using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Provedor
    {

        public Provedor()
        {
            Id = 0;
            Descripcion = "";
            Activo = 1;

        }

   
    public int Id { get; set; }
    public string Descripcion { get; set; }
        public int Activo { get; set; }

        public override string ToString()
    {
        return Descripcion;
    }

    }
}
