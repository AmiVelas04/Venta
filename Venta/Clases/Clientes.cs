using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Venta.Clases
{
    class Clientes
    {
        conexion conec = new conexion();
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
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
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
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
                return false;
            }
            return true;
        }
        #endregion

        public DataTable clientes()
        {
            String consulta;
            DataTable datos = new DataTable();
            consulta = "Select id_cliente, nombre from cliente";
            datos = buscar(consulta);
            return datos;

        }

        public DataTable clienSin()
        {
            String consulta;
            DataTable datos = new DataTable();
            consulta = "Select id_cliente, nombre from cliente where id_cliente != 1";
            datos = buscar(consulta);
            return datos;

        }
        private int IdCli()
        {
            string consulta = "Select max(id_cliente) from cliente";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
            {
                return int.Parse(datos.Rows[0][0].ToString())+1;
            }
            else
            {return 1;}
        }

        public int CliporConce(string conce)
        {
            string consulta = "Select id_cliente from concesion where id_conc=" + conce;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return int.Parse(datos.Rows[0][0].ToString());
        }

        public DataTable buscli(string cli)
        {
            string consulta;
            consulta = "Select DIRECCION,nit, credi,Nombre,telefono, dpi from cliente where id_cliente =" + cli;
            return  buscar(consulta);
        }

        public DataTable CrediCli(string idcli)
        {
            string consulta;
            consulta = "";
            return buscar(consulta);

        }

        public bool ingrecli(string [] datos)
        {
            int id = IdCli();
            string consulta = "insert into cliente(id_cliente,nombre,direccion,nit,dpi,telefono,credi) " +
                "Values("+id+",'"+datos[0]+"','"+ datos[1]+ "','"+ datos[2]+ "','"+datos[3]+"','"+ datos[4]+ "',"+ datos[5] +")";
            return consulta_gen(consulta);
        }
        public DataTable Nomcliente(string nom)
        {
            string consulta = "Select Nombre, Direccion,Nit, Telefono,Dpi ,Credi as Credito from cliente "+
                "where nombre like '%"+nom+"%'";
            return buscar(consulta);
        }
    }
}
