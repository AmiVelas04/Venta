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
using System.IO;

namespace Venta.Formularios
{
    public partial class Respaldo : Form
    {
        private MySqlConnection conn = new MySqlConnection();
        FolderBrowserDialog carpeta = new FolderBrowserDialog();

        string MiFecha = DateTime.Now.ToString("dd-MM-yyyy");
        //string rutaDump = "C:\\xampp\\mysql\bin\\mysqldump";
        string destino,carpetaOrig, CarpetaDest,miCarpeta;

        #region "Objetos"
        private void BtnCarpeta_Click(object sender, EventArgs e)
        {
            carpeta.RootFolder = Environment.SpecialFolder.Desktop;
            carpeta.Description = "Seleccione la ruta para realizar el respaldo";
            carpeta.ShowNewFolderButton = false;

            if (carpeta.ShowDialog() == DialogResult.OK)
            {
                carpetaOrig = @".\imagen";
                CarpetaDest = @"\Respaldo Tipicos";
                TxtRuta.Text = carpeta.SelectedPath;
                miCarpeta = carpeta.SelectedPath;
                destino = miCarpeta.Trim() + CarpetaDest + "\\RespaldoBd_" + MiFecha + ".sql";

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
        #endregion

        #region "Funciones"
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

                if (Directory.Exists(carpetaOrig))
                {
                    Directory.CreateDirectory(miCarpeta.Trim() + CarpetaDest);
                    conn.Open();
                    respaldo.ExportToFile(destino);
                    conn.Close();
                    string carpetadesti = miCarpeta.Trim() + CarpetaDest;

                    int cant;
                    string[] Archivos = Directory.GetFiles(carpetaOrig);
                    cant = Archivos.Length;
                    CopiarFiles(carpetadesti, carpetaOrig, cant);

                    /*
                     double avance,sumatoria=0;

                     PgbAvance.Maximum = cant;
                     avance = 100.0 / double.Parse(cant.ToString ());
                     for (cont= 0;cont<cant;cont++)
                     {
                         suavanz = Convert.ToInt32(sumatoria);
                         string NomArch,DestArch;
                         NomArch = Path.GetFileName(Archivos[cont]);
                         DestArch = Path.Combine(miCarpeta.Trim()+CarpetaDest, NomArch);
                         File.Copy(Archivos[cont], DestArch, true);
                         if (PgbAvance.Value < 100)
                         { PgbAvance.Value += 1;
                         }
                         else
                         {
                             PgbAvance.Value = 100;
                         }
                         sumatoria = PgbAvance.Value / cant * 100;
                         

                     }*/
                     }
               
                TxtRuta.Clear();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.ToString());
                TxtRuta.Clear();
            }
        }

        private async void CopiarFiles(string ruta, string origen, int total)
        {
            PgbAvance.Maximum = total;
            int avance = 0;
            decimal porcentaje;
            foreach (string filename in Directory.EnumerateFiles(origen))
            {
                using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                {
                    using (FileStream DestinationStream = File.Create(ruta + filename.Substring(filename.LastIndexOf("\\"))))
                    {
                        await SourceStream.CopyToAsync(DestinationStream);
                        avance++;
                        PgbAvance.Value = avance;
                        porcentaje = avance / Convert.ToDecimal(total / 100);
                        LblProg.Text = "Respaldo... " + porcentaje.ToString("###.##") + "%";
                    }
                }
            }
            MessageBox.Show("El respaldo se ha realizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LblProg.Text = "¡Respaldo Terminado!";

        }

        #endregion







    }
}
