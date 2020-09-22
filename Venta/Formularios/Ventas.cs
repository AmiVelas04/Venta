using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Venta.Formularios
{
    public partial class Ventas : Form
    {
        Clases.Producto prod = new Clases.Producto();
        Clases.Venta vent = new Clases.Venta();
        Clases.Clientes cli = new Clases.Clientes();
        Clases.Conces Conc = new Clases.Conces();
        Clases.Salidaprod sal = new Clases.Salidaprod();

        public Ventas()
        {
            InitializeComponent();
        }
        private void Ventas_Load(object sender, EventArgs e)
        {
            LblTotal.Text = "0";
            cargar();
            cargarcli();

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
            while (CboPrecioM.Items.Count > 0)
            { CboPrecioM.Items.RemoveAt(0); }
            CboPrecioM.Items.Add(datos.Rows[0][2].ToString());
            CboPrecioM.Items.Add(datos.Rows[0][3].ToString());
            CboPrecio.Items.Add(datos.Rows[0][4].ToString());
            CboPrecio.Items.Add(datos.Rows[0][5].ToString());
            CboPrecio.Items.Add(datos.Rows[0][6].ToString());
            char[] elim = { 'r', 'R' };
            TxtCod.Text = datos.Rows[0][0].ToString().TrimStart(elim);
            CboPrecioM.SelectedIndex = 1;
            CboPrecio.SelectedIndex = 2;
            LblPosi.Text = datos.Rows[0][15].ToString();
            try
            {
                using (var stream = File.Open(@".\" + @".\imagen\" + prod.imagen(id), FileMode.Open))
                {
                    Bitmap archivo = new Bitmap(stream);
                    Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                    PicExemp.Image = muestra;
                }
                //   PicExemp.Image = Image.FromFile();
                PicExemp.Tag = @".\imagen\" + prod.imagen(id);
               
            }
            catch (FileNotFoundException ex)
            {
                using (var stream = File.Open(@".\" + @".\imagen\0.jpg", FileMode.Open))
                {
                    Bitmap archivo = new Bitmap(stream);
                    Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                    PicExemp.Image = muestra;
                }
                //   PicExemp.Image = Image.FromFile();
                PicExemp.Tag = @".\imagen\" + prod.imagen(id);

            }
            int total = prod.cantidadprod(id);
            lbldisp.Text = total.ToString();
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
        private void cargar()
        {
            DataTable dt = new DataTable();
            dt = prod.prodvent();
            CboProd.DataSource = dt;
            CboProd.DisplayMember = "produ";
            CboProd.ValueMember = "Codigo";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(row["produ"].ToString());
            }
            CboProd.AutoCompleteCustomSource = coleccion;
            CboProd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboProd.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboProd.SelectedValue = 0;
            // CboProd.Text = "";
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
            if (datos.Rows.Count > 0)
            {
                //CboNomCli.SelectedValue = 1;
                busquedacli("1");
            }

        }
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
                DgvProd.Columns.Add("Materiap","Materia Prima");
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
            string color = dt.Rows[0][11].ToString();
            string tipo = dt.Rows[0][9].ToString();
            string estilo = dt.Rows[0][13].ToString();
            string precio="0";
            if (ChkMay.Checked)
            { precio = CboPrecioM.Text; }
            else { precio = CboPrecio.Text; }
            string materia = "";
            if (dt.Rows[0][16].ToString() == "True") { materia = "Si"; }
            else { materia = "No"; }
            DgvProd.Rows.Add(dt.Rows[0][0].ToString (),dt.Rows[0][14].ToString(), estilo, tipo, color,CboTalla .Text ,NudCant.Value, precio, (decimal.Parse(NudCant.Value.ToString ()) * decimal.Parse(precio)),materia);
            total += (decimal.Parse(NudCant.Value.ToString()) * decimal.Parse(precio));
            LblTotal.Text = total.ToString();
        }

        private void BtnGenVen_Click(object sender, EventArgs e)
        {
            if (TxtMonto.Text == "") TxtMonto.Text = "0";
            //if (DgvProd.Rows.Count > 0)
                venta();
            
        }

        private void venta()
        {
            if (RdbContado.Checked)
            {
                if ((decimal.Parse(LblTotal.Text) > decimal.Parse(TxtMonto.Text)))
                {// MessageBox.Show("El monto es menor que el valor total"); 
                }
                else
                {
                  /*  decimal cambio;
                    cambio = decimal.Parse(TxtMonto.Text) - decimal.Parse(LblTotal.Text);
                    MessageBox.Show("Cambio: Q." + cambio.ToString());*/
                    
                }
                if (TxtMonto.Text == "") TxtMonto.Text = "0";
                pago();
            }
            else if (RdbCredito.Checked)
            {
                if (TxtMonto.Text == "") TxtMonto.Text = "0";
                pago();
            }
            else if (RdbConce.Checked)
            {
                if (TxtMonto.Text == "") TxtMonto.Text = "0";
                pago();
            }
            else if (RdbProd.Checked)
            {
                SalidaProd();
            }
        }

        private void SalidaProd()
        {
            if (materiaprim())
            {
                string vende = Main.idvende.ToString();
                string soli = TxtSoli.Text;
                int filas = DgvProd.Rows.Count;
                int cont, indice;
                indice = DgvProd.CurrentRow.Index;
                DataTable produ = new DataTable();
                produ.Columns.Add("codigo").DataType = System.Type.GetType("System.String");
                produ.Columns.Add("cantidad").DataType = System.Type.GetType("System.String");
                string[] datos = { vende, soli };
                for (cont = 0; cont < filas; cont++)
                {
                    DataRow fila = produ.NewRow();
                    fila["codigo"] = DgvProd.Rows[cont].Cells[0].Value;
                    fila["cantidad"] = DgvProd.Rows[cont].Cells[6].Value;
                    produ.Rows.Add(fila);
                }
                if (sal.GenerarSalidaprod(datos, produ))
                {
                    MessageBox.Show("Salida de producto registrada");
                }
                else
                {
                    MessageBox.Show("Error de registro de salida");
                }
            }
            else
            {
                MessageBox.Show("No se puede dar salida a productos que no sean materia prima");
            }
        }

        private bool materiaprim()
        {
            int cant, cont;
            cant = DgvProd.Rows.Count;
            for (cont = 0; cont < cant; cont++)
            {
                if (DgvProd.Rows[cont].Cells[9].Value.ToString() == "No") return false;
            }
            return true;
        }
        private void pago()
        {
            string cli = CboNomCli.SelectedValue.ToString();
            string estado = "", tipo = "";
            decimal total;
            total = decimal.Parse(TxtMonto.Text);
            if (RdbContado.Checked)
            {
                tipo = "Contado";
                estado = "Cancelado";
                if (DgvProd.Rows.Count > 0)
                {
                    listarProd(tipo, estado, cli,total.ToString ());
                    LimpiarDatos();
                }
                else { MessageBox.Show("No exiten productos"); }
            }
            else if (RdbCredito.Checked)
            {
                tipo = "Credito";
                estado = "Pendiente";
                if (DgvProd.Rows.Count > 0)
                {
                    listarProd(tipo, estado, cli, total.ToString());
                    LimpiarDatos();
                }
                else { MessageBox.Show("No existen productos"); }
            }
            else if (RdbConce.Checked)
            {
                estado = "Pendiente";
                if (DgvProd.Rows.Count > 0)
                {
               ListConce(estado, cli,"");
                    LimpiarDatos();
                }
                else { MessageBox.Show("No existen productos"); }
            }
        }
       private void ListConce( string estado, string cli,string pago)
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
        private void listarProd(string tipo,string estado,string cli,string pago)
        {
            string vende = Main .idvende.ToString ();
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
            if (vent.generar_V(produ, vende,cli, estado, tipo,pago))
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
            TxtMonto.Text = "0";
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
        private void CboTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboTipo.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string nombrepod = prod.nomprod(CboProd.SelectedValue.ToString());
                llenarestilo(CboProd.SelectedValue.ToString(),nombrepod);
           }
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
                try
                {
                    using (var stream = File.Open(@".\" + @".\imagen\" + prod.imagen(CboTalla.SelectedValue.ToString()), FileMode.Open))
                    {
                        Bitmap archivo = new Bitmap(stream);
                        Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                        PicExemp.Image = muestra;
                    }
                    //PicExemp.Image = Image.FromFile(@".\imagen\" + prod.imagen(CboTalla.SelectedValue.ToString ()));
                    PicExemp.Tag = prod.imagen(CboTalla.SelectedValue.ToString());
                }
                catch (FileNotFoundException ex){
                    using (var stream = File.Open(@".\" + @".\imagen\0.jpg", FileMode.Open))
                    {
                        Bitmap archivo = new Bitmap(stream);
                        Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                        PicExemp.Image = muestra;
                    }
                    //PicExemp.Image = Image.FromFile(@".\imagen\" + prod.imagen(CboTalla.SelectedValue.ToString ()));
                    PicExemp.Tag = prod.imagen(CboTalla.SelectedValue.ToString());
                }

                }
        }

        private void BtnUltVent_Click(object sender, EventArgs e)
        {
            if (CboNomCli.Text != "") { 
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

        }

        private void TxtCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Busc_press();
            }
        }

        private void Busc_press()
        {
            string cod = "R"+TxtCod.Text;
            DataTable datos = new DataTable();
            datos = prod.prodId(cod);
            if (datos.Rows.Count > 0) {
                CboProd.SelectedIndex = 0;
                    CboProd.SelectedValue = cod; }

            else { MessageBox.Show("El codigo no esta registrado"); }
        }

        private void ChkMay_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkMay.Checked)
            {
                CboPrecio.Enabled = false;
                CboPrecioM.Enabled = true;
                CboPrecioM.Visible = true;
            }
            else
            {
                CboPrecio.Enabled = true;
                CboPrecioM.Enabled = false;
                CboPrecioM.Visible = false;
            }
        }

        private void RdbProd_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbProd.Checked)
            {
                BtnGenVen.Text = "Generar Salida";
                LblSoli.Visible = true;
                TxtSoli.Text = "";
                TxtSoli.Visible = true;
            }
            else {
                LblSoli.Visible =false;
                TxtSoli.Visible = false;
                BtnGenVen.Text = "Generar Venta"; }
        }

        private void PicExemp_DoubleClick(object sender, EventArgs e)
        {
            ImgAum();
        }

        private void ImgAum()
        {
            ImagenPic img = new ImagenPic();
            if (PicExemp.Image == null) { ImagenPic.ponerimg = @".\imagen\0.jpg"; }
            else { ImagenPic.ponerimg = PicExemp.Tag.ToString();  }
            img.Show();
        }

        private void CboProd_TextChanged(object sender, EventArgs e)
        {

        }
        public static Bitmap RedimImage(Image Imagenori, int width, int heigth)
        {
            var Radio = Math.Max((double)width / Imagenori.Width, (double)heigth / Imagenori.Height);
            var NuevoAncho = (int)(Imagenori.Width * Radio);
            var NuevoAlto = (int)(Imagenori.Height * Radio);
            var Imagenmodelo = new Bitmap(NuevoAncho, NuevoAlto);
            Graphics.FromImage(Imagenmodelo).DrawImage(Imagenori, 0, 0, NuevoAncho, NuevoAlto);
            Bitmap imageniFinal = new Bitmap(Imagenmodelo);
            return imageniFinal;
        }
    }
}
