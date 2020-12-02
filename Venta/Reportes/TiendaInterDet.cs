using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class TiendaInterDet
    {
        public string cod { get; set; }
        public string prod { get; set; }
        public string estilo { get; set; }
        public int cantidad { get; set; }
        public decimal  precio { get; set; }
        public decimal total { get; set; }
    }
}
