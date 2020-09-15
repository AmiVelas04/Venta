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
    public partial class Cajas : Form
    {
        Clases.Caja Caj = new Clases.Caja();
        public Cajas()
        {
            InitializeComponent();
        }

        private void Cajas_Load(object sender, EventArgs e)
        {
            CboOpe.Items.Add("Entrada");
            CboOpe.Items.Add("Salida");
            CboOpe.SelectedIndex = 0;
            DataTable datos = new DataTable();
            datos=Caj.buscar_ope(DateTime.Now.ToString("yyyy/MM/dd"));
            DgvCaja.DataSource = datos;
            busqueda();
        }

        private void BtnAgr_Click(object sender, EventArgs e)
        {
            agregarope();
            busqueda();
        }

        private void agregarope()
        {
            decimal monto = 0;
            if (TxtMonto.Text =="")
            {
                monto = 0;
            }

            if (TxtDesc.Text == "")
            {
                MessageBox.Show("Falta descripccion","Falta",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            monto = decimal.Parse(TxtMonto.Text);
            string Desc = TxtDesc.Text;
            string[] datos = {monto.ToString(),Desc ,CboOpe.Text,DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss"),Main.idvende };
            if (Caj.ingreso(datos))
            {
                MessageBox.Show("Operacion ingresada");
            }
            else
            {
                MessageBox.Show("Error al ingresar operacion");
            }

        }

        private void DtpCaja_ValueChanged(object sender, EventArgs e)
        {
            busqueda();
        }

        private void busqueda()
        {
            DataTable datos = new DataTable();
            decimal ventas = 0, egresos = 0, total=0;
            datos = Caj.buscar_ope(DtpCaja.Value.ToString("yyyy/MM/dd"));
            DgvCaja.DataSource = datos;
            egresos=  Caj.Tsalida(DtpCaja.Value.ToString("yyyy/MM/dd"));
            ventas = Caj.Tentrada(DtpCaja.Value.ToString("yyyy/MM/dd"));
            TxtSalida.Text ="Q."+ egresos.ToString ();
            TxtVenta.Text = "Q. " + ventas.ToString();
            total = ventas+500 - egresos;
            TxtTotal.Text ="Q. " +total.ToString();

        }

        private void BtnImp_Click(object sender, EventArgs e)
        {
            imprimir();
        }
        private void imprimir()
        {
            string operacion, Descripcion, Monto, entrada, salida, Hora,Atendio;
            int cont, cant;
            cant = DgvCaja.Rows.Count;
            DataTable datos = new DataTable();
            datos.Columns.Add("orden").DataType = System.Type.GetType("System.String");
            datos.Columns.Add("Desc").DataType = System.Type.GetType("System.String");
            datos.Columns.Add("Entrada").DataType = System.Type.GetType("System.String");
            datos.Columns.Add("Salida").DataType = System.Type.GetType("System.String");
            datos.Columns.Add("Hora").DataType = System.Type.GetType("System.String");
            for (cont = 0; cont < cant; cont++)
            {
                DataRow fila = datos.NewRow();
                entrada = "0";
                salida = "0";
                Monto= DgvCaja.Rows[cont].Cells[2].Value.ToString();
                Descripcion = DgvCaja.Rows[cont].Cells[0].Value.ToString();
                if (DgvCaja.Rows[cont].Cells[1].Value.ToString() == "Entrada")
                { entrada = Monto; }
                else
                { salida = Monto; }
                 Hora= DgvCaja.Rows[cont].Cells[3].Value.ToString();
                fila["orden"] = (cont + 1).ToString();
                fila["Desc"] = Descripcion;
                fila["Entrada"] = entrada;
                fila["Salida"] = salida;
                fila["Hora"] = Hora;
                datos.Rows.Add(fila);
            }
            Caj.imprep(datos);
            
        }
    }
}
