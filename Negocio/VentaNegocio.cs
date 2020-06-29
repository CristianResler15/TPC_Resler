using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Dominio;

namespace Negocio
{
    public class VentaNegocio
    {
        public void AgregarVenta(venta nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAgregarVenta");
                datos.agregarParametro("@IdProducto", nuevo.producto.id);
                datos.agregarParametro("@Cantidad", nuevo.producto.Cantidad);
                datos.agregarParametro("@Total", nuevo.Total);
                datos.agregarParametro("@fecha", nuevo.fechaventa);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        } 
        public void AgregarVentaxProducto(venta nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAgregarVentaxProductos");
                datos.agregarParametro("@IDventa", nuevo.Id);
                datos.agregarParametro("@IDproductos", nuevo.producto.id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }  
        public void AgregarVentaxUsuario(venta nuevo,int usua)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAgregarVentaxusuarios");
                datos.agregarParametro("@IDusuario", usua);
                datos.agregarParametro("@IDventa", nuevo.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<venta> listarTipo()
        {
            List<venta> Listadotipo = new List<venta>();
           venta aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarVenta");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new venta();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.producto.Cantidad = datos.lector.GetInt32(1);
                    aux.Envios = datos.lector.GetBoolean(2);
                    aux.fechaventa = datos.lector.GetDateTime(3);
                    aux.Total = datos.lector.GetDecimal(4);
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
        public List<venta> listarVentaXProductos()
        {
            List<venta> Listadotipo = new List<venta>();
           venta aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearSP("spListarVentaXProductos");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new venta();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.producto.id = datos.lector.GetInt32(1);
                    aux.Total = datos.lector.GetInt32(2); 
                    aux.usuario.Id= datos.lector.GetInt32(3);
                    aux.usuario.Nombre= (string)datos.lector["Nombreusu"];
                    aux.usuario.Id= datos.lector.GetInt32(5);
                    aux.usuario.Apellido= (string)datos.lector["Apellidousu"];
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
        public List<venta> listarVentasxUsuario(int idusu)
        {
            List<venta> Listadotipo = new List<venta>();
           venta aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.agregarParametro("@Id", idusu);
                datos.ejecutarAccion();
                datos.setearSP("spListarVentasxUsuarios");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
           
                    aux = new venta();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.producto.Nombre = (string)datos.lector["mombrepro"];
                    aux.producto.Cantidad = datos.lector.GetInt32(2);
                    aux.producto.idmarca.Descripcion = (string)datos.lector["nombremar"];
                    aux.Envios = datos.lector.GetBoolean(4);
                    aux.fechaventa= datos.lector.GetDateTime(5);
                    aux.producto.ImagenUrl = (string)datos.lector["imagenPro"];
                    aux.producto.Precio = datos.lector.GetDecimal(7);
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
        public void modificarVenta(venta nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spModificarVenta");
                datos.agregarParametro("@ID", nuevo.Id);
                datos.agregarParametro("@IDprducto", nuevo.producto.id);
                datos.agregarParametro("@Envio", nuevo.Envios);
                datos.agregarParametro("@Total", nuevo.Total);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
