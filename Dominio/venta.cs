using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class venta
    {
        public venta()
        {

            producto = new Productos();
            Total = 0;
            Envios = false;
        }
        public int Id { get; set; }
        public Productos producto { get; set; }
        public Usuario usuario { get; set; }
        public bool Envios { get; set; }
        public decimal Total { get; set; }
        public DateTime fechaventa { get; set; }

    }
}
