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
    public partial class prueba : System.Web.UI.Page
    {
        public Usuario Articulo { get; set; }
        List<Usuario> Listausu = new List<Usuario>();
        UsuarioNegocio negocio = new UsuarioNegocio();
        AccesoDatos datos = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            Listausu = negocio.listarUsuario();

            if (!IsPostBack)
            {
                dgvUsu.DataSource = Listausu;
                dgvUsu.DataBind();

            }

        }
        protected void dgvProv_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void dgvProv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Listausu = negocio.listarUsuario();


            int index = Convert.ToInt32(e.CommandArgument);
            string IDSeleccionado = dgvUsu.Rows[index].Cells[0].Text;
            int idSeleccionado = Convert.ToInt32(IDSeleccionado);
           Usuario aux = Listausu.Find(A => A.Id == idSeleccionado);
            if (Listausu != null)
            {
                if (e.CommandName == "Select2")
                {
                    Session.Add(Session.SessionID + "Usuario", aux);
                    Response.Redirect("ModificarProvedor.aspx");

                }
                else
                {
                    negocio.eliminarUsuario(aux.Id);
                    Response.Redirect("ListaProvedor.aspx");

                }

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaUsuario.aspx");
        }
    }
}