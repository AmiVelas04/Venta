using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class VentasD
    {
        public int venta { get; set; }
        public int venta_detalle { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }
        public string fecha { get; set; }

    }
}
