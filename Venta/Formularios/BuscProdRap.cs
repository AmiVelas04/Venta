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
    public partial class BuscProdRap : Form
    {
        public delegate void permiso(string codi);
        public event permiso Mostrarprodu;
        Clases.Producto produ = new Clases.Producto(Main.rutaimg1);
        public BuscProdRap()
        {
            InitializeComponent();
        }

        private void BtnBusc_Click(object sender, EventArgs e)
        {
            BuscarProdu();
        }

        private void BuscarProdu()
        {
            DataTable datos = new DataTable();
            string nom;
            nom = TxtNomB.Text;
            datos = produ.buscarprod(nom);
            Dgv1.DataSource = datos;
            Dgv1.Columns[13].Visible=false;
            Dgv1.Columns[12].Visible = false;
            Dgv1.Columns[11].Visible = false;
            Dgv1.Columns[10].Visible = false;
            Dgv1.Columns[9].Visible = false;
            Dgv1.Columns[8].Visible = false;
            Dgv1.Columns[7].Visible = false;
            Dgv1.Columns[6].Visible = false;
                    }

        
        private void ponerdatos() {
            string nom, cod;
            int indice;
            indice = Dgv1.CurrentRow.Index;
            cod = Dgv1.Rows[indice].Cells[0].Value.ToString();
            nom= Dgv1.Rows[indice].Cells[1].Value.ToString() +", "+Dgv1.Rows[indice].Cells[2].Value.ToString() + ", " + Dgv1.Rows[indice].Cells[3].Value.ToString() + ", " + Dgv1.Rows[indice].Cells[4].Value.ToString() + ", " + Dgv1.Rows[indice].Cells[5].Value.ToString() ;
            TxtCod.Text = cod;
            TxtNom.Text = nom;
        }

        private void ponerimg()
        {
            if (Dgv1.Rows.Count > 0 && Dgv1.CurrentRow != null)
            {
             PicImagen.InitialImage = null;
                PicImagen.Image = null;
                string id = Dgv1.Rows[Dgv1.CurrentRow.Index].Cells[0].Value.ToString();
                //  TxtCod.Text = id;
                string imag = produ.imagendar(id);
                //mostrar imagen
                try
                {//Directorio de produccion: @".\imagen\"
                    using (var stream = File.Open(@"\\192.168.0.100\imagenes\" + imag, FileMode.Open))
                    {
                        Bitmap archivo = new Bitmap(stream);
                        Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                        PicImagen.Image = muestra;
                        PicImagen.Tag = @"\\192.168.0.100\imagenes\" + imag;
                    }
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("¡Imagen no encontrada!", "No imagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    using (var stream = File.Open(@"\\192.168.0.100\imagenes\0.jpg", FileMode.Open))
                    {
                        Bitmap archivo = new Bitmap(stream);
                        Bitmap muestra = new Bitmap(RedimImage(archivo, 200, 150));
                        PicImagen.Image = muestra;
                        PicImagen.Tag = @"\\192.168.0.100\imagenes\" + imag;
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

        private void Dgv1_Click(object sender, EventArgs e)
        {
            ponerimg();
            ponerdatos();
        }

        private void TxtNomB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BuscarProdu();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TxtCod.Text != "")
            {
                Mostrarprodu(TxtCod.Text);
                this.Close();
            }
            
        }
    }
}
