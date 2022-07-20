using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Ionic.Zip;

namespace Venta.Clases
{
    class Salidaprod
    {
        conexion conn = new conexion();
        Producto prod = new Producto("");
        RastreoProd track = new RastreoProd();
        Errores err = new Errores();
        
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
                string mensaje = ex.ToString() + "\n" + consulta;
                MessageBox.Show("Se presento un inconveniente en el proceso de salida de productos ", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                err.Grabar_Error(mensaje);
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
                string mensaje = ex.ToString() + "\n" + consulta;
                MessageBox.Show("Se presento un inconveniente en el proceso de salida de productos ", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                err.Grabar_Error(mensaje);
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
        private int cod_salida_tienda()
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "Select Max(id_salida) from salida_tienda";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                return 1;
            }
            else
            {
                int valor = int.Parse(datos.Rows[0][0].ToString());
                valor++;
                return valor;
            }
        }
        private int cod_Salida_detalle()
    {
            string consulta;
            DataTable datos = new DataTable();
            int valor;
            consulta = "Select Max(id_detalle) from salida_detalle";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                valor= 1;
            }
            else
            {
                valor = int.Parse(datos.Rows[0][0].ToString());
                valor++;
               
            }
            return valor;
        }

        public bool GenerarSalidaprod(string [] sali, DataTable detalle)
        {
            int idsal = cod_salida();
            string fecha = DateTime.Now.ToString("yyyy/MM/dd ");
            string vende = sali[0],vendio;
            string ConsulVen = "Select nombre from vendedor where id_vendedor = " + vende;
            DataTable vendi = new DataTable();
            vendi = buscar(ConsulVen);
            vendio = vendi.Rows[0][0].ToString();
            string solicito = sali [1];
            string consulta= "insert into sprod(id_sprod,fecha,id_vende,solicito) values"+
                        "("+idsal +",'"+fecha+"',"+ vende+ ",'"+solicito+"')";
            if (consulta_gen(consulta))
            {

                if (GenerarSalidaDetalle(detalle, idsal.ToString(), vende))
                {
                    DocSalidaprod(fecha, vendio, solicito, idsal, detalle);
                    return true;
                }
                else
                { return false; }
            }
            else
            {
                return false;
            }
        }

