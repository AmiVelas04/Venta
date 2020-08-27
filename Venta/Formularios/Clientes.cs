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
    public partial class Clientes : Form
    {
        Clases.Clientes cli = new Clases.Clientes();
        public Clientes()
        {
            InitializeComponent();
        }

       
        private void ingresarcli()
        {
            string nombre, dir, nit, dpi, tel,cre;
            nombre = TxtNom.Text;
            dir = TxtDir.Text;
            nit = TxtNit.Text;
            dpi = TxtDpi.Text;
            tel = TxtTel.Text;
            cre = TxtCre.Text;
            string[] datos = {nombre,dir,nit,dpi,tel,cre};
            if (cli.ingrecli(datos))
            {
                MessageBox.Show("Cliente ingresado correctamente");
            }
            else { MessageBox.Show("Error en ingreso de cliente"); }
        }

        private void TxtCliNom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                buscarcli();
            }
        }

        private void buscarcli()
        {
            DataTable datos = new DataTable();
            datos = cli.Nomcliente(TxtCliNom.Text);
            Dgv1.DataSource = datos;
            Dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            TxtNom.Clear();
            TxtCre.Clear();
            TxtDir.Clear();
            TxtDpi.Clear();
            TxtTel.Clear();
            TxtNit.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ingresarcli();
            limpiar();
        }
    }
}
