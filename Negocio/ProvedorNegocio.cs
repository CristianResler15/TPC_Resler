using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Dominio;
namespace Negocio
{
    public class ProvedorNegocio
    {
        public void AgregarProve(Provedor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAgregarProvedor");
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Provedor> listarProve()
        {
            List<Provedor> ListadoProve = new List<Provedor>();
            Provedor aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearSP("spListarProvedor");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new Provedor();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.Descripcion = datos.lector.GetString(1);
                    ListadoProve.Add(aux);
                }

                return ListadoProve;
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
        public void modificarProve(Provedor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearSP("spModificarProvedor");
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);
                datos.agregarParametro("@Id", nuevo.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarProve(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarProvedor");
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
