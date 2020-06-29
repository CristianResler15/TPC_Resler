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
    public partial class AltaMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ALta_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                Marca producto = new Marca();
                producto.Descripcion = TxtDescripcion.Text;
                negocio.AgregarMarca(producto);
                Response.Redirect("ListaMarca.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}