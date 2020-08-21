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
    public partial class Concesion : Form
    {
        Clases.Clientes cli = new Clases.Clientes();
        Clases.Conces Conce = new Clases.Conces();
        Clases.Producto prod = new Clases.Producto();
        Clases.Venta ven = new Clases.Venta();

        public Concesion()
        {
            InitializeComponent();
        }

        private void Concesion_Load(object sender, EventArgs e)
        {
            CargarCli();
        }

        private void CargarCli()
        {
            DataTable datos = new DataTable();
            datos = cli.clienSin();
            CboCli.DataSource = datos;
            CboCli.DisplayMember = "nombre";
            CboCli.ValueMember = "id_cliente";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            foreach (DataRow row in datos.Rows)
            {
                coleccion.Add(row["nombre"].ToString());
            }
            CboCli.AutoCompleteCustomSource = coleccion;
            CboCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboCli.AutoCompleteSource = AutoCompleteSource.CustomSource;
            if (datos.Rows.Count>0)  CboCli.SelectedIndex = 0;
        }

        private void CboCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboCli.Text != "" && CboCli.SelectedValue.ToString() != "System.Data.DataRowView")
            { buscarVent(); }
        }

        private void buscarVent()
        {
            DataTable data = new DataTable();
            data = Conce.busconce(CboCli.SelectedValue.ToString());
            int total = data.Rows.Count, cont;
            limpiarconce();
            if (total > 0)
            {
                for (cont = 0; cont < total; cont++)
                {
                    CboConce.Items.Add(data.Rows[cont][0].ToString());
                }
            }
        }

        private void limpiarconce()
        {
            int cont,total = CboConce.Items.Count;

            for (cont = 0; cont < total; cont++)
            {
                CboConce.Items.RemoveAt(0);
            }
        }

        private void CboVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscarprod();
        }

        private void Buscarprod()
        {

            DataTable datos = new DataTable();
            datos = Conce.ProdConce(CboConce.Text);
            DgvProd.DataSource = datos;
            int total= datos.Rows .Count, cont;
            if (total > 0)
            {
                decimal ValorTot=0;
                for (cont = 0; cont < total; cont++)
                {
                    ValorTot += decimal.Parse(datos .Rows[cont][7].ToString ());
                }
                TxtTotal.Text = ValorTot.ToString ();
            }
        }

        private void DgvProd_Click(object sender, EventArgs e)
        {
            //vercant();
        }

        private void vercant()
        {
           
            int indice = DgvProd.CurrentRow.Index;
            NudProd.Value = decimal.Parse(DgvProd.Rows [indice].Cells [5].ToString ());
        }

        private void calculartot()
        {
            int total = DgvProd.RowCount, cont, cantp=0;
            decimal precio = 0, todoven=0,TotGen=0;
            for (cont = 0; cont < total; cont++)
            {
                cantp = int.Parse (DgvProd.Rows[cont].Cells[5].Value.ToString());
                precio = decimal.Parse(DgvProd.Rows[cont].Cells[6].Value.ToString());
                todoven = cantp * precio;
                TotGen += todoven;
                DgvProd.Rows[cont].Cells[7].Value = Convert.ToString(todoven );
            }
            TxtTotal.Text = TotGen.ToString();
        }

        private void NudProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                int indice = DgvProd.CurrentRow.Index;
                DgvProd.Rows[indice].Cells[5].Value = NudProd.Value;
            }
            calculartot();
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {
            prepFact();
        }

        private void prepFact()
        {
            DataTable Prefac = new DataTable();
            DataTable Fact = new DataTable();
            string cliente=cli .CliporConce(CboConce .Text).ToString (), vende= Main.idvende.ToString ();
            Prefac = Conce.ProdConce(CboConce.Text);
            int cont;decimal Vtotal = decimal.Parse(TxtTotal.Text);
            var total = Prefac.Rows.Count;
            Fact.Columns.Add("codigo").DataType = System.Type.GetType("System.String");
            Fact.Columns.Add("producto").DataType = System.Type.GetType("System.String");
            Fact.Columns.Add("estilo").DataType = System.Type.GetType("System.String");
            Fact.Columns.Add("tipo").DataType = System.Type.GetType("System.String");
            Fact.Columns.Add("color").DataType = System.Type.GetType("System.String");
            Fact.Columns.Add("talla").DataType = System.Type.GetType("System.String");
            Fact.Columns.Add("cantidad").DataType = System.Type.GetType("System.String");
            Fact.Columns.Add("precio").DataType = System.Type.GetType("System.String");
            Fact.Columns.Add("total").DataType = System.Type.GetType("System.String");
            for (cont=0;cont<total;cont++)
            {
                int cantAct, cantAnt, CantDvo;
                cantAct = int.Parse(DgvProd.Rows[cont].Cells[5].Value.ToString());
                string idP = DgvProd.Rows[cont].Cells[8].Value.ToString();
                if (cantAct > 0)
                {
                    decimal totalp, precio;
                    precio = decimal.Parse(DgvProd.Rows[cont].Cells[6].Value.ToString());
                    cantAnt = int.Parse(Prefac.Rows[cont][5].ToString());
                    if (cantAct > cantAnt) return;
                    DataRow fila = Fact.NewRow();
                    CantDvo = cantAnt - cantAct;
                    totalp = precio * cantAct;
                    prod.devolverprod(idP, CantDvo.ToString());
                    fila["codigo"] = idP.ToString();
                    fila["producto"] = Prefac.Rows[cont][0].ToString();
                    fila["estilo"] = Prefac.Rows[cont][1].ToString();
                    fila["tipo"] = Prefac.Rows[cont][2].ToString();
                    fila["color"] = Prefac.Rows[cont][3].ToString();
                    fila["talla"] = Prefac.Rows[cont][4].ToString();
                    fila["cantidad"] = cantAct.ToString();
                    fila["precio"] = precio.ToString();
                    fila["total"] = totalp.ToString();
                    Fact.Rows.Add(fila);
                }
                else
                {
                    CantDvo = int.Parse(Prefac.Rows[cont][5].ToString());
                    prod.devolverprod(idP, CantDvo.ToString());
                }
            }
            if (ven.generar_V(Fact, vende,cliente, "Cancelado", "Contado", Vtotal.ToString()))
            {
                if (Conce.CanceConce(CboConce.Text))
                { MessageBox.Show("Venta registrada correctamente"); }
                else { MessageBox.Show("Error al pagar concesion"); }
            }
            else
            {
                MessageBox.Show("Error al registrar ventas");
            } }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int indice = int.Parse (DgvProd.CurrentRow.ToString());
            DgvProd.Rows.RemoveAt(indice);
        }
    }
}
;
