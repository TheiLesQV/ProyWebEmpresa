using CapaNegociosWebEmpresa.Reglas;
using Microsoft.AspNetCore.Mvc;

namespace WebEmpresa2024.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListarProductoxCategoria(int id)
        {
            using (ProductoBL db = new ProductoBL())
            {
                return View(db.ListarProductoxCategoria(id));
            }
            
        }
        
        public IActionResult ListarProducto_Categoria_sqlCon(int id)
        {
            using (ProductoBL db = new ProductoBL())
            {
                return View(db.ListarProducto_Categoria_sqlCon(id));
            }
            
        }
        public IActionResult ListarProducto_Categ_by(int id)
        {
            using (ProductoBL db = new ProductoBL())
            {
                return View(db.ListarProducto_Categ_by(id));
            }

        }
    }
}
