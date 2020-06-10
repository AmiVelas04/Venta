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
     partial class Factura : Form
    {
       public  List<Reportes.FactDet> Deta = new List<Reportes.FactDet>();
        public List<Reportes.FactEnc> Enca = new List<Reportes.FactEnc>();
        public Factura()
        {
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            this.RepFactura.LocalReport.DataSources.Clear();
            this.RepFactura.LocalReport.DataSources.Add(new ReportDataSource("Enca", Enca));
            this.RepFactura.LocalReport.DataSources.Add(new ReportDataSource("Deta", Deta));

            this.RepFactura.RefreshReport();
        }
    }
}