        public bool GenerarSalidaDetalle(DataTable detalle, string salida, string idv)
        {
            int id, cont, cant;
            cant = detalle.Rows.Count;
            for (cont=0;cont<cant;cont++)
            {
                id = cod_detalle();
                string idprod = detalle.Rows[cont][0].ToString();
                string canti = detalle.Rows[cont][1].ToString();
                string consulta = "insert into sproddet(id_sdet,id_sprod,id_prod,cant) values"+
                                  "("+id+ ","+salida+ ",'"+ idprod +"',"+canti+")";
                int ante=prod.cantidadprod(idprod);
                DataTable datoes = new DataTable();
                datoes.Columns.Add("codigo").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("producto").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("estilo").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("tipo").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("color").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("talla").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("cantidad").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("cantante").DataType = System.Type.GetType("System.String");
                DataRow fila = datoes.NewRow();
                fila["codigo"] = idprod;
                fila["producto"] = "";
                fila["estilo"] = "";
                fila["tipo"] = "";
                fila["color"] = "";
                fila["talla"] = "";
                fila["cantidad"] = canti;
                fila["Cantante"] = "0";
                datoes.Rows.Add(fila);
                track.Movimiento(datoes, 8, idv, ante, salida);
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
            Reportes.RepSalGenEnc Enc = new Reportes.RepSalGenEnc();
            string consulta = "SELECT s.id_sprod,sd.Id_SDet,Concat(p.nombre,' - ', e.estilo,' - ', t.tipo, ' - ', c.color,' - ', p.talla) AS nombre,sd.cant,s.Fecha,s.solicito, ven.Nombre " +
                              "FROM sprod s " +
                              "INNER JOIN Vendedor ven ON ven.id_vendedor=s.id_vende "+
                              "INNER JOIN sproddet sd ON sd.id_Sprod = s.id_Sprod " +
                              "INNER JOIN producto p on sd.id_prod = p.ID_PROD " +
                              "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO " +
                              "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " +
                              "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR " +
                              "WHERE s.fecha <= '" + fechaf + "' AND s.Fecha >= '" + fechai + "' " +
                              "GROUP BY sd.Id_SDet";
            datos = buscar(consulta);
            Enc.fechai = fechai;
            Enc.fechaf = fechaf;
            int cont, cant;
            cant = datos.Rows.Count;
            for (cont= 0; cont<cant;cont++)
            {
                Reportes.RepSalGenDet deta = new Reportes.RepSalGenDet();
                deta.idSalida =int.Parse( datos.Rows[cont][0].ToString());
                deta.Sdet = int.Parse(datos.Rows[cont][1].ToString());
                deta.Producto = datos.Rows[cont][2].ToString ();
                deta.cantidad = int.Parse(datos.Rows[cont][3].ToString());
                deta.Solicito = datos.Rows[cont][5].ToString();
                deta.Atendio = datos.Rows[cont][6].ToString();
                Enc.Detalle.Add(deta);
            }
            Reportes.RepSalGen report = new Reportes.RepSalGen();
            report.Encabezado.Add(Enc);
            report.Detalle = Enc.Detalle;
            report.Show();
        }

        public bool salidaprod(string soli, DataTable datos, string opero)
        {

            return true;
        }

        public bool cotizagen(string cli, DataTable datos)
        {
            try
            {
                Reportes.ConceEnc enca = new Reportes.ConceEnc();
                enca.nombre = cli;
                enca.fecha = DateTime.Now.ToString("yyyy/MM/dd");
                int cont, cant;
                cant = datos.Rows.Count;
                for (cont = 0; cont < cant; cont++)
                {
                    Reportes.ConceDet deta = new Reportes.ConceDet();
                    deta.cod = datos.Rows[cont][0].ToString();
                    deta.descripcion = datos.Rows[cont][1].ToString() + ", " + datos.Rows[cont][2].ToString() + ", " + datos.Rows[cont][3].ToString() + ", " + datos.Rows[cont][4].ToString() + ", " + datos.Rows[cont][5].ToString();
                    deta.cantidad = int.Parse(datos.Rows[cont][6].ToString());
                    deta.precio = decimal.Parse(datos.Rows[cont][7].ToString());
                    deta.total = decimal.Parse(datos.Rows[cont][8].ToString());
                    enca.Detalle.Add(deta);
                }
                Reportes.Cotizacion Coti = new Reportes.Cotizacion();
                Coti.Deta = enca.Detalle;
                Coti.Enca.Add(enca);
                Coti.Show();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.ToString());

            }

        }

        public bool salidatienda(string idvende, DataTable datos)
        {
            string ConSaliGen, vendio,fecha,tienda;
            string ConsulVen= "Select nombre from vendedor where id_vendedor = " + idvende;
            DataTable vendi = new DataTable();
            vendi = buscar(ConsulVen);
            int num=cod_salida_tienda(); 

            vendio = vendi.Rows[0][0].ToString(); 
            tienda = "Sucursal Arcociris";
            fecha = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
               
            ConSaliGen = "insert into Salida_tienda(id_salida, id_vende, fecha,estado) " +
                         "values("+num+","+idvende+",'"+fecha+"','Enviado')";
            if (consulta_gen(ConSaliGen))
            {
                if (intercambdetalle(num, datos,idvende))
                {
                    reportSali(fecha, vendio, tienda,num, datos);
                    return true;
                }
                else
                {
                    return false;
                }
                   
            }
            else
            {
                return false;
            }
            
        }

        private bool intercambdetalle( int codC, DataTable datos,string idv)
        {
            int numer;
            int cont, cant;
            cant = datos.Rows.Count;
            string idprod, canti, precio, total;
            for (cont = 0; cont<cant; cont++)
            {
                string consulta;
                numer=cod_Salida_detalle();
                idprod = datos.Rows[cont][0].ToString();
                canti = datos.Rows[cont][6].ToString();
                precio = datos.Rows[cont][7].ToString();
                total = datos.Rows[cont][8].ToString();
                consulta = "insert into Salida_detalle(id_detalle,id_salida,id_prod,cantidad, precio, total) values(" +
                          numer + "," + codC + ",'" + idprod + "'," + canti + "," + precio + "," + total + ")";
                DataTable datoes = new DataTable();
                datoes.Columns.Add("codigo").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("producto").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("estilo").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("tipo").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("color").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("talla").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("cantidad").DataType = System.Type.GetType("System.String");
                datoes.Columns.Add("cantante").DataType = System.Type.GetType("System.String");
                DataRow fila = datoes.NewRow();
                fila["codigo"] = idprod;
                fila["producto"] = "";
                fila["estilo"] = "";
                fila["tipo"] = "";
                fila["color"] = "";
                fila["talla"] = "";
                fila["cantidad"] = canti;
                fila["Cantante"] = "0";
                datoes.Rows.Add(fila);
                int ante = prod.cantidadprod(idprod);
                track.Movimiento(datoes, 9, idv, ante, codC.ToString());
                if (!consulta_gen(consulta) || !prod.descontarprod(idprod,canti))
                {
                    return false;
                }
            }
            return true;
                }

