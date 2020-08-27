using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Venta.Formularios
{
    public partial class ImagenPic : Form
    {
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public static string ponerimg { get; set; }
        public ImagenPic()
        {
            InitializeComponent();
        }

        private void ImagenPic_Load(object sender, EventArgs e)
        {
           // LblCerrar.Parent = panel1;
            LblCerrar.BackColor = Color.FromArgb(1, Color.Blue);
            PcbImagen.Image = Image.FromFile(ponerimg);
        }

        private void PcbImagen_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       
        private void LblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
