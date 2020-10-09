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
    partial class Ganancia : Form
    {
        public List<GanaciaDet> Detalle = new List<GanaciaDet>();
        public List<GanaciaEnc> Encabezado = new List<GanaciaEnc>();
        public Ganancia()
        {
            InitializeComponent();
        }

        private void Ganancia_Load(object sender, EventArgs e)
        {
            this.RpvGanancia.LocalReport.DataSources.Clear();
            this.RpvGanancia.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detalle));
            this.RpvGanancia.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));
            this.RpvGanancia.SetDisplayMode(DisplayMode.PrintLayout);
            this.RpvGanancia.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.RpvGanancia.ZoomPercent = 100;
            this.RpvGanancia.RefreshReport();
        }
    }
}
