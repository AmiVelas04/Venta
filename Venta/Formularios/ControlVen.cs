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
    public partial class ControlVen : Form
    {
        Clases.Venta ven = new Clases.Venta();
        public ControlVen()
        {
            InitializeComponent();
        }

        private void ControlVen_Load(object sender, EventArgs e)
        {
            listarven();
        }
        private void listarven()
        {
            DataTable datos = new DataTable();
            datos = ven.listavent();
            CboVenta.DataSource = datos;
            CboVenta.ValueMember = "id_venta";
                CboVenta .DisplayMember= "id_venta";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in datos.Rows)
            {
                coleccion.Add(row["id_venta"].ToString());
            }
            CboVenta.AutoCompleteCustomSource = coleccion;
            CboVenta.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboVenta.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void CboVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenar();
        }

        private void llenar()
            {
            if (CboVenta.Text != "" && CboVenta.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                buscar(CboVenta.Text);
                
            }
            else
            { }
        }
        private void mostrar()
        {
            string idv = CboVenta.Text;
            DataTable datos = new DataTable();
            datos = ven.prodvent(idv);
            DgvDatos.DataSource = datos;
            decimal monto = 0;
            int cont, cant;
            cant = datos.Rows.Count;
            for (cont = 0; cont < cant; cont++)
            {
                monto += decimal.Parse(datos.Rows[cont][4].ToString());
           }
            //DgvDatos.Columns[0].Visible = false;
            lblTotal.Text = "Q." + monto.ToString();
            Lblt .Text = monto.ToString();
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            if (CboVenta.Text != "" && CboVenta.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                mostrar();
                if (DgvDatos .Rows.Count>0) BtnSuprVen.Enabled=true;
            }
            else
            { }
        }

        private void BtnSuprVen_Click(object sender, EventArgs e)
        {
            if (DgvDatos.Rows.Count > 0)
            {
                eliminar();
                BtnSuprVen.Enabled = false;
            }
        }

        private void buscar(string vent)
        {
            DataTable datos = new DataTable();
            datos = ven.datavent(vent);
            TxtVend.Text= datos.Rows[0][0].ToString();
            TxtCli.Text = datos.Rows[0][1].ToString();
            TxtFech.Text = datos.Rows[0][2].ToString();
        }
        private void eliminar()
        {
            int cont, cant;
            cant = DgvDatos.Rows.Count;
            for (cont= 0; cont<cant;cont++)
            { string id = DgvDatos.Rows[cont].Cells[0].Value.ToString();
              string cantprod= DgvDatos.Rows[cont].Cells[2].Value.ToString();
              if (!ven.devolver(id, cantprod)) return;
            }
            if (!ven.cambvent(CboVenta .Text)) return;
            decimal monto = decimal.Parse(Lblt.Text);
            string[] datos = { monto.ToString(), "Cancelacion de venta No." + CboVenta.Text + " por: " + Main.nombrev, "Salida", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"), Main.idvende };
            if (!ven.regcaja(datos)) return;
            MessageBox.Show("Venta cancelada");
            limpiar();
        }

        private void limpiar()
        {
            TxtCli.Clear();
            TxtFech.Clear();
            TxtVend.Clear();
            while (DgvDatos.Rows.Count > 0)
            {
                DgvDatos.Rows.RemoveAt(0);
            }
            listarven();
        }

        private void BtnImp_Click(object sender, EventArgs e)
        {
            if (TxtFech.Text != "") {
                ven.reimprimivent(CboVenta.Text,TxtVend.Text);
            }
            
        }
    }
}
