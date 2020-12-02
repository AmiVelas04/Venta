using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class TiendaInterEnca
    {
        public string Fecha { get; set; }
        public string Tienda { get; set; }
        public int Num { get; set; }
        public string vende { get; set; }

        public List<TiendaInterDet> Detalle = new List<TiendaInterDet>();
    }
}
