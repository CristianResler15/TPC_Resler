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
        VentaNegocio negocio1 = new VentaNegocio();
        UsuarioNegocio negocio2 = new UsuarioNegocio();
        Usuario usu = new Usuario();
        List<venta> lista = new List<venta>();
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
                if (e.CommandName == "Select")
                {
                    carro.cantidad--;
                    carro.Total -= Articulo.Precio;
                    carro.producto.Remove(Articulo);
                    Session.Add(Session.SessionID + "articulo", carro);
                    Session.Add(Session.SessionID + "Cantidad", carro.cantidad);
                    Session.Add(Session.SessionID + "Total", carro.Total);
                    Response.Redirect("Carrodecompras.aspx");
                }
                if (e.CommandName == "Select2")
                {
                    Articulo = carro.producto.Find(J => J.id == idSeleccionado);
                    Articulo.Cantidad++;
                    carro.cantidad++;
                    carro.Total += Articulo.Precio;
                    Session.Add(Session.SessionID + "articulo", carro);
                    Session.Add(Session.SessionID + "Cantidad", carro.cantidad);
                    Session.Add(Session.SessionID + "Total", carro.Total);
                    Response.Redirect("Carrodecompras.aspx");
                }
                if (e.CommandName == "Select3")
                {
                    Articulo = carro.producto.Find(J => J.id == idSeleccionado);
                    if(Articulo.Cantidad>1)
                    {
                
                    Articulo.Cantidad--;
                    carro.cantidad--;
                    carro.Total -= Articulo.Precio;
                    Session.Add(Session.SessionID + "articulo", carro);
                    Session.Add(Session.SessionID + "Cantidad", carro.cantidad);
                    Session.Add(Session.SessionID + "Total", carro.Total);
                    Response.Redirect("Carrodecompras.aspx");
                     
                    }
                    
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            venta aux = new venta();
            venta nueva = new venta();
            int bandera = 0;
            carro = (Carrito)Session[Session.SessionID + "articulo"];
            foreach (var item in carro.producto)
            {
                nueva.fechaventa = DateTime.Now.Date;
                nueva.producto = item;
                nueva.Total = Convert.ToDecimal( Session[Session.SessionID + "Total"]);
                if (bandera==0)
                {
                negocio1.AgregarVenta(nueva);
                    bandera++;
                }
                lista = negocio1.listarTipo();
                aux = lista[lista.Count - 1];
                nueva.Id = aux.Id;
                negocio1.AgregarVentaxProducto(nueva);
            }
            Usuario usua = new Usuario();
            usua = (Usuario)Session[Session.SessionID + "Usuario"];
             negocio1.AgregarVentaxUsuario(nueva,usua.Id);
            Response.Redirect("Listado.aspx");
        }
    }
}