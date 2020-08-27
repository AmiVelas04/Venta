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
using System.IO;

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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
            limpiar();
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
            decimal precio_m1 = Decimal.Parse(TxtPrecio_M1.Text);
            decimal precio_m2 = Decimal.Parse(TxtPrecio_M2.Text);
            decimal precio_v1 = Decimal.Parse(TxtPrecio_V1.Text);
            decimal precio_v2 = Decimal.Parse(TxtPrecio_V2.Text);
            decimal precio_v3 = decimal.Parse(TxtPrecio_V3.Text);
            string imagen;
            string estilo = CboEstilo.DisplayMember != null ?  CboEstilo.Text :"N/E";
            string tipo = CboTipo.DisplayMember != null ? CboTipo.Text : "N/E";
            string color = CboColor.DisplayMember != null ? CboColor.Text : "N/E";
            string ubicacion = TxtUbi.Text;
            string MatP = "";
            if (RdbSi.Checked) { MatP = "1"; }
            else if (RdbNo.Checked) { MatP = "0"; }

            if (prod.prodexist(Nomprod, idestilo, idtipo, idcolor, talla))
            {
                string idp = prod.busc_codprod(Nomprod, idestilo, idtipo, idcolor, talla);
                imagen = revimagen(Nomprod + idestilo + idtipo + idcolor + talla, idp); ;
                string[] datosupd = { Nomprod, idestilo, idtipo, idcolor, talla, cantidad.ToString(), precio_c.ToString(), precio_m1.ToString(), precio_m2.ToString(), precio_v1.ToString(), precio_v2.ToString(), precio_v3.ToString(),imagen,ubicacion,MatP };
                if (prod.upd_prod(datosupd))
                {
                    MessageBox.Show("Producto Actualizado correctamente"); }
                else { MessageBox.Show("Error al actualizar"); }
            }
            else
            {
                imagen = OFD1.FileName;
                string[] datosing = { Nomprod, idestilo, idtipo, idcolor, talla, cantidad.ToString(), precio_c.ToString(), precio_m1.ToString(), precio_m2.ToString(), precio_v1.ToString(), precio_v2.ToString(), precio_v3.ToString(), imagen, estilo, tipo, color,ubicacion,MatP };
                if (prod.ingreso_prod(datosing))
                {
                   // MessageBox.Show("Producto ingresado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al ingresar producto");
                }
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

            string talla = TxtTalla.Text;
            TxtTalla.Text = talla;
        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {
            OFD1.InitialDirectory = "c:\\";
        OFD1.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png|GIF|*.gif";
            if (OFD1.ShowDialog() == DialogResult.OK)
            {
                try {
                   // MessageBox.Show("Ruta Guardada: " + OFD1.FileName);
                    //PbxProd.Image = Image.FromFile(@"C:\Users\Insane\Pictures\7z6vh4.jpg");
                    PbxProd.Image = Image.FromFile(@""+ OFD1.FileName);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (RdbT.Checked) { DgvProd.DataSource = prod.buscarprod(TxtBuscNom.Text); }
            else if (RdbMp.Checked) { DgvProd.DataSource = prod.buscarprodM(TxtBuscNom.Text); }
            else if (RdbV.Checked) { DgvProd.DataSource = prod.buscarprodP(TxtBuscNom.Text); }
            DgvProd.Refresh();
        }

        private string revimagen(string imagen, string id)
        {
            string extension = Path.GetExtension(OFD1.FileName);
            string NombreFull,ruta;
            NombreFull = imagen + extension;
            string imgdefecto = prod.imagen(id);
        if(Directory.Exists("./imagen") )
                {}
        else{
                Directory.CreateDirectory("./imagen");
                    }
         ruta = Path.GetFullPath("./imagen/" + NombreFull);
        if (File.Exists(ruta)) {
                System.IO.File.Delete(ruta);
            if( extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png")
            {
                    try { File.Copy(OFD1.FileName, "./imagen/" + imagen + extension);
                    }
                    catch (Exception Ex) {
                        MessageBox.Show("./imagen/" + imagen + extension);
                        MessageBox.Show(Ex.ToString());
                    }
                    }
            else
                { MessageBox.Show("Imagen no valida/ o inexistente");
                    NombreFull = imgdefecto;
                }
            }
            else
            {
                if ( extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png")
                { File.Copy(OFD1.FileName, "./imagen/"+ imagen + extension);
                }
            else
                { MessageBox.Show("Imagen no valida/ o inexistente");
                    NombreFull = imgdefecto;
                }
            }
            return NombreFull;
        }

        private void TxtTalla_TextChanged(object sender, EventArgs e)
        {
            if (TxtTalla.Text != "")
            {
                string Nomprod = TxtProdNom.Text;
                string idestilo = CboEstilo.SelectedValue != null ? CboEstilo.SelectedValue.ToString() : "0";
                string idtipo = CboTipo.SelectedValue != null ? CboTipo.SelectedValue.ToString() : "0";
                string idcolor = CboColor.SelectedValue != null ? CboColor.SelectedValue.ToString() : "0";
                string talla = TxtTalla.Text;
                if (prod.prodexist(Nomprod, idestilo, idtipo, idcolor, talla))
                {
                    DataTable datos = new DataTable();
                    datos = prod.DatosRestant(Nomprod, idestilo, idtipo, idcolor, talla);
                    NudCantidad.Value = decimal.Parse(datos.Rows[0][0].ToString());
                    TxtPrecio_C.Text = datos.Rows[0][1].ToString();
                    TxtPrecio_M1.Text = datos.Rows[0][2].ToString();
                    TxtPrecio_M2.Text= datos.Rows[0][3].ToString();
                    TxtPrecio_V1.Text = datos.Rows[0][4].ToString();
                    TxtPrecio_V2.Text = datos.Rows[0][5].ToString();
                    TxtPrecio_V3.Text= datos.Rows[0][6].ToString();
                    TxtUbi.Text = datos.Rows[0][7].ToString();
                    PbxProd.Image = Image.FromFile(@".\imagen\"+datos.Rows[0][8].ToString());
                    string materia = datos.Rows[0][9].ToString();
                    if (materia== "False") { RdbNo.Checked = true; }
                    else if (materia == "True"){ RdbSi.Checked = true; }
                }
                else
                {
                    NudCantidad.Value = 0;
                    TxtPrecio_C.Text = "0";
                    TxtPrecio_M1.Text = "0";
                    TxtPrecio_M2.Text = "0";
                    TxtPrecio_V1.Text = "0";
                    TxtPrecio_V2.Text = "0";
                    TxtPrecio_V3.Text = "0";
                }
            }
        }

        private void TxtCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                buscarProd();
            }
        }

        private void buscarProd()
        {
            DataTable datos = new DataTable();
            datos = prod.PeticionProd(TxtCod.Text);
            if (datos.Rows.Count > 0)
            {
                TxtProdNom.Text = datos.Rows[0][1].ToString();
                //14-15-16
                CboEstilo.SelectedValue = datos.Rows[0][14].ToString();
                CboTipo.SelectedValue = datos.Rows[0][15].ToString();
                CboColor.SelectedValue = datos.Rows[0][16].ToString();
                TxtTalla.Text = datos.Rows[0][5].ToString();
            }
            else { }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DgvProd.Rows.Count > 0)
            { 
               string id = DgvProd.Rows[DgvProd.CurrentRow.Index].Cells[0].Value.ToString();
                TxtCod.Text = id;
                buscarProd();
            }
        }

        private void CboEstilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string talla = TxtTalla.Text;
            TxtTalla.Text = talla;
        }

        private void CboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string talla = TxtTalla.Text;
            TxtTalla.Text = talla;
        }

        private void CboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string talla = TxtTalla.Text;
            TxtTalla.Text = talla;
        }

        private void CboEstilo_TextChanged(object sender, EventArgs e)
        {
            string talla = TxtTalla.Text;
            TxtTalla.Text = talla;
        }

        private void CboTipo_TextChanged(object sender, EventArgs e)
        {
            string talla = TxtTalla.Text;
            TxtTalla.Text = talla;
        }

        private void CboColor_TextChanged(object sender, EventArgs e)
        {
            string talla = TxtTalla.Text;
            TxtTalla.Text = talla;
        }

        private void BtnNvo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            TxtCod.Text="";
            TxtProdNom.Text = "";
            CboEstilo.Text = "";
            CboColor.Text = "";
            CboTipo.Text = "";
            TxtTalla.Text = "";
            NudCantidad.Value = decimal.Parse("0");
            TxtPrecio_C.Text = "0";
            TxtPrecio_M1.Text = "0";
            TxtPrecio_M2.Text = "0";
            TxtPrecio_V1.Text = "0";
            TxtPrecio_V2.Text = "0";
            TxtUbi.Text = "";
            OFD1.FileName = "";
        }
    }
}
