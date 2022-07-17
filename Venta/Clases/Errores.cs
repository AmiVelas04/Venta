using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;



namespace Venta.Clases
{
    class Errores
    {
        private conexion conec = new conexion();

 public  void Grabar_Error(string datos)
        {
            try
            {
                string BasePAth = Application.StartupPath;
                string ruta = "log.txt";
                //string ruta = @"D:\log.txt";

                //ruta = Path.Combine(BasePAth ,ruta);
                string fecha = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                if (!File.Exists(ruta))
                {
                    using (StreamWriter mylogs = File.AppendText(ruta))
                    {

                        mylogs.WriteLine("Registro de Excepciones Sistema de Venta de Tipicos");
                        mylogs.Close();
                    }
                }

                using (StreamWriter file = new StreamWriter(ruta, true))
                {
                    file.WriteLine(fecha + ": " + datos);
                    file.Close();
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Advertencia de registro, consulte con su admininstrador de sistema \n" + ex.ToString(),"Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
    }
}
