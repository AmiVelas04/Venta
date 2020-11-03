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
   partial class RepSalGen : Form
    {
        public List<RepSalGenEnc> Encabezado = new List<RepSalGenEnc>();
        public List<RepSalGenDet> Detalle = new List<RepSalGenDet>();

        public RepSalGen()
        {
            InitializeComponent();
        }

        private void RepSalGen_Load(object sender, EventArgs e)
        {
            this.RpvSalidaGen.LocalReport.DataSources.Clear();
            this.RpvSalidaGen.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detalle));
            this.RpvSalidaGen.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));
            this.RpvSalidaGen.SetDisplayMode(DisplayMode.PrintLayout);
            this.RpvSalidaGen.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.RpvSalidaGen.ZoomPercent = 100;
            this.RpvSalidaGen.RefreshReport();
        }
    }
}
