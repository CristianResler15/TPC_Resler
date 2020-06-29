using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Dominio;
using System.Management.Instrumentation;

namespace Negocio
{
    public class MarcaNegocio
    {
        public void AgregarMarca( Marca nuevo)
        {


            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarMarca");
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Marca> listarMarcas()
        {
            List<Marca> ListadoMarca = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarMarca");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Marca aux= new Marca();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.Descripcion = datos.lector.GetString(1);
                    ListadoMarca.Add(aux);
                }

                return ListadoMarca;
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
        public void modificarMarca ( Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spModificarMarca");
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);
                datos.agregarParametro("@Id", nuevo.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarMarca(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarMarca");
                datos.agregarParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
