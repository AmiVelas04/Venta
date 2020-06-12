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
        public Creditos()
        {
            InitializeComponent();
        }

        private void Creditos_Load(object sender, EventArgs e)
        {
            Llenarcli();
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
            {  coleccion.Add(row["nombre"].ToString());
            }
            CboCli.AutoCompleteCustomSource = coleccion;
            CboCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboCli.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboCli.SelectedIndex = 0;
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
            //buscarcredi(idcli);

        }

        private void buscarcredi(string idC)
        {

        }
    }
}
