using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Productos
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca idmarca { get; set; }
        public Categoria idcategoria { get; set; }
        public Provedor idprovedor { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }
       
       


    }
}
