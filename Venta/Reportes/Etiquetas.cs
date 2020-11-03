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
     partial class Etiquetas : Form
    {
        public List<Etiqueta> Etiq = new List<Etiqueta>();
        public List<SalidaPEnc> Enc = new List<SalidaPEnc>();
        public Etiquetas()
        {
            InitializeComponent();
        }

        private void Etiquetas_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Etiqueta", Etiq));
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Enc));
            this.Rpv1.SetDisplayMode(DisplayMode.PrintLayout);
            this.Rpv1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.Rpv1.ZoomPercent = 100;
            this.Rpv1.RefreshReport();
        }
    }
}
