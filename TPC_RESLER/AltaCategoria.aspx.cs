using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_RESLER
{
    public partial class AltaCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ALta_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                Categoria producto = new Categoria();
                producto.Descripcion = TxtDescripcion.Text;
                negocio.AgregarCat(producto);
                Response.Redirect("ListaCategoria.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}