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
        Clases.Conces Conc = new Clases.Conces();
        

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
            { busqueda(CboProd.SelectedValue.ToString());
            }
            else
            {  }
        }
        //busca producto
        private void busqueda(string id)
        {
            DataTable datos = new DataTable();
            string nombrepod= prod.nomprod(id);
            string tipo="0", estilo="0", color="0";
            tipo = prod.codtipo(id);
            estilo = prod.codestilo(id);
            color = prod.codcolor(id);
            datos = prod.prodId(id);
            llenartipo(id, nombrepod);
            CboTipo.SelectedValue = int.Parse(tipo);
            CboEstilo.SelectedValue = int.Parse(estilo);
            CboColor.SelectedValue = int.Parse(color);
            CboTalla.SelectedValue = id;
            while (CboPrecio.Items.Count > 0)
            { CboPrecio.Items.RemoveAt(0); }
            CboPrecio.Items.Add(datos.Rows[0][2].ToString());
            CboPrecio.Items.Add(datos.Rows[0][3].ToString());
            CboPrecio.SelectedIndex = 1;
            PicExemp.Image = Image.FromFile(@".\imagen\"+prod.imagen(id));
        }

        private void busquedacli(string id)
        {
            DataTable datos = new DataTable();
            datos = cli.buscli(id);
            if (datos.Rows.Count > 0) { 
            TxtDirCli.Text = datos.Rows[0][0].ToString();
            TxtNit.Text = datos.Rows[0][1].ToString();
            TxtCredito.Text = datos.Rows[0][2].ToString();
            }
        }

        //buscar cliente

        #region "Llenado de combos"
        private void llenartipo(string id,string nom)
        {
            DataTable dt = new DataTable();
            dt = prod.tipolst(nom);
            CboTipo.DataSource = dt;
            CboTipo.DisplayMember = "tipo";
            CboTipo.ValueMember = "id";
            llenarestilo(id, nom);
        }
        private void llenarestilo(string id, string nom)
        {
            DataTable dt = new DataTable();
            string tipo = CboTipo.SelectedValue.ToString();
            dt = prod.estilolst(nom, tipo);
            CboEstilo.DataSource = dt;
            CboEstilo.DisplayMember = "estilo";
            CboEstilo.ValueMember = "id";

        }
        private void llenarcolor(string id,string nom)
        {
            DataTable dt = new DataTable();
            string tipo=CboTipo.SelectedValue.ToString (), estilo=CboEstilo.SelectedValue.ToString () ;
            dt = prod.colorlst(nom, estilo, tipo);
            CboColor.DataSource = dt;
            CboColor.DisplayMember = "color";
            CboColor.ValueMember = "id";
            llenarTalla(id, nom);
        }

        private void llenarTalla(string id,string nom)
        {
            DataTable dt = new DataTable();
            string tipo = CboTipo.SelectedValue.ToString(), estilo = CboEstilo.SelectedValue.ToString(), color = CboColor.SelectedValue.ToString();
            dt = prod.tallalst(nom,tipo,estilo,color);
            CboTalla.DataSource = dt;
            CboTalla.DisplayMember = "talla";
            CboTalla.ValueMember = "id_prod";
       }

#endregion



        private void BtnAgr_Click(object sender, EventArgs e)
        {
            agregarprod();
        }

        private void agregarprod()
        {
            string prod = CboProd.SelectedValue.ToString();
            string est = CboEstilo.SelectedValue.ToString();
            string col = CboColor.SelectedValue.ToString();
            string tipo = CboTipo.SelectedValue.ToString();

            if (DgvProd.Rows.Count <= 0)
            {
                DgvProd.Columns.Add("Cod", "Codigo");
                DgvProd.Columns.Add("Producto", "Producto");
                DgvProd.Columns.Add("Estilo", "Estilo");
                DgvProd.Columns.Add("Tipo", "Tipo");
                DgvProd.Columns.Add("Color", "Color");
                DgvProd.Columns.Add("Talla", "Talla");
                DgvProd.Columns.Add("Cantidad", "Cantidad");
                DgvProd.Columns.Add("Precio", "Precio");
                DgvProd.Columns.Add("Subtotal", "Subtotal");
                DgvProd.Columns[0].Visible = false;

            }
            if (revcant(prod, NudCant.Value))
            {
                addprod(prod, col, tipo, est);
            }
            else
            {
                MessageBox.Show("No hay existencias para cubrir venta");
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
            string color = dt.Rows[0][8].ToString();
            string tipo = dt.Rows[0][6].ToString();
            string estilo = dt.Rows[0][10].ToString();
            DgvProd.Rows.Add(dt.Rows[0][0].ToString (),dt.Rows[0][11].ToString(), estilo, tipo, color,CboTalla .Text ,NudCant.Value, CboPrecio.Text, (decimal.Parse(NudCant.Value.ToString ()) * decimal.Parse(CboPrecio.Text)).ToString());
            total += (decimal.Parse(NudCant.Value.ToString()) * decimal.Parse(CboPrecio.Text));
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
                if (DgvProd.Rows.Count > 0)
                { listarProd(tipo, estado, cli);
                    LimpiarDatos();
                }
                else { MessageBox.Show("No exiten productos"); }
            }
            else if (RdbCredito.Checked)
            {
                tipo = "Credito";
                estado = "Pendiente";
                if (DgvProd.Rows.Count > 0)
                { listarProd(tipo, estado, cli);
                    LimpiarDatos();
                }
                else { MessageBox.Show("No existen productos"); }
            }
            else if (RdbConce.Checked)
            {
                estado = "Pendiente";
                if (DgvProd.Rows.Count > 0)
                { ListConce(estado,cli );
                    LimpiarDatos();
                }
                else { MessageBox.Show("No existen productos"); }
            }
        }

        private void ListConce( string estado, string cli)
        {
            string vende = Main.idvende.ToString();
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
            for (cont = 0; cont < filas; cont++)
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

            if (Conc.GenConc(produ, cli,vende, estado ))
            {

                MessageBox.Show("Concesion registrada con exito");
                //vent.genfact(produ, "1", estado, tipo);
            }
            else
            {
                MessageBox.Show("Error en la Concesion");
            }
        }


        private void listarProd(string tipo,string estado,string cli)
        {
            string vende=Main .idvende.ToString ();
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

            if (vent.generar_V(produ, vende,cli, estado, tipo))
            {
                              
                MessageBox.Show("Venta registrada correctamente.");
                //vent.genfact(produ, "1", estado, tipo);
            }
            else
            {
                MessageBox.Show("Error en la venta");
            }
        }


        private void LimpiarDatos()
        {
            while (DgvProd.RowCount > 0)
                {
                    DgvProd.Rows.RemoveAt(0);
                }
            LblTotal.Text = "0";
        }
       
        private void CboNomCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboNomCli.Text != "" && CboNomCli.SelectedValue.ToString() != "System.Data.DataRowView")
            { busquedacli(CboNomCli.SelectedValue.ToString()); }
            else
            { busquedacli("0"); }

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private int selecTalla(string talla)
        {
            int cont, cant;
            cant = CboTalla.Items.Count;
            for(cont = 0;cont < cant;cont++)
            {
                CboTalla.SelectedIndex = cont;
                string tall = CboTalla.Text;
                if (tall == talla)
                {
                    return cont;
                }
               
            }
            return -1;
        }

        private void CboTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboTipo.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string nombrepod = prod.nomprod(CboProd.SelectedValue.ToString());
                llenarestilo(CboProd.SelectedValue.ToString(),nombrepod);
           }
        }

        private void selectprod(string tipo,string estilo, string color,string talla)
        {
            /*string idpod;
            CboTipo.SelectedValue = tipo;
            CboEstilo.SelectedValue = estilo;
            CboColor.SelectedValue = color;
           int tall=selecTalla(talla);
            CboTalla.SelectedIndex=tall ;
            idpod = prod.PeticionIdProd(tipo, estilo, color, talla);
            CboProd.SelectedValue = idpod;*/
            CboProd.Text = "";
        }

        private void CboEstilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboEstilo.Text != "" && CboEstilo.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string nombrepod = prod.nomprod(CboProd.SelectedValue.ToString());
                llenarcolor("", nombrepod);
            }
        }

        private void CboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboColor.Text != "" && CboColor.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string nombrepod = prod.nomprod(CboProd.SelectedValue.ToString());
                llenarTalla(CboProd.SelectedValue .ToString (), nombrepod);
            }
        }

        private void CboTalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( CboTalla.SelectedValue .ToString () != "System.Data.DataRowView" )
            {
                DataTable datos = new DataTable();
                datos = prod.prodId(CboTalla.SelectedValue.ToString());
                while (CboPrecio.Items.Count > 0)
                { CboPrecio.Items.RemoveAt(0); }
                CboPrecio.Items.Add(datos.Rows[0][2].ToString());
                CboPrecio.Items.Add(datos.Rows[0][3].ToString());
                CboPrecio.SelectedIndex = 1;
                PicExemp.Image = Image.FromFile(@".\imagen\" + prod.imagen(CboTalla.SelectedValue.ToString ()));
            }
        }

        private void BtnUltVent_Click(object sender, EventArgs e)
        {
            int idVenta = vent.idVentaCliente(CboNomCli.SelectedValue.ToString());
            if (idVenta <= 0)
            {
                MessageBox.Show("No existen ventas anteriores de este cliente");
            }
            else
            {
                //Mostrar ultima venta
                vent.RegenFact(idVenta.ToString());
            }

        }

        private void BtnBusca_Click(object sender, EventArgs e)
        {

        }
    }
}
