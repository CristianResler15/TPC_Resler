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
    public partial class WebForm4 : System.Web.UI.Page
    {
        public Productos Articulo { get; set; }
        List<Productos> ListaProductos = new List<Productos>();
        ProductosNegocio negocio = new ProductosNegocio();
        AccesoDatos datos = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaProductos = negocio.listar2();

            if (!IsPostBack)
            {
                dgvProductos.DataSource = ListaProductos;
                dgvProductos.DataBind();

            }

        }


        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void Btn_Alta(object sender, EventArgs e)
        {
            Response.Redirect("AltaProducto.aspx");

        }
        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ListaProductos = negocio.listar2();

            int index = Convert.ToInt32(e.CommandArgument);
            string IDSeleccionado = dgvProductos.Rows[index].Cells[0].Text;
            int idSeleccionado = Convert.ToInt32(IDSeleccionado);
            Productos aux = ListaProductos.Find(A => A.id == idSeleccionado);
            if (ListaProductos != null)
            {
                if (e.CommandName == "Select2")
                {
                    Session.Add(Session.SessionID + "Producto", aux);
                    Response.Redirect("ModificarProducto.aspx");

                }
                if (e.CommandName == "Select")
                {
                    negocio.eliminar(aux.id);
                    Response.Redirect("ListaProducto.aspx");

                }

            }
        }
    }
}