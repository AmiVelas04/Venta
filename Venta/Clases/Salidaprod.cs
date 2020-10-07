using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Venta.Clases
{
    class Salidaprod
    {
        conexion conn = new conexion();
        Producto prod = new Producto();
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
        private int cod_salida()
        {
            int id;
            DataTable datos = new DataTable();
            string consulta;
            consulta = "Select max(id_sprod) from sprod";
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

        private int cod_detalle()
        {
            int id;
            DataTable datos = new DataTable();
            string consulta;
            consulta = "Select max(id_sDet) from sproddet";
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

        public bool GenerarSalidaprod(string [] sali, DataTable detalle)
        {
            int idsal = cod_salida();
            string fecha = DateTime.Now.ToString("yyyy/MM/dd ");
            string vende = sali[0];
            string solicito = sali [1];
            string consulta= "insert into sprod(id_sprod,fecha,id_vende,solicito) values"+
                        "("+idsal +",'"+fecha+"',"+ vende+ ",'"+solicito+"')";
            if (consulta_gen(consulta))
            {
                return GenerarSalidaDetalle(detalle,idsal.ToString());
            }
            else
            {
                return false;
            }
        }

        public bool GenerarSalidaDetalle(DataTable detalle, string salida)
        {
            int id, cont, cant;
            cant = detalle.Rows.Count;
            for (cont=0;cont<cant;cont++)
            {
                id = cod_detalle();
                string idprod = detalle.Rows[0][0].ToString();
                string canti = detalle.Rows[0][1].ToString();
                string consulta = "insert into sproddet(id_sdet,id_sprod,id_prod,cant) values"+
                                  "("+id+ ","+salida+ ",'"+ idprod +"',"+canti+")";
                if (!consulta_gen(consulta))
                {
                    return false;
                }
                else if (!prod.descontarprod(idprod,canti))
                { 
                    return false;
                }
            }
            return true;
        }

        public void RepSalidaprod(string fechai,string fechaf)
        {
            DataTable datos = new DataTable();
            string consulta = "SELECT s.id_sprod,sd.Id_SDet,Concat(p.nombre,' - ', e.estilo,' - ', t.tipo, ' - ', c.color,' - ', p.talla) AS nombre,sd.cant,s.Fecha,s.solicito " +
                              "FROM sprod s " +
                              "INNER JOIN sproddet sd ON sd.id_Sprod = s.id_Sprod " +
                              "INNER JOIN producto p on sd.id_prod = p.ID_PROD " +
                              "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO " +
                              "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " +
                              "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR " +
                              "WHERE s.fecha <= '" + fechaf + "' AND s.Fecha >= '" + fechai + "' " +
                              "GROUP BY sd.Id_SDet";
            datos = buscar(consulta);
            int cont, cant;
            cant = datos.Rows.Count;
            for (cont= 0; cont<cant;cont++)
            {

            }
        }
    }
}
