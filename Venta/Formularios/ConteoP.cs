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
        private Clases.RastreoProd track = new Clases.RastreoProd();
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
            string nom, tipo, estilo, color, talla,cant,ubi;
            nom = TxtProd.Text;
            tipo = TxtTipo.Text;
            estilo = TxtEstilo.Text;
            color = Txtcolor.Text;
            talla = TxtTalla.Text;
            ubi = TxtUbi.Text;
            cant = NudCant.Value.ToString();
            
            DgvProd.DataSource = Produ.BuscaProdCant(nom, estilo,tipo, color,talla,cant,ubi);

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void imprimir()
        {
            DataTable datos = new DataTable();

            datos.Columns.Add("codigo").DataType = Type.GetType("System.String");
            datos.Columns.Add("producto").DataType = Type.GetType("System.String");
            datos.Columns.Add("cantidad").DataType = Type.GetType("System.String");
            datos.Columns.Add("Ubi").DataType = Type.GetType("System.String");
            int cont, canti;
            canti = DgvProd.Rows.Count;
           for (cont = 0; cont < canti; cont++)
            {
                DataRow fila = datos.NewRow();
                fila["codigo"] = DgvProd.Rows[cont].Cells[0].Value.ToString();
                fila["producto"]= DgvProd.Rows[cont].Cells[1].Value.ToString() + " " + DgvProd.Rows[cont].Cells[2].Value.ToString() + " " + DgvProd.Rows[cont].Cells[3].Value.ToString() + " " + DgvProd.Rows[cont].Cells[4].Value.ToString() + " " + DgvProd.Rows[cont].Cells[5].Value.ToString();
                fila["cantidad"] = DgvProd.Rows[cont].Cells[6].Value.ToString();
                fila["Ubi"] = DgvProd.Rows[cont].Cells[7].Value.ToString();
                datos.Rows.Add(fila);
            }
            Produ.ImpCantidadprod(datos);

          

        }

        private void BtnTrack_Click(object sender, EventArgs e)
        {
            tracking();
        }

        private void tracking()
        {
            string idprod;
            if (DgvProd.Rows.Count > 0)
            {
                int indice;
                indice = DgvProd.CurrentRow.Index;
                idprod = DgvProd.Rows[indice].Cells[0].Value.ToString();
                track.ReportTrack(idprod);

            }
        }

        private void ConteoP_Load(object sender, EventArgs e)
        {

        }
    }
}
