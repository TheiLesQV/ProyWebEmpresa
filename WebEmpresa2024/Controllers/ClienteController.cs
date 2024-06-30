using CapaDatosWebEmpresa.Models;
using CapaNegociosWebEmpresa.Reglas;
using Microsoft.AspNetCore.Mvc;

namespace WebEmpresa2024.Controllers
{
    public class ClienteController : Controller
    {
        /*::::::::::::::: LISTAR :::::::::::::::*/
        public IActionResult Index() //Peticiones get, son mediante una Url
        {
            using (ClienteBL db = new ClienteBL())
            {
                return View(db.Listar()); //Se llama a una vista para presentar los datos.
            }

        }
        /*::::::::::::::: AGREGAR :::::::::::::::*/
        public IActionResult Nuevo()
        {
            return View(); //Llama a la vista de Cliente
        }
        //Petición POST por un BTN
        [HttpPost]
        public IActionResult Nuevo(Cliente Cliente)
        {
            using (ClienteBL db = new ClienteBL())
            {
                db.Nuevo(Cliente); //Llama al metodo para guardar los datos.
                return RedirectToAction("Index"); // Redirecciona a la ventana de la Lista de Clientes
            }
        }
        /*::::::::::::::: EDITAR :::::::::::::::*/
        public IActionResult Editar(String id)  //Petición GET
        {
            using (ClienteBL db = new ClienteBL())
            {
                var Cliente = db.Buscar(id); //Llama al metodo para guardar los datos.
                return View(Cliente);
            }

        }
        //Petición POST por un BTN Editar Cliente
        [HttpPost]
        public IActionResult Editar(Cliente Cliente)
        {
            using (ClienteBL db = new ClienteBL())
            {
                db.Edita(Cliente); //Llama al metodo para editar los datos.
                return RedirectToAction("Index"); // Redirecciona a la ventana de la Lista de Clientes
            }
        }
        /*::::::::::::::: DETALLE :::::::::::::::*/
        public IActionResult Detalle(String id)
        {
            using (ClienteBL db = new ClienteBL())
            {
                var Cliente = db.Buscar(id);
                return View(Cliente);
            }
        }
        /*::::::::::::::: ELIMINAR :::::::::::::::*/
        public IActionResult Eliminar(String id) //Petición GET
        {
            using (ClienteBL db = new ClienteBL())
            {
                var Cliente = db.Buscar(id); //Llama al metodo para guardar los datos.
                return View(Cliente);
            }

        }
        //Petición POST por un BTN Eliminar Cliente
        [HttpPost]
        public IActionResult Eliminar(Cliente Cliente)
        {
            using (ClienteBL db = new ClienteBL())
            {
                db.Eliminar(Cliente.IdCliente); //Llama al metodo para eliminar los datos.
                return RedirectToAction("Index"); // Redirecciona a la ventana de la Lista de Clientes
            }
        }
    }
}
