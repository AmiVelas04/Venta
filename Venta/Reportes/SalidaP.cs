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
    partial class SalidaP : Form
    {
        public List<SalidaPEnc> Encabezado = new List<SalidaPEnc>();
        public List<SalidaPdet> Detalle = new List<SalidaPdet>();


        public SalidaP()
        {
            InitializeComponent();
        }

        private void SalidaP_Load(object sender, EventArgs e)
        {
            this.RpvSalida.LocalReport.DataSources.Clear();
            this.RpvSalida.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));
            this.RpvSalida.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detalle));
            this.RpvSalida.RefreshReport();
        }
    }
}
