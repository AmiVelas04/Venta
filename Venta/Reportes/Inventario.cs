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
    partial class Inventario : Form
    {
        public List<Reportes.ListaProd> inventario = new List<Reportes.ListaProd>();
        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Productos",inventario));
            this.Rpv1.LocalReport.EnableExternalImages = true;
            Rpv1.RefreshReport();
        }
    }
}
