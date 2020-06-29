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
    public partial class AltaUsuario : System.Web.UI.Page
    {
        public Usuario producto = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {


            }
            catch (Exception)
            {

                throw;
            }



        }
        protected void ALta_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            DomicilioNegocio negociodom = new DomicilioNegocio();
            TipoNegocio negociotipo = new TipoNegocio();
            try
            {

                producto.Nombre = Txtnombre.Text;
                producto.Apellido = TxtApellido.Text;
                producto.DNI = Convert.ToInt32(TxtDni.Text);
                //producto.idmarca.Id =Convert.ToInt32(Session[Session.SessionID + "Drop"]);
                producto.idDomicilio = new Domicilio();
                producto.idDomicilio.calle = "";
                producto.idDomicilio.altura = 0;
                producto.idDomicilio.CodigoPostal = 0;
                producto.idDomicilio.Partido = "";
                producto.idDomicilio.provincia ="";
                producto.idDomicilio.piso =0;
                producto.Edad = Convert.ToInt32(TxtEdad.Text) ;
                //producto.idtipo = new TipoUsuario();
                producto.idtipo.Email = TxtEmail.Text;
                producto.idtipo.Contraseña = TxtContraseña.Text;
                //CargarContacto(producto.contacto);
                Cargartipo(producto.idtipo);
                Cargardomicilio(producto.idDomicilio);
                producto.idtipo=(TipoUsuario)Session[Session.SessionID+"Tipo"];
                producto.idDomicilio=(Domicilio)Session[Session.SessionID+"Domicilio"];
                //producto.contacto = (Contacto)Session[Session.SessionID + "Contacto"];
                negocio.AgregarUsuario(producto);
                Response.Redirect("Cuenta.aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void Cargartipo(TipoUsuario nuevo)
        {
            TipoNegocio negocio = new TipoNegocio();
            negocio.AgregarTipo(nuevo);
            List<TipoUsuario> lista = new List<TipoUsuario>();
            TipoUsuario tipo = new TipoUsuario();
            lista = negocio.listarTipo();
            if(lista!=null)
            {
               tipo=lista.Find(J => J.Email== nuevo.Email&& J.Contraseña==nuevo.Contraseña);
                Session.Add(Session.SessionID + "Tipo", tipo);
            }

        } 
        protected void Cargardomicilio(Domicilio nuevo)
        {
           DomicilioNegocio negocio = new DomicilioNegocio();
            negocio.AgregarDomicilio(nuevo);
            List<Domicilio> lista = new List<Domicilio>();
            Domicilio tipo = new Domicilio();
            lista = negocio.listarDomicilio();
            if(lista!=null)
            {
               tipo=lista.Find(J => J.calle== nuevo.calle && J.altura == nuevo.altura
               && J.CodigoPostal == nuevo.CodigoPostal && J.piso == nuevo.piso );
                Session.Add(Session.SessionID + "Domicilio", tipo);
            }

        }
        
    }
}
