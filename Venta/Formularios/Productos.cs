using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta.Formularios
{
    public partial class Productos : Form
    {
        Clases.conexion conn = new Clases.conexion();
        Clases.Producto prod = new Clases.Producto();
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            //Agregar datos al combo box clientre
            DataTable datoscli = new DataTable();
            datoscli = prod.nomprod();
            TxtProdNom.AutoCompleteCustomSource = prod.Productos();
            TxtProdNom.AutoCompleteMode = AutoCompleteMode.Suggest;
            TxtProdNom.AutoCompleteSource = AutoCompleteSource.CustomSource;

                
  
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
            string idestilo = CboEstilo.SelectedValue!=null ?CboEstilo .SelectedValue .ToString() :"0" ;
            string idtipo = CboTipo.SelectedValue != null? CboTipo.SelectedValue.ToString() : "0";
            string idcolor = CboColor.SelectedValue != null ? CboColor.SelectedValue.ToString() : "0" ; 
            string talla = TxtTalla.Text;
            int cantidad = Int32 .Parse(NudCantidad.Value.ToString ());
            decimal precio_c = Decimal.Parse(TxtPrecio_C.Text);
            decimal precio_m = Decimal.Parse(TxtPrecio_M.Text);
            decimal precio_v = Decimal.Parse(TxtPrecio_V.Text);
            string imagen = " ";
            string estilo = CboEstilo.DisplayMember != null ?  CboEstilo.Text :"";
            string tipo = CboTipo.DisplayMember != null ? CboTipo.Text : "";
            string color = CboColor.DisplayMember != null ? CboColor.Text : "";
            



            string[] datos = {Nomprod,idestilo,idtipo,idcolor,talla,cantidad.ToString (),precio_c.ToString () ,precio_m.ToString () ,precio_v.ToString () ,imagen,estilo,tipo,color};

            if (prod.ingreso_prod(datos))
            {
                MessageBox.Show("Producto ingresado correctamente");
            }
            else
            {
                MessageBox.Show("Error al ingresar producto");
            }
        }

        private void TxtProdNom_TextChanged(object sender, EventArgs e)
        {
            // agregar estilos
            DataTable datos = new DataTable();
            datos = prod.estilo(TxtProdNom .Text);
            CboEstilo.DataSource = datos;
            CboEstilo.DisplayMember = "estilo";
            CboEstilo.ValueMember = "id";
            AutoCompleteStringCollection coleccionE = new AutoCompleteStringCollection();
            foreach (DataRow row in datos.Rows)
            {
                coleccionE.Add(row["estilo"].ToString());

            }
            CboEstilo.AutoCompleteCustomSource = coleccionE;
            CboEstilo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboEstilo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            

            // agregar tipo
            datos = prod.tipo(TxtProdNom .Text);
            CboTipo .DataSource = datos;
            CboTipo.DisplayMember = "tipo";
            CboTipo.ValueMember = "id";
            AutoCompleteStringCollection coleccionT = new AutoCompleteStringCollection();
            foreach (DataRow row in datos.Rows)
            {
                coleccionT.Add(row["tipo"].ToString());

            }
            CboTipo.AutoCompleteCustomSource = coleccionT;
            CboTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboTipo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            
            //agregar color
            datos = prod.color(TxtProdNom.Text);
            CboColor  .DataSource = datos;
            CboColor.DisplayMember = "color";
            CboColor.ValueMember = "id";
            AutoCompleteStringCollection coleccionC = new AutoCompleteStringCollection();
            foreach (DataRow row in datos.Rows)
            {
                coleccionC.Add(row["color"].ToString());
            }
            CboColor.AutoCompleteCustomSource = coleccionT;
            CboColor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboColor.AutoCompleteSource = AutoCompleteSource.CustomSource;






        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {

        }
    }
}
