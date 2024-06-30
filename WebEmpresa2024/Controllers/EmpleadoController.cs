using CapaDatosWebEmpresa.Models;
using CapaNegociosWebEmpresa.Reglas;
using Microsoft.AspNetCore.Mvc;

namespace WebEmpresa2024.Controllers
{
    public class EmpleadoController : Controller
    {
        /*::::::::::::::: LISTAR :::::::::::::::*/
        public IActionResult Index() //Peticiones get, son mediante una Url
        {
            using (EmpleadoBL db = new EmpleadoBL())
            {
                return View(db.Listar()); //Se llama a una vista para presentar los datos.
            }
            
        }
        /*::::::::::::::: AGREGAR :::::::::::::::*/
        public IActionResult Nuevo()
        {
            return View(); //Llama a la vista de empleado
        }
        //Petición por un BTN Guardar Empleado
        [HttpPost]
        public IActionResult Nuevo(Empleado empleado)
        {
            using (EmpleadoBL db = new EmpleadoBL())
            {
                db.Nuevo(empleado); //Llama al metodo para guardar los datos.
                return RedirectToAction("Index"); // Redirecciona a la ventana de la Lista de empleados
            }
        }

       /*::::::::::::::: EDITAR :::::::::::::::*/
        public IActionResult Editar(int id)  //Petición GET
        {
            using (EmpleadoBL db = new EmpleadoBL())
            {
                var empleado = db.Buscar(id); //Llama al metodo para guardar los datos.
                return View(empleado);
            }
            
        }
        //Petición POST por un BTN Editar Empleado
        [HttpPost]
        public IActionResult Editar(Empleado empleado)
        {
            using (EmpleadoBL db = new EmpleadoBL())
            {
                db.Edita(empleado); //Llama al metodo para editar los datos.
                return RedirectToAction("Index"); // Redirecciona a la ventana de la Lista de empleados
            }
        }
        /*::::::::::::::: DETALLE :::::::::::::::*/
        public IActionResult Detalle(int id)
        {
            using (EmpleadoBL db = new EmpleadoBL())
            {
                var empleado = db.Buscar(id);
                return View(empleado);
            }
        }
        /*::::::::::::::: ELIMINAR :::::::::::::::*/
        public IActionResult Eliminar(int id) //Petición GET
        {
            using (EmpleadoBL db = new EmpleadoBL())
            {
                var empleado = db.Buscar(id); //Llama al metodo para guardar los datos.
                return View(empleado);
            }
            
        }
        //Petición POST por un BTN Eliminar Empleado
        [HttpPost]
        public IActionResult Eliminar(Empleado empleado)
        {
            using (EmpleadoBL db = new EmpleadoBL())
            {
                db.Eliminar(empleado.IdEmpleado); //Llama al metodo para eliminar los datos.
                return RedirectToAction("Index"); // Redirecciona a la ventana de la Lista de empleados
            }
        }

    }
}
