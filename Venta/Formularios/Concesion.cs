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
            CboCli.SelectedIndex = 0;
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
            if (total > 0)
            {
                for (cont = 0; cont < total; cont++)
                {
                    CboVenta.Items.Add(data.Rows[cont][0].ToString());
                }
            }
        }

        private void CboVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscarprod();
        }

        private void Buscarprod()
        {

            DataTable datos = new DataTable();
            datos = Conce.ProdConce(CboVenta.Text);
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
            


        }

        private void prepFact()
        {
            DataTable Prefac = new DataTable();
            Prefac = Conce.ProdConce(CboVenta.Text);
            int cont;
            var total = Prefac.Rows.Count;
            for (cont=0;cont<total;cont++)
            {
                int cantAct, cantAnt, CantDvo;
                decimal totalp, precio;
                string idP = DgvProd.Rows[cont].Cells[7].Value.ToString();
                string idvd= DgvProd.Rows[cont].Cells[8].Value.ToString();
                precio = decimal.Parse(DgvProd.Rows[cont].Cells[6].Value.ToString());
                
                cantAnt = int.Parse (Prefac.Rows[cont][5].ToString());
                cantAct = int.Parse(DgvProd.Rows[cont].Cells[5].Value.ToString());
                if (cantAct > cantAnt) return;
                CantDvo = cantAnt - cantAct;
                totalp = precio * cantAct;
                prod.devolverprod(idP, CantDvo.ToString());
                ven.modVenta(idvd, cantAct.ToString(), totalp.ToString());
            }
        }


    }
}
;
