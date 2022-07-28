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
    public partial class IngresoRapidoProd : Form
    {
        Clases.Producto prod = new Clases.Producto("");
        public IngresoRapidoProd()
        {
            InitializeComponent();
        }

        private void TxtCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string cod;
                string mensajes;
                DataTable datos = new DataTable();
                cod = "R"+TxtCod.Text;
                datos = prod.prodId(cod);
                if (datos.Rows.Count > 0)
                {
                    mensajes = "Producto:" + datos.Rows[0][14].ToString();
                    mensajes = mensajes + "\n";
                    mensajes = mensajes + "Estilo:" + datos.Rows[0][13].ToString();
                    mensajes = mensajes + "\n";
                    mensajes = mensajes + "Tipo:" + datos.Rows[0][9].ToString();
                    mensajes = mensajes + "\n";
                    mensajes = mensajes + "Color: " + datos.Rows[0][11].ToString();
                    mensajes = mensajes + "\n";
                    mensajes = mensajes + "Talla: " + datos.Rows[0][7].ToString();
                   LblDatos.Text = mensajes;
                }
                else
                { }
                
                

            }
        }

        private void BtnAgre_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void agregar()
        {
            if (NudCant.Value > 0)
            {
                string cod = "R"+TxtCod.Text;
                int cantidad = int.Parse(NudCant.Value.ToString());
                if (prod.aumentarprod(cod, cantidad.ToString()))
                {
                    MessageBox.Show("Producto ingresado correctamente","Ingreso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar el producto", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No se ha ingresado la cantidad del producto");
            }
        }

        private void limpiar()
        {
            TxtCod.Clear();
            LblDatos.Text = "";
            NudCant.Value = 0;

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void IngresoRapidoProd_Load(object sender, EventArgs e)
        {

        }
    }
}
