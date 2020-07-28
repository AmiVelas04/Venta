using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class Boleta
    {
       public string NoBol { get; set; }
        public string NoCre { get; set; }
        public string Cliente { get; set; }
        public string Vende { get; set; }
        public decimal pago { get; set; }
        public decimal saldo { get; set; }
        public string fecha { get; set; }
        public string concepto { get; set; }

    }
}
