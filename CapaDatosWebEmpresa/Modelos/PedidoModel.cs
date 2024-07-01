using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosWebEmpresa.Modelos
{
    public class PedidoModel: Models.Pedido
    {
        public string Cliente { get; set; }
        public string Empleado_nombre { get; set; }
        public string Empleado_apellido { get; set; }
    }
}
