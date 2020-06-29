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
    public partial class AltaProvedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ALta_Click(object sender, EventArgs e)
        {
            ProvedorNegocio negocio = new ProvedorNegocio();
            try
            {
                Provedor producto = new Provedor();
                producto.Descripcion = TxtDescripcion.Text;
                negocio.AgregarProve(producto);
                Response.Redirect("ListaProvedor.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}