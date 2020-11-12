using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta.Reportes
{
    class FactDet
    {
        public string codigo { get; set; }
        public int Numero{get;set;}
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }
        
    }
}
