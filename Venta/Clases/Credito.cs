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
    class Credito
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

        private int codpag()
        {
            string consulta;
            int id = 1;
            consulta = "Select Max(id_pago) from pago";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value) id = int.Parse(datos.Rows[0][0].ToString ());
            return id;
        }

        public DataTable BusCred(string cli)
        {
            string consulta;
            consulta = "SELECT id_credito " +
                       "FROM credito "+
                       "WHERE id_cliente ="+cli+" AND Estado = 'Activo'";
            return buscar(consulta);
        }

        public DataTable saldos(string cred)
        {
            string consulta = "SELECT SUM(p.Monto),c.anticipo,c.Total FROM pago p "+
                               "INNER JOIN credito c ON c.ID_CREDITO = p.id_credito "+
                               "WHERE p.id_credito ="+cred;
            return buscar(consulta);
        }
        public DataTable pagos(string cred)
        {
            string consulta = "SELECT p.Id_pago,p.id_credito,p.Monto,p.detalle,p.fecha,v.nombre "+
                               "FROM pago p "+
                               "INNER JOIN vendedor v ON v.ID_VENDEDOR = p.id_vende "+
                               "WHERE p.id_credito ="+cred;
            return buscar(consulta);
        }

        public bool RegPago(string []datos)
        {
            int id = codpag();
            string consulta = "insert into pago(id_pago,id_credito,Monto,detalle,fecha,id_vende) " +
                 "Values("+id+","+datos[0]+","+datos [1]+",'"+datos [2]+ "','"+datos [3]+"',"+datos [4]+")";
            return consulta_gen(consulta);

        }
    }
}
