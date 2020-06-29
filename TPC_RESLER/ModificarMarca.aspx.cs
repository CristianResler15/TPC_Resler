using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_RESLER
{
    public partial class ModificarMarca : System.Web.UI.Page
    {
        Marca marca = new Marca();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Marca aux = new Marca();
                aux = (Marca)Session[Session.SessionID + "Marca"];
                TxtDescripcion.Text = aux.Descripcion;
                TxtID.Text = aux.Id.ToString();
            }
        }
        protected void Modificar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {

                Marca marca = new Marca();
                marca.Descripcion = TxtDescripcion.Text;
                marca.Id =Convert.ToInt32(TxtID.Text);
                negocio.modificarMarca(marca);
                Response.Redirect("ListaMarca.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}