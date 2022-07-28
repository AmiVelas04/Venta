using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta.SubForms
{
    public partial class FrmCostoCh : Form
    {
        Clases.Producto prod = new Clases.Producto("");
       public string id { get; set; }
        public string Nom { get; set; }
        public FrmCostoCh()
        {
            InitializeComponent();
        }

        private void FrmCostoCh_Load(object sender, EventArgs e)
        {
            cargarcosto(id);
        }

        private void cargarcosto(string id)
        {
            int total;
            decimal valor = 0;
            TextBox[] Desc = {TxtD1, TxtD2, TxtD3, TxtD4, TxtD5 };
            TextBox[] Costo = { TxtC1, TxtC2, TxtC3, TxtC4, TxtC5};
            DataTable datos = new DataTable();
            datos = prod.TodosCostos(id);
            total = datos.Rows.Count;
            if (total > 0)
            {
                for (int i = 0; i < total; i++)
                {
                    Desc[i].Text = datos.Rows[i][2].ToString();
                    Costo[i].Text = datos.Rows[i][3].ToString();
                    valor += decimal.Parse(datos.Rows[i][3].ToString());
                }
            }
            LblTotal.Text = "Total Q." + valor.ToString();
        }


        private bool SaveCosto(string cod)
        {
            TextBox[] Desc = { TxtD1, TxtD2, TxtD3, TxtD4, TxtD5 };
            TextBox[] Costo = { TxtC1, TxtC2, TxtC3, TxtC4, TxtC5 };
            decimal total = 0;
            bool Exito= false;
            foreach (var item in Costo)
            {
                decimal val = decimal.Parse(item.Text);
                total += val;
            }
            for (int i = 0; i < 5; i++)
            {
                string[] datos = {cod,Desc[i].Text,Costo[i].Text,total.ToString() };
                Exito = prod.savecosto(datos);
                if (!Exito) return Exito;
            }
            return Exito;
        }

        private bool UpdateCosto(string cod)
        {
            TextBox[] Desc = { TxtD1, TxtD2, TxtD3, TxtD4, TxtD5 };
            TextBox[] Costo = { TxtC1, TxtC2, TxtC3, TxtC4, TxtC5 };
            List<string[]> todo = new List<string[]>();
            decimal total = 0;
            bool Exito = false;
            foreach (var item in Costo)
            {
                decimal val = decimal.Parse(item.Text);
                total += val;
            }
            for (int i = 0; i < 5; i++)
            {
                string[] datos = { Desc[i].Text, Costo[i].Text, total.ToString(),cod };
                todo.Add(datos);
                            }
            return prod.updatecosto(todo,cod);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            datos = prod.TodosCostos(id);
            if (datos.Rows.Count > 0)
            {
                if (UpdateCosto(id))
                { MessageBox.Show("Se actualizó correctamente los datos de costo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                { MessageBox.Show("No se pudo actualizar los datos de costo" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else
            { if (SaveCosto(id))
                { MessageBox.Show("Se guardó correctamente los datos de costo", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                { MessageBox.Show("No se pudo guardar los datos de costo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }

        }

        private void TxtC1_TextChanged(object sender, EventArgs e)
        {
            cambioTexto();
        }

        private void cambioTexto()
        {
            TextBox[] Costo = { TxtC1, TxtC2, TxtC3, TxtC4, TxtC5 };
            decimal total=0, valor;
            foreach (var item in Costo)
            {
                if (decimal.TryParse(item.Text, out valor))
                {
                    total += valor;
                }
                else
                { total += 0; }
            }
            LblTotal.Text = "Total Q." + total.ToString();
        }

        private void TxtC2_TextChanged(object sender, EventArgs e)
        {
            cambioTexto();
        }

        private void TxtC3_TextChanged(object sender, EventArgs e)
        {
            cambioTexto();

        }

        private void TxtC4_TextChanged(object sender, EventArgs e)
        {
            cambioTexto();
        }

        private void TxtC5_TextChanged(object sender, EventArgs e)
        {
            cambioTexto();
        }
    }
}
