using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Productos
    {
        public Productos()
        {
            id = 0;
            Nombre = "";
            Descripcion = "";
            ImagenUrl = "";
            Precio = 0;
            idmarca = new Marca();
            idcategoria= new Categoria();
            idprovedor = new Provedor();
            Cantidad = 0;
            Activo = 1;
        }
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca idmarca { get; set; }
        public Categoria idcategoria { get; set; }
        public Provedor idprovedor { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }
        public int Cantidad { get; set; }
        public int Activo { get; set; }


    }
}
