using CapaDatosWebEmpresa.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosWebEmpresa.Repositorios
{
    public class ClienteDAO : IDisposable
    {
        NegocioWebContext db=new NegocioWebContext();
        public int Nuevo(Cliente cliente)
        {
            db.Add(cliente);
            return db.SaveChanges();
        }
        public int Edita(Cliente cliente)
        {
            var clienteBuscado = db.Clientes.Where(x=>x.IdCliente ==cliente.IdCliente.ToString()).SingleOrDefault();
            var rpta = 0;
            if (clienteBuscado != null) { 
                clienteBuscado.NombreCompañía = cliente.NombreCompañía;
                clienteBuscado.NombreContacto = cliente.NombreContacto;
                clienteBuscado.CargoContacto = cliente.CargoContacto;
                clienteBuscado.Dirección = cliente.Dirección;
                clienteBuscado.Ciudad=cliente.Ciudad;
                clienteBuscado.País = cliente.País;
                clienteBuscado.Teléfono = cliente.Teléfono;

                rpta = db.SaveChanges();
            }
            return rpta;
        }
        public int Eliminar(String id)
        {
            var clienteBuscado = db.Clientes.Where(x=>x.IdCliente == id).SingleOrDefault();
            var rpta = 0;
            if (clienteBuscado != null) {

                db.Remove(clienteBuscado);
                rpta = db.SaveChanges();
            }
            return rpta;
        }
        public Cliente Buscar (String id)
        {
            var clienteBuscado = db.Clientes.Where(x=>x.IdCliente == id).SingleOrDefault();
            
            return clienteBuscado;
        } 
        public List<Cliente> Listar ()
        {
            return db.Clientes.ToList(); //ToList:Devuelve una lista de datos
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
        // ~ClienteDAO()
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
