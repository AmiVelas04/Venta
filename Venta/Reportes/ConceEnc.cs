﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class ConceEnc
    {
        public string No { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public string vendedor { get; set; }
        public string tipo { get; set; }
        public string fecha { get; set; }

        public List<ConceDet> Detalle = new List<ConceDet>();
        public List<VentasD> Venta = new List<VentasD>();
    }
}
