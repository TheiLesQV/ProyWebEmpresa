using CapaDatosWebEmpresa.Models;
using CapaDatosWebEmpresa.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegociosWebEmpresa.Reglas
{
    //Reglas de Negocio
    public class EmpleadoBL :IDisposable
    {
        NegocioWebContext db = new NegocioWebContext();
        

        public int Nuevo(Empleado empleado)
        {
            using(EmpleadoDAO empleadodao = new EmpleadoDAO()) //Using :Permite que el objeto se autodestruya de memoria
            { 

                //Verificar Si existe el Id_Empleado
                if(empleadodao.Buscar(empleado.IdEmpleado)==null)
                {
                    //llamar al metodo Nuevo 
                    return empleadodao.Nuevo(empleado);

                }
                else
                {
                    throw new Exception("Ya existe el empleado con el código:" + empleado.IdEmpleado);
                }
            }
        }
        public int Edita(Empleado empleado)
        {
            using (EmpleadoDAO empleadodao = new EmpleadoDAO()) //Using :Permite que el objeto se autodestruya de memoria
            { 
                //Verificar Si existe el Id_Empleado
                if(empleadodao.Buscar(empleado.IdEmpleado)!=null)
                {
                    //llamar al metodo Editar 
                    return empleadodao.Edita(empleado);

                }
                else
                {
                    throw new Exception("No existe el empleado con el código:" + empleado.IdEmpleado +"para ser actualizado");
                }
            }
        }
        public int Eliminar(int id)
        {
            using (EmpleadoDAO empleadodao = new EmpleadoDAO()) //Using :Permite que el objeto se autodestruya de memoria
            { 
                //Verificar Si existe el Id_Empleado
                if (empleadodao.Buscar(id) != null)
                {
                    //llamar al metodo Eliminar 
                    return empleadodao.Eliminar(id);

                }
                else
                {
                    throw new Exception("No existe el empleado con el código:" + id + "para ser eliminado");
                }
            }
        }
        public Empleado Buscar(int id)
        {
            using (EmpleadoDAO empleadodao = new EmpleadoDAO()) //Using :Permite que el objeto se autodestruya de memoria
            { 
                //Verificar Si existe el Id_Empleado
                if (empleadodao.Buscar(id) != null)
                {
                    //llamar al metodo Eliminar 
                    return empleadodao.Buscar(id);

                }
                else
                {
                    throw new Exception("No existe el empleado con el código:" + id);
                }
            }
        }
        public List<Empleado> Listar()
        {
            using (EmpleadoDAO empleadodao = new EmpleadoDAO()) //Using :Permite que el objeto se autodestruya de memoria
            {
                return empleadodao.Listar();
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
        // ~EmpleadoBL()
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
