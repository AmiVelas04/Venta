using System;
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
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void abrir_form(Object formhijo ) { 
        if( this.PanCent.Controls.Count >= 1){
               this.PanCent.Controls.RemoveAt(0);
        }
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
        this.PanCent.Controls.Add(fh);
            this.PanCent.Tag = fh;
            fh.Show();

    }

        private void BtnVenta_Click(object sender, EventArgs e)
        {
            abrir_form(new Formularios.Ventas());
        }

        private void BtnProd_Click(object sender, EventArgs e)
        {
            abrir_form(new Formularios.Productos());
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            abrir_form(new Formularios.Clientes());
        }
    }
}
