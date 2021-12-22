using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class TrackEnc
    {
        public string titulo { get; set; }
        public string idprod { get; set; }
        public string prod { get; set; }


        public List<TrackDet> Detalle = new List<TrackDet>();
    }
}
