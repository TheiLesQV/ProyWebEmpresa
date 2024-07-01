using CapaDatosWebEmpresa.Models;
using CapaNegociosWebEmpresa.Reglas;
using Microsoft.AspNetCore.Mvc;

namespace WebEmpresa2024.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*::::::::::::::::::::::::: SELECT_ BY:::::::::::::::::::::::::::*/
        [HttpGet]
        public IActionResult listarPedido_by_filtro()
        {
            return View();
        }
        public PartialViewResult ListarPedido_by(DateTime fechInicial, DateTime fechFinal) 
        {
            using (PedidoBL db = new PedidoBL())
            {
                //return View(db.ListarPedido_by(fechInicial, fechFinal));
                var pedidos = db.ListarPedido_by(fechInicial, fechFinal);
                return PartialView("ListarPedido_by", pedidos); //Devuelve los datos parciales de la consulta
            }

        }
        /*::::::::::::::::::::::::: SELECT_ BY_clientexAnio:::::::::::::::::::::::::::*/
        [HttpGet]
        public IActionResult ListarPedido_ClientexAnio_filtro()
        {
            return View();
        }
        public PartialViewResult ListarPedido_ClientexAnio(string idCliente, string anio) 
        {
            using (PedidoBL db = new PedidoBL())
            {
                //return View(db.ListarPedido_by(fechInicial, fechFinal));
                var pedidos = db.ListarPedido_ClientexAnio(idCliente, anio);
                return PartialView("ListarPedido_ClientexAnio", pedidos); //Devuelve los datos parciales de la consulta
            }

        }
    }
}
