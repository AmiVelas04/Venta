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
   partial class RepCaja : Form
    {
        public List<FactEnc> Enc = new List<FactEnc>();
        public List<ListaProd> Detalle = new List<ListaProd>();

        public RepCaja()
        {
            InitializeComponent();
        }

        private void RepCaja_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detalle));
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Enc));
            this.Rpv1.RefreshReport();
        }
    }
}
