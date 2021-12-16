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
       
        private void AyudaControles()
        {
         HelpProvider AyudaBot = new HelpProvider();
            AyudaBot.SetShowHelp(BtnCompro,true);
            AyudaBot.SetHelpString(BtnCompro,"Imprimir Comprobante de credito");
        }
        
        public Creditos()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.BtnPagH, "Este boton muestra Todos los pagos realizados por este cliente a su cuenta general");
        }

        private void Creditos_Load(object sender, EventArgs e)
        {
            Llenarcli();
            AyudaControles();
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
            { buscardata(CboCli.SelectedValue.ToString());
                buscarComproAnte(CboCli.SelectedValue.ToString());
                BtnPagH.Enabled = true;
            }
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
        private void buscarComproAnte(string idcli)
        {
            DataTable datos = new DataTable();
            datos = cre.ultimos3cred(idcli);
            CboCompAnte.DataSource = datos;
            CboCompAnte.DisplayMember = "fecha";
            CboCompAnte.ValueMember = "id";

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
            decimal sald=0, monto=0, anti=0, ante=0,gasto=0;
            if (saldo.Rows[0][0] != DBNull.Value) sald = decimal.Parse(saldo.Rows[0][0].ToString());
            if (saldo.Rows[0][1] != DBNull.Value) anti = decimal.Parse(saldo.Rows[0][1].ToString());
            if (saldo.Rows[0][2] != DBNull.Value) monto = decimal.Parse(saldo.Rows[0][2].ToString());
            if (saldo.Rows[0][3] != DBNull.Value) ante = decimal.Parse(saldo.Rows[0][3].ToString());
            if (saldo.Rows[0][4] != DBNull.Value) gasto = decimal.Parse(saldo.Rows[0][4].ToString());

            TxtTot.Text = monto.ToString();
            TxtSaldo.Text = Convert .ToString (monto+gasto+ante - (sald));
            TxtAnte.Text = ante.ToString();
            TxtGast.Text = gasto.ToString();
            pagoslst(cred);

        }

        private void pagoslst(string cred)
        {
            DataTable datos = new DataTable();
            datos = cre.pagos(cred);
            DgvPagos.DataSource = datos;
        }

        private void BtnPago_Click(object sender, EventArgs e)
        {
            pago();
            BtnPago.Enabled = false;
            DataCred(CboCred.SelectedValue.ToString());
            
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
                MessageBox.Show("Pago Registrado");
                TxtPago.Clear();
                TxtPagoDet.Clear();
                TxtPagoDet.Visible = false;
                LblDet.Visible = false;
            }
            else
            { MessageBox.Show("Error en pago"); }

        }

        private void BtnReImp_Click(object sender, EventArgs e)
        {
            if (DgvPagos.Rows.Count > 0) {
                reimprimir();
            }
        }
        private void reimprimir()
        {
            int indice = DgvPagos.CurrentRow.Index,idpago=0;
            string credito, monto, detalle, fecha, opero;
            idpago = int.Parse(DgvPagos.Rows[indice].Cells[0].Value.ToString());
            credito = DgvPagos.Rows[indice].Cells[1].Value.ToString();
            monto = DgvPagos.Rows[indice].Cells[2].Value.ToString();
            detalle = DgvPagos.Rows[indice].Cells[3].Value.ToString();
            fecha = DgvPagos.Rows[indice].Cells[4].Value.ToString();
            opero = DgvPagos.Rows[indice].Cells[5].Value.ToString();
            string[] datos = { credito,monto,detalle,fecha,opero};
            cre.ReImp(idpago, datos);
        }

        private void CboTipop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboTipop.SelectedIndex == 0)
            {
               LblDet.Visible = false;
                TxtPagoDet.Visible = false;
                TxtPagoDet.Clear();
            }
            else
            {
                LblDet.Visible = true;
                TxtPagoDet.Visible = true;
            }
        }

        private void TxtGast_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void TxtGast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string cod = CboCred.SelectedValue.ToString();
                string monto=TxtGast.Text;
                if (TxtGast.Text == "") monto ="0";

                if (cre.ingresogasto(cod, monto))
                { MessageBox.Show("Gasto Ingresado Correctamente");
                    DataCred(cod);
                }
                else
                { MessageBox.Show("Error en ingreso de gasto"); }
                
            }
        }

        private void ChkEditar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkEditar.Checked)
            {
                TxtGast.Enabled = true;
            }
            else
            {
                TxtGast.Enabled = false;
            }
        }

       private void ReimpCompro()
      {
           
        }

        private void BtnCompro_Click(object sender, EventArgs e)
        {
            cre.reimpCompro(CboCred.Text,"Vendiendo");
            
        }

        private void BtnAnte_Click(object sender, EventArgs e)
        {
            if (CboCompAnte.Text != "" && CboCred.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                cre.reimpCompro2(CboCompAnte.SelectedValue.ToString());
                //BtnPago.Enabled = true;
            }
        }

        private void BtnPagH_Click(object sender, EventArgs e)
        {
            if (CboCli.Text != "" && CboCli.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                cre.ReportePagos(CboCli.SelectedValue.ToString());
            }
        }
    }
}
