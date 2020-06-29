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
    public partial class ListaProvedor : System.Web.UI.Page
    {
          public Provedor Articulo { get; set; }
        List<Provedor> ListaProv= new List<Provedor>();
       ProvedorNegocio negocio = new ProvedorNegocio();
        AccesoDatos datos = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaProv = negocio.listarProve();

            if (!IsPostBack)
            {
                dgvProv.DataSource = ListaProv;
                dgvProv.DataBind();

            }

        }
        protected void dgvProv_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void dgvProv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ListaProv = negocio.listarProve();


            int index = Convert.ToInt32(e.CommandArgument);
            string IDSeleccionado = dgvProv.Rows[index].Cells[0].Text;
            int idSeleccionado = Convert.ToInt32(IDSeleccionado);
            Provedor aux = ListaProv.Find(A => A.Id == idSeleccionado);
            if (ListaProv != null)
            {
                if (e.CommandName == "Select2")
                {
                    Session.Add(Session.SessionID + "Provedor", aux);
                    Response.Redirect("ModificarProvedor.aspx");

                }
                else
                {
                    negocio.eliminarProve(aux.Id);
                    Response.Redirect("ListaProvedor.aspx");

                }

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaProvedor.aspx");
        }
    }

    }
