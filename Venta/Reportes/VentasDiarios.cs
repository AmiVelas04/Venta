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
    partial class VentasDiarios : Form
    {
        public List<Reportes.ConceEnc> Enca = new List<Reportes.ConceEnc>();
        public List<Reportes.VentasD> venta = new List<Reportes.VentasD>();

        public VentasDiarios()
        {
            InitializeComponent();
        }

        private void VentasDiarios_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Ventas", venta));
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Enca));
            this.Rpv1.RefreshReport();
        }
    }
}
