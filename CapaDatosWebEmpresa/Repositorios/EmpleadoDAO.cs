using CapaDatosWebEmpresa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosWebEmpresa.Repositorios
{
    
    public class EmpleadoDAO:IDisposable
    {
        // Crear una clase de Contexto
        NegocioWebContext db = new NegocioWebContext();
        

        public int Nuevo(Empleado empleado)
        {
            db.Add(empleado); //Agregar empleado
            return db.SaveChanges(); //Guarda el registro

        }
        public int Edita(Empleado empleado)
        {
            var empleadoBuscado = db.Empleados.Where(x => x.IdEmpleado == empleado.IdEmpleado).SingleOrDefault(); //Devuelve un solo registro como maximo
            var rpta = 0;
            if(empleadoBuscado != null)
            {
                //capturar los datos de empleado 
                empleadoBuscado.Nombre = empleado.Nombre;
                empleadoBuscado.Apellidos = empleado.Apellidos;
                empleadoBuscado.Cargo = empleado.Cargo;
                empleadoBuscado.FechaContratación = empleado.FechaContratación;
                empleadoBuscado.FechaNacimiento = empleado.FechaNacimiento;
                empleadoBuscado.Ciudad= empleado.Ciudad;
                empleadoBuscado.País = empleado.País;    
                empleadoBuscado.Dirección = empleado.Dirección;
                empleadoBuscado.TelDomicilio = empleado.TelDomicilio;

                //Guardar la actualizacion
                rpta = db.SaveChanges();
            }
            return rpta;
        }
        public int Eliminar(int id)
        {
            var empleadoBuscado = db.Empleados.Where(x => x.IdEmpleado == id).SingleOrDefault(); //Devuelve un solo registro como maximo
            var rpta = 0;
            if(empleadoBuscado != null)
            {
                db.Remove(empleadoBuscado); //Remote: Eliminar
                //Confirma la eliminación
                rpta=db.SaveChanges();

            }
            return rpta;
        }
        public Empleado Buscar(int id)
        {
            var empleadoBuscado = db.Empleados.Where(x => x.IdEmpleado == id).SingleOrDefault(); //Devuelve un solo registro como maximo
            return empleadoBuscado;
        }
        public List<Empleado> Listar()
        {
            
            return db.Empleados.ToList(); //Devuelve una lista de datos
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
        // ~EmpleadoDAO()
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
