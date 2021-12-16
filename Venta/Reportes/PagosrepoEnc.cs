using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class PagosrepoEnc
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    

        public List<PagosrepoDet> Detalle = new List<PagosrepoDet>();
    }
}
