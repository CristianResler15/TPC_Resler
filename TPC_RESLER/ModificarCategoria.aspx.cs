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
    public partial class ModificarCategoria : System.Web.UI.Page
    {
        Categoria marca = new Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Categoria aux = new Categoria();
                aux = (Categoria)Session[Session.SessionID + "Categoria"];
                TxtDescripcion.Text = aux.Descripcion;
                TxtID.Text = aux.Id.ToString();
            }
        }
        protected void Modificar_Click(object sender, EventArgs e)
        {
           CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
               Categoria marca = new Categoria();
                marca.Descripcion = TxtDescripcion.Text;
                marca.Id = Convert.ToInt32(TxtID.Text);
                negocio.modificarCat(marca);
                Response.Redirect("ListaCategoria.aspx");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
     
    }
}