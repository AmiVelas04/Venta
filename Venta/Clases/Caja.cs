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
    class Caja
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

        private int cod()
        {
            string consulta;
            int cod;
            consulta = "Select count(*) from caja";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows.Count > 0)
            { cod = int.Parse(datos.Rows[0][0].ToString());
                cod++;
            }
            else
            {
                cod = 1;
            }
            return cod;
        }

        public bool ingreso(string[] datos)
        {
            string codigo,consulta;
            codigo = cod().ToString();
            consulta = "insert into caja(id_caja,Monto,Descripcion,operacion,fecha) " +
                     "values("+codigo+","+datos[0]+ ",'"+datos[1]+ "','"+datos[2]+ "','"+datos[3]+"')";

            return consulta_gen(consulta);
        }

        public DataTable  buscar_ope(string fecha)
        {
            string fechai, fechaf;
            fechai = fecha + " 00:00:00";
            fechaf = fecha + " 23:59:59";
            string consulta = "Select Descripcion,Operacion,Monto,DATE_FORMAT(fecha,'%h:%m:%s') AS Hora from caja " +
                              "where fecha>= '" + fechai + "' and fecha<='" + fechaf + "'";
            return buscar(consulta);
        }
        public decimal Tentrada(string fecha)
        {
            string fechai, fechaf;
            fechai = fecha + " 00:00:00";
            fechaf = fecha + " 23:59:59";
            string consulta = "SELECT SUM(monto) FROM caja WHERE operacion='Entrada' and FECHA >= '" + fechai + "' and fecha<='" + fechaf + "'";
            string consultav = "SELECT SUM(vd.Total) AS Total " +
                               "FROM venta_detalle vd " +
                               "INNER JOIN venta v ON v.ID_VENTA = vd.ID_VENTA " +
                               "WHERE v.FECHA >= '"+fechai+"' and v.fecha<='"+fechaf+"' and Tipo='Contado' ";
            decimal totalope = 0,total=0,totalventa=0;
            DataTable datos = new DataTable();
            DataTable venta = new DataTable();
            datos = buscar(consulta);
            venta = buscar(consultav);
            if (datos.Rows[0][0] != DBNull.Value)
            {
                totalope = decimal.Parse(datos.Rows[0][0].ToString());
            }
            if (venta.Rows[0][0]!=DBNull.Value)
            {
                //   totalventa = decimal.Parse(venta.Rows[0][0].ToString());            
            }
            total = totalope + totalventa;
            return total;
        }
        
        public decimal Tsalida(string fecha)
        {
            string fechai, fechaf;
            fechai = fecha + " 00:00:00";
            fechaf = fecha + " 23:59:59";
            string consulta = "SELECT SUM(monto) FROM caja WHERE operacion='Salida'  and FECHA >= '" + fechai + "' and fecha<='" + fechaf + "'"; 
            decimal total = 0;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
            {
                total = decimal.Parse(datos.Rows[0][0].ToString ());
            }
            return total;
        }
        public bool Regcaja(string [] datos)
        {
            int codi = cod();
            string consulta = "insert into caja(id_caja,monto,descripcion,operacion,Fecha,id_vende) "+
                              "values("+codi+","+datos[0]+",'"+datos[1]+"','"+datos[2]+"','"+datos[3]+"','"+datos[4]+"')";
            return consulta_gen(consulta);
        }

        public void imprep(DataTable datos)
        {
            Reportes.FactEnc enc = new Reportes.FactEnc();
            enc.direccion = "Reporte de caja: " + DateTime.Now.ToString("dd/MM/yyyy");
            int cant, cont;
            cant = datos.Rows.Count;
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.ListaProd prods = new Reportes.ListaProd();
                //cantidad=orden
                prods.cantidad = int.Parse(datos.Rows[cont][0].ToString ());
                //tipo= descripcion
                prods.tipo = datos.Rows[cont][1].ToString ();
                //estilo= Operacion
               // prods.estilo = datos.Rows[cont][2].ToString();
                //precio= entrdada
                prods.precio = decimal.Parse(datos.Rows[cont][2].ToString());
                //imagen= salida
                prods.imagen = datos.Rows[cont][3].ToString();
                //Talla=Hora
                prods .Talla = datos.Rows[cont][4].ToString();
                enc.Prod.Add(prods);
            }
            Reportes.RepCaja Rcaja = new Reportes.RepCaja();
            Rcaja.Enc.Add(enc);
            Rcaja.Detalle = enc.Prod;
            Rcaja.Show();
        }
    }
}
