﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class GanaciaEnc
    {
        public string Titulo { get; set; }
        public string FechaI { get; set; }
        public string FechaF { get; set; }
        
      public List<GanaciaDet> Detalle = new List<GanaciaDet>();
    }
}
