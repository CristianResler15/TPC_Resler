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
    public partial class Contact : Page
    {
        public Productos Articulo { get; set; }
        List<Productos> ListaArticulos = new List<Productos>();
        Carrito carro = new Carrito();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "Cantidad"] != null && Session[Session.SessionID + "Total"] != null)
            {
                LblCarrito.Text = Session[Session.SessionID + "Cantidad"].ToString();
                LblTotal.Text = LblTotal.Text + Session[Session.SessionID + "Total"].ToString();
            }
            carro = (Carrito)Session[Session.SessionID + "articulo"];
            if (carro != null)
            {

                dgvCarrito.DataSource = carro.producto;
                dgvCarrito.DataBind();
            }
        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void dgvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            string IDSeleccionado = dgvCarrito.Rows[index].Cells[0].Text;
            int idSeleccionado = Convert.ToInt32(IDSeleccionado);
            if (carro.producto.Exists(A => A.id == idSeleccionado))
            {
                Articulo = carro.producto.Find(J => J.id == idSeleccionado);
                carro.cantidad--;
                carro.Total -= Articulo.Precio;
                carro.producto.Remove(Articulo);
                Session.Add(Session.SessionID + "articulo", carro);
                Session.Add(Session.SessionID + "Cantidad", carro.cantidad);
                Session.Add(Session.SessionID + "Total", carro.Total);
                Response.Redirect("Carrodecompras.aspx");

            }
        }
    }
}