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
    public partial class Main : Form
    {
        public static string idvende { get; set; }
        public static string nombrev { get; set; }
        public static string nivel { get; set; }
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void abrir_form(Object formhijo ) { 
        if( this.PanCentral.Controls.Count >= 1){
               this.PanCentral.Controls.RemoveAt(0);
        }
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
        this.PanCentral.Controls.Add(fh);
            this.PanCentral.Tag = fh;
            
            fh.Show();
    }

        private void BtnVenta_Click(object sender, EventArgs e)
        {
            abrir_form(new Ventas());
        }

        private void BtnProd_Click(object sender, EventArgs e)
        {
            abrir_form(new Productos());
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            abrir_form(new Clientes());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LblUsu.Text = nombrev;
            if (nivel.Equals("3"))
            {
                BtnProd.Visible = false;
                BtnCliente.Visible = false;
                BtnCreditos.Visible = false;
                BtnCencesion.Visible = false;
                BtnReportes.Visible = false;
            }
        }

        private void BtnCreditos_Click(object sender, EventArgs e)
        {
            abrir_form(new Creditos());
        }

        private void BtnCencesion_Click(object sender, EventArgs e)
        {
            abrir_form(new Concesion());
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            abrir_form(new Reportes());
        }

        private void BtnCaja_Click(object sender, EventArgs e)
        {
            abrir_form(new Cajas());
        }

        private void BtnVent_Click(object sender, EventArgs e)
        {
            abrir_form(new ControlVen());
        }
    }
}
