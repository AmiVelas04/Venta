using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Venta.Clases
{
   
    class Producto
    {
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

        private bool prodexist(string nom,string est,string tip,string col,string tall)
        {
            string consulta = "Select * from producto "+
                              "where nombre='" + nom + "' and id_estilo=" + est + " and id_tipo=" + tip + " and id_color="+col +" and Talla='" + tall + "'" ;
            DataTable datos = new DataTable();
            datos = buscar(consulta );
            if (datos.Rows.Count <=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int busc_codprod(string nom)
        {
            int cod;
            string consulta = "Select id_prod from producto where nombre='" + nom + "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows.Count >0)
            {
                cod = Int32.Parse(datos.Rows[0][0].ToString());
               
            }
            else
            {
                cod = -1;
            }
            return cod;

        }
        private int cod_prod()
        {
            string consulta = "Select max(id_prod) from producto";
            int cod;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
            {
                cod = Int32.Parse(datos.Rows[0][0].ToString());
                cod++;
               
            }
            else
            {
                cod = 1;
            }
            return cod;
        }

        private int ingreEstil(string estilo)
        {
            DataTable datos = new DataTable();
            int cod;
            string consulta = "Select max(id_estilo) from estilo";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                cod = 1;
            }
            else
            {
                cod = Int32.Parse(datos.Rows[0][0].ToString ());
                cod++;
            }
            string consulingre;
            consulingre = "insert into estilo(id_estilo, estilo) values("+cod+",'" +estilo +"')";
            if (consulta_gen(consulingre))
            {
                return cod;
            }
            else
            {
                return 0;
            }
        }

        private int ingreColor(string Color)
        {
            DataTable datos = new DataTable();
            int cod;
            string consulta = "Select max(id_color) from color";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                cod = 1;
            }
            else
            {
                cod = Int32.Parse(datos.Rows[0][0].ToString());
                cod++;
            }
            string consulingre;
            consulingre = "insert into color(id_color, color) values(" + cod + ",'" + Color + "')";
            if (consulta_gen(consulingre))
            {
                return cod;
            }
            else
            {
                return 0;
            }
        }

        private int ingreTipo(string Tipo)
        {
            DataTable datos = new DataTable();
            int cod;
            string consulta = "Select max(id_tipo) from tipo";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                cod = 1;
            }
            else
            {
                cod = Int32.Parse(datos.Rows[0][0].ToString());
                cod++;
            }
            string consulingre;
            consulingre = "insert into tipo(id_tipo, tipo) values(" + cod + ",'" + Tipo + "')";
            if (consulta_gen(consulingre))
            {
                return cod;
            }
            else
            {
                return 0;
            }
        }

        public bool ingreso_prod(string[] datos)
        {
            int codpod;
            string est=datos[1];
            string tipo= datos[2];
            string color= datos[3];
            string val;
            if (prodexist(datos[0], est, tipo, color, datos[4]))
            {

                //si existe enviar a actualizar
                codpod =busc_codprod (datos[1]);
            }
            else
            {
                codpod = cod_prod();
            }
            val = datos[10];
            //esta ingresado el estilo
            if (datos[1] == "0")
            {
               
                if (datos[10] != "")
                {
                    
                    est = ingreEstil(datos[10]).ToString ();
                }
              
            }
            //esta ingresado el tipo
            val = datos[11];
            if (datos[2] == "0")
            {
              
                if (datos[11] != "")
                {
                    tipo  = ingreTipo (datos[11]).ToString();
                }
            }
            //esta ingresado el color
            val = datos[12];
            if (datos[3] == "0")
            {
              
                if (datos[12] != "")
                {
                    color = ingreColor(datos[12]).ToString();
                }
            }


            string consulta = "Insert into producto(id_prod,nombre,id_estilo,id_tipo,id_color,talla,cantidad,precio_cost,precio_m,precio_v,imagen) " +
                               "values ("+codpod+",'"+datos[0] + "','"+est + "','"+ tipo + "','"+color + "','"+datos[4] + "','"+datos[5] + "',"+datos[6] + "," + datos[7] +  "," + datos[8] + ",'" + datos[9] + "')";
            if (consulta_gen(consulta))
            {
                return true;
            }
            else
            {return false; }
                
        }

        public  AutoCompleteStringCollection Productos()
        {
            DataTable dt = new DataTable();
            dt = nomprod();

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["Nombre"]));
            }

            return coleccion;
        }

        private string codestilo(string nom)
        {
            int id;
            DataTable datos = new DataTable();
            string consulta = "SELECT MAX(e.id_estilo) FROM estilo e " +
                               "INNER JOIN producto p ON p.ID_ESTILO = e.ID_ESTILO " +
                               "WHERE p.NOMBRE ='" +nom + "' ";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                id = 1;
            }
            else
            {
                id = Int32.Parse(datos.Rows[0][0].ToString ());
                id++;
            }
            return id.ToString();
        }

        private string codcolor(string nom)
        {
            int id;
            DataTable datos = new DataTable();
            string consulta = "SELECT MAX(c.id_color) FROM color c " +
                              "INNER JOIN producto p ON p.ID_color = c.ID_color " +
                              "WHERE p.NOMBRE ='" + nom + "' ";
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
            return id.ToString();
        }

        private string codtipo(string nom)
        {
            int id;
            DataTable datos = new DataTable();
            string consulta = "SELECT MAX(c.id_tipo) FROM tipo t " +
                              "INNER JOIN producto p ON p.ID_tipo = c.ID_tipo " +
                              "WHERE p.NOMBRE ='" + nom + "' ";
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
            return id.ToString();
        }





        #region "Datos de productos"
        public DataTable nomprod()
        {
            string consulta = "Select Nombre from producto";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
       }

        public DataTable estilo(string prod )
        {
            string consulta = "Select e.id_estilo as id,e.estilo as estilo from estilo e inner join producto p on e.id_estilo=p.id_estilo " +
                "where p.nombre='" + prod + "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
                    
        }

        public DataTable tipo(string prod)
        {
            string consulta = "Select t.id_tipo as id,t.tipo as tipo from Tipo t inner join producto p on t.id_tipo=p.id_tipo " +
               "where p.nombre='" + prod + "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }

        public DataTable color(string prod)
        {

            string consulta = "Select c.id_color as id,c.color as color from color c inner join producto p on c.id_color=p.id_color " +
                   "where p.nombre='" + prod + "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }


        #endregion

    }
}
