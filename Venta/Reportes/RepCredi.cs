using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace Venta.Reportes
{
    partial class RepCredi : Form
    {
        public List<Reportes.ConceDet> Detalle = new List<ConceDet>();
        public List<Reportes.ConceEnc> Encabezado = new List<ConceEnc>();

        public RepCredi()
        {
            InitializeComponent();
        }

        private void RepCredi_Load(object sender, EventArgs e)
        {
            Rpv1.LocalReport.DataSources.Clear();
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detalle));
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));
            this.Rpv1.RefreshReport();
        }
    }
}
