using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta.Reportes
{
     partial class ProducSalida : Form
    {
        public List<TiendaInterDet> Detalle = new List<TiendaInterDet>();
        public List<TiendaInterEnca> Encabezado = new List<TiendaInterEnca>();
        public ProducSalida()
        {
            InitializeComponent();
        }

        private void ProducSalida_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detalle));
            this.Rpv1.SetDisplayMode(DisplayMode.PrintLayout);
            this.Rpv1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.Rpv1.ZoomPercent = 100;
            this.Rpv1.RefreshReport();
        }
    }
}
