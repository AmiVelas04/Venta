using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Venta.Reportes
{
     partial class TiendaInter : Form
    {
        public List<TiendaInterDet> Detalle = new List<TiendaInterDet>();
        public List<TiendaInterEnca> Encabezado = new List<TiendaInterEnca>();
        public TiendaInter()
        {
            InitializeComponent();
        }

        private void TiendaInter_Load(object sender, EventArgs e)
        {
            Rpv1.LocalReport.DataSources.Clear();
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detalle));
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));
            this.Rpv1.RefreshReport();
        }
    }
}
