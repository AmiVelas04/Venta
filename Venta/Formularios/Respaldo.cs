using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Venta.Formularios
{
    public partial class Respaldo : Form
    {
        private MySqlConnection conn = new MySqlConnection();
        FolderBrowserDialog carpeta = new FolderBrowserDialog();

        string MiFecha = DateTime.Now.ToString("dd-MM-yyyy");
        //string rutaDump = "C:\\xampp\\mysql\bin\\mysqldump";
        string destino;
        public Respaldo()
        {
            InitializeComponent();

        }
        private void respaldo()
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = conn;
                MySqlBackup respaldo = new MySqlBackup(com);
                // MessageBox.Show(cadena)
                //   Shell(cadena, 0);
                conn.Open();
                respaldo.ExportToFile(destino);
                conn.Close();
                MessageBox.Show("El respaldo se ha realizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtRuta.Clear();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.ToString());
                TxtRuta.Clear();
            }
        }

        private void BtnCarpeta_Click(object sender, EventArgs e)
        {
            carpeta.RootFolder = Environment.SpecialFolder.Desktop;
            carpeta.Description = "Seleccione la ruta para realizar el respaldo";
            carpeta.ShowNewFolderButton = false;

            string miCarpeta;
            if (carpeta.ShowDialog() == DialogResult.OK)
            {
                TxtRuta.Text = carpeta.SelectedPath;
                miCarpeta = carpeta.SelectedPath;
                //miCarpeta =  miCarpeta .Replace("'\'","\\");
                destino = miCarpeta.Trim() + "\\RespaldoBd_" + MiFecha + ".sql";
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtRuta.Text != "")
            {
                respaldo();
            }
            else
            {
                MessageBox.Show("Ruta no encontrada");
            }
        }

        private void Respaldo_Load(object sender, EventArgs e)
        {
            string cadena_conn = "server=Localhost;  database=tienda; user id=creditos; password=Cre-2020-Sis; port=3306; allow zero Datetime= true";
            // string cadena_conn = "server=Localhost;  database=Bdtipicos; user id=Tipicos; password=Venta_2020_Sis; port=3306; allow zero Datetime= true";
            conn.ConnectionString = cadena_conn;
        }
    }
}
