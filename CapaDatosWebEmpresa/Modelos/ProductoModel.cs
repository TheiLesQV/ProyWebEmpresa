using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosWebEmpresa.Modelos
{
    public class ProductoModel: Models.Producto
    {
        public string Categoria { get; set; }
        public string Proveedor { get; set; }   
    }
}
