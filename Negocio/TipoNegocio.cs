using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TipoNegocio
    {

        public void AgregarTipo(TipoUsuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAgregarTipo");
                datos.agregarParametro("@Nombre", nuevo.Nombre);
                datos.agregarParametro("@Email", nuevo.Email);
                datos.agregarParametro("@Contraseña", nuevo.Contraseña);
                datos.agregarParametro("@Acceso", nuevo.Acceso);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<TipoUsuario> listarTipo()
        {
            List<TipoUsuario> Listadotipo = new List<TipoUsuario>();
            TipoUsuario aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearSP("spListarTipoUsu");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new TipoUsuario();
                    aux.id = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Email = datos.lector.GetString(2);
                    aux.Contraseña= datos.lector.GetString(3);
                    aux.Acceso = datos.lector.GetInt32(4);
                    Listadotipo.Add(aux);
                }

                return Listadotipo;
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
        public void modificartipo(TipoUsuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearSP("spModificarTipo");
                datos.agregarParametro("@Descripcion", nuevo.Nombre);
                datos.agregarParametro("@Email", nuevo.Email);
                datos.agregarParametro("@Contraseña", nuevo.Contraseña);
                datos.agregarParametro("@Acceso", nuevo.Acceso);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarTipo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarTipo");
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
