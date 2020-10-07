using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class RepSalGenEnc
    {
                public string fechai { get; set; }
        public string fechaf { get; set; }

        public List<RepSalGenDet> Detalle = new List<RepSalGenDet>();
    }
}
