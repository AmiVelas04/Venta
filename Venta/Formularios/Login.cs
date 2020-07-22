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
    public partial class Login : Form
    {
        Clases .Login log=  new Clases.Login();
       
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            datos = log.Logueo(TxtUsu.Text, TxtPass.Text);
            if (datos.Rows.Count>0)
            {
                Formularios.Main inicio = new Formularios.Main();
                inicio.Show();
                Main.idvende = datos.Rows[0][0].ToString();
                Main .nombrev = datos.Rows[0][1].ToString();
                Main.nivel = datos.Rows[0][4].ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error de inicio de sesion");
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
