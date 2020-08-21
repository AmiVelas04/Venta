﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
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

        public bool prodexist(string nom,string est,string tip,string col,string tall)
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

        public DataTable DatosRestant(string nom, string est, string tip, string col, string tall)
        {
            string consulta = "Select cantidad,precio_cost,precio_m1,precio_m2,precio_V1,precio_V2,ubicacion from producto " +
                              "where nombre='" + nom + "' and id_estilo=" + est + " and id_tipo=" + tip + " and id_color=" + col + " and Talla='" + tall + "'";
            return buscar(consulta);
        }

        public string busc_codprod(string nom,string est,string tip,string col,string tall)
        {
            string cod;
            string consulta = "Select id_prod from producto " +
                               "where nombre='" + nom + "' and id_estilo=" + est + " and id_tipo=" + tip + " and id_color=" + col + " and Talla='" + tall + "'";
           DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows.Count >0)
            {
                cod = (datos.Rows[0][0].ToString());
               
            }
            else
            {
                cod = "N";
            }
            return cod;

        }

        private int cant_prod(string cod)
        {
            int codigo;
            string consulta = "select cantidad from producto where id_prod='" + cod + "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta );
            codigo = Int32.Parse(datos.Rows[0][0].ToString ());
            return codigo;

        }
        private string cod_prod(string tip, string est, string tall)
        {
           string cod;
            string buscaid = "SELECT p.id_prod FROM producto p " +
                            "WHERE p.ID_TIPO ="+tip+" AND p.ID_ESTILO ="+est+" AND p.talla = '"+tall+"'";
            DataTable codig = new DataTable();
            codig = buscar(buscaid);
            if (codig.Rows.Count > 0)
            {
                string dato = codig.Rows[0][0].ToString();
                cod = dato.Substring(0, 2);
            }
            else {
                string consulta = "Select count(*) from producto";
                DataTable datos = new DataTable();
                datos = buscar(consulta);
                if (datos.Rows[0][0] != DBNull.Value)
                {
                    int num= Int32.Parse(datos.Rows[0][0].ToString());
                    num += 1;
                    cod="R"+num.ToString();
                }
                else
                {
                    cod = "R1";
                }
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
        private string ConvCol(string col)
        { string NvoCol = "";

            if (int.Parse(col) > 0 && int.Parse(col) < 10)
            { NvoCol = "00"+col.ToString(); }
            else if (int.Parse(col) > 9 && int.Parse(col) < 100)
            { NvoCol = "0" + col.ToString(); }
            else if (int.Parse(col) > 99 && int.Parse(col) < 1000)
            { NvoCol = col.ToString(); }
            return NvoCol;

        }
        public bool ingreso_prod(string[] datos)
        {
            string codpod="";
            string est=datos[1];
            string tipo= datos[2];
            string color= datos[3];
            string val;
            val = datos[10];
            //esta ingresado el estilo
            if (datos[1] == "0")
            {
                if (datos[10] != "")
                {
                    est = ingreEstil(datos[12]).ToString ();
                }
            }
            //esta ingresado el tipo
            val = datos[11];
            if (datos[2] == "0")
            {
                if (datos[11] != "")
                {
                    tipo  = ingreTipo (datos[13]).ToString();
                }
            }
            //esta ingresado el color
            val = datos[12];
            if (datos[3] == "0")
            {
                if (datos[12] != "")
                {
                    color = ingreColor(datos[14]).ToString();
                }
            }
            codpod =cod_prod(tipo,est,datos[4]) + "-" + ConvCol(color);
            string nomcomp = datos[0] + est + tipo + color + datos[4];
            string imagen = revimagen(nomcomp, datos[11]);
            string consulta = "Insert into producto(id_prod,nombre,id_estilo,id_tipo,id_color,talla,cantidad,precio_cost,precio_m1,precio_m2,precio_v1,precio_v2,imagen,ubicacion) " +
                               "values ('"+codpod+"','"+datos[0] + "','"+est + "','"+ tipo + "','"+color + "','"+datos[4] + "',"+datos[5] + ","+datos[6] + "," + datos[7] +  "," + datos[8] +"," +datos[9]+ ","+datos[10]+",'" + imagen +"','"+datos[15]+ "')";
            if (consulta_gen(consulta))
            {
                MessageBox.Show("Codigo: " + codpod + "\nProducto: " + datos[0]+ "\nEstilo: "+ datos[12] + "\nTipo: "+ datos[13] + "\nColor: "+datos[14] + "\nTalla: " + datos [4] + "\n¡Registro correcto!","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return true;
            }
            else
            {return false; }
        }
        public bool upd_prod(string[] datos)
        {
            int cantant,cantnova;
            string consulta,codprod;
            codprod = busc_codprod(datos[0], datos[1], datos[2], datos[3],datos[4]);
            cantant = cant_prod(codprod);
            cantnova = Int32.Parse(datos[5]);
            //cantnova += cantant;
            consulta = "Update producto set cantidad=" + cantnova +", precio_cost="+datos[6]+ ", precio_M1=" + datos[7] + ", precio_M2=" + datos[8] + ", precio_v1=" + datos[9] + ", precio_v2=" + datos[10] + ", imagen='" +datos[11]+"', ubicacion = '"+datos[15]+"' where id_Prod='" + codprod+ "'"; 
            return consulta_gen(consulta);
        }
        public DataTable buscarprod(string nom)
        {
            string consulta = "SELECT p.id_prod AS Codigo,p.nombre AS Nombre,e.estilo AS Estilo,t.tipo AS Tipo,c.color AS Color,p.talla AS Talla,p.cantidad as Cantidad,p.precio_cost AS Costo,p.precio_m1 AS P_Mayorista_2,p.precio_m2 AS P_Mayorista_2,p.precio_v1 AS P_Venta_1,p.precio_v2 AS P_Venta_2, p.Ubicacion as Ubicacion " +
                             "FROM producto p " +
                             "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO " +
                             "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " +
                             "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR " +
                             "WHERE p.nombre LIKE '%" + nom + "%'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }
        public DataTable prodvent()
        {
            string consulta = "SELECT p.id_prod AS Codigo,Concat(p.nombre ,' ',e.estilo,' ' ,t.tipo ,' ' ,c.color,' ', p.talla) as produ,p.cantidad as Cantidad,p.precio_cost AS Costo,p.precio_v1,p.precio_v2,p.precio_m1,precio_m2 " +
                                "FROM producto p " +
                                "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO " +
                                "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " +
                                "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR " +
                                "order by p.nombre";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
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
        public DataTable  prodId(string id)
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "SELECT p.id_prod, p.PRECIO_COST as costo,p.PRECIO_M1,p.PRECIO_M2,p.PRECIO_V1,p.PRECIO_V2,p.TALLA as Talla,t.id_tipo as idt ,t.tipo as tipo,c.id_color as idc, c.color as color,e.id_estilo as ide,e.estilo as estilo, p.nombre,p.ubicacion " +
                       "FROM producto p " +
                       "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " +
                       "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR " +
                       "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO " +
                       "WHERE p.ID_PROD ='" + id +
                       "' ORDER BY p.NOMBRE";
            return datos = buscar(consulta);
           
        }

        public bool exitencias(string id,int cant)
        {
            string consulta;
            int existe=0;
            bool resp = false;
            DataTable datos = new DataTable();
            consulta = "Select cantidad from producto where id_prod='"+id + "'";
            datos=buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value) existe = Int32.Parse(datos.Rows[0][0].ToString()); 
            if (existe >= cant) resp = true;
            return resp;
        }

        public string codestilo(string idprod)
        {
            string id;
            DataTable datos = new DataTable();
            string consulta = "SELECT id_estilo from producto where id_prod='" + idprod + "'";
            datos = buscar(consulta);
            if (datos.Rows .Count<=0)
            {
                id = "0";
            }
            else
            {
                id = datos.Rows[0][0].ToString ();
            }
            return id.ToString();
        }

        public string codcolor(string idprod)
        {
            string id;
            DataTable datos = new DataTable();
            string consulta = "SELECT id_color from producto where id_prod='" + idprod + "'";
            datos = buscar(consulta);
            if (datos.Rows.Count <= 0)
            {
                id = "0";
            }
            else
            {
                id = datos.Rows[0][0].ToString();
            }
            return id.ToString();
        }

        public string codtipo(string idprod)
        {
            string id;
            DataTable datos = new DataTable();
            string consulta = "SELECT id_tipo from producto where id_prod='" + idprod +"'";
            datos = buscar(consulta);
            if (datos.Rows.Count <= 0)
            {
                id = "0";
            }
            else
            {
                id = datos.Rows[0][0].ToString();
            }
            return id.ToString();
        }
        #region "Datos de productos"
        
            
        public  bool devolverprod (string id, string cant)
        {
            string consultaCant;
            int canti=0;
            consultaCant = "Select cantidad from producto where id_Prod='" + id +"'";
            DataTable datos = new DataTable();
            datos = buscar(consultaCant);
            if (datos.Rows.Count<=0) return false;
            canti = int.Parse(datos.Rows[0][0].ToString ());
            canti += int.Parse(cant);
            string consulupd = "Update producto set cantidad="+canti +" where id_prod='"+id +"'";
            return consulta_gen(consulupd);
        }
        //Listado para escoger productos
        public DataTable estilolst(string nom, string tipo)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "SELECT e.id_estilo as id, e.estilo as estilo FROM estilo e " +
                       "INNER JOIN producto p ON p.id_estilo = e.id_estilo " +
                       "WHERE p.Nombre ='" +nom + "' and p.id_tipo="+tipo +
                       " Group by p.id_estilo";
            return datos = buscar(consulta);
        }

        public DataTable tipolst(string prod)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "SELECT t.id_tipo as id,t.tipo as tipo FROM tipo t " +
                       "INNER JOIN producto p ON p.ID_TIPO = t.ID_TIPO " +
                       "WHERE p.Nombre ='" +prod+"' "+
                       "Group by p.id_tipo";
            return datos = buscar(consulta);
        }

        public DataTable colorlst(string nom, string estilo, string tipo)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "SELECT c.id_color as id,c.color as color FROM color c " +
                       "INNER JOIN producto p ON p.ID_color = c.ID_color " +
                       "WHERE p.nombre='" +nom +"' and p.id_estilo="+ estilo + " and p.id_tipo="+tipo +
                       " Group by p.id_color";
            return datos = buscar(consulta);
        }

        public DataTable tallalst(string nom,string tip, string  est,string col)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "SELECT talla, id_prod from producto " +
                       "WHERE Nombre = '" + nom + "' and id_tipo=" + tip + " and id_estilo="+est + " and id_color="+col;
            return datos = buscar(consulta);
        }

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
                "where p.nombre='" + prod + "' "+
                "GROUP BY e.ID_ESTILO";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
                    
        }

        public DataTable tipo(string prod)
        {
            string consulta = "Select t.id_tipo as id,t.tipo as tipo from Tipo t inner join producto p on t.id_tipo=p.id_tipo " +
               "where p.nombre='" + prod + "' "+
               "Group by t.id_tipo";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }

        public DataTable color(string prod)
        {

            string consulta = "Select c.id_color as id,c.color as color from color c " +
                  // "where p.nombre='" + prod + "' "+
                   "Group by c.id_color";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }

        public string nomprod(string id)
        { string consulta = "Select nombre from producto where id_prod='" + id +"'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos.Rows[0][0].ToString ();
        }

        public DataTable PeticionProd(string id)
        {
            string consulta = "SELECT p.ID_PROD, p.NOMBRE, e.estilo,t.tipo,c.color,p.TALLA,p.CANTIDAD,p.PRECIO_COST,p.PRECIO_M1, p.PRECIO_M2,p.PRECIO_V1,p.PRECIO_V2,p.IMAGEN,p.UBICACION,e.ID_ESTILO,t.ID_TIPO,c.ID_COLOR " + 
                                "FROM producto p "+
                                "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO "+
                                "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO "+ 
                                "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR "+
                                "WHERE p.ID_PROD = '"+id+"'";
            return buscar(consulta);
         
        }
        public string imagen(string id)
        {
            string consulta = "Select imagen from producto where id_prod='" + id + "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows.Count > 0) { return datos.Rows[0][0].ToString(); }
            else { return "0.jpg"; }
        }

        #endregion

        public bool descontarprod(string id, string cant)
        {
            string consultaCant;
            int canti = 0;
            consultaCant = "Select cantidad from producto where id_Prod='" + id + "'";
            DataTable datos = new DataTable();
            datos = buscar(consultaCant);
            if (datos.Rows.Count <= 0) return false;
            canti = int.Parse(datos.Rows[0][0].ToString());
            canti -= int.Parse(cant);
            string consulupd = "Update producto set cantidad=" + canti + " where id_prod='" + id + "'";
            return consulta_gen(consulupd);
        }


        #region "Reportes"
        public void inventario()
        {
            DataTable datos = new DataTable();
            string consulta = "SELECT p.Nombre,t.tipo,e.estilo,c.color, p.talla, p.cantidad, p.precio_cost,p.imagen FROM producto p "+
                                "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO "+
                                "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO "+
                                "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR";
            datos= buscar(consulta);
            int cont, cant;
            cant = datos.Rows.Count;
            Reportes.FactEnc Encab = new Reportes.FactEnc();
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.ListaProd produ = new Reportes.ListaProd();
                produ.NombreProd = datos.Rows[cont][0].ToString();
                produ.tipo = datos.Rows[cont][1].ToString();
                produ.estilo= datos.Rows[cont][2].ToString();
                produ.color= datos.Rows[cont][3].ToString();
                produ.Talla= datos.Rows[cont][4].ToString();
                produ.cantidad= int.Parse(datos.Rows[cont][5].ToString());
                produ.precio= decimal.Parse(datos.Rows[cont][6].ToString());
                produ.imagen=@""+Application.StartupPath + @"\imagen\"+ datos.Rows[cont][7].ToString();
                Encab.Prod.Add(produ);
            }
            Reportes.Inventario inven = new Reportes.Inventario();
            inven.inventario = Encab .Prod;
            inven.Show();
        }
        public void ConteoP(int cant)
        {
            string consulta = "SELECT p.nombre, e.estilo,t.tipo,c.color, p.talla, p.CANTIDAD "+
                              "FROM producto p "+
                              "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO "+
                              "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO "+
                              "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR "+
                              "WHERE p.CANTIDAD <= "+cant+" " +
                              "GROUP BY p.ID_PROD "+
                              "ORDER BY p.CANTIDAD,p.NOMBRE";
            int cont,canti;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            canti = datos.Rows.Count;
            Reportes.ConceEnc titulo = new Reportes.ConceEnc();
            titulo.fecha = DateTime.Now.ToString("yyyy/MM/dd");
            for(cont=0;cont<canti;cont++)
            {
                Reportes.ConceDet deta = new Reportes.ConceDet();
                deta.descripcion = datos.Rows[cont][0].ToString() + " "+ datos.Rows[cont][1].ToString() + " "+datos.Rows[cont][2].ToString() + " "+datos.Rows[cont][3].ToString() + " " + datos.Rows[cont][4].ToString();
                deta.cantidad =int.Parse( datos.Rows[cont][5].ToString());
                titulo.Detalle.Add(deta);
            }
            Reportes.CantidadP cantid = new Reportes.CantidadP();
            cantid.encabezado.Add(titulo);
            cantid.detalle = titulo.Detalle;
            cantid.Show();
        }
        #endregion
        private string revimagen(string imagen,string origen)
        {
           
            string NombreFull, ruta;
            string extension = Path.GetExtension(origen);
            NombreFull = imagen + extension;
            if (Directory.Exists("./imagen"))
            { }
            else
            {
                Directory.CreateDirectory("./imagen");
            }
            ruta = Path.GetFullPath("./imagen/" + NombreFull);
            if (File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png")
                {
                    try
                    {
                        File.Copy(origen, "./imagen/" + imagen + extension);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("./imagen/" + imagen + extension);
                        MessageBox.Show(Ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Imagen no valida/ o inexistente");
                    NombreFull = "0.jpg";
                }
            }
            else
            {
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png")
                {
                    File.Copy(origen, "./imagen/" + imagen + extension);
                }
                else
                {
                    MessageBox.Show("Imagen no valida/ o inexistente");
                    NombreFull = "0.jpg";
                }
            }
            return NombreFull;
        }

    }
}
