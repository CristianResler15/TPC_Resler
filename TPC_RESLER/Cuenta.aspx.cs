using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_RESLER
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario nuevo = new Usuario();
            List<Usuario> lista = new List<Usuario>();
            lista = negocio.listarUsuario();
            if (lista != null)
            {
                nuevo = lista.Find(k => k.idtipo.Email == TxtEmail.Text && k.idtipo.Contraseña == TxtContraseña.Text);
                if (nuevo != null)
                {
                    Session.Add(Session.SessionID + "Usuario", nuevo);
                    Response.Redirect("Listado.aspx");
                }
                else
                {
                    Response.Redirect("AltaUsuario.aspx");
                }
            }
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AltaUsuario.aspx");
        }
    }
}