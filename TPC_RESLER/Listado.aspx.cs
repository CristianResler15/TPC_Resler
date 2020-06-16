using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_RESLER
{
    public partial class _Default : Page
    {
        public List<Productos> listaProductos { get; set; }
        Productos producto = new Productos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProductosNegocio negocio = new ProductosNegocio();
                listaProductos = negocio.listar2();
                if (!IsPostBack)
                {

                    repetidor.DataSource = listaProductos;
                    repetidor.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnArgumento_Click(object sender, EventArgs e)
        {

            ProductosNegocio negocio = new ProductosNegocio();
            Carrito carro = new Carrito();

            try
            {

                listaProductos = negocio.listar2();
                var articuloSelec = Convert.ToInt32(((Button)sender).CommandArgument);
                producto = listaProductos.Find(J => J.id == articuloSelec);

                if (!carro.producto.Exists(A => A.id == producto.id))
                {
                    carro.producto.Add(producto);
                    carro.Total += producto.Precio;
                    carro.cantidad++;
                    Session.Add(Session.SessionID + "articulo", carro);
                    Session.Add(Session.SessionID + "Cantidad", carro.cantidad);
                    Session.Add(Session.SessionID + "Total", carro.Total);
                }

                Response.Redirect("Listado.aspx");
            }
            catch (Exception)
            {


            }

        }
    }
}