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
    partial class BoletaP : Form
    {
        public List<Boleta> bol = new List<Boleta>();
        public BoletaP()
        {
            InitializeComponent();
        }

        private void BoletaP_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Boleta", bol));
            this.Rpv1.RefreshReport();
        }
    }
}
