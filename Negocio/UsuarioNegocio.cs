using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public void AgregarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarUsuario");
                datos.agregarParametro("@Nombre", nuevo.Nombre);
                datos.agregarParametro("@Apellido", nuevo.Apellido);
                datos.agregarParametro("@Edad", nuevo.Edad.ToString());
                datos.agregarParametro("@DNI", nuevo.DNI.ToString());
                datos.agregarParametro("@idtipo", nuevo.idtipo.id.ToString());
                //datos.agregarParametro("@IdContacto", nuevo.contacto.id.ToString());
                datos.agregarParametro("@IdDomicilio", nuevo.idDomicilio.id.ToString());
                datos.agregarParametro("@Activo", nuevo.activo.ToString());
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Usuario> listarUsuario()
        {
            List<Usuario> listadoProductos = new List<Usuario>();
            Usuario aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarUsuario");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new Usuario();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Apellido = datos.lector.GetString(2);
                    aux.Edad = datos.lector.GetInt32(3);
                    aux.DNI = datos.lector.GetInt32(4);
                    aux.idtipo = new TipoUsuario();
                    aux.idtipo.id = datos.lector.GetInt32(5); 
                    aux.idtipo.Email = (string)datos.lector["Emailusu"];
                    aux.idtipo.Contraseña = (string)datos.lector["Contrausu"];
                    aux.idtipo.Nombre = (string)datos.lector["nombretipo"];
                    aux.idDomicilio = new Domicilio();
                    aux.idDomicilio.Partido = (string)datos.lector["ciudadusu"];
                    aux.idDomicilio.id = datos.lector.GetInt32(10);
                    aux.idDomicilio.provincia = (string)datos.lector["Provusu"];
                    aux.idDomicilio.piso = datos.lector.GetInt32(12);
                    aux.idDomicilio.altura = datos.lector.GetInt32(13);
                    aux.idDomicilio.calle = (string)datos.lector["Calleusu"];
                    aux.idDomicilio.CodigoPostal = datos.lector.GetInt32(15);
                    listadoProductos.Add(aux);

                }

                return listadoProductos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearSP("spModificarUsuario");
                datos.agregarParametro("@id", nuevo.Id.ToString());
                datos.agregarParametro("@Nombre", nuevo.Nombre);
                datos.agregarParametro("@Apellido", nuevo.Apellido);
                datos.agregarParametro("@Edad", nuevo.Edad.ToString());
                datos.agregarParametro("@DNI", nuevo.DNI.ToString());
                datos.agregarParametro("@idtipo", nuevo.idtipo.id.ToString());
                //datos.agregarParametro("@IdContacto", nuevo.contacto.id.ToString());
                datos.agregarParametro("@IdDomicilio", nuevo.idDomicilio.id.ToString());
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminar");
                datos.agregarParametro("@ID", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
