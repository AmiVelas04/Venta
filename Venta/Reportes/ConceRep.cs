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
   partial class ConceRep : Form
    {
        public List<ConceDet> Detalle = new List<ConceDet>();
        public List<ConceEnc> Encabezado = new List<ConceEnc>();
        public ConceRep()
        {
            InitializeComponent();
        }

        private void ConceRep_Load(object sender, EventArgs e)
        {
            RpvConce.LocalReport.DataSources.Clear();
            RpvConce.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detalle));
            RpvConce.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));

            this.RpvConce.RefreshReport();
        }
    }
}
