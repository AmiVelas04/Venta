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
      
        conexion conn = new Clases.conexion();
        Producto prod = new Producto();
        Clientes cli = new Clientes();
        Credito cre = new Credito();
        Caja caj = new Caja();

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
        public string CredPorVent(string idvent)
        {
            string consulta = "Select id_credito from credito where id_venta=" + idvent;
            return buscar(consulta).Rows[0][0].ToString();
        }

        public bool generar_V(DataTable  datos, string vende,string cli,string estado,string tipo,string pago)
        {
           string fecha;
            fecha = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int Nventa = cod_venta();
            string consulta = "insert into  venta(id_venta,id_vendedor,id_cli,fecha, tipo,estado) " +
                              "values(" +Nventa + "," +vende + ","+cli+",'" + fecha + "','"+ tipo +"','" +estado+ "')";
            if (consulta_gen(consulta))
            {
                if (tipo == "Credito")
                {
                    if (RegCred(datos, Nventa.ToString(),pago,vende,cli))
                    {
                        string idcred = CredPorVent(Nventa.ToString());
                        //RegAnti(idcred, pago, vende);
                    }
                }
                return generar_det(datos, Nventa.ToString(),cli,tipo,pago,vende);
            }
            else
            {
                return false;
            }
        }

        private bool generar_det(DataTable datos, string Nventa,string cli,string tipo,string pago,string vende)
        {
            int id, total, cont;
            string consulta;
            total = datos.Rows.Count;
            decimal Tvent = 0;
            for (cont =0; cont<total;cont++) { 
            id = cod_detalle();
            string idpord = datos.Rows[cont][0].ToString();
                string cant = datos.Rows[cont][6].ToString();
            consulta = "insert into venta_detalle(id_detalle,id_venta,id_prod,cantidad,precio,total) " +
                               "values(" + id + "," + Nventa + ",'" +datos.Rows[cont][0].ToString () + "', "+ datos.Rows[cont][6].ToString() +","+ datos.Rows[cont][7].ToString()+","+ datos.Rows[cont][8].ToString() + ")";
                if (!consulta_gen(consulta))
                {
                    return false;
                }
                if (!prod.descontarprod(idpord, cant))
                { return false; }
                Tvent += decimal.Parse(datos.Rows[cont][8].ToString());
            }
            string ConsV = "Select nombre from vendedor where id_vendedor=" + vende;
            DataTable data = new DataTable();
            data = buscar(ConsV);
            string nombre = data.Rows[0][0].ToString();
            string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            if (tipo=="Contado") RegVent(Nventa,Tvent.ToString (),vende);
            if (MessageBox.Show("¿Desea imprimir comprobante?","Imprimir",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) {
                genfact(datos, Nventa, cli, tipo, nombre);
            }
            
            return true;
        }

        private bool RegCred(DataTable datos,string Nventa,string pago,string vende,string cli)
        {
            string consulta,detalle,fecha,cancelant;
            fecha = DateTime.Now.ToString ("yyyy/MM/dd");
            int id = cod_cred(),cont,idant;
            decimal saldoant= SaldoAntCred(cli);
            detalle = "Anticipo de credito No." + id;
            int total = datos.Rows.Count;
            decimal valor = 0;
            for (cont = 0; cont < total; cont++)
            {
                valor += decimal.Parse(datos.Rows[cont][8].ToString ());
            }
            //ingresar el codigo del cliente
            idant = codant(cli);
            cancelant = "Update credito set estado='Cancelado' where id_credito=" + idant.ToString();
            if (consulta_gen(cancelant))
            {
                consulta = "insert into credito(id_credito, id_cliente, id_venta,Total, anticipo,saldo_Ant, Estado) " +
                            "values(" + id + "," + cli + "," + Nventa + "," + valor + "," + pago + "," + saldoant.ToString() + ",'Activo')";
                if (consulta_gen(consulta))
                {

                    string[] regi = { id.ToString(), pago, detalle, fecha, vende };
                    return (cre.RegPago(regi));
                }
            }
            return false;
        }

        private decimal SaldoAntCred(string idccli)
        {
            string consulta, consultapg="0";
            decimal anticipo=0, totalpagos=0, saldoant=0, saldo=0;
            DataTable datospag = new DataTable();
            DataTable datoscred = new DataTable();

            consulta = "Select id_credito,saldo_ant,anticipo,total from credito where id_cliente="+idccli +" and estado='Activo'";
            datoscred = buscar(consulta);
            if (datoscred.Rows.Count > 0)
            {
                consultapg = "Select sum(monto) from pago where id_credito=" + datoscred.Rows[0][0].ToString();
                datospag = buscar(consultapg);
            }
            if (datoscred.Rows.Count > 0)
            {
                saldo = decimal.Parse(datoscred.Rows[0][1].ToString()) + decimal.Parse(datoscred.Rows[0][3].ToString());
                anticipo = decimal.Parse(datoscred.Rows[0][2].ToString());
            }
          if (datospag.Rows.Count>0) totalpagos = decimal.Parse(datospag.Rows[0][0].ToString());

            saldoant = saldo - anticipo - totalpagos;

            return saldoant;
        }

        private int codant(string cli)
        {
            int codigo=0;
            string consulta = "Select id_credito from credito where id_cliente="+cli +" and estado='Activo'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows.Count > 0) codigo = int.Parse(datos.Rows[0][0].ToString());

            return codigo;

        }

        private void genfact(DataTable datos,string Nventa,string clien,string tipo, string vendio)
        {
            DataTable data = new DataTable();
            data = cli.buscli(clien);
            int cant=datos.Rows.Count,cont;
            Reportes.FactEnc Encab = new Reportes.FactEnc();
            Encab .fecha = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            Encab.No = Nventa;
            Encab.tipo = tipo;
            Encab.direccion = data.Rows[0][0].ToString();
            Encab .nit= data.Rows[0][1].ToString();
            Encab.nombre = data.Rows[0][3].ToString();
            Encab.vendedor = vendio;

            for (cont = 0; cont < cant; cont++)
            {
                Reportes.FactDet Deta = new Reportes.FactDet();
                Deta.Numero = cont +1;
                Deta.codigo = datos.Rows[cont][0].ToString();
                Deta.descripcion =datos .Rows[cont][1].ToString () +" - " + datos.Rows[cont][2].ToString() + " - "+datos.Rows[cont][3].ToString() + " - "+datos.Rows[cont][4].ToString() +" - " + datos.Rows[cont][5].ToString();
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
        private void RegAnti(string idcred,string pago, string vende)
        {
            string fecha = DateTime.Now.ToString ("yyyy/MM/dd hh:mm:ss");
            string operacion = "Entrada";
            string ConsV = "Select nombre from vendedor where id_vendedor=" + vende;
            DataTable data = new DataTable();
            data = buscar(ConsV);
            string nombre = data.Rows[0][0].ToString();
            string detalle = "Anticipo de credito No." + idcred + " A nombre de " + nombre;
            string[] datos = {pago,detalle,operacion,fecha,vende};
            caj.Regcaja(datos);
        }

        public int idVentaCliente(string idcli)
        {
            string consulta="Select max(id_venta) from venta where id_cli=" + idcli;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            { return 0; }
            else { return int.Parse(datos.Rows[0][0].ToString()); }
        }

        public void RegenFact(string id)
        {
            int cont, cant;
            Reportes.FactEnc Encab = new Reportes.FactEnc();
            DataTable datos = new DataTable();
            DataTable encabe = new DataTable();
            string ConsulDat = "SELECT Concat(p.nombre,' - ',e.ESTILO,' - ',t.TIPO,' - ',c.COLOR,' - Talla: ',p.TALLA) AS nombre,vd.cantidad,vd.precio,vd.total,p.id_prod FROM venta_detalle vd " +
                               "INNER JOIN producto p ON p.ID_PROD = vd.ID_PROD " +
                               "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO " +
                               "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " +
                               "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR " +
                               "WHERE vd.ID_VENTA ="+id;
            string ConsulEnca = "select ven.NOMBRE AS cliente,c.nombre AS cliente,c.DIRECCION,c.NIT,date_format(v.fecha,'%d/%m/%Y %H:%m:%s'),v.Tipo FROM venta v " +
                                "INNER JOIN vendedor ven ON ven.ID_VENDEDOR = v.ID_VENDEDOR " +
                                "INNER JOIN cliente c ON c.ID_CLIENTE = v.ID_CLI " +
                                "WHERE v.ID_VENTA =" + id;
            datos = buscar(ConsulDat);
            encabe = buscar(ConsulEnca);
            cant = datos.Rows.Count;
            Encab.No = id;
            Encab.nombre = encabe.Rows[0][1].ToString();
            Encab.direccion= encabe.Rows[0][2].ToString();
            Encab.nit= encabe.Rows[0][3].ToString();
            Encab.fecha= encabe.Rows[0][4].ToString();
            Encab.vendedor = encabe.Rows[0][0].ToString();
            Encab.tipo= encabe.Rows[0][5].ToString();
            for (cont=0;cont<cant;cont++)
            {
                Reportes.FactDet Deta = new Reportes.FactDet();
                Deta.Numero = cont + 1;
                Deta.codigo = datos.Rows[cont][4].ToString();
                Deta.descripcion = datos.Rows[cont][0].ToString();
                Deta.cantidad = int.Parse(datos.Rows[cont][1].ToString());
                Deta.precio = decimal.Parse(datos.Rows[cont][2].ToString());
                Deta.total = decimal.Parse(datos.Rows[cont][3].ToString());
                Encab.Detalle.Add(Deta);
            }
            Reportes.Factura Fact = new Reportes.Factura();
            Fact.Enca.Add(Encab);
            Fact.Deta = Encab.Detalle;
            Fact.Show();
        }
        public void RegVent(string venta, string pago, string vende)
        {
            string ConsV = "Select nombre from vendedor where id_vendedor=" + vende;
            DataTable data = new DataTable();
            data = buscar(ConsV);
            string nombre = data.Rows[0][0].ToString();
            string detalle = "Registro de venta No." + venta.ToString();
            string operacion = "Entrada";
            string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            string[] datos = {pago,detalle,operacion,fecha,vende };
            caj.Regcaja(datos);
        }
        public void ventasD(string fechini, string fechaFin)
        {
            string consulta = "SELECT V.id_venta, Concat(p.nombre, ' - ', e.ESTILO, ' - ', t.TIPO, ' - ', c.COLOR, ' - Talla: ', p.TALLA) AS nombre, vd.cantidad,vd.precio,vd.total,Date_format(v.FECHA,'%d/%m/%Y'), p.id_prod " +
                               "FROM venta v "+
                               "INNER JOIN venta_detalle vd ON vd.ID_VENTA = v.ID_VENTA "+
                               "INNER JOIN producto p ON p.ID_PROD = vd.ID_PROD "+
                               "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO "+
                               "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO "+
                               "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR "+
                               "WHERE v.FECHA >= '"+fechini+"' AND v.FECHA <= '"+fechaFin+"' and Estado='Cancelado'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int cont, cant;
            cant = datos.Rows.Count;
            Reportes.ConceEnc Encab = new Reportes.ConceEnc();
            Encab.direccion = fechini;
            Encab.vendedor = fechaFin;

            for (cont = 0; cont < cant; cont++)
            {
                Reportes.VentasD ven = new Reportes.VentasD();
                ven.codigo = datos.Rows[cont][6].ToString();
                ven.venta = int.Parse(datos.Rows[cont][0].ToString());
                ven.producto = datos.Rows[cont][1].ToString();
                ven.cantidad = int.Parse(datos.Rows[cont][2].ToString());
                ven.precio = decimal.Parse(datos.Rows[cont][3].ToString());
                ven.total = decimal.Parse(datos.Rows[cont][4].ToString());
                ven.fecha = datos.Rows[cont][5].ToString();
                Encab.Venta.Add(ven);
            }
            Reportes.VentasDiarios Fventa= new Reportes.VentasDiarios();
            Fventa.Enca.Add(Encab);
            Fventa.venta = Encab.Venta;
            Fventa.Show();

        }

        public DataTable  listavent()
        {
            string f1,f2, fecha = DateTime.Now.ToString("yyyy/MM/dd");
            f1 = fecha + " 00:00:00";
            f2 = fecha + " 23:59:59";
            string consulta = "SELECT id_venta " +
                             "FROM venta " +
                             "WHERE fecha>='"+f1+"' and fecha<='"+f2+"' and Estado= 'Cancelado'";
            return buscar(consulta);
        }
        public DataTable ListVenFech(string fecha)
        {
            string f1, f2;
            f1 = fecha + " 00:00:00";
            f2 = fecha + " 23:59:59";
            string consulta = "SELECT id_venta " +
                             "FROM venta " +
                             "WHERE fecha>='" + f1 + "' and fecha<='" + f2 + "'";
            return buscar(consulta);
        }

        public DataTable prodvent(string id)
        {
            string consulta;
            consulta = "SELECT p.id_prod,p.Nombre, vd.CANTIDAD,vd.PRECIO ,vd.TOTAL "+
                       "FROM venta_detalle vd "+
                       "INNER JOIN producto p ON p.ID_PROD = vd.ID_PROD "+
                       "WHERE vd.ID_VENTA ="+id;
            return buscar(consulta);
        }

        public DataTable datavent(string ven)
        {
            string consulta = "SELECT ve.Nombre,cli.nombre,date_format(v.FECHA,'%d/%M/%Y %H:%i:%s') FROM venta v "+
                              "INNER JOIN cliente cli ON cli.ID_CLIENTE = v.ID_CLI "+
                              "INNER JOIN vendedor ve ON ve.ID_VENDEDOR = v.ID_VENDEDOR "+
                              "WHERE v.ID_VENTA ="+ven;
            return buscar(consulta);
        }

        public bool cambvent(string id)
        {
            string consulta = "update venta set Estado='Retorno' where id_venta='"+id + "'";
            return consulta_gen(consulta);
        }

        public bool devolver(string id, string cant)
        {
            return prod.devolverprod(id, cant);
        }

        public bool regcaja(string [] datos)
        {
            return caj.Regcaja(datos);
        }

        public void reimprimivent(string idv,string atendio)
        {
            DataTable venta= new DataTable ();
            DataTable detalle = new DataTable();
            DataTable data = new DataTable();
            string consultaV = "SELECT id_vendedor,id_cli,Date_format(fecha,'%d/%M/%y %H:%m:%s'),tipo FROM venta " +
                              "WHERE id_venta =" + idv;
            string ConsutaDet = "SELECT Concat(p.nombre,' - ',e.estilo,' - ',t.tipo,' - ',c.color,' - ',p.talla) AS nombre,vd.cantidad,vd.precio,vd.total,p.id_prod "+
                                "FROM venta_detalle vd "+
                                "INNER JOIN producto p ON p.ID_PROD = vd.ID_PROD "+
                                "INNER JOIN estilo e ON e.ID_ESTILO = p.ID_ESTILO "+
                                "INNER JOIN tipo t ON t.ID_TIPO = p.ID_TIPO " +
                                "INNER JOIN color c ON c.ID_COLOR = p.ID_COLOR "+
                                "WHERE vd.ID_VENTA = "+idv;
            venta = buscar(consultaV);
            detalle = buscar(ConsutaDet);
            int cant, cont;
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
                Deta.descripcion = detalle.Rows[cont][0].ToString() ;
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

        public void Ganacia(string Fechai, string fechaf)
        {
            Reportes.GanaciaEnc Enca = new Reportes.GanaciaEnc();
            DataTable datos = new DataTable();
            Fechai = Fechai + " 00:00:00";
            fechaf = fechaf + " 23:59:59";
            string Consulta= "SELECT DATE_FORMAT(v.fecha,'%Y/%m/%d') AS Fecha1, DATE_FORMAT(v.fecha,'%d/%m/%Y') AS Fecha2 "+
                              "FROM venta v "+
                              "WHERE v.FECHA >= '"+Fechai+"' AND fecha <= '"+fechaf+ "' and estado!='Anulado' and estado!='Retorno' " +
                              "GROUP BY Fecha1";
            datos = buscar(Consulta);
            int cant, cont;
            Enca.Titulo = "Reporte de ganancias";
            cant = datos.Rows.Count;
            Enca.FechaI = Fechai;
            Enca.FechaF = fechaf;
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.GanaciaDet deta = new Reportes.GanaciaDet();
                decimal costo, Ganacia, vendido;
                string fecha=datos.Rows[cont][0].ToString();
                costo = costoVenta(fecha);
                vendido = vendidoTot(fecha);
                Ganacia = vendido - costo;
                deta.Fecha = datos.Rows[cont][1].ToString();
                deta.Totalcosto = costo;
                deta.TotalGan = Ganacia;
                deta.TotalGene = vendido;
                Enca.Detalle.Add(deta);
            }
            Reportes.Ganancia formu = new Reportes.Ganancia();
            formu.Encabezado.Add(Enca);
            formu.Detalle = Enca.Detalle;
            formu.Show();

        }

        private decimal costoVenta(string fecha)
        {
            string fechai, fechaf;
            fechai = fecha + " 00:00:00";
            fechaf = fecha + " 23:59:59";
            DataTable datos = new DataTable();
            string consulta = "SELECT vd.id_prod, vd.cantidad, p.Precio_cost " +
                             "FROM venta_detalle vd " +
                             "INNER JOIN producto p ON p.ID_PROD = vd.ID_PROD " +
                             "INNER JOIN venta v ON v.ID_VENTA = vd.ID_VENTA " +
                             "WHERE v.Fecha>='"+fechai+"' and v.fecha<='"+fechaf+ "' and estado!='Anulado' and estado!='Retorno' " +
                             "GROUP BY vd.ID_DETALLE";
            datos = buscar(consulta);
            decimal total = 0;
            int cont, cant;
            cant = datos.Rows.Count;
            for (cont = 0; cont < cant; cont++)
            {
                total += (decimal.Parse(datos.Rows[cont][1].ToString()) * decimal.Parse(datos.Rows[cont][2].ToString()));
            }
            return total;
        }

        private decimal vendidoTot(string fecha)
        {
            string fechai, fechaf;
            fechai = fecha + " 00:00:00";
            fechaf = fecha + " 23:59:59";
            DataTable datos = new DataTable();
            string consulta = "SELECT SUM(vd.TOTAL) " +
                              "FROM venta_detalle vd " +
                              "INNER JOIN producto p ON p.ID_PROD = vd.ID_PROD " +
                              "INNER JOIN venta v ON v.ID_VENTA = vd.ID_VENTA " +
                              "WHERE v.FECHA >= '"+fechai+"' AND v.fecha <= '"+fechaf+ "' and estado!='Anulado' and estado!='Retorno'  " +
                              "GROUP BY v.FECHA";
            datos = buscar(consulta);
            decimal total = 0;
            int cont, cant;
            cant = datos.Rows.Count;
            for (cont = 0; cont < cant; cont++)
            {
                total += (decimal.Parse(datos.Rows[cont][0].ToString()));
            }
            return total;
        }
    }
}
