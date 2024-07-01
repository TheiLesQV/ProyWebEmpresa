using CapaDatosWebEmpresa.Models;
using CapaDatosWebEmpresa.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosWebEmpresa.Modelos;

namespace CapaNegociosWebEmpresa.Reglas
{
    public class ProductoBL : IDisposable
    {

        public List<Producto> ListarProductoxCategoria(int id)
        {
            using (ProductoDAO db = new ProductoDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {
                return db.ListarProductoxCategoria(id);
            }
        }
        public List<Producto> ListarProducto_Categoria_sqlCon(int id)
        {
            using (ProductoDAO db = new ProductoDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {
                return db.ListarProducto_Categoria_sqlCon(id);
            }
        }
        public List<ProductoModel> ListarProducto_Categ_by(int id)
        {
            using (ProductoDAO db = new ProductoDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {
                return db.ListarProd_Categ_by(id);
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
        // ~ProductoBL()
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
