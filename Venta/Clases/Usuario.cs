using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Venta.Clases
{
    class Usuario
    {
        conexion conec = new conexion();
        Errores err = new Errores();
        #region "General"
        private DataTable buscar(string consulta)
        {
            conec.iniciar();
            DataTable datos = new DataTable();
            try
            {

                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conec.conn);
                adap.Fill(datos);
            }
            catch (Exception ex)
            {
                string mensaje = ex.ToString() + "\n" + consulta;
                MessageBox.Show("Se presento un inconveniente en el proceso de caja ", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                err.Grabar_Error(mensaje);

            }
            return datos;


        }

        private bool consulta_gen(string consulta)
        {
            conec.iniciar();
            MySqlCommand com1 = new MySqlCommand();
            com1.Connection = conec.conn;
            com1.CommandText = consulta;
            com1.CommandType = CommandType.Text;
            try
            {
                conec.conn.Open();
                com1.ExecuteNonQuery();
                conec.conn.Close();
            }

            catch (Exception ex)
            {
                conec.conn.Close();
                string mensaje = ex.ToString() + "\n" + consulta;
                MessageBox.Show("Se presento un inconveniente en el proceso de caja ", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                err.Grabar_Error(mensaje);
                return false;
            }
            return true;
        }
        #endregion

        public DataTable bucarusu()
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "SELECT Id_vendedor, nombre,usuario,contrasenia, nivel " +
                       "FROM vendedor " +
                       "WHERE Id_vendedor != 1";
            datos = buscar(consulta);
            return datos;
        }

        public DataTable bucarusucod(string cod)
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "SELECT Id_vendedor, nombre,usuario,contrasenia, nivel " +
                       "FROM vendedor " +
                       "WHERE Id_vendedor =" + cod;
            datos = buscar(consulta);
            return datos;
        }

        public bool existe(string cod)
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "SELECT Id_vendedor, nombre,usuario,contrasenia, nivel " +
                       "FROM vendedor " +
                       "WHERE Id_vendedor =" + cod;
            datos = buscar(consulta);
            if (datos.Rows.Count > 0)
            { return true; }
            else
            { return false; }

        }

        public bool ingre(string[] datos)
        {
            string consulta;
            int cod = codigo();
            consulta = "insert into vendedor(Id_vendedor,nombre,usuario,contrasenia,nivel) " +
                       "values(" + cod + ",'" + datos[1] + "','" + datos[2] + "','" + datos[3] + "','" + datos[4] + "')";
            return consulta_gen(consulta);
        }

        public bool updat(string[] datos)
        {
            string consulta;
            consulta = " update vendedor set nombre='" + datos[1] + "', usuario='" + datos[2] + "', contrasenia='" + datos[3] +
                "', nivel=" + datos[4] + " where Id_vendedor=" + datos[0];
            return consulta_gen(consulta);
        }


        private int codigo()
        {
            DataTable datos = new DataTable();
            int cod = 0;
            string consulta;
            consulta = "SELECT MAX(Id_vendedor) FROM vendedor";
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
                cod = Int32.Parse(datos.Rows[0][0].ToString());
            cod++;
            return cod;
        }
    }
}
