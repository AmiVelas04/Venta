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

       

        public bool generar_V(DataTable  datos, string vende,string cli,string estado,string tipo)
        {
           string fecha;
            fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            
            int venta = cod_venta();
            string consulta = "insert into  venta(id_venta,id_vendedor,fecha, tipo,estado) " +
                              "values(" +venta + "," +vende + ",'" + fecha + "','"+ tipo +"','" +estado+ "')";
            if (consulta_gen(consulta))
            {
                if (tipo == "Credito")
                {
                    RegCred(datos, venta.ToString ());
                }
              

                return generar_det(datos, venta.ToString(),cli,tipo);
            }
            else
            {
                return false;
            }
        }

        private bool generar_det(DataTable datos, string venta,string cli,string tipo)
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
            genfact(datos, venta, cli, tipo);
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
            //ingresar el codigo del cliente
            consulta = "insert into credito(id_credito, id_cliente, id_venta,Total, anticipo, Estado) " +
                        "values("+id+",1," +venta+ ","+ valor+",0,'Activo')";
            return consulta_gen(consulta); 
        }


       

        private void genfact(DataTable datos,string venta,string clien,string tipo)
        {
            DataTable data = new DataTable();
            data = cli.buscli(clien);
            int cant=datos.Rows.Count,cont;

            Reportes.FactEnc Encab = new Reportes.FactEnc();
            Encab .fecha = DateTime.Now.ToString("yyyyy/MM/dd hh:mm:ss");
            Encab.No = venta;
            Encab.tipo = tipo;
            Encab.direccion = data.Rows[0][0].ToString();
            Encab .nit= data.Rows[0][1].ToString();
            Encab.nombre = data.Rows[0][3].ToString();


            for (cont = 0; cont < cant; cont++)
            {
                Reportes.FactDet Deta = new Reportes.FactDet();
                Deta.Numero = cont +1;
                Deta.descripcion =datos .Rows[cont][1].ToString () +" - " + datos.Rows[cont][2].ToString() + " - "+datos.Rows[cont][3].ToString() + " - "+datos.Rows[cont][4].ToString();
                Deta.cantidad = Int32.Parse(datos.Rows[cont][6].ToString());
                Deta.precio = decimal.Parse(datos.Rows[cont][7].ToString());
                Deta.total = decimal.Parse (datos.Rows[cont][8].ToString());
                Encab.Detalle.Add(Deta);
            }
            Reportes.Factura Fact = new Reportes.Factura();
            Fact.Enca.Add(Encab);
            Fact.Deta = Encab.Detalle;
            Fact.Show();
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
