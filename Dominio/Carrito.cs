using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public Carrito()
        {
            producto = new List<Productos>();
            cantidad = 0;
            Total = 0;
        }
        public List<Productos> producto { get; set; }
        public int cantidad { get; set; }
        public decimal Total { get; set; }

    }
}
