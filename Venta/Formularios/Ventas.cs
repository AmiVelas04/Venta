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
    public partial class Ventas : Form
    {
        Clases.Producto prod = new Clases.Producto();
        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            DataTable dt = new DataTable();
            dt= prod.prodvent();
            CboProd.DataSource = dt; 
            CboProd.DisplayMember = "produ";
            CboProd.ValueMember = "Codigo";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(row["produ"].ToString());
            }
            CboProd.AutoCompleteCustomSource = coleccion;
            CboProd.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboProd.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboProd.Text = "";
            PicExemp.Image = PicExemp.ErrorImage;
            
        }

        private void CboProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboProd.Text !="" && CboProd.SelectedValue.ToString() !="System.Data.DataRowView" )
            { busqueda(CboProd.SelectedValue.ToString()); }
            else
            {  }
            
        }

        private void busqueda(string id)
        {
            DataTable datos = new DataTable();
            datos = prod.prodId(id);

            llenarcolor(id);
            llenarestilo(id);
            llenarTalla(id);
            llenartipo(id);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            coleccion.Add(datos.Rows[0][1].ToString ());
            coleccion.Add(datos.Rows[0][2].ToString());
            TxtPrecio.AutoCompleteCustomSource = coleccion;
            //TxtPrecio.AutoCompleteMode = AutoCompleteMode.Suggest;
            //TxtPrecio.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtPrecio.Text = datos.Rows[0][1].ToString();

        }

        private void llenartipo(string id)
        {
            DataTable dt = new DataTable();
            dt = prod.tipop(id);
            CboTipo.DataSource = dt;
            CboTipo.DisplayMember = "tipo";
            CboTipo.ValueMember = "id";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(row["tipo"].ToString());
            }
            CboTipo.AutoCompleteCustomSource = coleccion;
            CboTipo.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboTipo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void llenarcolor(string id)
        {
            DataTable dt = new DataTable();
            dt = prod.colorp(id);
            CboColor.DataSource = dt;
            CboColor.DisplayMember = "color";
            CboColor.ValueMember = "id";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(row["color"].ToString());
            }
            CboColor.AutoCompleteCustomSource = coleccion;
            CboColor.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboColor.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void llenarTalla(string id)
        {
            DataTable dt = new DataTable();
            dt = prod.tallap(id);
            CboTalla.DataSource = dt;
            CboTalla.DisplayMember = "talla";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(row["talla"].ToString());
            }
            CboTalla.AutoCompleteCustomSource = coleccion;
            CboTalla.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboTalla.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void llenarestilo(string id)
        {
            DataTable dt = new DataTable();
            dt = prod.estilop(id);
            CboEstilo.DataSource = dt;
            CboEstilo.DisplayMember = "estilo";
            CboEstilo.ValueMember = "id";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(row["estilo"].ToString());
            }
            CboEstilo.AutoCompleteCustomSource = coleccion;
            CboEstilo.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboEstilo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void BtnAgr_Click(object sender, EventArgs e)
        {
            string prod = CboProd.SelectedValue .ToString();
            string est = CboEstilo.SelectedValue.ToString();
            string col = CboColor.SelectedValue.ToString();
            string tipo = CboTipo.SelectedValue.ToString();
            if (DgvProd.Rows.Count <= 0)
            {
                DgvProd.Columns.Add("Producto","Producto");
                DgvProd.Columns.Add("Estilo", "Estilo");
                DgvProd.Columns.Add("Tipo", "Tipo");
                DgvProd.Columns.Add("Color", "Color");
                DgvProd.Columns.Add("Talla", "Talla");
                DgvProd.Columns.Add("Cantidad", "Cantidad");
                DgvProd.Columns.Add("Precio", "Precio");
                DgvProd.Columns.Add("Subtotal", "Subtotal");
            }
            addprod(prod, col,tipo,est);

        }

        private void addprod(string idp, string idcolor, string idtipo, string idestilo)
        {
            DataTable dt = new DataTable();
            
            dt = prod.prodId(idp);
            string color = prod.colorp(idcolor).Rows[0][1].ToString();
            string tipo = prod.tipop(idtipo).Rows[0][1].ToString();
            string estilo = prod.estilop(idestilo).Rows[0][1].ToString();
            DgvProd.Rows.Add(dt.Rows[0][10].ToString(), estilo, tipo, color,CboTalla .Text ,NudCant.Value, TxtPrecio.Text, (decimal.Parse(NudCant.Value.ToString ()) * decimal.Parse(TxtPrecio.Text)).ToString());

        }

    }
}
