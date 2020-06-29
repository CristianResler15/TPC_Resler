using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoUsuario
    {
        public TipoUsuario()
        {
            Nombre = "Cliente";
            Contraseña = "";
            Email = "";
            Contraseña = "";
            Acceso = 1;
            activo = 1;
        }

        public int id { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public int Acceso { get; set; }
        public int activo { get; set; }

    }
}
