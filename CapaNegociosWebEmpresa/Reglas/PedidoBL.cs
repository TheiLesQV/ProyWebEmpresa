using CapaDatosWebEmpresa.Modelos;
using CapaDatosWebEmpresa.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegociosWebEmpresa.Reglas
{
    public class PedidoBL : IDisposable
    {
        public List<PedidoModel> ListarPedido_by(DateTime fechInicial, DateTime fechFinal)
        {
            using (PedidoDAO db = new PedidoDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {
                return db.ListarPedido_by(fechInicial, fechFinal);
            }
        }
        public List<PedidoModel> ListarPedido_ClientexAnio(string idCliente, string anio)
        {
            using (PedidoDAO db = new PedidoDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {
                return db.ListarPedido_ClientexAnio(idCliente, anio);
            }
        }

        /*::::::::::::::::::: METODO PARA AUTODESTRUIR LOS DATOS DE MEMORIA ::::::::::::::::*/
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
        // ~PedidoBL()
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
