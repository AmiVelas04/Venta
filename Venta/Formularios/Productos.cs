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
    public partial class Productos : Form
    {
        Clases.conexion conn = new Clases.conexion();
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
        private void guardar()
        {
            string Nomprod = TxtProdNom.Text;
            string estilo = CboEstilo.Text;
            string tipo = CboTipo.Text;
            string color = CboColor.Text;
            string talla = TxtTalla.Text;
            int cantidad = Int32 .Parse(NudCantidad.Value.ToString ());
            decimal precio_c = Decimal.Parse(TxtPrecio_C.Text);
            decimal precio_m = Decimal.Parse(TxtPrecio_C.Text);
            decimal precio_v = Decimal.Parse(TxtPrecio_C.Text);
            string imagen = " ";


            string[] datos = {Nomprod,estilo,tipo,color,talla,cantidad.ToString (),precio_c.ToString () ,precio_m.ToString () ,precio_v.ToString () ,imagen };

        }
    }
}
