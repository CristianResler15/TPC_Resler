using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public void AgregarCat(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAgregarCategoria");
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Categoria> listarCat()
        {
            List<Categoria> ListadoCat = new List<Categoria>();
            Categoria aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarCategoria");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new Categoria();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.Descripcion = datos.lector.GetString(1);
                    ListadoCat.Add(aux);
                }

                return ListadoCat;
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
        public void modificarCat(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearSP("spModificarCategoria");
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);
                datos.agregarParametro("@Id", nuevo.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarCat(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarCategoria");
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
