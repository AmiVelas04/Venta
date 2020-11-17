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
    public partial class Login : Form
    {
        Clases.Login log = new Clases.Login();

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loguear();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Fecha y hora" + DateTime.Now.ToString("dd/MM/yyyy H:m:s"));
            TxtUsu.Focus();
        }

        private void loguear()
        {
            DataTable datos = new DataTable();
            datos = log.Logueo(TxtUsu.Text, TxtPass.Text);
            if (datos.Rows.Count > 0)
            {
                if (datos.Rows[0][2].ToString() == TxtUsu.Text && datos.Rows[0][3].ToString() == TxtPass.Text)
                {
                   // MessageBox.Show("Ingreso Correcto", "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Formularios.Main inicio = new Formularios.Main();

                    Main.idvende = datos.Rows[0][0].ToString();
                    Main.nombrev = datos.Rows[0][1].ToString();
                    Main.nivel = datos.Rows[0][4].ToString();
                    inicio.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPass.Clear();
                    TxtUsu.Clear();
                    TxtUsu.Focus();
                }
            }
            else
            {
                MessageBox.Show("Error de inicio de sesion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtPass.Clear();
                TxtUsu.Clear();
                TxtUsu.Focus();
            }
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                loguear();
            }
        }
    }
}
