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
   partial class RepSalTien : Form
    {
        public List<RepSalGenDet> Detalle = new List<RepSalGenDet>();
        public List<RepSalGenEnc> Encabezado = new List<RepSalGenEnc>();

        public RepSalTien()
        {
            InitializeComponent();
        }

        private void RepSalTien_Load(object sender, EventArgs e)
        {
            Rpv1.LocalReport.DataSources.Clear();
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detalle));
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));
            Rpv1.SetDisplayMode(DisplayMode.PrintLayout);
            Rpv1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            Rpv1.ZoomPercent = 100;
            this.Rpv1.RefreshReport();
        }
    }
}
