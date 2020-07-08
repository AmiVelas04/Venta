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
    class Conces
    {
        conexion conec = new conexion();
        Producto prod = new Producto();
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

        public DataTable busconce(string cli)
        {
            string consulta;
            consulta = "SELECT id_venta FROM venta WHERE id_cli ="+cli+"  AND tipo = 'Consesion'";
            return buscar(consulta);
        }

        public DataTable ProdConce(string venta)
        {
            string consulta;
            consulta = "SELECT p.Nombre,p.TALLA,c.color,e.estilo,t.tipo, d.cantidad,d.precio,d.total,p.id_prod, d.id_detalle FROM producto p "+
                       "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR "+
                       "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO "+
                       "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " + 
                       "INNER JOIN venta_detalle d ON d.ID_PROD = p.ID_PROD "+
                       "WHERE d.ID_VENTA ="+venta;
            return buscar(consulta);
        }


    }
}
