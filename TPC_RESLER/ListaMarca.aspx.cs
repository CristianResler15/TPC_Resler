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
    public partial class WebForm5 : System.Web.UI.Page
    {
          public Marca Articulo { get; set; }
        List<Marca> ListaMarcas = new List<Marca>();
        MarcaNegocio negocio = new MarcaNegocio();
        AccesoDatos datos = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaMarcas=negocio.listarMarcas();

            if (!IsPostBack)
            {
                dgvMarca.DataSource = ListaMarcas;
                dgvMarca.DataBind();

            }
           
        }
        protected void dgvMarca_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void dgvMarca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ListaMarcas = negocio.listarMarcas();
           
            int index = Convert.ToInt32(e.CommandArgument);
            string IDSeleccionado = dgvMarca.Rows[index].Cells[0].Text;
            int idSeleccionado = Convert.ToInt32(IDSeleccionado);
            Marca aux=ListaMarcas.Find(A => A.Id == idSeleccionado);
            if ( ListaMarcas!= null)
            {
                if  (e.CommandName=="Select2")
                {
                    Session.Add(Session.SessionID + "Marca", aux);
                    Response.Redirect("ModificarMarca.aspx");

                }
                if(e.CommandName=="Select")
                {
                negocio.eliminarMarca(aux.Id);
                Response.Redirect("ListaMarca.aspx");

                }

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

            Response.Redirect("AltaMarca.aspx");

        }
    }
    }