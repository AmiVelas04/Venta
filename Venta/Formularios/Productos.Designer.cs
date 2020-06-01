namespace Venta.Formularios
{
    partial class Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnImagen = new System.Windows.Forms.Button();
            this.TxtPrecio_V = new System.Windows.Forms.TextBox();
            this.TxtPrecio_M = new System.Windows.Forms.TextBox();
            this.TxtPrecio_C = new System.Windows.Forms.TextBox();
            this.NudCantidad = new System.Windows.Forms.NumericUpDown();
            this.TxtTalla = new System.Windows.Forms.TextBox();
            this.CboColor = new System.Windows.Forms.ComboBox();
            this.CboTipo = new System.Windows.Forms.ComboBox();
            this.CboEstilo = new System.Windows.Forms.ComboBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblNomProd = new System.Windows.Forms.Label();
            this.TxtProdNom = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PbxProd = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtBuscNom = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxProd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnAdd);
            this.panel1.Controls.Add(this.PbxProd);
            this.panel1.Controls.Add(this.BtnImagen);
            this.panel1.Controls.Add(this.TxtPrecio_V);
            this.panel1.Controls.Add(this.TxtPrecio_M);
            this.panel1.Controls.Add(this.TxtPrecio_C);
            this.panel1.Controls.Add(this.NudCantidad);
            this.panel1.Controls.Add(this.TxtTalla);
            this.panel1.Controls.Add(this.CboColor);
            this.panel1.Controls.Add(this.CboTipo);
            this.panel1.Controls.Add(this.CboEstilo);
            this.panel1.Controls.Add(this.BtnGuardar);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LblNomProd);
            this.panel1.Controls.Add(this.TxtProdNom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(830, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 590);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BtnImagen
            // 
            this.BtnImagen.Location = new System.Drawing.Point(109, 512);
            this.BtnImagen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnImagen.Name = "BtnImagen";
            this.BtnImagen.Size = new System.Drawing.Size(54, 27);
            this.BtnImagen.TabIndex = 20;
            this.BtnImagen.Text = "Subir";
            this.BtnImagen.UseVisualStyleBackColor = true;
            this.BtnImagen.Click += new System.EventHandler(this.BtnImagen_Click);
            // 
            // TxtPrecio_V
            // 
            this.TxtPrecio_V.Location = new System.Drawing.Point(27, 472);
            this.TxtPrecio_V.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtPrecio_V.Name = "TxtPrecio_V";
            this.TxtPrecio_V.Size = new System.Drawing.Size(149, 23);
            this.TxtPrecio_V.TabIndex = 19;
            this.TxtPrecio_V.Text = "0";
            // 
            // TxtPrecio_M
            // 
            this.TxtPrecio_M.Location = new System.Drawing.Point(27, 414);
            this.TxtPrecio_M.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtPrecio_M.Name = "TxtPrecio_M";
            this.TxtPrecio_M.Size = new System.Drawing.Size(148, 23);
            this.TxtPrecio_M.TabIndex = 18;
            this.TxtPrecio_M.Text = "0";
            // 
            // TxtPrecio_C
            // 
            this.TxtPrecio_C.Location = new System.Drawing.Point(18, 356);
            this.TxtPrecio_C.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtPrecio_C.Name = "TxtPrecio_C";
            this.TxtPrecio_C.Size = new System.Drawing.Size(158, 23);
            this.TxtPrecio_C.TabIndex = 17;
            this.TxtPrecio_C.Text = "0";
            // 
            // NudCantidad
            // 
            this.NudCantidad.Location = new System.Drawing.Point(27, 300);
            this.NudCantidad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NudCantidad.Name = "NudCantidad";
            this.NudCantidad.Size = new System.Drawing.Size(114, 23);
            this.NudCantidad.TabIndex = 16;
            this.NudCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtTalla
            // 
            this.TxtTalla.Location = new System.Drawing.Point(27, 246);
            this.TxtTalla.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtTalla.Name = "TxtTalla";
            this.TxtTalla.Size = new System.Drawing.Size(114, 23);
            this.TxtTalla.TabIndex = 15;
            // 
            // CboColor
            // 
            this.CboColor.FormattingEnabled = true;
            this.CboColor.Location = new System.Drawing.Point(27, 190);
            this.CboColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CboColor.Name = "CboColor";
            this.CboColor.Size = new System.Drawing.Size(180, 23);
            this.CboColor.TabIndex = 14;
            // 
            // CboTipo
            // 
            this.CboTipo.FormattingEnabled = true;
            this.CboTipo.Location = new System.Drawing.Point(27, 134);
            this.CboTipo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CboTipo.Name = "CboTipo";
            this.CboTipo.Size = new System.Drawing.Size(180, 23);
            this.CboTipo.TabIndex = 13;
            // 
            // CboEstilo
            // 
            this.CboEstilo.FormattingEnabled = true;
            this.CboEstilo.Location = new System.Drawing.Point(27, 81);
            this.CboEstilo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CboEstilo.Name = "CboEstilo";
            this.CboEstilo.Size = new System.Drawing.Size(180, 23);
            this.CboEstilo.TabIndex = 12;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnGuardar.Location = new System.Drawing.Point(0, 545);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(300, 45);
            this.BtnGuardar.TabIndex = 11;
            this.BtnGuardar.Text = "Agregar producto";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 518);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Imagen";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 453);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Precio de Venta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 395);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Precio Mayorista";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 338);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Precio de costo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 281);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 228);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Talla";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estilo";
            // 
            // LblNomProd
            // 
            this.LblNomProd.AutoSize = true;
            this.LblNomProd.Location = new System.Drawing.Point(35, 10);
            this.LblNomProd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNomProd.Name = "LblNomProd";
            this.LblNomProd.Size = new System.Drawing.Size(140, 15);
            this.LblNomProd.TabIndex = 1;
            this.LblNomProd.Text = "Nombre del producto";
            // 
            // TxtProdNom
            // 
            this.TxtProdNom.Location = new System.Drawing.Point(27, 29);
            this.TxtProdNom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtProdNom.Name = "TxtProdNom";
            this.TxtProdNom.Size = new System.Drawing.Size(241, 23);
            this.TxtProdNom.TabIndex = 0;
            this.TxtProdNom.TextChanged += new System.EventHandler(this.TxtProdNom_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnEditar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 518);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 72);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnBuscar);
            this.panel3.Controls.Add(this.TxtBuscNom);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(830, 91);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 91);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(830, 427);
            this.dataGridView1.TabIndex = 3;
            // 
            // PbxProd
            // 
            this.PbxProd.Location = new System.Drawing.Point(211, 472);
            this.PbxProd.Name = "PbxProd";
            this.PbxProd.Size = new System.Drawing.Size(76, 67);
            this.PbxProd.TabIndex = 21;
            this.PbxProd.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Buscar Producto";
            // 
            // TxtBuscNom
            // 
            this.TxtBuscNom.Location = new System.Drawing.Point(47, 34);
            this.TxtBuscNom.Name = "TxtBuscNom";
            this.TxtBuscNom.Size = new System.Drawing.Size(442, 23);
            this.TxtBuscNom.TabIndex = 1;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(528, 34);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 23);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(12, 18);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(102, 42);
            this.BtnEditar.TabIndex = 0;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(268, 29);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(29, 23);
            this.BtnAdd.TabIndex = 22;
            this.BtnAdd.Text = "+";
            this.BtnAdd.UseVisualStyleBackColor = true;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 590);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Productos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox TxtProdNom;
        private System.Windows.Forms.Label LblNomProd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnImagen;
        private System.Windows.Forms.TextBox TxtPrecio_V;
        private System.Windows.Forms.TextBox TxtPrecio_M;
        private System.Windows.Forms.TextBox TxtPrecio_C;
        private System.Windows.Forms.NumericUpDown NudCantidad;
        private System.Windows.Forms.TextBox TxtTalla;
        private System.Windows.Forms.ComboBox CboColor;
        private System.Windows.Forms.ComboBox CboTipo;
        private System.Windows.Forms.ComboBox CboEstilo;
        private System.Windows.Forms.PictureBox PbxProd;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBuscNom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnAdd;
    }
}