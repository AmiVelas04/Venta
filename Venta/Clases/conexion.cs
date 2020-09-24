using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Venta.Clases
{
    class conexion
    {
        //Prueba
   //string cadena_conn = "server=Localhost;  database=tienda; user id=creditos; password=Cre-2020-Sis; port=3306; allow zero Datetime= true";
   //Produccion
  string cadena_conn = "server=Localhost;  database=Bdtipicos; user id=Tipicos; password=Venta_2020_Sis; port=3306; allow zero Datetime= true";

        public MySqlConnection conn = new MySqlConnection();
        public void iniciar()
        {
            conn.ConnectionString = cadena_conn;

        }
        public string probar_conn()
        {
            string mensaje;
            conn.ConnectionString = cadena_conn;
            try

            {
                conn.Open();
                conn.Close();

                mensaje = "Conexion exitosa";
                return mensaje;

            }
            catch (Exception ex)
            {
                conn.Close();
                mensaje = "Error: " + ex.ToString() + "\n" + cadena_conn;
                return mensaje;

            }

        }
    }
}
