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
        Clientes cli = new Clientes();
        Login log = new Login();
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
            consulta = "SELECT id_conc FROM concesion WHERE id_cliente ="+cli+"  AND Estado = 'Pendiente'";
            return buscar(consulta);
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
        private int cod_cetConc()
        {
            int id;
            DataTable datos = new DataTable();
            string consulta;
            consulta = "Select max(conc_detalle) from conce_detalle";
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

        public DataTable ProdConce(string conc)
        {
            string consulta;
            consulta = "SELECT p.Nombre,e.estilo,t.tipo,c.color, p.TALLA,cd.cantidad,cd.precio,cd.total,p.id_prod, cd.conc_detalle FROM producto p " +
                       "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR "+
                       "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO "+
                       "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " + 
                       "INNER JOIN conce_detalle cd ON cd.ID_PROD = p.ID_PROD "+
                       "WHERE cd.ID_Conc ="+conc;
            return buscar(consulta);
        }

        public bool GenConc(DataTable datos,string cli,string vende,string estado)
        {
            string fecha;
            fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            int conc = cod_conc();
            string consulta = "insert into Concesion (id_conc,id_cliente,id_vende,fecha,estado) " +
                              "values(" + conc +"," + cli+ "," + vende + ",'" + fecha + "','" + estado + "')";
            if (consulta_gen(consulta))
            {
                return DetConc(datos, conc.ToString(),cli,vende); 
            }
            else
            {
                return false;
            }
        }

        public bool DetConc(DataTable datos,string Conce,string cli,string vende)
        {
            int id, total, cont;
            string consulta, totprod, CambioProd;
            total = datos.Rows.Count;
            for (cont = 0; cont < total; cont++)
            {
                int totalP,Resto;
                DataTable prod = new DataTable();
                id = cod_cetConc();
                totprod = "Select Cantidad from producto where id_Prod='"+datos.Rows[cont][0].ToString()+"'";
                prod = buscar(totprod);
                totalP = int.Parse(prod.Rows[0][0].ToString());
                Resto = totalP - int.Parse(datos.Rows[cont][6].ToString());
                consulta = "insert into conce_detalle(conc_detalle,id_conc,id_prod,cantidad,precio,total) " +
                                   "values(" + id + "," + Conce + ",'" + datos.Rows[cont][0].ToString() + "', " + datos.Rows[cont][6].ToString() + "," + datos.Rows[cont][7].ToString() + "," + datos.Rows[cont][8].ToString() + ")";
                CambioProd = "Update Producto set cantidad= " + Resto +" where id_prod='"+ datos.Rows[cont][0].ToString()+"'";

                if (!consulta_gen(consulta)|| !consulta_gen(CambioProd))
                {
                    return false;
                }
            }
            GenConce(datos, Conce,cli,vende);
            return true;
        }

        public void GenConce(DataTable datos, string conce,string clien,string vende)
        {
            DataTable data = new DataTable();
            data = cli.buscli(clien);
            int cant, cont;
            cant = datos.Rows.Count;
            Reportes.ConceEnc Encab = new Reportes.ConceEnc();
            Encab .fecha = DateTime.Now.ToString("dd/MM/yyyyy hh:mm:ss");
            Encab.No = conce;
            Encab.vendedor = log.NomVende(vende);
            //Encab.tipo = tipo;
            Encab.direccion = data.Rows[0][0].ToString();
            Encab .nit= data.Rows[0][1].ToString();
            Encab.nombre = data.Rows[0][3].ToString();
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.ConceDet Det = new Reportes.ConceDet();
                Det.Numero = cont + 1;
                Det.cod = datos.Rows[cont][0].ToString();
                Det.descripcion = datos.Rows[cont][1].ToString() + "  " + datos.Rows[cont][2].ToString() + "  " + datos.Rows[cont][3].ToString() + "  " + datos.Rows[cont][4].ToString();
                Det.cantidad =int.Parse( datos.Rows[cont][6].ToString());
                Det.precio = decimal.Parse(datos.Rows[cont][7].ToString());
                Det.total = decimal.Parse(datos.Rows[cont][8].ToString());
                Encab.Detalle.Add(Det);
            }
            Reportes.Conces Conceso = new Reportes.Conces();
            Conceso.Encab.Add(Encab);
            Conceso.Deta = Encab.Detalle;
            Conceso.Show();
        }

        public void reimprimir(string idc)
        {
            DataTable Dcli = new DataTable();
            DataTable Conce = new DataTable();
            DataTable ConcDet = new DataTable();
            DataTable clie = new DataTable();
           
            string concon = "SELECT id_vende,id_cliente,fecha,estado "+
                            "FROM concesion "+
                            "WHERE id_conc ="+idc;
            string condet = "SELECT Concat(p.nombre,' - ',e.estilo,' - ',t.tipo,' - ',c.color,' - ',p.talla) AS nombre,cd.cantidad,cd.precio,cd.total,p.id_prod "+
                            "FROM conce_detalle cd "+
                            "INNER JOIN producto p ON p.ID_PROD = cd.ID_PROD "+
                            "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO "+
                            "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO "+
                            "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR "+
                            "WHERE cd.id_conc ="+idc;
            Conce = buscar(concon);
            ConcDet = buscar(condet);
            clie = cli.buscli(Conce.Rows[0][1].ToString());
            int cant, cont;
            cant = ConcDet.Rows.Count;
            Reportes.ConceEnc Encab = new Reportes.ConceEnc();
            Encab.fecha = Conce.Rows[0][2].ToString ();
            Encab.No = idc;
            Encab.vendedor = log.NomVende(Conce.Rows[0][0].ToString ());
            //Encab.tipo = tipo;
            Encab.direccion = clie.Rows[0][0].ToString();
            Encab.nit = clie.Rows[0][1].ToString();
            Encab.nombre = clie.Rows[0][3].ToString();
            for (cont=0;cont<cant;cont++)
            {
                Reportes.ConceDet Det = new Reportes.ConceDet();
                Det.Numero = cont + 1;
                Det.cod = ConcDet.Rows[cont][4].ToString();
                Det.descripcion = ConcDet.Rows[cont][0].ToString() ;
                Det.cantidad = int.Parse(ConcDet.Rows[cont][1].ToString());
                Det.precio = decimal.Parse(ConcDet.Rows[cont][2].ToString());
                Det.total = decimal.Parse(ConcDet.Rows[cont][3].ToString());
                Encab.Detalle.Add(Det);
            }
            Reportes.Conces Conceso = new Reportes.Conces();
            Conceso.Encab.Add(Encab);
            Conceso.Deta = Encab.Detalle;
            Conceso.Show();
        }

        public bool CanceConce(string id_conce)
        {
            string consulta = "Update concesion set estado= 'Entregado' where id_conc="+ id_conce;
            return consulta_gen(consulta);
                }

    }
}