        private void DocSalidaprod(string fecha, string vendio, string soli, int salida, DataTable datos)
        {
            Reportes.TiendaInterEnca enca = new Reportes.TiendaInterEnca();
            enca.vende = vendio;
            enca.Fecha = fecha;
            enca.Num = salida;
            enca.Tienda = soli;
            int cont, cant;
            cant = datos.Rows.Count;
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.TiendaInterDet deta = new Reportes.TiendaInterDet();
                deta.cod = datos.Rows[cont][0].ToString();
                deta.prod = datos.Rows[cont][2].ToString();
                deta.cantidad = int.Parse(datos.Rows[cont][1].ToString());
                enca.Detalle.Add(deta);
            }
            Reportes.ProducSalida ventana = new Reportes.ProducSalida();
            ventana.Detalle = enca.Detalle;
            ventana.Encabezado.Add(enca);
            ventana.Show();
        }

        private void reportSali (string fecha, string vendio, string tienda,int salida , DataTable datos)
            {
            Reportes.TiendaInterEnca enca = new Reportes.TiendaInterEnca();
            enca.vende = vendio;
            enca.Fecha = fecha;
            enca.Num = salida;
            enca.Tienda = tienda;
            int cont, cant;
            cant = datos.Rows.Count;
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.TiendaInterDet deta = new Reportes.TiendaInterDet();
                deta.cod = datos.Rows[cont][0].ToString();
                deta.prod = datos.Rows[cont][1].ToString() + ", " + datos.Rows[cont][2].ToString() + ", " + datos.Rows[cont][3].ToString() + ", " + datos.Rows[cont][4].ToString() + ", " + datos.Rows[cont][4].ToString();
                deta.cantidad = int.Parse(datos.Rows[cont][6].ToString());
                enca.Detalle.Add(deta);
            }
            Reportes.TiendaInter ventana = new Reportes.TiendaInter();
            ventana.Detalle = enca.Detalle;
            ventana.Encabezado.Add(enca);
            ventana.Show();
        }


        public void RepSalidaTien(string fechai, string fechaf)
        {
            DataTable datos = new DataTable();
            Reportes.RepSalGenEnc Enc = new Reportes.RepSalGenEnc();
            string consulta = "SELECT st.id_salida,satd.id_detalle, CONCAT(p.NOMBRE, ' - ',e.ESTILO, ' - ',t.TIPO, ' - ',c.COLOR, ' - ',p.TALLA)  AS Productos,ven.NOMBRE,satd.Cantidad  " +
                              "FROM salida_tienda st "+
                              "INNER JOIN vendedor ven ON ven.ID_VENDEDOR = st.id_vende "+
                              "INNER JOIN salida_detalle satd ON satd.id_salida = st.id_salida "+
                              "INNER JOIN producto p ON satd.id_prod = p.ID_PROD "+
                              "INNER JOIN estilo e ON p.ID_ESTILO = e.ID_ESTILO "+
                              "INNER JOIN tipo t ON p.ID_TIPO = t.ID_TIPO "+
                              "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR "+
                              "WHERE st.fecha >= '"+fechai+"' AND fecha>= '"+fechaf+"' "+
                              "GROUP BY  satd.id_detalle";
            datos = buscar(consulta);
            Enc.fechai = fechai;
            Enc.fechaf = fechaf;
            int cont, cant;
            cant = datos.Rows.Count;
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.RepSalGenDet deta = new Reportes.RepSalGenDet();
                deta.idSalida = int.Parse(datos.Rows[cont][0].ToString());
                deta.Sdet = int.Parse(datos.Rows[cont][1].ToString());
                deta.Producto = datos.Rows[cont][2].ToString();
                deta.cantidad = int.Parse(datos.Rows[cont][4].ToString());
                deta.Solicito = "Sucursal Aroiris";
                deta.Atendio = datos.Rows[cont][3].ToString();
                Enc.Detalle.Add(deta);
            }
            Reportes.RepSalTien report = new Reportes.RepSalTien();
            report.Encabezado.Add(Enc);
            report.Detalle = Enc.Detalle;
            report.Show();
        }


    }
}
