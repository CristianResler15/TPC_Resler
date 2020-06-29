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
    public partial class WebForm3 : System.Web.UI.Page
    {
        public Productos producto = new Productos();
        public List<Marca> ListaMarca = new List<Marca>();
        public List<Categoria> ListaCategoria = new List<Categoria>();
        public List<Provedor> ListaProvedor= new List<Provedor>();
        public Marca aux = new Marca();
        public Provedor aux2 = new Provedor();
        public Categoria aux3 = new Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            CategoriaNegocio negocio2 = new CategoriaNegocio();
            ProvedorNegocio negocio3 = new ProvedorNegocio();

            try
            {
                if (!IsPostBack)
                {
                    List<Marca> listanueva = new List<Marca>();
                    listanueva = negocio.listarMarcas();
                    List<Categoria> listanueva2 = new List<Categoria>();
                    listanueva2 = negocio2.listarCat();
                    List<Provedor> listanueva3 = new List<Provedor>();
                    listanueva3 = negocio3.listarProve();
                    CboMarca.DataSource = listanueva;
                    Cbocat.DataSource = listanueva2;
                    CboProve.DataSource = listanueva3;
                    CboMarca.DataBind();
                    Cbocat.DataBind();
                    CboProve.DataBind();
                    CboMarca.DataTextField = "id";
                    CboMarca.DataValueField = "Descripcion";
                    Cbocat.DataTextField = "id";
                    Cbocat.DataValueField = "Descripcion";
                    CboProve.DataTextField = "id";
                    CboProve.DataValueField = "Descripcion";
                    
                }

            }
            catch (Exception)
            {

                throw;
            }



        }
        protected void ALta_Click(object sender, EventArgs e)
        {
            ProductosNegocio negocio = new ProductosNegocio();
            try
            {
                producto.Nombre = Txtnombre.Text;
                producto.Descripcion = TxtDescripcion.Text;
                producto.ImagenUrl = TxtImagen.Text;
                producto.Precio = Convert.ToDecimal(TxtPrecio.Text);
                producto.Cantidad = 1;
                producto.idmarca.Id = (int)Session[Session.SessionID + "idmarca"];
                producto.idcategoria.Id = (int)Session[Session.SessionID + "idcat"];
                producto.idprovedor.Id = (int)Session[Session.SessionID + "idprov"];
                negocio.Agregar(producto);
                Response.Redirect("Listado.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void CboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaMarca = new List<Marca>();
            MarcaNegocio negocio = new MarcaNegocio();
            ListaMarca = negocio.listarMarcas();
            String idmarca =CboMarca.SelectedItem.Value;
            Marca id =ListaMarca.Find(k => k.Descripcion == idmarca);
            Session.Add(Session.SessionID + "idmarca",id.Id);
        }

        protected void Cbocat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaCategoria = new List<Categoria>();
            CategoriaNegocio negocio = new CategoriaNegocio();
            ListaCategoria = negocio.listarCat();
            String idmarca = Cbocat.SelectedItem.Value;
            Categoria id = ListaCategoria.Find(k => k.Descripcion == idmarca);
            Session.Add(Session.SessionID + "idcat", id.Id);
        }
        protected void CboProve_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaProvedor= new List<Provedor>();
            ProvedorNegocio negocio = new ProvedorNegocio();
            ListaProvedor = negocio.listarProve();
            String idmarca = CboProve.SelectedItem.Value;
            Provedor id = ListaProvedor.Find(k => k.Descripcion == idmarca);
            Session.Add(Session.SessionID + "idprov", id.Id);
        }
    }
}