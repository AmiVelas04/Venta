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
    public partial class ConteoP : Form
    {
        private Clases.Producto Produ = new Clases.Producto();
        public ConteoP()
        {
            InitializeComponent();
        }

        private void BtnBusca_Click(object sender, EventArgs e)
        {
            buscarp();
        }

        private void buscarp()
        {
            string nom, tipo, estilo, color, talla,cant;
            nom = TxtProd.Text;
            tipo = TxtTipo.Text;
            estilo = TxtEstilo.Text;
            color = Txtcolor.Text;
            talla = TxtTalla.Text;
            cant = NudCant.Value.ToString();
            
            DgvProd.DataSource = Produ.BuscaProdCant(nom, estilo,tipo, color,talla,cant);

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void imprimir()
        {
            DataTable datos = new DataTable();

            datos.Columns.Add("codigo").DataType = System.Type.GetType("System.String");
            datos.Columns.Add("producto").DataType = System.Type.GetType("System.String");
            datos.Columns.Add("cantidad").DataType = System.Type.GetType("System.String");
            int cont, canti;
            canti = DgvProd.Rows.Count;
           for (cont = 0; cont < canti; cont++)
            {
                DataRow fila = datos.NewRow();
                fila["codigo"] = DgvProd.Rows[cont].Cells[0].Value.ToString();
                fila["producto"]= DgvProd.Rows[cont].Cells[1].Value.ToString() + " " + DgvProd.Rows[cont].Cells[2].Value.ToString() + " " + DgvProd.Rows[cont].Cells[3].Value.ToString() + " " + DgvProd.Rows[cont].Cells[4].Value.ToString() + " " + DgvProd.Rows[cont].Cells[5].Value.ToString();
                fila["cantidad"] = DgvProd.Rows[cont].Cells[6].Value.ToString();

                datos.Rows.Add(fila);
            }
            Produ.ImpCantidadprod(datos);

          

        }
    }
}
