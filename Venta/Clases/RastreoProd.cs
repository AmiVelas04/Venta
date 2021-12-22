using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.InteropServices;

namespace Venta.Clases
{
    public class RastreoProd
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
                MessageBox.Show("Se presento un inconveniente en el Rastreo de productos ", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Se presento un inconveniente en el Rastreo de productos ", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                err.Grabar_Error(mensaje);
                return false;
            }
            return true;
        }


        #endregion


        #region Procesos
        private int cod()
        {
            string consulta;
            int cod;
            consulta = "Select count(*) from rastreo";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows.Count > 0)
            {
                cod = int.Parse(datos.Rows[0][0].ToString());
                cod++;
            }
            else
            {
                cod = 1;
            }
            return cod;
        }


        public bool Movimiento(DataTable datos, int ope,string idvende,[Optional]int anter,[Optional]string  venta)
        {
            //Tipo ope, Venta=1, Credito=2, agregar prod = 3, modif produ = 4, concesion = 5, retorno de cosesion = 6
            string consulta, idprod,fechastr,idtrack="",opera="";
            int tot,canti;
            DateTime ahora = DateTime.Now;
            fechastr = ahora.ToString("yyyy/MM/dd HH:mm:ss");
            tot = datos.Rows.Count;
            for (int i = 0; i < tot; i++)
            {
                idprod = datos.Rows[i][0].ToString();
                idtrack = cod().ToString();
                int ante=anter, posti=0;
               // ante = prod.cantidadprod(idprod);
                canti = int.Parse(datos.Rows[i][6].ToString());
                if (ope == 1)
                {
                    posti = ante - canti;
                    opera = "Se realizó una venta con número " + venta;
                }
                else if (ope == 2)
                {
                    posti = ante - canti;
                    opera = "Se realizó una salida por credito con número " + venta;
                }
                else if (ope == 3)
                {
                   // ante = int.Parse(datos.Rows[i][6].ToString());
                    canti= int.Parse(datos.Rows[i][7].ToString());
                    posti = canti;
                    opera = "Se modificó manualmente la cantidad de producto manualmente";

                }
                else if (ope == 4)
                {
                   // ante = int.Parse(datos.Rows[i][6].ToString());
                    canti= int.Parse(datos.Rows[i][6].ToString());
                    opera = "Se agrego la cantidad de producto existente";
                    posti = ante+canti;

                }
                else if (ope == 5)
                {
                   // ante = int.Parse(datos.Rows[i][6].ToString());
                    posti = ante - canti;
                    opera = "Se realizo una consignación con número " + venta;

                }
                else if (ope == 6)
                {
                    posti = ante + canti;
                    opera = "Se realizó un retorno de producto de consignación con número " + venta;
                }
                else if (ope == 7)
                {
                  //  ante = int.Parse(datos.Rows[i][6].ToString());
                    posti = ante + canti;
                    opera = "Se Canceló una venta con Numero " + venta;
                }
                consulta = "Insert into rastreo(id_track,fecha,cantprev,canti,operacion,Cantpost,tipoOpe,id_prod,id_vende) "+
                    "values("+ idtrack + ",'" +fechastr + "'," + ante.ToString() +","+canti+ ",'" + opera + "'," + posti +","+ ope +",'" +idprod +"',"+idvende+")";
                if (!consulta_gen(consulta))
                { return false; }
            }
            return true;

           
          
           
        }


        public void ReportTrack(string id)
        {
            DataTable datos = new DataTable();
            Reportes.TrackEnc enc = new Reportes.TrackEnc();
            string consulta;
            consulta = "SELECT ras.id_track,ras.fecha,ras.CantPrev,ras.Canti,ras.CantPost,ras.Operacion,ras.TipoOpe,ven.NOMBRE,pro.NOMBRE,pro.UBICACION,ras.id_prod " +
                          "FROM rastreo ras " +
                          "INNER JOIN vendedor ven ON ven.ID_VENDEDOR = ras.Id_vende " +
                          "INNER JOIN producto pro ON pro.ID_PROD = ras.id_prod " +
                          "WHERE ras.id_prod = '" + id + "'";
            datos = buscar(consulta);
            int tot = datos.Rows.Count;
            if (tot > 0) {
                enc.idprod = datos.Rows[0][10].ToString();
                enc.prod = datos.Rows[0][8].ToString();
                enc.titulo = "Rastreo de producto";
            }
            else
            {
                MessageBox.Show("No existes operaciones registradas para este producto","No hay operaciones",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            for (int i = 0; i < tot; i++)
            {
                int ope;
                string operacion = "";
                ope = int.Parse(datos.Rows[i][6].ToString());
                
                if (ope == 1)
                {
                    operacion = "Venta/Salida";
                }
                else if (ope == 2)
                {
                    operacion = "Credito/Salida";
                }

                else if (ope == 3)
                {
                    operacion = "Entrada/Modificacion";
                }
                else if (ope == 4)
                {
                    operacion = "Entrada/Ingreso producto";
                }
                else if (ope == 5)
                {
                    operacion = "Salida/Consignación";
                }
                else if (ope == 6)
                {
                    operacion = "Entrada/Retorno Consignación";
                }
                else if (ope==7)
                {
                    operacion = "Entrada/Cancelación Venta";
                }
                Reportes.TrackDet det = new Reportes.TrackDet();
                det.Numero = i+1;
                det.fecha = datos.Rows[i][1].ToString();
                det.prev = int.Parse(datos.Rows[i][2].ToString());
                det.cant = int.Parse(datos.Rows[i][3].ToString());
                det.post = int.Parse(datos.Rows[i][4].ToString());
                det.ope = datos.Rows[i][5].ToString();
                det.TipOpe = operacion;
                det.Vende = datos.Rows[i][7].ToString();
                det.ubi = datos.Rows[i][9].ToString();
                enc.Detalle.Add(det);
            }
            Reportes.TrackProd produ = new Reportes.TrackProd();
            produ.Encabezado.Add(enc);
            produ.Detalle = enc.Detalle;
            produ.Show();

            
        }


        
        #endregion



    }
}
