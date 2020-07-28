﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta.Formularios
{
    public partial class Reportes : Form
    {
        Clases.Producto prod = new Clases.Producto();
        Clases.Venta ven = new Clases.Venta();
        public Reportes()
        {
            InitializeComponent();
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            prod.inventario();
                    }

        private void BtnVenta_Click(object sender, EventArgs e)
        {
            string fechi,fechaf;
            fechi = DtpIni.Value.ToString("yyyy/MM/dd");
            fechaf = DtpFin.Value.ToString("yyyy/MM/dd");
            fechi = fechi + " 00:00:00";
            fechaf = fechaf + " 23:59:59";
            ven.ventas(fechi, fechaf);
        }
    }
}
