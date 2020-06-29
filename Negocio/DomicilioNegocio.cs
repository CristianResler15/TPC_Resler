using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DomicilioNegocio
    {
        public void AgregarDomicilio( Domicilio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAgregarDomicilio");
                datos.agregarParametro("@Partido", nuevo.Partido);
                datos.agregarParametro("@Calle", nuevo.calle);
                datos.agregarParametro("@CodigoPostal", nuevo.CodigoPostal);
                datos.agregarParametro("@Altura", nuevo.altura);
                datos.agregarParametro("@Provincia", nuevo.provincia);
                datos.agregarParametro("@Piso", nuevo.piso);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Domicilio> listarDomicilio()
        {
            List<Domicilio> ListadoDom = new List<Domicilio>();
            Domicilio aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarDomicilio");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new Domicilio();
                    aux.id = datos.lector.GetInt32(0);
                    aux.Partido = datos.lector.GetString(1);
                    aux.provincia = datos.lector.GetString(2);
                    aux.calle = datos.lector.GetString(3);
                    aux.CodigoPostal = datos.lector.GetInt32(4);
                    aux.altura = datos.lector.GetInt32(5);
                    aux.piso = datos.lector.GetInt32(6);
                    ListadoDom.Add(aux);
                }
                return ListadoDom;
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
        public void modificarDomicilio( Domicilio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearSP("spModificarDomicilio");
                datos.agregarParametro("@Provincia", nuevo.provincia);
                datos.agregarParametro("@Partido", nuevo.Partido);
                datos.agregarParametro("@Calle", nuevo.calle);
                datos.agregarParametro("@CodigoPostal", nuevo.CodigoPostal);
                datos.agregarParametro("@Altura", nuevo.altura);
                datos.agregarParametro("@Piso", nuevo.piso);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminardomicilio(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarDomicilio");
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
