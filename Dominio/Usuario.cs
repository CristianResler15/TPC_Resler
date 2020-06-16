using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public Persona persona { get; set; }
        public Contacto contacto { get; set; }
        public TipoUsuario idtipo { get; set; }
        public bool activo { get; set; }
        
    }
}
