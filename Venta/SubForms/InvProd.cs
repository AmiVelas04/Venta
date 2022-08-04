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
    public partial class InvProd : Form
    {
        Clases.Producto prod = new Clases.Producto("");
        DataTable datos = new DataTable();
        
        public InvProd()
        {
            InitializeComponent();
        }

        private void InvProd_Load(object sender, EventArgs e)
        {

        }

        private void buscar()
        {
            datos.Clear();
            datos= prod.buscarprod(TxtNom.Text);
            DgvProd.DataSource = datos;
            DgvProd.Refresh();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardarcambios();
        }

        private void DgvProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarcantidades();
        }

        private void TxtNom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                buscar();
            }
        }

        private void guardarcambios()
        {
            int ante, actual;
            string codprod;
            int indice = DgvProd.CurrentRow.Index;
            codprod = DgvProd.Rows[indice].Cells[0].Value.ToString();
            ante = Int32.Parse(TxtCant.Text);
            actual = Int32.Parse(TxtRev.Text);
            if (ante == actual)
            {
                MessageBox.Show("Exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (prod.inv_camb_prods(codprod,ante,actual))
                {
                    MessageBox.Show("Se realizaron los cambios correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buscar();
                    DgvProd.Rows[indice].Selected = true;
                    TxtCant.Text = TxtRev.Text;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar los cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void DgvProd_SelectionChanged(object sender, EventArgs e)
        {
         //   cargarcantidades();
        }

        private void cargarcantidades()
        {
            int indice = DgvProd.CurrentRow.Index;
            TxtCant.Text = DgvProd.Rows[indice].Cells[6].Value.ToString();
            TxtRev.Text = DgvProd.Rows[indice].Cells[6].Value.ToString();
        }
    }
}
