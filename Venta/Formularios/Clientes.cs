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
            Dgv1.Columns[0].Visible = false;

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
            BtnGuardar.Text = "Guardar";
            TxtNom.Tag="0";
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtNom.Tag.ToString() == "0")
            { ingresarcli(); }
            else
            { editarcli(); }
            
            limpiar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (Dgv1.Rows.Count > 0)
            { BtnGuardar.Text = "Actualizar";
                editar();
            }
        }
        private void editar()
            {
            int indice = Dgv1.CurrentRow.Index;
            TxtNom.Tag = Dgv1.Rows[indice].Cells[0].Value.ToString();
            TxtNom .Text= Dgv1.Rows[indice].Cells[1].Value.ToString();
            TxtDir.Text = Dgv1.Rows[indice].Cells[2].Value.ToString();
            TxtNit.Text = Dgv1.Rows[indice].Cells[3].Value.ToString();
            TxtDpi.Text = Dgv1.Rows[indice].Cells[5].Value.ToString();
            TxtTel.Text = Dgv1.Rows[indice].Cells[4].Value.ToString();
            TxtCre.Text = Dgv1.Rows[indice].Cells[6].Value.ToString();
        }

        private void editarcli()
        {
            string nombre, dir, nit, dpi, tel, cre;
            nombre = TxtNom.Text;
            dir = TxtDir.Text;
            nit = TxtNit.Text;
            dpi = TxtDpi.Text;
            tel = TxtTel.Text;
            cre = TxtCre.Text;
            string[] datos = { nombre, dir, nit, dpi, tel, cre };
            if (cli.Actucli(datos))
            {
                MessageBox.Show("Cliente Actualizado correctamente");
            }
            else { MessageBox.Show("Error al actualizar cliente"); }
        }
    }
}
