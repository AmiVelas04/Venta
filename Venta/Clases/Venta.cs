using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Venta.Clases
{
    
    class Venta
    {
        Producto prod = new Producto();
        Clientes cli = new Clientes();
        conexion conn = new conexion();

        #region "General"
        private DataTable buscar(string consulta)
        {
            conn.iniciar();
            DataTable datos = new DataTable();
            try
            {

                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conn.conn);
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
        //Generacion de codigos
        private int cod_venta()
        {
            int id;
            DataTable datos = new DataTable();
            string consulta;
            consulta = "Select max(id_venta) from venta";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                id = 1;
            }
            else
            { id = Int32.Parse(datos.Rows[0][0].ToString());
                id++;
            }
            return id;
        }

        private int cod_detalle()
        {
            int id;
            DataTable datos = new DataTable();
            string consulta;
            consulta = "Select max(id_detalle) from venta_detalle";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                id = 1;
            }
            else
            {
                id = Int32.Parse(datos.Rows[0][0].ToString());
                id++;
            }
            return id;
        }
        private int cod_cred()
        {
            int id;
            DataTable datos = new DataTable();
            string consulta;
            consulta = "Select max(id_credito) from credito";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                id = 1;
            }
            else
            {
                id = Int32.Parse(datos.Rows[0][0].ToString());
                id++;
            }
            return id;
        }

        private int cod_conc()
        {
            int id;
            DataTable datos = new DataTable();
            string consulta;
            consulta = "Select max(id_conc) from concesion";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                id = 1;
            }
            else
            {
                id = Int32.Parse(datos.Rows[0][0].ToString());
                id++;
            }
            return id;
        }

        public bool generar_V(DataTable  datos, string vende,string estado,string tipo)
        {
           string fecha;
            fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            

            int venta = cod_venta();
            string consulta = "insert into  venta(id_venta,id_vendedor,fecha, tipo,estado) " +
                              "values(" +venta + "," +vende + ",'" + fecha + "','"+ tipo +"','" +estado+ "')";
            if (consulta_gen(consulta))
            {
                return generar_det(datos, venta.ToString());
            }
            else
            {
                return false;
            }
        }

        private bool generar_det(DataTable datos, string venta)
        {
            int id, total, cont;
            string consulta;
            total = datos.Rows.Count;

            for (cont =0; cont<total;cont++) { 
            id = cod_detalle();
            consulta = "insert into venta_detalle(id_detalle,id_venta,id_prod,cantidad,precio,total) " +
                               "values(" + id + "," + venta + "," +datos.Rows[cont][0].ToString () + ", "+ datos.Rows[cont][6].ToString() +","+ datos.Rows[cont][7].ToString()+","+ datos.Rows[cont][8].ToString() + ")";
                if (!consulta_gen(consulta))
                {
                    return false;
                }
            }
            
            return true;
        }

        private bool RegCred(DataTable datos,string venta)
        {
            string consulta;
           
            int id = cod_cred(),cont;
            int total = datos.Rows.Count;
            decimal valor = 0;
            for (cont = 0; cont < total; cont++)
            {
                valor += decimal.Parse(datos.Rows[cont][8].ToString ());
            }
            consulta = "insert into credito(id_credtio, id_cliente, id_venta,Total, anticipo, Estado) " +
                        "values("+id+",1," +venta+ ","+ valor+",0,'Activo')";
            return consulta_gen(consulta); 
        }


        private bool Regconc(DataTable datos, string venta)
        {
            string consulta;

            int id = cod_conc(), cont;
            int total = datos.Rows.Count;
            decimal valor = 0;
            for (cont = 0; cont < total; cont++)
            {
                valor += decimal.Parse(datos.Rows[cont][8].ToString());
            }
            consulta = "insert into concesion(id_conc, id_venta,id_cliente, Estado) " +
                        "values(" + id + ",1," + venta + ",1,'Activo')";
            return consulta_gen(consulta);
        }

        private bool borrar_det(DataTable datos)
        {
            string consulta = "";
            return consulta_gen(consulta);
        }

        private bool borrar_vent(DataTable datos)
        {
            string consulta = "";
            return consulta_gen(consulta);
        }
    }
}
