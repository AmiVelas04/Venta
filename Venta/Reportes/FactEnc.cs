using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class FactEnc
    {
        public string No { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public string vendedor { get; set; }
        public string tipo { get; set; }
        public string fecha { get; set; }
        public string firma { get; set; }
        public string Recibi { get; set; }

        public List<FactDet> Detalle = new List<FactDet>();
        public List<ListaProd> Prod = new List<ListaProd>();
        public List<Etiqueta> Etiqu = new List<Etiqueta>();
       

    }
}
