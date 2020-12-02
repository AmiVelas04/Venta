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
     partial class Cotizacion : Form
    {
        public List<ConceDet> Deta = new List<ConceDet>();
        public List<ConceEnc> Enca = new List<ConceEnc>();

        public Cotizacion()
        {
            InitializeComponent();
        }

        private void Cotizacion_Load(object sender, EventArgs e)
        {
            Rpv1.LocalReport.DataSources.Clear();
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle",Deta));
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado",Enca));

            this.Rpv1.RefreshReport();
        }
    }
}
