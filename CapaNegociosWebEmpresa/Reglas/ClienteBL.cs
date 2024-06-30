using CapaDatosWebEmpresa.Models;
using CapaDatosWebEmpresa.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegociosWebEmpresa.Reglas
{
    public class ClienteBL:IDisposable
    {
        NegocioWebContext db = new NegocioWebContext();
        

        public int Nuevo(Cliente Cliente)
        {
            using (ClienteDAO Clientedao = new ClienteDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {

                //Verificar Si existe el Id_Cliente
                if (Clientedao.Buscar(Cliente.IdCliente) == null)
                {
                    //llamar al metodo Nuevo 
                    return Clientedao.Nuevo(Cliente);

                }
                else
                {
                    throw new Exception("Ya existe el Cliente con el código:" + Cliente.IdCliente);
                }
            }
        }
        public int Edita(Cliente Cliente)
        {
            using (ClienteDAO Clientedao = new ClienteDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {
                //Verificar Si existe el Id_Cliente
                if (Clientedao.Buscar(Cliente.IdCliente) != null)
                {
                    //llamar al metodo Editar 
                    return Clientedao.Edita(Cliente);

                }
                else
                {
                    throw new Exception("No existe el Cliente con el código:" + Cliente.IdCliente + "para ser actualizado");
                }
            }
        }
        public int Eliminar(String id)
        {
            using (ClienteDAO Clientedao = new ClienteDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {
                //Verificar Si existe el Id_Cliente
                if (Clientedao.Buscar(id) != null)
                {
                    //llamar al metodo Eliminar 
                    return Clientedao.Eliminar(id);

                }
                else
                {
                    throw new Exception("No existe el Cliente con el código:" + id + "para ser eliminado");
                }
            }
        }
        public Cliente Buscar(String id)
        {
            using (ClienteDAO Clientedao = new ClienteDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {
                //Verificar Si existe el Id_Cliente
                if (Clientedao.Buscar(id) != null)
                {
                    //llamar al metodo Eliminar 
                    return Clientedao.Buscar(id);

                }
                else
                {
                    throw new Exception("No existe el Cliente con el código:" + id);
                }
            }
        }
        public List<Cliente> Listar()
        {
            using (ClienteDAO Clientedao = new ClienteDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {
                return Clientedao.Listar();
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
        // ~ClienteBL()
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
