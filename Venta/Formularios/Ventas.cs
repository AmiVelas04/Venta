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
        string rutaimg1 = @".\imagen\", rutaimg2 = @"\\192.168.0.100\imagenes\";
        public Ventas()
        {
            InitializeComponent();
        }

        #region Controles
        private void CboPrecio_Enter(object sender, EventArgs e)
        {
            CboPrecio.DroppedDown = true;
        }

        private void CboPrecio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            NudCant.Focus();
        }

        private void NudCant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                agregarprod();
                TxtCod.Focus();

            }
        }

        private void CboPrecio_Click(object sender, EventArgs e)
        {
            CboPrecio.DroppedDown = true;
        }

        private void TxtSoli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                ventaportecla();
            }
        }

        private void CboPrecioM_Enter(object sender, EventArgs e)
        {
            CboPrecioM.DroppedDown = true;
        }

        private void CboPrecioM_Click(object sender, EventArgs e)
        {
            CboPrecioM.DroppedDown = true;
        }

        private void CboPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                ChkMay.Checked = true;
            }
        }

        private void CboPrecioM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                ChkMay.Checked = false;
            }
        }

        private void CboPrecioM_SelectionChangeCommitted(object sender, EventArgs e)
        {
            NudCant.Focus();
        }

        private void TxtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)

            {
                ventaportecla();
            }
        }

        private void CboProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboProd.Text != "" && CboProd.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                busqueda(CboProd.SelectedValue.ToString());
            }
            else
            { }
        }

        private void BtnAgr_Click(object sender, EventArgs e)
        {
            agregarprod();
        }


        private void BtnGenVen_Click(object sender, EventArgs e)
        {
            if (TxtMonto.Text == "") TxtMonto.Text = "0";
            //if (DgvProd.Rows.Count > 0)
            venta();
            cargarcli();
            ChkNvoCli.Checked = false;

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
                llenarestilo(CboProd.SelectedValue.ToString(), nombrepod);
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
                llenarTalla(CboProd.SelectedValue.ToString(), nombrepod);
            }
        }

        private void CboTalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboTalla.SelectedValue.ToString() != "System.Data.DataRowView")
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
                    using (var stream = File.Open(rutaimg1 + prod.imagendar(CboTalla.SelectedValue.ToString()), FileMode.Open))
                    {
                        Bitmap archivo = new Bitmap(stream);
                        Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                        PicExemp.Image = muestra;
                    }
                    //PicExemp.Image = Image.FromFile(@".\imagen\" + prod.imagen(CboTalla.SelectedValue.ToString ()));
                    PicExemp.Tag = prod.imagendar(CboTalla.SelectedValue.ToString());
                }
                catch (FileNotFoundException ex)
                {
                    using (var stream = File.Open(rutaimg1 + "0.jpg", FileMode.Open))
                    {
                        Bitmap archivo = new Bitmap(stream);
                        Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                        PicExemp.Image = muestra;
                    }
                    //PicExemp.Image = Image.FromFile(@".\imagen\" + prod.imagen(CboTalla.SelectedValue.ToString ()));
                    PicExemp.Tag = prod.imagendar(CboTalla.SelectedValue.ToString());
                }

            }
        }

        private void BtnUltVent_Click(object sender, EventArgs e)
        {
            if (CboNomCli.Text != "")
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

        }

        private void TxtCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Busc_press();
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (MessageBox.Show("¿Desea realizar la Venta?", "Hacer venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { ventaportecla(); }
                else
                {

                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                BuscProdRap busc = new BuscProdRap();
                busc.Mostrarprodu += new BuscProdRap.permiso(codivent);
                busc.ShowDialog();
                Busc_press();
            }
        }

        #endregion

        private void Ventas_Load(object sender, EventArgs e)
        {
            LblTotal.Text = "0";
            LblCantprod.Text = "0";
            cargar();
            cargarcli();
            TxtCod.Focus();


        }

      
        //busca producto
        private void busqueda(string id)
        {
            DataTable datos = new DataTable();
            string nombrepod = prod.nomprod(id);
            string tipo = "0", estilo = "0", color = "0";
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
            LblPosi.Text = "Ubicación: " + datos.Rows[0][15].ToString();
            try
            {//Ubicacion de imagenes en produccion: @".\imagen\"
                

                using (var stream = File.Open(rutaimg1 + prod.imagendar(id), FileMode.Open))
                {
                    Bitmap archivo = new Bitmap(stream);
                    Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                    PicExemp.Image = muestra;
                }
                //   PicExemp.Image = Image.FromFile();
                PicExemp.Tag = rutaimg1 + prod.imagendar(id);

            }
            catch (FileNotFoundException ex)
            {
                using (var stream = File.Open(rutaimg1+"0.jpg", FileMode.Open))
                {
                    Bitmap archivo = new Bitmap(stream);
                    Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                    PicExemp.Image = muestra;
                }
                //   PicExemp.Image = Image.FromFile();
                PicExemp.Tag = rutaimg1 + prod.imagendar(id);

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
        private void llenartipo(string id, string nom)
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
        private void llenarcolor(string id, string nom)
        {
            DataTable dt = new DataTable();
            string tipo = CboTipo.SelectedValue.ToString(), estilo = CboEstilo.SelectedValue.ToString();
            dt = prod.colorlst(nom, estilo, tipo);
            CboColor.DataSource = dt;
            CboColor.DisplayMember = "color";
            CboColor.ValueMember = "id";
            llenarTalla(id, nom);
        }

        private void llenarTalla(string id, string nom)
        {
            DataTable dt = new DataTable();
            string tipo = CboTipo.SelectedValue.ToString(), estilo = CboEstilo.SelectedValue.ToString(), color = CboColor.SelectedValue.ToString();
            dt = prod.tallalst(nom, tipo, estilo, color);
            CboTalla.DataSource = dt;
            CboTalla.DisplayMember = "talla";
            CboTalla.ValueMember = "id_prod";
        }

        #endregion

     

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
                DgvProd.Columns.Add("Materiap", "Materia Prima");
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

        private bool revcant(string idprod, decimal cant)
        {
            int total = DgvProd.Rows.Count;
            int cont, canti = Int32.Parse(cant.ToString());

            for (cont = 0; cont < total; cont++)
            {
                if (DgvProd.Rows[cont].Cells[0].Value.ToString() == idprod)
                    canti += Int32.Parse(DgvProd.Rows[cont].Cells[6].Value.ToString());
            }
            return prod.exitencias(idprod, canti);
        }

        private void addprod(string idp, string idcolor, string idtipo, string idestilo)
        {
            decimal total = 0, Tprod=0;
            if (LblTotal.Text != "Precio") total = decimal.Parse(LblTotal.Text);
            if (LblCantprod.Text != "Total") Tprod = decimal.Parse(LblCantprod.Text);
            DataTable dt = new DataTable();
            dt = prod.prodId(idp);
            string color = dt.Rows[0][11].ToString();
            string tipo = dt.Rows[0][9].ToString();
            string estilo = dt.Rows[0][13].ToString();
            string precio = "0";
            if (ChkMay.Checked)
            { precio = CboPrecioM.Text; }
            else { precio = CboPrecio.Text; }
            string materia = "";
            if (dt.Rows[0][16].ToString() == "True") { materia = "Si"; }
            else { materia = "No"; }
            DgvProd.Rows.Add(dt.Rows[0][0].ToString(), dt.Rows[0][14].ToString(), estilo, tipo, color, CboTalla.Text, NudCant.Value, precio, (decimal.Parse(NudCant.Value.ToString()) * decimal.Parse(precio)), materia);
            total += (decimal.Parse(NudCant.Value.ToString()) * decimal.Parse(precio));
            Tprod += decimal.Parse(NudCant.Value.ToString());

            LblTotal.Text = total.ToString();
            LblCantprod.Text = Tprod.ToString();
           
        }

    

        private void ventaportecla()
        {
            if (TxtMonto.Text == "") TxtMonto.Text = "0";
            //if (DgvProd.Rows.Count > 0)
            venta();
            cargarcli();
            ChkNvoCli.Checked = false;
        }

        private void contarprods()
        {
            if (DgvProd.Rows.Count > 0)
            {
               int cant = DgvProd.Rows.Count;
                int cont, produc=0;
                for (cont = 0; cont < cant;cant++)
                {
                    produc += int.Parse(DgvProd.Rows[cont].Cells[6].Value.ToString());
                }
                LblCantprod.Text = produc.ToString();
            }
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
            else if (RdbEnvio.Checked)
            { SalidaProd(); }
            else if (Rdcoti.Checked)
            {
                cotiza();
            }
        }

        private void SalidaProd()
        {
            if (RdbProd.Checked)
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
                        LimpiarDatos();
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
            else if (RdbEnvio.Checked)
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

                if (sal.salidatienda(Main.idvende, produ))
                {
                    MessageBox.Show("Salida registrada Correctamente", "Salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarDatos();
                }
                else
                {
                    MessageBox.Show("Error al registrar salida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                

            }
        }

        private void cotiza()
        {
            string vende = Main.idvende.ToString();
            string cli = CboNomCli.Text;
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
            sal.cotizagen(cli,produ);
            LimpiarDatos();
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
            string cli = buscarcli();
            if (cli == "0") {
                MessageBox.Show("No se pudo encontrar al cliente");
                return;
            }

            string estado = "", tipo = "";
            decimal total;
            total = decimal.Parse(TxtMonto.Text);
            if (RdbContado.Checked)
            {
                tipo = "Contado";
                estado = "Cancelado";
                if (DgvProd.Rows.Count > 0)
                {
                    listarProd(tipo, estado, cli,total.ToString());
                    LimpiarDatos();
                }
                else { MessageBox.Show("No existen productos","Sin existencias", MessageBoxButtons.OK,MessageBoxIcon.Exclamation); }
            }
            else if (RdbCredito.Checked)
            {
                if (cli == "1")
                {
                                       MessageBox.Show("No se puede asignar credito a consumidor final","Credito no asignado",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                tipo = "Credito";
                estado = "Pendiente";
                if (DgvProd.Rows.Count > 0)
                {
                    listarProd(tipo, estado, cli, total.ToString());
                    LimpiarDatos();
                }
                else { MessageBox.Show("No exisiten productos", "Sin existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else if (RdbConce.Checked)
            {
                if (cli == "1")
                {
                    MessageBox.Show("No se puede asignar Consignacion a consumidor final", "Consignación no asignado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                estado = "Pendiente";
                if (DgvProd.Rows.Count > 0)
                {
               ListConce(estado, cli,"");
                    LimpiarDatos();
                }
                else { MessageBox.Show("No exisiten productos", "Sin existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
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

                MessageBox.Show("Consignación registrada con exito","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //vent.genfact(produ, "1", estado, tipo);
            }
            else
            {
                MessageBox.Show("Error en la consignación","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Venta registrada correctamente.","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //vent.genfact(produ, "1", estado, tipo);
            }
            else
            {
                MessageBox.Show("No se pudo lleva a cabo la venta","Error",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void LimpiarDatos()
        {
            while (DgvProd.RowCount > 0)
                {
                    DgvProd.Rows.RemoveAt(0);
                }
            while (DgvProd.ColumnCount > 0)
            {
                DgvProd.Columns.RemoveAt(0);
            }
            LblTotal.Text = "0";
            TxtMonto.Text = "0";
        }
      

        private void Busc_press()
        {
            string cod = "R"+TxtCod.Text;
            DataTable datos = new DataTable();
            datos = prod.prodId(cod);
            if (datos.Rows.Count > 0) {
            CboProd.SelectedIndex = 0;
            CboProd.SelectedValue = cod;
                if (ChkMay.Checked)
                { CboPrecioM.Focus(); }
                else
                {
                    CboPrecio.Focus();
                }

                
           CboPrecio.Focus();
            }

            else { MessageBox.Show("El codigo no esta registrado"); }
        }

        public void codivent(string cod)
        {
            char[] elim = { 'r', 'R' };
            TxtCod.Text = cod.TrimStart(elim);
        }

        private void ChkMay_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkMay.Checked)
            {
                CboPrecio.Enabled = false;
                CboPrecioM.Enabled = true;
                CboPrecioM.Visible = true;
                CboPrecioM.Focus();
            }
            else
            {
                CboPrecio.Enabled = true;
                CboPrecioM.Enabled = false;
                CboPrecioM.Visible = false;
                CboPrecio.Focus();
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
            if (PicExemp.Image == null) { ImagenPic.ponerimg =rutaimg1+"0.jpg"; }
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

        private string buscarcli()
        {
           string codigo=CboNomCli.SelectedValue != null ? CboNomCli.SelectedValue.ToString() : "0";
            if (ChkNvoCli.Checked) codigo = "0";
            string nom,dir, nit, dpi, tel, cre;
            if (codigo == "0" && ChkNvoCli.Checked)
            {
                nom = CboNomCli.Text;
                dir = TxtDirCli.Text != "" ? TxtDirCli.Text : "N/E";
                nit = TxtNit.Text != "" ? TxtNit.Text : "N/E";
                dpi = "N/E";
                tel = "N/E";
                cre = TxtCredito.Text != "" ? TxtCredito.Text : "0"; ;
                string[] datos = { nom, dir, nit, dpi, tel, cre };
                codigo = cli.clienvent(datos);
                return codigo;
            }
            else if (codigo == "0" && !ChkNvoCli.Checked)
            {
                return "0";
            }
            else
            {
                return codigo;
            }
        }

        private void ChkNvoCli_CheckStateChanged(object sender, EventArgs e)
        {
            if (ChkNvoCli.Checked)
            {
                TxtDirCli.Text = "";
                TxtNit.Text = "";
                TxtCredito.Text = "";
                CboNomCli.Text = "";
                TxtDirCli.Enabled = true;
                TxtNit.Enabled = true;
                TxtCredito.Enabled = true;
            }
            else
            {
                TxtDirCli.Text = "";
                TxtNit.Text = "";
                TxtCredito.Text = "";
                CboNomCli.Text = "";
                TxtDirCli.Enabled = false;
                TxtNit.Enabled = false;
                TxtCredito.Enabled =false;
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            BorrarProd();
        }

        private void BorrarProd()
        {
            if (DgvProd.Rows.Count > 0)
            {
                int indice = DgvProd.CurrentRow.Index;
                // columna 8 praa obetener el subtotal
                DgvProd.Rows.RemoveAt(indice);
                if (DgvProd.Rows.Count < 1)
                {
                    while (DgvProd.ColumnCount > 0)
                    {

                        DgvProd.Columns.RemoveAt(0);

                    }
                    LblCantprod.Text = "0";
                }

            }

            decimal total = 0, tprod=0;
            if (LblTotal.Text != "Precio") //total = decimal.Parse(LblTotal.Text);
            if (DgvProd.Rows.Count <= 0)
            {
                LblTotal.Text = total.ToString();
            }
            else
            {
                int cant, cont;
                cant = DgvProd.Rows.Count;
                for (cont = 0; cont < cant; cont++)
                {
                    total += decimal.Parse(DgvProd.Rows[cont].Cells[8].Value.ToString());
                        tprod += decimal.Parse(DgvProd.Rows[cont].Cells[6].Value.ToString());
                }
                LblTotal.Text = total.ToString();
                    LblCantprod.Text = tprod.ToString();
            }
            

        }

     
    }
}
