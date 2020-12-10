using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class SalidaPEnc
    {
        public int NoPedido { get; set; }

        public string Fecha { get; set; }
        public string salida { get; set; }
        public string Solicitante { get; set; }
        public string Opero { get; set; }

        public List<SalidaPdet> Detalle = new List<SalidaPdet>();
        public List<Etiqueta> Etiqueta = new List<Reportes.Etiqueta>();
    }
}
