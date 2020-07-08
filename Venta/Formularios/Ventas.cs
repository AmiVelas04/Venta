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
        Clases.Venta vent = new Clases.Venta();
        Clases.Clientes cli = new Clases.Clientes();
    
        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            cargar();
            cargarcli();
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
            RdbContado.Select();
        }
        private void cargarcli()
        {
            DataTable datos = new DataTable();
            datos = cli.clientes();
            CboNomCli.DataSource = datos;
            CboNomCli.DisplayMember = "nombre";
            CboNomCli.ValueMember = "id_cliente";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in datos.Rows)
            {
                coleccion.Add(row["nombre"].ToString());
            }
            CboNomCli.AutoCompleteCustomSource = coleccion;
            CboNomCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboNomCli.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboNomCli.SelectedIndex = 0;
        }

        private void CboProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboProd.Text !="" && CboProd.SelectedValue.ToString() !="System.Data.DataRowView" )
            { busqueda(CboProd.SelectedValue.ToString()); }
            else
            {  }
            
        }
        //busca producto
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

        private void busquedacli(string id)
        {
            DataTable datos = new DataTable();
            datos = cli.buscli(id);
            TxtDirCli.Text = datos.Rows[0][0].ToString();
            TxtNit.Text = datos.Rows[0][1].ToString();
            TxtCredito.Text = datos.Rows[0][2].ToString();
        }

        //buscar cliente
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
                DgvProd.Columns.Add("Cod","Codigo");
                DgvProd.Columns.Add("Producto","Producto");
                DgvProd.Columns.Add("Estilo", "Estilo");
                DgvProd.Columns.Add("Tipo", "Tipo");
                DgvProd.Columns.Add("Color", "Color");
                DgvProd.Columns.Add("Talla", "Talla");
                DgvProd.Columns.Add("Cantidad", "Cantidad");
                DgvProd.Columns.Add("Precio", "Precio");
                DgvProd.Columns.Add("Subtotal", "Subtotal");
                DgvProd.Columns[0].Visible = false;
            }
            if (revcant(prod,NudCant .Value ))
            {
                addprod(prod, col, tipo, est);
            }
            else
            {
                MessageBox.Show("No hay exitencias para cubrir venta");
            }
        }

        private bool revcant(string idprod,decimal cant)
        {
            int total = DgvProd.Rows.Count;
            int cont,canti=Int32.Parse (cant.ToString ());
            
            for (cont = 0; cont < total; cont++)
            {
                if (DgvProd.Rows[cont].Cells[0].Value .ToString () == idprod)
                    canti += Int32.Parse(DgvProd.Rows[cont].Cells[6].Value.ToString ());
            }
            return prod.exitencias(idprod, canti);
        }

        private void addprod(string idp, string idcolor, string idtipo, string idestilo)
        {
            decimal total = 0;
            if (LblTotal.Text != "Precio") total = decimal.Parse(LblTotal.Text);
            DataTable dt = new DataTable();
            dt = prod.prodId(idp);
            string color = prod.colorp(idcolor).Rows[0][1].ToString();
            string tipo = prod.tipop(idtipo).Rows[0][1].ToString();
            string estilo = prod.estilop(idestilo).Rows[0][1].ToString();
            DgvProd.Rows.Add(dt.Rows[0][0].ToString (),dt.Rows[0][11].ToString(), estilo, tipo, color,CboTalla .Text ,NudCant.Value, TxtPrecio.Text, (decimal.Parse(NudCant.Value.ToString ()) * decimal.Parse(TxtPrecio.Text)).ToString());
            
            total += (decimal.Parse(NudCant.Value.ToString()) * decimal.Parse(TxtPrecio.Text));
            LblTotal.Text = total.ToString();
        }

        private void BtnGenVen_Click(object sender, EventArgs e)
        {
            string cli = CboNomCli.SelectedValue.ToString();
            string estado="", tipo="";
            if (RdbContado.Checked)
            {
                tipo = "Contado";
                estado = "Cancelado";
            }
            else if (RdbCredito.Checked)
            {
                tipo = "Credito";
                estado = "Pendiente";
            }
            else if (RdbConce.Checked)
            {
                tipo = "Concesion";
                estado = "Pendiente";
            }
            if (DgvProd.Rows.Count > 0)
            { listarProd(tipo, estado,cli); }
            else { MessageBox.Show("No exiten productos"); }
            

        }

        private void listarProd(string tipo,string estado,string cli)
        {
            int filas = DgvProd.Rows.Count;
            int cont, indice;
            indice = DgvProd.CurrentRow.Index;
           
            DataTable produ = new DataTable();
            produ.Columns.Add("codigo").DataType = System.Type.GetType("System.String");
            produ.Columns.Add("producto").DataType = System.Type.GetType("System.String");
            produ.Columns.Add("estilo").DataType = System.Type.GetType("System.String");
            produ.Columns.Add("tipo").DataType = System.Type.GetType("System.String");
            produ.Columns.Add("color").DataType = System.Type.GetType("System.String");
            produ.Columns.Add("talla").DataType = System.Type.GetType("System.String");
            produ.Columns.Add("cantidad").DataType = System.Type.GetType("System.String");
            produ.Columns.Add("precio").DataType = System.Type.GetType("System.String");
            produ.Columns.Add("total").DataType = System.Type.GetType("System.String");

            for (cont=0;cont<filas;cont++)
            {
                DataRow fila = produ.NewRow();
                fila["codigo"] = DgvProd.Rows[cont].Cells[0].Value;
                fila["producto"] = DgvProd.Rows[cont].Cells[1].Value;
                fila["estilo"] = DgvProd.Rows[cont].Cells[2].Value;
                fila["tipo"] = DgvProd.Rows[cont].Cells[3].Value;
                fila["color"] = DgvProd.Rows[cont].Cells[4].Value;
                fila["talla"] = DgvProd.Rows[cont].Cells[5].Value;
                fila["cantidad"] = DgvProd.Rows[cont].Cells[6].Value;
                fila["precio"] = DgvProd.Rows[cont].Cells[7].Value;
                fila["total"] = DgvProd.Rows[cont].Cells[8].Value;
                produ.Rows.Add(fila);
            }

            if (vent.generar_V(produ, "1",cli, estado, tipo))
            {
                              
                MessageBox.Show("Venta registrada correctamente.");
                //vent.genfact(produ, "1", estado, tipo);
            }
            else
            {
                MessageBox.Show("Error en la venta");
            }
        }


        private void IngConce()
        { }
       
        private void CboNomCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboNomCli.Text != "" && CboNomCli.SelectedValue.ToString() != "System.Data.DataRowView")
            { busquedacli(CboNomCli.SelectedValue.ToString()); }
            else
            { busquedacli("1"); }

        }
    }
}
