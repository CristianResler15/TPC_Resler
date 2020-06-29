using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;



namespace Negocio
{
    public class ProductosNegocio
    {

        public void Agregar(Productos nuevo)
        {


            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarProducto");
                datos.agregarParametro("@Nombre", nuevo.Nombre);
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);
                datos.agregarParametro("@ImagenURL", nuevo.ImagenUrl);
                datos.agregarParametro("@Precio", nuevo.Precio);
                datos.agregarParametro("@Cantidad", nuevo.Cantidad);
                datos.agregarParametro("@IDmarca", nuevo.idmarca.Id.ToString());
                datos.agregarParametro("@IDCatergoria", nuevo.idcategoria.Id.ToString());
                datos.agregarParametro("@IDProvedor", nuevo.idprovedor.Id.ToString());
                datos.agregarParametro("@Activo", nuevo.Activo.ToString());
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Productos> listar2()
    {
        List<Productos> listadoProductos = new List<Productos>();
        Productos aux;
        AccesoDatos datos = new AccesoDatos();
        try
        {
            datos.setearSP("spListarProducto");
            datos.ejecutarLector();
            while (datos.lector.Read())
            {
                    aux = new Productos();
                    aux.id = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Descripcion = datos.lector.GetString(2);
                    aux.Cantidad= datos.lector.GetInt32(3);
                    aux.ImagenUrl = datos.lector.GetString(4);
                    aux.Precio = Decimal.Round((decimal)datos.lector["Precio"], 3);
                    aux.idmarca = new Marca();
                    aux.idmarca.Descripcion = (string)datos.lector["DescMarca"];
                    aux.idmarca.Id = datos.lector.GetInt32(7);
                    aux.idcategoria = new Categoria();
                    aux.idcategoria.Descripcion = (string)datos.lector["DescCat"];
                    aux.idcategoria.Id = datos.lector.GetInt32(9);
                    aux.idprovedor = new Provedor();
                    aux.idprovedor.Descripcion = (string)datos.lector["DescPro"];
                    aux.idprovedor.Id = datos.lector.GetInt32(11);
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
        public void modificar(Productos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
             
                datos.setearSP("spModificarProducto");
                datos.agregarParametro("@Nombre", nuevo.Nombre);
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);
                datos.agregarParametro("@Cantidad", nuevo.Cantidad);
                datos.agregarParametro("@ImagenURL", nuevo.ImagenUrl);
                datos.agregarParametro("@Id", nuevo.id);
                datos.agregarParametro("@Precio", nuevo.Precio);
                datos.agregarParametro("@IDmarca", nuevo.idmarca.Id.ToString());
                datos.agregarParametro("@IDCatergoria", nuevo.idcategoria.Id.ToString());
                datos.agregarParametro("@IDProvedor", nuevo.idprovedor.Id.ToString());
                datos.agregarParametro("@Activo", nuevo.Activo.ToString());
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarProducto");
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
