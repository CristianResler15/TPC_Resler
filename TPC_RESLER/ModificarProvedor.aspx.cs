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
    public partial class ModificarProvedor : System.Web.UI.Page
    {
        Provedor prov = new Provedor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Provedor aux = new Provedor();
                aux = (Provedor)Session[Session.SessionID + "Provedor"];
                TxtDescripcion.Text = aux.Descripcion;
                TxtID.Text = aux.Id.ToString();
            }
        }
        protected void Modificar_Click(object sender, EventArgs e)
        {
           ProvedorNegocio negocio = new ProvedorNegocio();
            try
            {

                Provedor provedor = new Provedor();
                prov.Descripcion = TxtDescripcion.Text;
                prov.Id = Convert.ToInt32(TxtID.Text);
                negocio.modificarProve(prov);
                Response.Redirect("ListaProvedor.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}