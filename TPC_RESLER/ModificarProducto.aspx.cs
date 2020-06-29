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
    public partial class ModificarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Productos aux = new Productos();
                aux = (Productos)Session[Session.SessionID + "Producto"];
                TxtDescripcion.Text = aux.Descripcion;
                TxtID.Text = aux.id.ToString();
                Txtidcategoria.Text = aux.idcategoria.ToString();
                TxtIdmarca.Text = aux.idmarca.ToString();
                Txtidprovedor.Text = aux.idprovedor.ToString();
                Txtimagen.Text = aux.ImagenUrl.ToString();
                Txtnombre.Text = aux.Nombre.ToString();
                TxtPrecio.Text = aux.Precio.ToString();
            }
        }
        protected void Modificar_Click(object sender, EventArgs e)
        {
            ProductosNegocio negocio = new ProductosNegocio();
            try
            {
                Productos Producto = new Productos();
                Producto.Descripcion = TxtDescripcion.Text;
                Producto.id = Convert.ToInt32(TxtID.Text);
                Producto.idcategoria.Id = Convert.ToInt32(Txtidcategoria.Text);
                Producto.idprovedor.Id = Convert.ToInt32(Txtidprovedor.Text);
                Producto.idmarca.Id = Convert.ToInt32(TxtIdmarca.Text);
                Producto.Nombre= Txtnombre.Text;
                Producto.Precio = Convert.ToInt32(TxtPrecio.Text);
                Producto.ImagenUrl = Txtimagen.Text;
                negocio.modificar(Producto);
                Response.Redirect("ListaProducto.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}