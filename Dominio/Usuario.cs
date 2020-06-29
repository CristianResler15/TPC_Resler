using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Usuario : Persona
    {
        public Usuario()
        {
         
            idtipo = new TipoUsuario();
            activo = 1;
        }
        public int Id { get; set; }
        public TipoUsuario idtipo { get; set; }
        public int activo { get; set; }
        
    }
}
