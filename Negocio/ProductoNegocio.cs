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
      
    public List<Productos> listar2()
    {
        List<Productos> listadoProductos = new List<Productos>();
        Productos aux;
        AccesoDatos datos = new AccesoDatos();
        try
        {
            datos.setearQuery("select p.id, p.Nombre, p.Descripcion, p.ImagenUrl, p.Precio,m.Descripcion as DescMarca, m.IDMarca as idMarca, C.Descripcion as DescCat, C.IDCat as IdCat, pr.Descripcion as DescPro,pr.IDPro as IdPro from productos as p inner join Marca as m on m.IDMarca =p.IDmarca inner join Categoria as C on C.IDCat =p.IDCatergoria inner join Provedor as pr on pr.IDPro = p.idProvedor");
            datos.ejecutarLector();
            while (datos.lector.Read())
            {
                    aux = new Productos();
                    aux.id = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Descripcion = datos.lector.GetString(2);
                    aux.ImagenUrl = datos.lector.GetString(3);
                    aux.Precio = Decimal.Round((decimal)datos.lector["Precio"], 3);
                    aux.idmarca = new Marca();
                    aux.idmarca.Descripcion = (string)datos.lector["DescMarca"];
                    aux.idmarca.Id = datos.lector.GetInt32(6);
                    aux.idcategoria = new Categoria();
                    aux.idcategoria.Descripcion = (string)datos.lector["DescCat"];
                    aux.idcategoria.Id = datos.lector.GetInt32(8);
                    aux.idprovedor = new Provedor();
                    aux.idprovedor.Descripcion = (string)datos.lector["DescPro"];
                    aux.idprovedor.Id = datos.lector.GetInt32(10);
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

}
}
