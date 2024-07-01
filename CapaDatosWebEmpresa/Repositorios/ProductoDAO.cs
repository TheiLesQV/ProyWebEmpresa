using CapaDatosWebEmpresa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosWebEmpresa.Repositorios
{
    public class ProductoDAO:IDisposable
    {
        NegocioWebContext db = new NegocioWebContext();
        

        //Metodo con filtros
        public List<Producto>ListarProductoxCategoria(int id)
        {
            return db.Productos.Where(p => p.IdCategoría == id).ToList();
        }
        public List<Producto> ListarProducto_Categoria_sqlCon(int id)
        {
            List<Producto> Productos = new List<Producto>();
            //Crear una conección
            using (SqlConnection cn = new SqlConnection(db.Database.GetConnectionString()))
            {
                //Crear un comando para ejecutar el query
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTOS WHERE IdCategoría = @IDCATEGORIA", cn))
                //using (SqlCommand cmd = new SqlCommand("USP_ListarProductoCategoria", cn))
                {
                    cn.Open();
                    //Crea los parametros
                    cmd.Parameters.AddWithValue("@IDCATEGORIA", id);
                    var datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        Producto producto = new Producto();
                        producto.IdProducto = Convert.ToInt32(datos["IdProducto"]);
                        producto.NombreProducto = Convert.ToString(datos["NombreProducto"]);
                        producto.IdProveedor = Convert.ToInt32(datos["IdProveedor"]);
                        producto.IdCategoría = Convert.ToInt32(datos["IdCategoría"]);
                        producto.CantidadPorUnidad = Convert.ToString(datos["CantidadPorUnidad"]);
                        producto.PrecioUnidad = Convert.ToInt32(datos["PrecioUnidad"]);
                        producto.UnidadesEnExistencia = Convert.ToInt16(datos["UnidadesEnExistencia"]);
                        producto.UnidadesEnPedido = Convert.ToInt16(datos["UnidadesEnPedido"]);
                        producto.NivelNuevoPedido = Convert.ToInt32(datos["NivelNuevoPedido"]);
                        producto.Suspendido = Convert.ToBoolean(datos["Suspendido"]);
                        producto.Foto = Convert.ToString(datos["foto"]);

                        Productos.Add(producto);
                    }
                    //Crear un adaptador para ejecutar el comando y obtener los resultados
                   return Productos;
                }
            }
        }
        public List<Modelos.ProductoModel> ListarProd_Categ_by(int id)
        {
            List<Modelos.ProductoModel> Productos = new List<Modelos.ProductoModel>();
            //Crear una conección
            using (SqlConnection cn = new SqlConnection(db.Database.GetConnectionString()))
            {
                //Crear un comando para ejecutar el query
                using (SqlCommand cmd = new SqlCommand("SELECT P.IdProducto,  P.NombreProducto,   P.PrecioUnidad,   C.NombreCategoría,   D.NombreCompañía FROM Productos P INNER JOIN Categorías C ON P.IdCategoría=C.IdCategoría INNER JOIN Proveedores D ON D.IdProveedor = P.IdProveedor WHERE P.IdCategoría= @IDCATEGORIA", cn))
                //using (SqlCommand cmd = new SqlCommand("USP_ListarProductoCategoria", cn))
                {
                    cn.Open();
                    //Crea los parametros
                    cmd.Parameters.AddWithValue("@IDCATEGORIA", id);
                    var datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        Modelos.ProductoModel producto = new Modelos.ProductoModel();
                        producto.IdProducto = Convert.ToInt32(datos["IdProducto"]);
                        producto.NombreProducto = Convert.ToString(datos["NombreProducto"]);
                        producto.PrecioUnidad = Convert.ToInt32(datos["PrecioUnidad"]);
                        producto.Categoria = Convert.ToString(datos["NombreCategoría"]);
                        producto.Proveedor = Convert.ToString(datos["NombreCompañía"]);

                        Productos.Add(producto);
                    }
                    //Crear un adaptador para ejecutar el comando y obtener los resultados
                   return Productos;
                }
            }
        }
        //DATASET
        public DataSet ListarProducto_Categ(int id)
        {
            DataSet ds = new DataSet();
            //Crear una conección
            using (SqlConnection cn = new SqlConnection(db.Database.GetConnectionString()))
            {
                //Crear un comando para ejecutar el query
                //using (SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTOS WHERE IDCATEGORIA = @IDCATEGORIA",cn))
                using (SqlCommand cmd = new SqlCommand("USP_ListarProductoCategoria",cn))
                {   
                    //Define el tipo de comado a Ejecutar
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Crea los parametros
                    cmd.Parameters.AddWithValue("@IDCATEGORIA", id);
                    //Crear un adaptador para ejecutar el comando y obtener los resultados
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
        }


        /*::::::::::::::::::::::::::: METÓDO PARA AUTODESTRUIR LOS DATOS DE MEMORIA DESPUES DE EJECUTAR:::::::::::::::::::::::::::::*/
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~ProductoDAO()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
