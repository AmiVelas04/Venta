using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta.Formularios
{
    public partial class Creditos : Form
    {
        Clases.Clientes cli = new Clases.Clientes();
        Clases.Credito cre = new Clases.Credito();
        
        public Creditos()
        {
            InitializeComponent();
        }

        private void Creditos_Load(object sender, EventArgs e)
        {
            Llenarcli();
            CboTipop.SelectedIndex = 0;
        }



        private void Llenarcli()
        {
            DataTable datos = new DataTable();
            datos = cli.clienSin();
            CboCli.DataSource = datos;
            CboCli.DisplayMember = "nombre";
            CboCli.ValueMember = "id_cliente";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            foreach (DataRow row in datos.Rows)
            { coleccion.Add(row["nombre"].ToString());
            }
            CboCli.AutoCompleteCustomSource = coleccion;
            CboCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboCli.AutoCompleteSource = AutoCompleteSource.CustomSource;
            if (datos.Rows.Count >0)  CboCli.SelectedIndex = 0;
        }

        private void CboCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboCli.Text != "" && CboCli.SelectedValue.ToString() != "System.Data.DataRowView")
            { buscardata(CboCli.SelectedValue.ToString()); }
            else
            { }
        }

        private void buscardata(string idcli)
        {
            DataTable datos = new DataTable();
            datos = cli.buscli(CboCli.SelectedValue.ToString());
            TxtDir.Text = datos.Rows[0][0].ToString();
            TxtNit.Text = datos.Rows[0][1].ToString();
            TxtTel.Text = datos.Rows[0][4].ToString();
            TxtDpi.Text = datos.Rows[0][5].ToString();
            buscarcredi(idcli);
        }

        private void buscarcredi(string idC)
        {
            DataTable datos = new DataTable();
            datos = cre.BusCred(idC);
            CboCred.DataSource = datos;
            CboCred.DisplayMember = "id_credito";
            CboCred.ValueMember = "id_credito";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            foreach (DataRow row in datos.Rows)
            {
                coleccion.Add(row["id_credito"].ToString());
            }
            CboCred.AutoCompleteCustomSource = coleccion;
            CboCred.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboCred.AutoCompleteSource = AutoCompleteSource.CustomSource;
            if (CboCred.Items.Count>0)CboCred.SelectedIndex = 0;
        }

        private void CboCred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboCred.Text != "" && CboCred.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                DataCred(CboCred.SelectedValue.ToString());
                BtnPago.Enabled = true;
            }
        }

        private void DataCred(string cred)
        {
            DataTable saldo = new DataTable();
            saldo = cre.saldos(cred);
            decimal sald=0, monto=0, anti=0, ante=0;
            if (saldo.Rows[0][0] != DBNull.Value) sald = decimal.Parse(saldo.Rows[0][0].ToString());
            if (saldo.Rows[0][1] != DBNull.Value) anti = decimal.Parse(saldo.Rows[0][1].ToString());
            if (saldo.Rows[0][2] != DBNull.Value) monto = decimal.Parse(saldo.Rows[0][2].ToString());
            if (saldo.Rows[0][3] != DBNull.Value) ante = decimal.Parse(saldo.Rows[0][3].ToString());
            TxtTot.Text = monto.ToString();
            TxtSaldo.Text = Convert .ToString (monto - sald+ante);
            TxtAnte.Text = ante.ToString();
            pagoslst(cred);

        }

        private void pagoslst(string cred)
        {
            DataTable datos = new DataTable();
            datos = cre.pagos(cred);
            LblDet.DataSource = datos;
        }

        private void BtnPago_Click(object sender, EventArgs e)
        {
            pago();
            BtnPago.Enabled = false;
            DataCred(CboCred.SelectedValue.ToString());
            TxtPago.Clear();
        }

        private void pago()
        {
            string pago = "0";
            string detallepago;
            if (CboTipop.SelectedIndex == 0)
            {
                detallepago = "";
            }
            else
            {
                detallepago = TxtPagoDet.Text;
            }
           
            if (TxtPago.Text != "") { pago = TxtPago.Text; }
            string[] datos = new string[5];
            datos[0] = CboCred.SelectedValue.ToString();
            datos[1] = pago;
            datos[2] = "Abono a Credito " + detallepago ;
            datos[3] = DateTime.Now.ToString("yyyy/MM/dd");
            datos[4] =Main.idvende;
            if (cre.RegPago(datos))
            {
                MessageBox.Show("Pago Registrado"); }
            else
            { MessageBox.Show("Error en pago"); }

        }

        private void BtnReImp_Click(object sender, EventArgs e)
        {
            if (LblDet.Rows.Count > 0) {
                reimprimir();
            }
        }
        private void reimprimir()
        {
            int indice = LblDet.CurrentRow.Index,idpago=0;
            string credito, monto, detalle, fecha, opero;
            idpago = int.Parse(LblDet.Rows[indice].Cells[0].Value.ToString());
            credito = LblDet.Rows[indice].Cells[1].Value.ToString();
            monto = LblDet.Rows[indice].Cells[2].Value.ToString();
            detalle = LblDet.Rows[indice].Cells[3].Value.ToString();
            fecha = LblDet.Rows[indice].Cells[4].Value.ToString();
            opero = LblDet.Rows[indice].Cells[5].Value.ToString();
            string[] datos = { credito,monto,detalle,fecha,opero};
            cre.ReImp(idpago, datos);
        }

        private void CboTipop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboTipop.SelectedIndex == 0)
            {
                LblDet.Visible = false;
                TxtPagoDet.Visible = false;
            }
            else
            {
                LblDet.Visible = true;
                TxtPagoDet.Visible = true;
            }
        }
    }
}
