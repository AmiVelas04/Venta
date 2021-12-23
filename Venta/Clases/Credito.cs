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
        Errores err = new Errores();
        Clientes cli = new Clientes();


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
                MessageBox.Show("Se presento un inconveniente en el proceso de credito ", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Se presento un inconveniente en el proceso de credito ", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                err.Grabar_Error(mensaje);
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
            if (datos.Rows[0][0] != DBNull.Value) id = int.Parse(datos.Rows[0][0].ToString()) + 1;
            return id;
        }

        private string CliporCre(string idcre)
        {
            string consulta, nombre = "";
            DataTable datos = new DataTable();
            consulta = "SELECT cli.nombre FROM cliente cli " +
                        "INNER JOIN credito cre ON cre.ID_CLIENTE = cli.ID_CLIENTE " +
                        "WHERE cre.ID_CREDITO =" + idcre;
            datos = buscar(consulta);
            return datos.Rows[0][0].ToString();
        }
        public DataTable BusCred(string cli)
        {
            string consulta;
            consulta = "SELECT id_credito " +
                       "FROM credito " +
                       "WHERE id_cliente =" + cli + " order by id_credito desc limit 3";
            return buscar(consulta);
        }

        public DataTable saldos(string cred)
        {
            string consulta = "SELECT SUM(p.Monto),c.anticipo,c.Total, Saldo_ant, gastos,c.estado FROM pago p " +
                               "INNER JOIN credito c ON c.ID_CREDITO = p.id_credito " +
                               "WHERE p.id_credito =" + cred;
            return buscar(consulta);
        }
        public DataTable pagos(string cred)
        {
            string consulta = "SELECT p.Id_pago as Codigo,p.id_credito as Credito,p.Monto,p.Detalle,date_format(p.Fecha,'%d/%m/%y') as Fecha,v.Nombre " +
                               "FROM pago p " +
                               "INNER JOIN vendedor v ON v.ID_VENDEDOR = p.id_vende " +
                               "WHERE p.id_credito =" + cred;
            return buscar(consulta);
        }
        public decimal saldo(string id)
        {
            DataTable datos = new DataTable();
            DataTable pagos = new DataTable();
            decimal total = 0, anticipo = 0, totalpag = 0, saldoant = 0, gastos = 0;
            string consulta = "Select total, anticipo,saldo_ant ,gastos from credito where id_credito=" + id + "";
            string Consulpagos = "select sum(monto) from pago where id_credito=" + id;
            datos = buscar(consulta);
            pagos = buscar(Consulpagos);

            if (datos.Rows.Count > 0)
            {
                total = decimal.Parse(datos.Rows[0][0].ToString());
                anticipo = decimal.Parse(datos.Rows[0][1].ToString());
                saldoant = decimal.Parse(datos.Rows[0][2].ToString());
                gastos = decimal.Parse(datos.Rows[0][3].ToString());
            }
            if (pagos.Rows[0][0] != DBNull.Value)
            {
                totalpag = decimal.Parse(pagos.Rows[0][0].ToString());
            }

            decimal saldo;
            saldo = total + saldoant + gastos - totalpag - anticipo;
            return saldo;
        }

        public bool RegPago(string[] datos)
        {
            int id = codpag();
            string consulta = "insert into pago(id_pago,id_credito,Monto,detalle,fecha,id_vende) " +
                 "Values(" + id + "," + datos[0] + "," + datos[1] + ",'" + datos[2] + "','" + datos[3] + "'," + datos[4] + ")";

            if (consulta_gen(consulta))
            {
                if (saldo(datos[0]) <= 0)
                {
                    try
                    {
                        string consul = "update credito set estado='Cancelado' where id_credito=" + datos[0];
                        if (consulta_gen(consul))
                        {
                            MessageBox.Show("El credito ha sido Cancelador en su totalidad", "Pagado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        err.Grabar_Error(ex.ToString());
                    }
                }
            }

            imprimirBoleta(id, datos);
            return RpagoCre(id.ToString(), datos[0], datos[1], datos[4]);
        }

        public void imprimirBoleta(int id, string[] datos)
        {
            decimal monto = saldo(datos[0]);
           
            decimal total, pago;
            pago = decimal.Parse(datos[1]);
            total = monto /*- pago*/;
            if (total <= 0) total = 0.00M;
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
        public void ReImp(int id, string[] datos)
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

        private string idVentDeCredi(string idcred)
        {
            string consulta = "SELECT c.id_venta FROM   credito c " +
                              "WHERE c.ID_CREDITO=" + idcred;
            string idv;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                idv = "0";
            }
            else
            {
                idv = datos.Rows[0][0].ToString();
            }
            return idv;

        }
        public string VendePorCre(string idcre)
        {
            DataTable datos = new DataTable();
            string vende = "";
            string consulta = "SELECT ven.nombre FROM vendedor ven " +
                                "INNER JOIN venta v ON v.ID_VENDEDOR = ven.ID_VENDEDOR " +
                                "INNER JOIN credito cre ON cre.id_venta = v.ID_VENTA " +
                                "WHERE cre.ID_CREDITO =" + idcre;
            datos = buscar(consulta);
            if (datos.Rows.Count <= 0)
            {
                vende = "Vendedor";
            }
            else
            {
                vende = datos.Rows[0][0].ToString();
            }


            return vende;
        }
        private bool RpagoCre(string idp, string cre, string pago, string vende)
        {
            string ConsV = "Select nombre from vendedor where id_vendedor=" + vende;
            DataTable data = new DataTable();
            data = buscar(ConsV);
            string nombre = data.Rows[0][0].ToString();
            string ConsCli = "SELECT c.nombre FROM cliente c " +
                            "INNER JOIN credito cre ON cre.ID_CLIENTE = c.ID_CLIENTE " +
                            "INNER JOIN pago p ON p.id_credito = cre.ID_CREDITO " +
                            "WHERE cre.ID_CREDITO =" + cre;
            DataTable datcli = new DataTable();
            datcli = buscar(ConsCli);
            string nomcli = datcli.Rows[0][0].ToString();
            string detalle = "Pago de  abono a credito No." + cre + " nombre de " + nomcli;
            string operacion = "Entrada";
            string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            string[] datos = { pago, detalle, operacion, fecha, vende };
            return caj.Regcaja(datos);
        }
        public bool ingresogasto(string cod, string gasto)
        {
            string consulta = "update credito set gastos=" + gasto + " where id_credito=" + cod;
            return consulta_gen(consulta);
        }

        public void reimpCompro(string idc, string atendio)
        {
            DataTable venta = new DataTable();
            DataTable detalle = new DataTable();
            DataTable data = new DataTable();

            string idv = idVentDeCredi(idc);
            string consultaV = "SELECT id_vendedor,id_cli,Date_format(fecha,'%d/%M/%y %H:%m:%s'),tipo FROM venta " +
                              "WHERE id_venta =" + idv;
            string ConsutaDet = "SELECT Concat(p.nombre,' - ',e.estilo,' - ',t.tipo,' - ',c.color,' - ',p.talla) AS nombre,vd.cantidad,vd.precio,vd.total,p.id_prod " +
                                "FROM venta_detalle vd " +
                                "INNER JOIN producto p ON p.ID_PROD = vd.ID_PROD " +
                                "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO " +
                                "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " +
                                "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR " +
                                "WHERE vd.ID_VENTA = " + idv;
            venta = buscar(consultaV);
            detalle = buscar(ConsutaDet);
            int cant, cont;
            if (venta.Rows.Count <= 0)
            {
                MessageBox.Show("No existe comprobante registrado");
                return;
            }


            string idcli = venta.Rows[0][1].ToString();
            data = cli.buscli(idcli);
            cant = detalle.Rows.Count;
            Reportes.FactEnc Encab = new Reportes.FactEnc();
            Encab.fecha = venta.Rows[0][2].ToString();
            Encab.No = idv;
            Encab.tipo = venta.Rows[0][3].ToString();
            Encab.direccion = data.Rows[0][0].ToString();
            Encab.nit = data.Rows[0][1].ToString();
            Encab.nombre = data.Rows[0][3].ToString();
            Encab.vendedor = atendio;
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.FactDet Deta = new Reportes.FactDet();
                Deta.Numero = cont + 1;
                Deta.codigo = detalle.Rows[cont][4].ToString();
                Deta.descripcion = detalle.Rows[cont][0].ToString();
                Deta.cantidad = Int32.Parse(detalle.Rows[cont][1].ToString());
                Deta.precio = decimal.Parse(detalle.Rows[cont][2].ToString());
                Deta.total = decimal.Parse(detalle.Rows[cont][3].ToString());
                Encab.Detalle.Add(Deta);
            }
            Reportes.Factura Fact = new Reportes.Factura();
            Fact.Enca.Add(Encab);
            Fact.Deta = Encab.Detalle;
            Fact.Show();

        }

        public void reimpCompro2(string idv)
        {
            DataTable venta = new DataTable();
            DataTable detalle = new DataTable();
            DataTable data = new DataTable();

            string atendio = "";
            string consultaV = "SELECT id_vendedor,id_cli,Date_format(fecha,'%d/%M/%y %H:%m:%s'),tipo FROM venta " +
                              "WHERE id_venta =" + idv;
            string ConsutaDet = "SELECT Concat(p.nombre,' - ',e.estilo,' - ',t.tipo,' - ',c.color,' - ',p.talla) AS nombre,vd.cantidad,vd.precio,vd.total,p.id_prod " +
                                "FROM venta_detalle vd " +
                                "INNER JOIN producto p ON p.ID_PROD = vd.ID_PROD " +
                                "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO " +
                                "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " +
                                "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR " +
                                "WHERE vd.ID_VENTA = " + idv;
            venta = buscar(consultaV);
            detalle = buscar(ConsutaDet);
            int cant, cont;
            if (venta.Rows.Count <= 0)
            {
                MessageBox.Show("No existe comprobante registrado");
                return;
            }


            string idcli = venta.Rows[0][1].ToString();
            data = cli.buscli(idcli);
            cant = detalle.Rows.Count;
            Reportes.FactEnc Encab = new Reportes.FactEnc();
            Encab.fecha = venta.Rows[0][2].ToString();
            Encab.No = idv;
            Encab.tipo = venta.Rows[0][3].ToString();
            Encab.direccion = data.Rows[0][0].ToString();
            Encab.nit = data.Rows[0][1].ToString();
            Encab.nombre = data.Rows[0][3].ToString();
            Encab.vendedor = atendio;
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.FactDet Deta = new Reportes.FactDet();
                Deta.Numero = cont + 1;
                Deta.codigo = detalle.Rows[cont][4].ToString();
                Deta.descripcion = detalle.Rows[cont][0].ToString();
                Deta.cantidad = Int32.Parse(detalle.Rows[cont][1].ToString());
                Deta.precio = decimal.Parse(detalle.Rows[cont][2].ToString());
                Deta.total = decimal.Parse(detalle.Rows[cont][3].ToString());
                Encab.Detalle.Add(Deta);
            }
            Reportes.Factura Fact = new Reportes.Factura();
            Fact.Enca.Add(Encab);
            Fact.Deta = Encab.Detalle;
            Fact.Show();

        }

        public void ReporteCredi()
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "SELECT c.id_credito, cli.NOMBRE FROM credito c " +
                      "INNER JOIN cliente cli ON cli.ID_CLIENTE = c.ID_CLIENTE " +
                      "WHERE c.ESTADO = 'Activo' " +
                      "GROUP BY c.ID_CREDITO";
            datos = buscar(consulta);
            Reportes.ConceEnc enca = new Reportes.ConceEnc();
            enca.nombre = "Reporte de Creditos Activos";
            int cant, cont;
            cant = datos.Rows.Count;
            for (cont = 0; cont < cant; cont++)
            {
                decimal saldocred = 0;
                saldocred = saldo(datos.Rows[cont][0].ToString());
                if (saldocred > 0)
                {
                    Reportes.ConceDet deta = new Reportes.ConceDet();
                    deta.cod = datos.Rows[cont][0].ToString();
                    deta.descripcion = datos.Rows[cont][1].ToString();

                    deta.total = saldocred;
                    enca.Detalle.Add(deta);
                }

            }
            Reportes.RepCredi Repo = new Reportes.RepCredi();
            Repo.Detalle = enca.Detalle;
            Repo.Encabezado.Add(enca);
            Repo.Show();


        }

        public DataTable ultimos3cred(string idcli)
        {
            string consulta = "SELECT v.ID_VENTA AS id, date_format(v.FECHA,'%d/%M/%Y') AS fecha " +
                               "FROM venta v " +
                                "WHERE v.TIPO = 'Credito' AND v.ID_CLI =" + idcli + " order BY v.FECHA  desc LIMIT 3 ";
            return buscar(consulta);
        }

        public void ReportePagos(string idcli)
        {
            string consulta;
            int cant, cont;
            consulta = "SELECT p.Id_pago AS id,c.ID_CREDITO AS CreditoNum,c.id_venta AS compro,p.Monto,date_format(p.Fecha,'%d/%M/%Y') AS fecha, cli.NOMBRE,cli.DIRECCION, p.detalle " +
                       "FROM pago p " +
                       "INNER JOIN credito c ON c.ID_CREDITO = p.id_credito " +
                       "INNER JOIN vendedor ven ON ven.ID_VENDEDOR = p.id_vende " +
                       "INNER JOIN cliente cli ON cli.ID_CLIENTE = c.ID_CLIENTE " +
                       "WHERE cli.ID_CLIENTE = " + idcli + " AND p.Monto > 0";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            cant = datos.Rows.Count;
            Reportes.PagosrepoEnc enca = new Reportes.PagosrepoEnc();
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.PagosrepoDet deta = new Reportes.PagosrepoDet();
                deta.Idpag = Int32.Parse(datos.Rows[cont][0].ToString());
                deta.Credito = Int32.Parse(datos.Rows[cont][1].ToString());
                deta.Compro = Int32.Parse(datos.Rows[cont][2].ToString());
                deta.Monto = decimal.Parse(datos.Rows[cont][3].ToString());
                deta.fecha = (datos.Rows[cont][4].ToString());
                deta.detalle = datos.Rows[cont][7].ToString();
                enca.Detalle.Add(deta);
                enca.Nombre = datos.Rows[cont][5].ToString();
                enca.Direccion = datos.Rows[cont][6].ToString();
            }

            Reportes.PagoHechos repo = new Reportes.PagoHechos();
            repo.encabezado.Add(enca);
            repo.detalle = enca.Detalle;
            repo.Show();

        }
    }
}
