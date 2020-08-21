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
    partial class CantidadP : Form
    {
        public List<ConceEnc> encabezado = new List<ConceEnc>();
        public List<ConceDet> detalle = new List<ConceDet>();
        public CantidadP()
        {
            InitializeComponent();
        }

        private void CantidadP_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", detalle));
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encab", encabezado));
            this.Rpv1.RefreshReport();
        }
    }
}
