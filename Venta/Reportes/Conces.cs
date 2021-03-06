﻿using System;
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
    partial class Conces : Form
    {
        public List<ConceDet> Deta = new List<ConceDet>();
        public List<ConceEnc> Encab = new List<ConceEnc>();


        public Conces()
        {
            InitializeComponent();
        }

        private void Conces_Load(object sender, EventArgs e)
        {
            this.RepConc.LocalReport.DataSources.Clear();
            this.RepConc.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encab));
            this.RepConc.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Deta));
            this.RepConc.RefreshReport();
        }
    }
}
