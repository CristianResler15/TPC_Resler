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
    public partial class ListaCategoria : System.Web.UI.Page
    {
        public Categoria Articulo { get; set; }
        List<Categoria> ListaCat = new List<Categoria>();
        CategoriaNegocio negocio = new CategoriaNegocio();
        AccesoDatos datos = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaCat = negocio.listarCat();

            if (!IsPostBack)
            {
                dgvCat.DataSource = ListaCat;
                dgvCat.DataBind();

            }

        }
        protected void dgvCat_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void dgvCat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ListaCat = negocio.listarCat();


            int index = Convert.ToInt32(e.CommandArgument);
            string IDSeleccionado = dgvCat.Rows[index].Cells[0].Text;
            int idSeleccionado = Convert.ToInt32(IDSeleccionado);
            Categoria aux = ListaCat.Find(A => A.Id == idSeleccionado);
            if (ListaCat != null)
            {
                if (e.CommandName == "Select2")
                {
                    Session.Add(Session.SessionID + "Categoria", aux);
                    Response.Redirect("ModificarCategoria.aspx");

                }
                else
                {
                    negocio.eliminarCat(aux.Id);
                    Response.Redirect("ListaCategoria.aspx");

                }

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaCategoria.aspx");
        }
    }
}