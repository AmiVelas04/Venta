using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Venta.Clases
{
   
    class Producto
    {
        conexion conn = new conexion();

        #region "General"
        private DataTable buscar(string consulta)
        {
            conn.iniciar();
            DataTable datos = new DataTable();
            try
            {

                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
                adap.Fill(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
            }
            return datos;


        }


        private bool consulta_gen(string consulta)
        {
            conn.iniciar();
            MySqlCommand com1 = new MySqlCommand();
            com1.Connection = conn.conn;
            com1.CommandText = consulta;
            com1.CommandType = CommandType.Text;
            try
            {
                conn.conn.Open();
                com1.ExecuteNonQuery();
                conn.conn.Close();
            }

            catch (Exception ex)
            {
                conn.conn.Close();
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
                return false;
            }
            return true;
        }
        #endregion

        public bool ingreso_prod(string[] datos)
        {
            string consulta = "Insert into producto(id_prod,nombre,id_estilo,id_tipo,id_color,talla,cantidad,precio_cost,precio_m,precio_v,imagen) " +
                               "values ("+1+"','"+datos[0] + "','"+datos[0] + "','"+datos[0] + "','"+datos[0] + "','"+datos[0] + "','"+datos[0] + "','" + ")";

                {
                
        }
    }
}
