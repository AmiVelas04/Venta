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
    class Credito
    {
        conexion conec = new conexion();
        Caja caj = new Caja();
      
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

        private int codpag()
        {
            string consulta;
            int id = 1;
            consulta = "Select Max(id_pago) from pago";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value) id = int.Parse(datos.Rows[0][0].ToString ())+1;
            return id;
        }

        private string CliporCre(string idcre)
        {
            string consulta,nombre="";
            DataTable datos = new DataTable();
            consulta =  "SELECT cli.nombre FROM cliente cli "+
                        "INNER JOIN credito cre ON cre.ID_CLIENTE = cli.ID_CLIENTE "+
                        "WHERE cre.ID_CREDITO ="+idcre;
            datos = buscar(consulta);
            return datos.Rows[0][0].ToString();
        }
        public DataTable BusCred(string cli)
        {
            string consulta;
            consulta = "SELECT id_credito " +
                       "FROM credito "+
                       "WHERE id_cliente ="+cli+" AND Estado = 'Activo'";
            return buscar(consulta);
        }

        public DataTable saldos(string cred)
        {
            string consulta = "SELECT SUM(p.Monto),c.anticipo,c.Total, Saldo_ant FROM pago p "+
                               "INNER JOIN credito c ON c.ID_CREDITO = p.id_credito "+
                               "WHERE p.id_credito ="+cred;
            return buscar(consulta);
        }
        public DataTable pagos(string cred)
        {
            string consulta = "SELECT p.Id_pago as Codigo,p.id_credito as Credito,p.Monto,p.Detalle,p.Fecha,v.Nombre "+
                               "FROM pago p "+
                               "INNER JOIN vendedor v ON v.ID_VENDEDOR = p.id_vende "+
                               "WHERE p.id_credito ="+cred;
            return buscar(consulta);
        }
        public decimal saldo(string id)
        {
            DataTable datos = new DataTable();
            DataTable pagos = new DataTable();
            decimal total=0, anticipo=0, totalpag=0,saldoant=0;
            string consulta = "Select total, anticipo,saldo_ant from credito where id_credito="+id +" and Estado ='Activo'";
            string Consulpagos = "select sum(monto) from pago where id_credito="+id;
            datos = buscar(consulta);
            pagos = buscar(Consulpagos);

            if (datos.Rows.Count >0)
            {
                total = decimal.Parse(datos.Rows[0][0].ToString());
                anticipo =decimal.Parse(datos.Rows[0][1].ToString());
                saldoant = decimal.Parse(datos.Rows[0][2].ToString());
            }
            if (pagos.Rows[0][0] != DBNull.Value)
            {
                totalpag = decimal.Parse (pagos.Rows[0][0].ToString());
            }

            decimal saldo;
            saldo = total +saldoant- totalpag-anticipo;
            return saldo;
        }

        public bool RegPago(string []datos)
        {
            int id = codpag();
            string consulta = "insert into pago(id_pago,id_credito,Monto,detalle,fecha,id_vende) " +
                 "Values("+id+","+datos[0]+","+datos [1]+",'"+datos [2]+ "','"+datos [3]+"',"+datos [4]+")";
           
            consulta_gen(consulta);
            imprimirBoleta(id, datos);
            return RpagoCre(id.ToString(), datos[0], datos[1], datos[4]);
        }

        public void imprimirBoleta(int id,string [] datos)
        {
            decimal monto = saldo(datos[0]);
            decimal total, pago;
            pago = decimal.Parse(datos[1]);
            total = monto - pago;
            Reportes.Boleta bol = new Reportes.Boleta();
            bol.NoBol = id.ToString ();
            bol.NoCre = datos[0];
            bol.pago = pago;
            bol.saldo = total;
            bol.concepto = datos[2];
            bol.fecha = datos[3];
            bol.Cliente = CliporCre(datos[0]);
            bol.Vende = VendePorCre(datos[0]);
            Reportes.BoletaP Bolet = new Reportes.BoletaP();
            Bolet.bol.Add(bol);
            Bolet.Show();
        }
        public void ReImp(int id,string [] datos)
        {
            decimal monto = saldo(datos[0]);
            decimal total, pago;
            pago = decimal.Parse(datos[1]);
            total = monto;
            Reportes.Boleta bol = new Reportes.Boleta();
            bol.NoBol = id.ToString();
            bol.NoCre = datos[0];
            bol.pago = pago;
            bol.saldo = total;
            bol.concepto = datos[2];
            bol.fecha = datos[3];
            bol.Cliente = CliporCre(datos[0]);
            bol.Vende = VendePorCre(datos[0]);
            Reportes.BoletaP Bolet = new Reportes.BoletaP();
            Bolet.bol.Add(bol);
            Bolet.Show();
        }
      
        public string VendePorCre(string idcre)
        {
            string consulta = "SELECT ven.nombre FROM vendedor ven " +
                                "INNER JOIN venta v ON v.ID_VENDEDOR = ven.ID_VENDEDOR " +
                                "INNER JOIN credito cre ON cre.id_venta = v.ID_VENTA " +
                                "WHERE cre.ID_CREDITO =" + idcre;

            return buscar(consulta).Rows[0][0].ToString();
        }
        private bool RpagoCre(string idp,string cre,string pago,string vende)
        {
            string ConsV = "Select nombre from vendedor where id_vendedor=" + vende;
            DataTable data = new DataTable();
            data = buscar(ConsV);
            string nombre = data.Rows[0][0].ToString();
            string ConsCli = "SELECT c.nombre FROM cliente c " +
                            "INNER JOIN credito cre ON cre.ID_CLIENTE = c.ID_CLIENTE " +
                            "INNER JOIN pago p ON p.id_credito = cre.ID_CREDITO " +
                            "WHERE cre.ID_CREDITO ="+cre;
            DataTable datcli = new DataTable();
            datcli = buscar(ConsCli);
            string nomcli = datcli.Rows[0][0].ToString();
            string detalle = "Pago de  abono a credito No."+cre+ " nombre de "+nomcli;
            string operacion = "Entrada";
            string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            string[] datos = { pago, detalle, operacion, fecha, vende };
            return caj.Regcaja(datos);
        }
    }
}
