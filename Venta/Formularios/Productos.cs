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


        #region "Objetos"
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

            if (TxtCod.Text == "")
            {
                MessageBox.Show("¡No se ha ingresado el codigo del producto, porfavor ingrese un codigo valido!", "No codigo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                guardar();
                limpiar();
                /*string cod;
                cod = TxtCod.Text;
                cod = "R" + cod;
                if (prod.hayprod(cod))
                {
                    MessageBox.Show("¡El codigo ingresado ya existe dentro del registro de productos, intente de nuevo!", "Codigo existente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                  
                }*/
            }

            
        }

        private void TxtProdNom_TextChanged(object sender, EventArgs e)
        {
            // agregar estilos
            DataTable datos = new DataTable();
            datos = prod.estilo(TxtProdNom.Text);
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
            datos = prod.tipo(TxtProdNom.Text);
            CboTipo.DataSource = datos;
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
            CboColor.DataSource = datos;
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
                try
                {
                    // MessageBox.Show("Ruta Guardada: " + OFD1.FileName);
                    //PbxProd.Image = Image.FromFile(@"C:\Users\Insane\Pictures\7z6vh4.jpg");
                    PbxProd.Image = Image.FromFile(@"" + OFD1.FileName);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
            BtnLblPrint.Visible = true;
            NudEtiqueta.Visible = true;
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
                    TxtPrecio_M2.Text = datos.Rows[0][3].ToString();
                    TxtPrecio_V1.Text = datos.Rows[0][4].ToString();
                    TxtPrecio_V2.Text = datos.Rows[0][5].ToString();
                    TxtPrecio_V3.Text = datos.Rows[0][6].ToString();
                    TxtUbi.Text = datos.Rows[0][7].ToString();

                    /*  using (var stream = File.Open(@".\imagen\" + datos.Rows[0][8].ToString(), FileMode.Open))
                       {
                           Bitmap archivo = new Bitmap(stream);
                           Bitmap muestra = new Bitmap(RedimImage(archivo, 300, 200));
                           PbxProd.Image = muestra;
                       }*/
                    ponerimg();
                    string materia = datos.Rows[0][9].ToString();
                    if (materia == "False") { RdbNo.Checked = true; }
                    else if (materia == "True") { RdbSi.Checked = true; }
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
                    PbxProd.InitialImage = null;
                    PbxProd.Image = null;
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

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DgvProd.Rows.Count > 0)
            {
                string id = DgvProd.Rows[DgvProd.CurrentRow.Index].Cells[0].Value.ToString();
                char[] elim = { 'r', 'R' };
                TxtCod.Text = id.TrimStart(elim);
                LblRow.Text = DgvProd.CurrentRow.Index.ToString();
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
            IdTip.Text = CboTipo.SelectedValue.ToString();
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

        private void BtnLimp_Click(object sender, EventArgs e)
        {
            NudCantidad.Value = 0;
            TxtPrecio_C.Text = "0";
            TxtPrecio_M1.Text = "0";
            TxtPrecio_M2.Text = "0";
            TxtPrecio_V1.Text = "0";
            TxtPrecio_V2.Text = "0";
            TxtPrecio_V3.Text = "0";
            TxtUltimoIng.Text = "0";
            NudIngreso.Value = 0;
            TxtUbi.Text = "";
            OFD1.FileName = "";
            PbxProd.InitialImage = null;
            PbxProd.Image = null;
        }

        private void BtnModif_Click(object sender, EventArgs e)
        {
            Actualiz();
            limpiar();
        }

        private void DgvProd_Click(object sender, EventArgs e)
        {
            ponerimg();
        }

        private void TxtBuscNom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) buscar();

        }


        #endregion

        #region "Funciones"
        private void guardar()
        {
            string Nomprod = TxtProdNom.Text;
            string idestilo = CboEstilo.SelectedValue != null ? CboEstilo.SelectedValue.ToString() : "0";
            string idtipo = CboTipo.SelectedValue != null ? CboTipo.SelectedValue.ToString() : "0";
            string idcolor = CboColor.SelectedValue != null ? CboColor.SelectedValue.ToString() : "0";
            string talla = TxtTalla.Text;
            int cantidad, cantingre;
            cantidad = Int32.Parse(NudCantidad.Value.ToString());
            if (ChkCantCamb.Checked)
            {
                cantingre = 0;
            }
            else
            {
                cantingre = Int32.Parse(NudIngreso.Value.ToString());
            }
            
            
            decimal precio_c = Decimal.Parse(TxtPrecio_C.Text);
            decimal precio_m1 = Decimal.Parse(TxtPrecio_M1.Text);
            decimal precio_m2 = Decimal.Parse(TxtPrecio_M2.Text);
            decimal precio_v1 = Decimal.Parse(TxtPrecio_V1.Text);
            decimal precio_v2 = Decimal.Parse(TxtPrecio_V2.Text);
            decimal precio_v3 = decimal.Parse(TxtPrecio_V3.Text);
            string imagen;
            string[] images = new string[2];
            string estilo = CboEstilo.DisplayMember != null ? CboEstilo.Text : "N/E";
            string tipo = CboTipo.DisplayMember != null ? CboTipo.Text : "N/E";
            string color = CboColor.DisplayMember != null ? CboColor.Text : "N/E";
            string ubicacion = TxtUbi.Text;
            string MatP = "";
            if (RdbSi.Checked) { MatP = "1"; }
            else if (RdbNo.Checked) { MatP = "0"; }

            if (prod.prodexist(Nomprod, idestilo, idtipo, idcolor, talla))
            //if (prod.hayprod("R"+TxtCod.Text))
            {
                string idp = prod.busc_codprod(Nomprod, idestilo, idtipo, idcolor, talla);

                imagen = revimagen(Nomprod + idestilo + idtipo + idcolor + talla, idp); ;
                string[] datosupd = { Nomprod, idestilo, idtipo, idcolor, talla, cantidad.ToString(), precio_c.ToString(), precio_m1.ToString(), precio_m2.ToString(), precio_v1.ToString(), precio_v2.ToString(), precio_v3.ToString(), imagen, ubicacion, MatP, idp,cantingre.ToString()};
                if (prod.upd_prod(datosupd))
                {
                    MessageBox.Show("Producto Actualizado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PbxProd.InitialImage = null;
                    PbxProd.Image = null;
                    if (cantingre.ToString() != "0")
                    {
                        if (MessageBox.Show("¿Desea Imprimir " + cantingre.ToString() + " etiqueta(s)?", "Imprimir etiquetas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ImpAlIngr(idp, cantingre);
                        }
                    }
                    if (DgvProd.Rows.Count>0) ModifLista();
                }
                else { MessageBox.Show("Error al actualizar", "revisar datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else
            {
               // string idp = "R"+TxtCod.Text;
                //Se ingresa directamente el codigo del producto para poder agregar producto ya existente en la tienda central
                imagen = OFD1.FileName;
                string[] datosing = { Nomprod, idestilo, idtipo, idcolor, talla, cantidad.ToString(), precio_c.ToString(), precio_m1.ToString(), precio_m2.ToString(), precio_v1.ToString(), precio_v2.ToString(), precio_v3.ToString(), imagen, estilo, tipo, color, ubicacion, MatP,/*idp*/ };
                if (prod.ingreso_prod(datosing))
                {
                    // MessageBox.Show("¿Desea Imprimir Producto ingresado correctamente");
                  
                    buscar();
                }
                else
                {
                    MessageBox.Show("Error al ingresar producto", "revisar datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //MessageBox.Show("Error al ingresar producto");
                }
            }

           
        }

        private void Actualiz()
        {
            int cantidad,CantIng;
            string Nomprod = TxtProdNom.Text;
            string idestilo = CboEstilo.SelectedValue != null ? CboEstilo.SelectedValue.ToString() : "0";
            string idtipo = CboTipo.SelectedValue != null ? CboTipo.SelectedValue.ToString() : "0";
            string idcolor = CboColor.SelectedValue != null ? CboColor.SelectedValue.ToString() : "0";
            string talla = TxtTalla.Text;
            if (idtipo == "0")
            {
                idtipo = prod.IngresoTip(CboTipo.Text).ToString();
            }
            if (idestilo == "0")
            {
                idestilo = prod.IngresoEst(CboEstilo.Text).ToString();
            }
            if (idcolor=="0")
            {
                idcolor = prod.IngresoCol(CboColor.Text).ToString();
            }

            cantidad = Int32.Parse(NudCantidad.Value.ToString());
            if (ChkCantCamb.Checked)
            {
                CantIng = 0;
            }
            else
            {
                CantIng = Int32.Parse(NudIngreso.Value.ToString());
            }
            
            decimal precio_c = Decimal.Parse(TxtPrecio_C.Text);
            decimal precio_m1 = Decimal.Parse(TxtPrecio_M1.Text);
            decimal precio_m2 = Decimal.Parse(TxtPrecio_M2.Text);
            decimal precio_v1 = Decimal.Parse(TxtPrecio_V1.Text);
            decimal precio_v2 = Decimal.Parse(TxtPrecio_V2.Text);
            decimal precio_v3 = decimal.Parse(TxtPrecio_V3.Text);
            string imagen;
            string[] images = new string[2];
            string ubicacion = TxtUbi.Text;
            string MatP = "";
            string Nestilo = CboEstilo.Text;
            string Ntipo = CboTipo.Text;
            string NColor = CboColor.Text;
            if (RdbSi.Checked)
            { MatP = "1"; }
            else if (RdbNo.Checked)
            { MatP = "0"; }
         
            string idp = "R" + TxtCod.Text;
            imagen = revimagen(Nomprod + idestilo + idtipo + idcolor + talla, idp); ;
            string[] datosupd = { Nomprod, idestilo, idtipo, idcolor, talla, cantidad.ToString(), precio_c.ToString(), precio_m1.ToString(), precio_m2.ToString(), precio_v1.ToString(), precio_v2.ToString(), precio_v3.ToString(), imagen, ubicacion, MatP, idp,CantIng.ToString() };
            string[] datoscamb = { idp, Nomprod, idestilo, Nestilo, idtipo, Ntipo, idcolor, NColor };
            if (prod.mod_prod(datosupd) && prod.Modnoms(datoscamb))
            {
                MessageBox.Show("Producto Actualizado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModifLista();
                PbxProd.InitialImage = null;
                PbxProd.Image = null;
                if (CantIng.ToString() != "0")
                {
                    if (MessageBox.Show("¿Desea Imprimir " + CantIng.ToString() + " etiqueta(s)?", "Imprimir etiquetas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ImpAlIngr(idp, CantIng);
                    }
                }
            }
            else { MessageBox.Show("Error al actualizar", "revisar dartos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            /*  }
              else
              {
              }*/
        }


        private void buscar()
        {
            if (RdbT.Checked) { DgvProd.DataSource = prod.buscarprod(TxtBuscNom.Text); }
            else if (RdbMp.Checked)
            {
                DgvProd.DataSource = prod.buscarprodM(TxtBuscNom.Text);
            }
            else if (RdbV.Checked) { DgvProd.DataSource = prod.buscarprodP(TxtBuscNom.Text); }
            DgvProd.Refresh();
        }

        private string revimagen(string imagen, string id)
        {
            string extension = Path.GetExtension(OFD1.FileName);

            string NombreFull, ruta, alterno = "";
            NombreFull = imagen + extension;
            string imgdefecto = prod.imagen(id);
            ruta = Path.GetFullPath(@".\imagen\" + NombreFull);

            if (File.Exists(ruta))
            {
                File.Delete(ruta);
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png")
                {
                    try
                    {
                        /*Bitmap imag = new Bitmap(OFD1.FileName);
                        byte[] contenido =  ImagenaByte( imag) ;
                        FileStream archi = new FileStream("./imagen/" + imagen + extension,FileMode.Create);
                        archi.Write(contenido, 0, contenido.Length);
                        archi.Close();*/
                        File.Copy(OFD1.FileName, "./imagen/" + imagen + extension);

                        alterno = "./imagen/" + imagen + "B" + extension;
                    }
                    catch (Exception Ex)
                    {
                        //   MessageBox.Show("./imagen/" + imagen + extension);
                        MessageBox.Show(Ex.ToString());
                    }
                }
                else
                { //MessageBox.Show("Imagen no valida/ o inexistente");
                    NombreFull = imgdefecto;
                }
            }
            else
            {
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png")
                {
                    File.Copy(OFD1.FileName, "./imagen/" + imagen + extension);
                }
                else
                {
                    // MessageBox.Show("Imagen no valida/ o inexistente");
                    NombreFull = imgdefecto;
                }
            }
            return NombreFull;
        }

        private void buscarProd()
        {
            DataTable datos = new DataTable();
            datos = prod.PeticionProd("R" + TxtCod.Text);
            if (datos.Rows.Count > 0)
            {
                //int cantidad = int.Parse(datos.Rows[0][16].ToString());
                TxtProdNom.Text = datos.Rows[0][1].ToString();
                TxtProdNom.Tag = datos.Rows[0][1].ToString();
                //14-15-16
                CboEstilo.SelectedValue = datos.Rows[0][14].ToString();
                IdEst.Text = datos.Rows[0][14].ToString();
                CboTipo.SelectedValue = datos.Rows[0][15].ToString();
                IdTip.Text = datos.Rows[0][15].ToString();
                CboColor.SelectedValue = datos.Rows[0][16].ToString();
                IdCol.Text = datos.Rows[0][16].ToString();
                TxtTalla.Text = "";
                TxtTalla.Text = datos.Rows[0][5].ToString();
                PbxProd.InitialImage = null;
                PbxProd.Image = null;
                TxtUltimoIng.Text = datos.Rows[0][17].ToString();
                string id = "R" + TxtCod.Text;
                //  TxtCod.Text = id;
                string imag = prod.imagen(id);
                try
                {
                    //mostrar imagen
                    using (var stream = File.Open(@".\imagen\" + imag, FileMode.Open))
                    {
                        Bitmap archivo = new Bitmap(stream);
                        Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                        PbxProd.Image = muestra;
                    }
                }
                catch (FileNotFoundException ex)
                {
                    // MessageBox.Show("¡Imagen no encontrada!", "No imagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    using (var stream = File.Open(@".\imagen\0.jpg", FileMode.Open))
                    {
                        Bitmap archivo = new Bitmap(stream);
                        Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                        PbxProd.Image = muestra;
                    }
                }

            }
            else { }
        }


        private void limpiar()
        {
            TxtCod.Text = "";
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
            TxtPrecio_V3.Text = "0";
            TxtUltimoIng.Text = "0";
            NudIngreso.Value = 0;
            TxtUbi.Text = "";
            OFD1.FileName = "";
            PbxProd.InitialImage = null;
            PbxProd.Image = null;
            LblRow.Text = "0";
        }

        private void ponerimg()
        {
            if (DgvProd.Rows.Count > 0 && DgvProd.CurrentRow != null)
            {
                PbxProd.InitialImage = null;
                PbxProd.Image = null;
                string id = DgvProd.Rows[DgvProd.CurrentRow.Index].Cells[0].Value.ToString();
                //  TxtCod.Text = id;
                string imag = prod.imagen(id);
                //mostrar imagen
                try
                {
                    using (var stream = File.Open(@".\imagen\" + imag, FileMode.Open))
                    {
                        Bitmap archivo = new Bitmap(stream);
                        Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                        PbxProd.Image = muestra;
                        PbxProd.Tag = @".\imagen\" + imag;
                    }
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("¡Imagen no encontrada!", "No imagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    using (var stream = File.Open(@".\imagen\0.jpg", FileMode.Open))
                    {
                        Bitmap archivo = new Bitmap(stream);
                        Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                        PbxProd.Image = muestra;
                        PbxProd.Tag = @".\imagen\" + imag;
                    }

                }
            }
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

        private void ModifLista()
        {
            int indice = int.Parse(LblRow.Text);
            DgvProd.Rows[indice].Cells[1].Value = TxtProdNom.Text;
            DgvProd.Rows[indice].Cells[2].Value = CboEstilo.Text;
            DgvProd.Rows[indice].Cells[3].Value = CboTipo.Text;
            DgvProd.Rows[indice].Cells[4].Value = CboColor.Text;
            DgvProd.Rows[indice].Cells[5].Value = TxtTalla.Text;
            if (ChkCantCamb.Checked)
            {
                DgvProd.Rows[indice].Cells[6].Value = NudCantidad.Value.ToString();
            }
            else
            {
                int cantAnt, cantnvo, Total;
                cantAnt = int.Parse(NudCantidad.Value.ToString());
                cantnvo = int.Parse(NudIngreso.Value.ToString());
                Total = cantAnt + cantnvo;

                DgvProd.Rows[indice].Cells[6].Value = Total.ToString();
            }
            DgvProd.Rows[indice].Cells[7].Value = Decimal2(TxtPrecio_C.Text);
            DgvProd.Rows[indice].Cells[8].Value = Decimal2(TxtPrecio_M1.Text);
            DgvProd.Rows[indice].Cells[9].Value = Decimal2(TxtPrecio_M2.Text);
            DgvProd.Rows[indice].Cells[10].Value = Decimal2(TxtPrecio_V1.Text);
            DgvProd.Rows[indice].Cells[11].Value = Decimal2(TxtPrecio_V2.Text);
            DgvProd.Rows[indice].Cells[12].Value = Decimal2(TxtPrecio_V3.Text);
            DgvProd.Rows[indice].Cells[13].Value = TxtUbi.Text;
        }

        private string Decimal2(string cantidad)
        {
            decimal canti = decimal.Parse(cantidad);
            string regreso; int total;
            if ((canti % 1) == 0)
            {
                /*   int total = cantidad.Length;
                   int m = Math.Max(0, total - 3);
                   StringBuilder sb = new StringBuilder(cantidad);
                   sb.Length = m;
                   int canti2 = int.Parse(sb.ToString());*/
                total = Convert.ToInt32(canti);
                return regreso = total.ToString() + ".00";
            }
            else
            {
                return regreso = canti.ToString();
            }
        }



        #endregion

        private void PbxProd_DoubleClick(object sender, EventArgs e)
        {
            ImgAum();
        }
        private void ImgAum()
        {
            ImagenPic img = new ImagenPic();
            if (PbxProd.Image == null) { ImagenPic.ponerimg = @".\imagen\0.jpg"; }
            else { ImagenPic.ponerimg = PbxProd.Tag.ToString(); }
            img.Show();
        }

        private void BtnLblPrint_Click(object sender, EventArgs e)
        {
            if (DgvProd.Rows.Count > 0)
            { ImprimirEtiquetas(); }
            
        }

        private void ImpAlIngr(string cod, int cant)
        {

            DataTable datos = new DataTable();
            datos = prod.PeticionProd(cod);
            string nombre = datos.Rows[0][1].ToString()+ " " + datos.Rows[0][2].ToString() + " " + datos.Rows[0][3].ToString() + " " + datos.Rows[0][4].ToString() + " " + datos.Rows[0][5].ToString();
            string Ltitulo = "Modas y Artesanias\n Veronica";
            string Lprecio = datos.Rows[0][10].ToString();

            int cantidad = cant;
            int canfil = (cantidad - (cantidad % 4)) / 4;
            int cantcolumn, ultcol;
            if (cantidad % 4 > 0)
            {
                canfil++;
                ultcol = cantidad % 4;
            }
            else
            {
                ultcol = 4;
            }
            int fila, columna;

            string[,] titulo = new string[canfil, 4];
            string[,] subtitulo = new string[canfil, 4];
            string[,] codigo = new string[canfil, 4];
            string[,] precio = new string[canfil, 4];

            //iniciar varialbes
            for (fila = 0; fila < canfil; fila++)
            {
                for (columna = 0; columna <= 3; columna++)
                {
                    titulo[fila, columna] = "";
                    subtitulo[fila, columna] = "";
                    codigo[fila, columna] = "";
                    precio[fila, columna] = "";
                }
            }


            //darle valor a todas las filas  ycolumnas
            for (fila = 0; fila < canfil; fila++)
            {
                if (fila == (canfil - 1))
                {
                    for (columna = 0; columna < ultcol; columna++)
                    {
                        titulo[fila, columna] = Ltitulo;
                        subtitulo[fila, columna] = nombre;
                        codigo[fila, columna] = cod;
                        precio[fila, columna] = "Q." + Lprecio;
                    }
                }
                else
                {
                    for (columna = 0; columna <= 3; columna++)
                    {
                        titulo[fila, columna] = Ltitulo;
                        subtitulo[fila, columna] = nombre;
                        codigo[fila, columna] = cod;
                        precio[fila, columna] = "Q." + Lprecio;
                    }
                }
            }

            prod.ImpEti(titulo, subtitulo, codigo, precio);
        }

        private void ImprimirEtiquetas()
        {
            int indice = DgvProd.CurrentRow.Index;
            string cod = DgvProd.Rows[indice].Cells[0].Value.ToString();
            string nombre = DgvProd.Rows[indice].Cells[1].Value.ToString() +" " + DgvProd.Rows[indice].Cells[2].Value.ToString() + " " + DgvProd.Rows[indice].Cells[3].Value.ToString() + " " + DgvProd.Rows[indice].Cells[4].Value.ToString() + " " + DgvProd.Rows[indice].Cells[5].Value.ToString();
            string Ltitulo = "Modas y Artesanias\n Veronica";
            string Lprecio = DgvProd.Rows[indice].Cells[12].Value.ToString();
           
            int cantidad = int.Parse(NudEtiqueta.Value.ToString());
            int canfil = (cantidad - (cantidad % 4)) / 4;
            int cantcolumn,ultcol;
            if (cantidad % 4 > 0)
            {
                canfil++;
                ultcol = cantidad % 4;
            }
            else
            {
                ultcol = 4;
            }
            int fila, columna;
            
            string[,] titulo = new string[canfil,4];
            string[,] subtitulo = new string[canfil, 4];
            string[,] codigo = new string[canfil, 4];
            string[,] precio = new string[canfil, 4];

            //iniciar varialbes
            for (fila=0;fila<canfil;fila++)
            {
                for (columna=0;columna<=3;columna++)
                {
                    titulo[fila, columna] = "";
                    subtitulo[fila, columna] = "";
                    codigo[fila, columna] = "";
                    precio[fila, columna] = "";
                }
            }


           //darle valor a todas las filas  ycolumnas
            for (fila = 0; fila <canfil  ; fila++)
            {
                if (fila == (canfil - 1))
                {
                    for (columna = 0; columna < ultcol; columna++)
                    {
                        titulo[fila, columna] = Ltitulo;
                        subtitulo[fila, columna] = nombre;
                        codigo[fila, columna] = cod;
                        precio[fila, columna] = "Q."+Lprecio;
                    }
                }
                else
                {
                    for (columna = 0; columna <= 3; columna++)
                    {
                        titulo[fila, columna] = Ltitulo;
                        subtitulo[fila, columna] = nombre;
                        codigo[fila, columna] = cod;
                        precio[fila, columna] = "Q." + Lprecio;
                    }
                }
            }

            prod.ImpEti(titulo,subtitulo,codigo,precio);
        }

        private void ChkCantCamb_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCantCamb.Checked)
            { NudCantidad.Enabled = true;
                NudIngreso.Value = 0;
                NudIngreso.Enabled = false;
            }
            else
            {
                NudCantidad.Enabled =false;
                NudIngreso.Value = 0;
                NudIngreso.Enabled = true;
            }
        }
    }
}
