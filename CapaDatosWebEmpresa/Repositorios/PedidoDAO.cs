using CapaDatosWebEmpresa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosWebEmpresa.Repositorios
{

    public class PedidoDAO : IDisposable
    {
        NegocioWebContext db = new NegocioWebContext();
        public List<Modelos.PedidoModel> ListarPedido_by(DateTime fechInicial,DateTime fechFinal)
        {
            List<Modelos.PedidoModel> Pedidos = new List<Modelos.PedidoModel>();
            //Crear una conección
            using (SqlConnection cn = new SqlConnection(db.Database.GetConnectionString()))
            {
                //Crear un comando para ejecutar el query
                using (SqlCommand cmd = new SqlCommand("SELECT P.IdPedido,E.Nombre,E.Apellidos,C.NombreCompañía,P.FechaPedido,P.FechaEntrega, P.Cargo FROM Pedidos P INNER JOIN Empleados E ON P.IdEmpleado= E.IdEmpleado INNER JOIN Clientes C ON P.IdCliente = C.IdCliente WHERE P.FechaPedido between @FECHINICIAL AND @FECHFINAL", cn))
                //using (SqlCommand cmd = new SqlCommand("USP_ListarPedidoCategoria", cn))
                {
                    cn.Open();
                    //Crea los parametros
                    cmd.Parameters.AddWithValue("@FECHINICIAL", fechInicial);
                    cmd.Parameters.AddWithValue("@FECHFINAL", fechFinal);
                    var datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        Modelos.PedidoModel Pedido = new Modelos.PedidoModel();
                        Pedido.IdPedido = Convert.ToInt32(datos["IdPedido"]);
                        Pedido.Empleado_nombre = Convert.ToString(datos["Nombre"]);
                        Pedido.Empleado_apellido = Convert.ToString(datos["Apellidos"]);
                        Pedido.Cliente = Convert.ToString(datos["NombreCompañía"]);
                        Pedido.FechaPedido = Convert.ToDateTime(datos["FechaPedido"]);
                        Pedido.FechaEntrega = Convert.ToDateTime(datos["FechaEntrega"]);
                        Pedido.Cargo = Convert.ToDecimal(datos["Cargo"]);
                        

                        Pedidos.Add(Pedido);
                    }
                    //Crear un adaptador para ejecutar el comando y obtener los resultados
                    return Pedidos;
                }
            }
        }
        public List<Modelos.PedidoModel> ListarPedido_ClientexAnio(string idCliente,string anio)
        {
            List<Modelos.PedidoModel> Pedidos = new List<Modelos.PedidoModel>();
            //Crear una conección
            using (SqlConnection cn = new SqlConnection(db.Database.GetConnectionString()))
            {
                //Crear un comando para ejecutar el query
                using (SqlCommand cmd = new SqlCommand("SELECT P.IdPedido,C.NombreCompañía,P.FechaPedido,P.FechaEntrega, P.Cargo FROM Pedidos P INNER JOIN Clientes C ON P.IdCliente = C.IdCliente WHERE YEAR(P.FechaPedido) =@ANIO  AND C.IdCliente = @IDCLIENTE", cn))
                //using (SqlCommand cmd = new SqlCommand("USP_ListarPedidoCategoria", cn))
                {
                    cn.Open();
                    //Crea los parametros
                    cmd.Parameters.AddWithValue("@IDCLIENTE", idCliente);
                    cmd.Parameters.AddWithValue("@ANIO", anio);
                    var datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        Modelos.PedidoModel Pedido = new Modelos.PedidoModel();
                        Pedido.IdPedido = Convert.ToInt32(datos["IdPedido"]);
                        Pedido.Cliente = Convert.ToString(datos["NombreCompañía"]);
                        Pedido.FechaPedido = Convert.ToDateTime(datos["FechaPedido"]);
                        Pedido.FechaEntrega = Convert.ToDateTime(datos["FechaEntrega"]);
                        Pedido.Cargo = Convert.ToDecimal(datos["Cargo"]);
                        

                        Pedidos.Add(Pedido);
                    }
                    //Crear un adaptador para ejecutar el comando y obtener los resultados
                    return Pedidos;
                }
            }
        }



        /*::::::::::CLASE QUE PERMITE AUTODESTRUIR DE MEMORIA LOS DATOS DESPUES DE HABER SIDO EJECUTADO ::::::::::::::*/
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
        // ~PedidoDAO()
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
