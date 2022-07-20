using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Venta.Formularios
{
    public partial class Main : Form
    {
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public static string idvende { get; set; }
        public static string nombrev { get; set; }
        public static string nivel { get; set; }
        //public string 
            public static string rutaimg1 { get; set; }
        public Main()
        {
            InitializeComponent();
         //  rutaimg1 = @"\\192.168.0.100\imagenes\";
           rutaimg1 = @".\imagen\";

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
            BtnVent.Focus();
            if (nivel.Equals("3"))
            {
                BtnProd.Visible = false;
                BtnCliente.Visible = false;
                BtnCreditos.Visible = false;
                BtnCencesion.Visible = false;
                BtnReportes.Visible = false;
                BtnVent.Visible = false;
                BtnResp.Visible = false;
                BtnUsu.Visible = false;
            }
            if (nivel.Equals("2"))
            {
                BtnUsu.Visible = false;
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

        private void PanSup_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnResp_Click(object sender, EventArgs e)
        {
            Respaldo Guardar = new Respaldo();
            Guardar.ShowDialog();
        }

        private void BtnVenta_Enter(object sender, EventArgs e)
        {
            this.BtnVenta.BackColor = Color.FromArgb(255, 30, 86);
           this.BtnCaja.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnVent.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnProd.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCliente.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCreditos.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCencesion.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnReportes.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnResp.BackColor = Color.FromArgb(255, 172, 65);
            
        }

        private void BtnCaja_Enter(object sender, EventArgs e)
        {
            this.BtnVenta.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCaja.BackColor = Color.FromArgb(255, 30, 86);
            this.BtnVent.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnProd.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCliente.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCreditos.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCencesion.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnReportes.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnResp.BackColor = Color.FromArgb(255, 172, 65);
        }

        private void BtnVent_Enter(object sender, EventArgs e)
        {
            this.BtnVenta.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCaja.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnVent.BackColor = Color.FromArgb(255, 30, 86);
            this.BtnProd.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCliente.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCreditos.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCencesion.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnReportes.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnResp.BackColor = Color.FromArgb(255, 172, 65);
        }

        private void BtnProd_Enter(object sender, EventArgs e)
        {
            this.BtnVenta.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCaja.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnVent.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnProd.BackColor = Color.FromArgb(255, 30, 86);
            this.BtnCliente.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCreditos.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCencesion.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnReportes.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnResp.BackColor = Color.FromArgb(255, 172, 65);
        }

        private void BtnCliente_Enter(object sender, EventArgs e)
        {
            this.BtnVenta.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCaja.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnVent.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnProd.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCliente.BackColor = Color.FromArgb(255, 30, 86);
            this.BtnCreditos.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCencesion.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnReportes.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnResp.BackColor = Color.FromArgb(255, 172, 65);
        }

        private void BtnCreditos_Enter(object sender, EventArgs e)
        {
            this.BtnVenta.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCaja.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnVent.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnProd.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCliente.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCreditos.BackColor = Color.FromArgb(255, 30, 86);
            this.BtnCencesion.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnReportes.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnResp.BackColor = Color.FromArgb(255, 172, 65);
        }

        private void BtnCencesion_Enter(object sender, EventArgs e)
        {
            this.BtnVenta.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCaja.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnVent.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnProd.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCliente.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCreditos.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCencesion.BackColor = Color.FromArgb(255, 30, 86);
            this.BtnReportes.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnResp.BackColor = Color.FromArgb(255, 172, 65);
        }

        private void BtnReportes_Enter(object sender, EventArgs e)
        {
            this.BtnVenta.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCaja.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnVent.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnProd.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCliente.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCreditos.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCencesion.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnReportes.BackColor = Color.FromArgb(255, 30, 86);
            this.BtnResp.BackColor = Color.FromArgb(255, 172, 65);
        }

        private void BtnResp_Enter(object sender, EventArgs e)
        {
            this.BtnVenta.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCaja.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnVent.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnProd.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCliente.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCreditos.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnCencesion.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnReportes.BackColor = Color.FromArgb(255, 172, 65);
            this.BtnResp.BackColor = Color.FromArgb(255, 30, 86);
        }

        private void BtnIngrerap_Click(object sender, EventArgs e)
        {
            IngresoRapidoProd ingre = new IngresoRapidoProd();
            ingre.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ControlUsu Usu = new ControlUsu();
            Usu.ShowDialog();
        }

        private void BtnUsu_Click(object sender, EventArgs e)
        {

            ControlUsu Usu = new ControlUsu();
            Usu.ShowDialog();
        }
    }
}
