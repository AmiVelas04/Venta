using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta.SubForms
{
    public partial class VentaSalvarTemp : Form
    {
        public delegate void permiso(string vent);
        public event permiso Cargar;
        private Clases.Venta ven = new Clases.Venta();
        private DataTable produs = new DataTable();
        public string vende { get; set; }
        public string ope { get; set; }
        public VentaSalvarTemp()
        {
            InitializeComponent();
        }

        private void VentaSalvarTemp_Load(object sender, EventArgs e)
        {
            cargarventas();
            if (ope.Equals("Guardar"))
            {
                BtnSave.Visible = true;
                BtnCarga.Visible = false;
            }
            else
            {
                BtnSave.Visible = false;
                BtnCarga.Visible = true;
            }
        }

        

        private void cargarventas()
        {
            TextBox[] venta = { TxtV1, TxtV2, TxtV3, TxtV4, TxtV5 };
            TextBox[] vende = { TxtNom1, TxtNom2, TxtNom3, TxtNom4, TxtNom5 };
            TextBox[] fecha = { TxtDate1, TxtDate2, TxtDate3, TxtDate4, TxtDate5 };
            TextBox[] Total = { TxtTot1, TxtTot2, TxtTot3, TxtTot4, TxtTot5 };
            RadioButton[] boton = { RdbCarga1, RdbCarga2, RdbCarga3, RdbCarga4, RdbCarga5 };
            Button[] Del = { BtnDel1, BtnDel2, BtnDel3, BtnDel4, BtnDel5 };
            DataTable datos = new DataTable();
            datos = ven.BuscaTemp();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                venta[i].Text = datos.Rows[i][0].ToString();

                if (datos.Rows[i][2].Equals("Libre") && ope.Equals("Guardar"))
                {
                    boton[i].Enabled = true;
                    Del[i].Enabled = false;
                    vende[i].Text = "Disponible";
                    fecha[i].Text = "Disponible";
                    Total[i].Text = "Disponible";
                }
                else if (datos.Rows[i][2].Equals("Libre") && ope.Equals("Cargar"))
                {
                    Del[i].Enabled = false;
                    boton[i].Enabled = false;
                    vende[i].Text = "Sin registro";
                    fecha[i].Text = "Sin registro";
                    Total[i].Text = "Sin registro";
                }
                else if (datos.Rows[i][2].Equals("Guardado") && ope.Equals("Guardar"))
                {
                    Del[i].Enabled = true;
                    boton[i].Enabled = false;
                    string indice = (i + 1).ToString();
                    fecha[i].Text = datos.Rows[i][3].ToString();
                    Total[i].Text = ven.TotalTempVen(indice).ToString();
                }
                else
                {
                    Del[i].Enabled = false;
                    boton[i].Enabled = true;
                    string indice = (i + 1).ToString();
                    vende[i].Text = datos.Rows[i][1].ToString();
                    fecha[i].Text = datos.Rows[i][3].ToString();
                    Total[i].Text = ven.TotalTempVen(indice).ToString();
                   
                }
            }
        }

        private string selectedventa()
        {
            if (RdbCarga1.Checked)
            {
                return TxtV1.Text;
            }
            else if (RdbCarga2.Checked)
            { return TxtV2.Text; }
            else if (RdbCarga3.Checked)
            { return TxtV3.Text; }
            else if (RdbCarga4.Checked)
            { return TxtV4.Text; }
            else if (RdbCarga5.Checked)
            { return TxtV5.Text; }
            return "";
        }

        public void CargarProds(DataTable prod)
        {
            produs = prod;
        }

        private void CargarVenta()
        {
            DataTable datos = new DataTable();
            string venta = selectedventa();
            Cargar(venta);
        }


      

        private void liberar(string cod)
        {
            if (ven.Liberar(cod) && ven.ElimDeta(cod))
            {
                MessageBox.Show("La venta seleccionada se eliminó", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarventas();
            }
            else
            {
                MessageBox.Show("La venta seleccionada no pudo eliminarse", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        #region Borrar
        private void BtnDel1_Click(object sender, EventArgs e)
        {
            liberar("1");
        }

        private void BtnDel2_Click(object sender, EventArgs e)
        {
            liberar("2");
        }

        private void BtnDel3_Click(object sender, EventArgs e)
        {
            liberar("3");
        }

        private void BtnDel4_Click(object sender, EventArgs e)
        {
            liberar("4");
        }

        private void BtnDel5_Click(object sender, EventArgs e)
        {
            liberar("5");
        }

        #endregion

        private void BtnCarga_Click(object sender, EventArgs e)
        {
            Cargar(selectedventa());
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ven.Venta_Temp(selectedventa(), vende, produs))
            {
                MessageBox.Show("La venta ha sido almacenada temporalmente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarventas();
                //liberar(selectedventa());
            }
            else
            {
                MessageBox.Show("No se ha podido alamcenar venta temporal", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
