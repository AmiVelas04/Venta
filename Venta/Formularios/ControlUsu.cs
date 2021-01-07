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
    public partial class ControlUsu : Form
    {
        Clases.Usuario usu = new Clases.Usuario();
        public ControlUsu()
        {
            InitializeComponent();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = usu.bucarusucod(CboUsu.SelectedValue.ToString());
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos que modficar");

            }
            else
            {
                LblId.Text = dt.Rows[0][0].ToString();
                TxtNom.Text = dt.Rows[0][1].ToString();
                TxtUsu.Text = dt.Rows[0][2].ToString();
                if (dt.Rows[0][4].ToString() == "2") CboNivel.SelectedIndex = 0;
                if (dt.Rows[0][4].ToString() == "3") CboNivel.SelectedIndex = 1;


            }
        }

        private void editar()
        {
            DataTable dt = new DataTable();
            dt = usu.bucarusucod(CboUsu.SelectedValue.ToString());
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos que modficar");

            }
            else
            {
                LblId.Text = dt.Rows[0][0].ToString();
                TxtNom.Text = dt.Rows[0][1].ToString();
                TxtUsu.Text = dt.Rows[0][2].ToString();
                if (dt.Rows[0][4].ToString() == "2") CboNivel.SelectedIndex = 0;
                if (dt.Rows[0][4].ToString() == "3") CboNivel.SelectedIndex = 1;


            }
        }

        private void ingreso()
        {
            string nivel = "0";
            if (CboNivel.Text == "Administrador")
            { nivel = "1"; }
            else if (CboNivel.Text == "Gerente")
            { nivel = "2"; }
            else
            {
                nivel = "2";
            }
            string[] datos = { LblId.Text, TxtNom.Text, TxtUsu.Text, TxtPass2.Text, nivel };
            if (usu.existe(LblId.Text))
            {
                if (usu.updat(datos))
                {
                    MessageBox.Show("Datos actualizados correctamente");
                }
                else
                {
                    MessageBox.Show("Error al actualizar datos");
                }
            }
            else
            {

                if (usu.ingre(datos))
                {
                    MessageBox.Show("Datos ingresados correctamente");
                }
                else
                {
                    MessageBox.Show("Error al ingresar datos");
                }

            }
           limpiar();
        }

        private void limpiar()
        {
            TxtNom.Clear();
            TxtUsu.Clear();
            TxtPass1.Clear();
            TxtPass2.Clear();
            LblId.Text = "0";
        }
        private void ControlUsu_Load(object sender, EventArgs e)
        {
            CboNivel.Items.Add("Administrador");
            CboNivel.Items.Add("Gerente");
            CboNivel.Items.Add("Vendedor");
            CboNivel.SelectedIndex = 0;

            DataTable dt = new DataTable();
            dt = usu.bucarusu();
            int total = dt.Rows.Count;
            //   int cont;
            CboUsu.Items.Clear();
            CboUsu.DataSource = dt;
            CboUsu.DisplayMember = "nombre";
            CboUsu.ValueMember = "Id_vendedor";
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (TxtPass1.Text == TxtPass2.Text) { ingreso(); }

            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                TxtPass2.Clear();
                TxtPass1.Clear();
            }
        }

    }
}
