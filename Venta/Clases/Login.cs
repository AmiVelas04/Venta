using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Venta.Clases
{
    class Login
    {
        conexion Conec = new conexion();

        #region "General"
        private DataTable buscar(string consulta)
        {
            Conec.iniciar();
            DataTable datos = new DataTable();
            try
            {
                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, Conec.conn);
                adap.Fill(datos);
            }
            catch (Exception ex)
            {
               //MessageBox.Show(ex.ToString());
               // MessageBox.Show(consulta);
            }
            return datos;


        }

        private bool consulta_gen(string consulta)
        {
            Conec.iniciar();
            MySqlCommand com1 = new MySqlCommand();
            com1.Connection = Conec.conn;
            com1.CommandText = consulta;
            com1.CommandType = CommandType.Text;
            try
            {
                Conec.conn.Open();
                com1.ExecuteNonQuery();
                Conec.conn.Close();
            }

            catch (Exception ex)
            {
                Conec.conn.Close();
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
                return false;
            }
            return true;
        }
        #endregion
        public DataTable Logueo(string user, string pass)
        {
        string consulta = "Select id_vendedor,nombre,usuario,contrasenia,nivel from vendedor where usuario='" + user + "' and contrasenia='" + pass + "'";
        return  buscar(consulta);
        }

        public string NomVende(string id)       {
            string consulta = "Select nombre from vendedor where id_vendedor="+id;
            string nombre= buscar (consulta).Rows[0][0].ToString();
            return nombre;
        }
    }
}
