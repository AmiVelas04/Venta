using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TmrInicio_Tick(object sender, EventArgs e)
        {
            Formularios.Login logueo = new Formularios.Login();
            TmrInicio.Enabled = false;
            logueo .Show();
            this .Hide();
        }
    }
}
