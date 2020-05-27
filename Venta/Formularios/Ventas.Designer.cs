namespace Venta.Formularios
{
    partial class Ventas
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
            this.PanData = new System.Windows.Forms.Panel();
            this.Gbx2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnAgr = new System.Windows.Forms.Button();
            this.NudCant = new System.Windows.Forms.NumericUpDown();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.CboProd = new System.Windows.Forms.ComboBox();
            this.Gbx1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCredito = new System.Windows.Forms.TextBox();
            this.TxtNit = new System.Windows.Forms.TextBox();
            this.TxtDirCli = new System.Windows.Forms.TextBox();
            this.CboNomCli = new System.Windows.Forms.ComboBox();
            this.PanCentral = new System.Windows.Forms.Panel();
            this.DgvProd = new System.Windows.Forms.DataGridView();
            this.PanAbajo = new System.Windows.Forms.Panel();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.RdbConce = new System.Windows.Forms.RadioButton();
            this.RdbCredito = new System.Windows.Forms.RadioButton();
            this.RdbContado = new System.Windows.Forms.RadioButton();
            this.Cancelar = new System.Windows.Forms.Button();
            this.BtnGenVen = new System.Windows.Forms.Button();
            this.PanArriba = new System.Windows.Forms.Panel();
            this.PanData.SuspendLayout();
            this.Gbx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCant)).BeginInit();
            this.Gbx1.SuspendLayout();
            this.PanCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProd)).BeginInit();
            this.PanAbajo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanData
            // 
            this.PanData.Controls.Add(this.Gbx2);
            this.PanData.Controls.Add(this.Gbx1);
            this.PanData.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanData.Location = new System.Drawing.Point(0, 0);
            this.PanData.Name = "PanData";
            this.PanData.Size = new System.Drawing.Size(249, 629);
            this.PanData.TabIndex = 0;
            // 
            // Gbx2
            // 
            this.Gbx2.Controls.Add(this.label3);
            this.Gbx2.Controls.Add(this.label2);
            this.Gbx2.Controls.Add(this.label1);
            this.Gbx2.Controls.Add(this.pictureBox1);
            this.Gbx2.Controls.Add(this.BtnAgr);
            this.Gbx2.Controls.Add(this.NudCant);
            this.Gbx2.Controls.Add(this.TxtPrecio);
            this.Gbx2.Controls.Add(this.CboProd);
            this.Gbx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gbx2.Location = new System.Drawing.Point(0, 195);
            this.Gbx2.Name = "Gbx2";
            this.Gbx2.Size = new System.Drawing.Size(249, 434);
            this.Gbx2.TabIndex = 1;
            this.Gbx2.TabStop = false;
            this.Gbx2.Text = "Producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cantidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Precio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre del producto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 268);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 121);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // BtnAgr
            // 
            this.BtnAgr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnAgr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgr.Location = new System.Drawing.Point(3, 389);
            this.BtnAgr.Name = "BtnAgr";
            this.BtnAgr.Size = new System.Drawing.Size(243, 42);
            this.BtnAgr.TabIndex = 4;
            this.BtnAgr.Text = "Agregar producto";
            this.BtnAgr.UseVisualStyleBackColor = true;
            // 
            // NudCant
            // 
            this.NudCant.Location = new System.Drawing.Point(160, 80);
            this.NudCant.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.NudCant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudCant.Name = "NudCant";
            this.NudCant.Size = new System.Drawing.Size(74, 20);
            this.NudCant.TabIndex = 2;
            this.NudCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(16, 79);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(100, 20);
            this.TxtPrecio.TabIndex = 1;
            // 
            // CboProd
            // 
            this.CboProd.FormattingEnabled = true;
            this.CboProd.Location = new System.Drawing.Point(16, 39);
            this.CboProd.Name = "CboProd";
            this.CboProd.Size = new System.Drawing.Size(218, 21);
            this.CboProd.TabIndex = 0;
            // 
            // Gbx1
            // 
            this.Gbx1.Controls.Add(this.label7);
            this.Gbx1.Controls.Add(this.label6);
            this.Gbx1.Controls.Add(this.label5);
            this.Gbx1.Controls.Add(this.label4);
            this.Gbx1.Controls.Add(this.TxtCredito);
            this.Gbx1.Controls.Add(this.TxtNit);
            this.Gbx1.Controls.Add(this.TxtDirCli);
            this.Gbx1.Controls.Add(this.CboNomCli);
            this.Gbx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Gbx1.Location = new System.Drawing.Point(0, 0);
            this.Gbx1.Name = "Gbx1";
            this.Gbx1.Size = new System.Drawing.Size(249, 195);
            this.Gbx1.TabIndex = 0;
            this.Gbx1.TabStop = false;
            this.Gbx1.Text = "Datos del cliente";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Credito";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Nit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Direccion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cliente";
            // 
            // TxtCredito
            // 
            this.TxtCredito.Location = new System.Drawing.Point(12, 158);
            this.TxtCredito.Name = "TxtCredito";
            this.TxtCredito.Size = new System.Drawing.Size(120, 20);
            this.TxtCredito.TabIndex = 3;
            // 
            // TxtNit
            // 
            this.TxtNit.Location = new System.Drawing.Point(12, 116);
            this.TxtNit.Name = "TxtNit";
            this.TxtNit.Size = new System.Drawing.Size(174, 20);
            this.TxtNit.TabIndex = 2;
            // 
            // TxtDirCli
            // 
            this.TxtDirCli.Location = new System.Drawing.Point(12, 74);
            this.TxtDirCli.Name = "TxtDirCli";
            this.TxtDirCli.Size = new System.Drawing.Size(174, 20);
            this.TxtDirCli.TabIndex = 1;
            // 
            // CboNomCli
            // 
            this.CboNomCli.FormattingEnabled = true;
            this.CboNomCli.Location = new System.Drawing.Point(12, 32);
            this.CboNomCli.Name = "CboNomCli";
            this.CboNomCli.Size = new System.Drawing.Size(174, 21);
            this.CboNomCli.TabIndex = 0;
            // 
            // PanCentral
            // 
            this.PanCentral.Controls.Add(this.DgvProd);
            this.PanCentral.Controls.Add(this.PanAbajo);
            this.PanCentral.Controls.Add(this.PanArriba);
            this.PanCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCentral.Location = new System.Drawing.Point(249, 0);
            this.PanCentral.Name = "PanCentral";
            this.PanCentral.Size = new System.Drawing.Size(897, 629);
            this.PanCentral.TabIndex = 1;
            // 
            // DgvProd
            // 
            this.DgvProd.AllowUserToAddRows = false;
            this.DgvProd.AllowUserToDeleteRows = false;
            this.DgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProd.Location = new System.Drawing.Point(0, 67);
            this.DgvProd.Name = "DgvProd";
            this.DgvProd.ReadOnly = true;
            this.DgvProd.Size = new System.Drawing.Size(897, 488);
            this.DgvProd.TabIndex = 2;
            // 
            // PanAbajo
            // 
            this.PanAbajo.Controls.Add(this.TxtTotal);
            this.PanAbajo.Controls.Add(this.RdbConce);
            this.PanAbajo.Controls.Add(this.RdbCredito);
            this.PanAbajo.Controls.Add(this.RdbContado);
            this.PanAbajo.Controls.Add(this.Cancelar);
            this.PanAbajo.Controls.Add(this.BtnGenVen);
            this.PanAbajo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanAbajo.Location = new System.Drawing.Point(0, 555);
            this.PanAbajo.Name = "PanAbajo";
            this.PanAbajo.Size = new System.Drawing.Size(897, 74);
            this.PanAbajo.TabIndex = 1;
            // 
            // TxtTotal
            // 
            this.TxtTotal.Location = new System.Drawing.Point(734, 7);
            this.TxtTotal.Multiline = true;
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(154, 60);
            this.TxtTotal.TabIndex = 5;
            // 
            // RdbConce
            // 
            this.RdbConce.AutoSize = true;
            this.RdbConce.Location = new System.Drawing.Point(631, 50);
            this.RdbConce.Name = "RdbConce";
            this.RdbConce.Size = new System.Drawing.Size(75, 17);
            this.RdbConce.TabIndex = 4;
            this.RdbConce.TabStop = true;
            this.RdbConce.Text = "Concesion";
            this.RdbConce.UseVisualStyleBackColor = true;
            // 
            // RdbCredito
            // 
            this.RdbCredito.AutoSize = true;
            this.RdbCredito.Location = new System.Drawing.Point(631, 29);
            this.RdbCredito.Name = "RdbCredito";
            this.RdbCredito.Size = new System.Drawing.Size(58, 17);
            this.RdbCredito.TabIndex = 3;
            this.RdbCredito.TabStop = true;
            this.RdbCredito.Text = "Credito";
            this.RdbCredito.UseVisualStyleBackColor = true;
            // 
            // RdbContado
            // 
            this.RdbContado.AutoSize = true;
            this.RdbContado.Location = new System.Drawing.Point(631, 6);
            this.RdbContado.Name = "RdbContado";
            this.RdbContado.Size = new System.Drawing.Size(65, 17);
            this.RdbContado.TabIndex = 2;
            this.RdbContado.TabStop = true;
            this.RdbContado.Text = "Contado";
            this.RdbContado.UseVisualStyleBackColor = true;
            // 
            // Cancelar
            // 
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelar.Location = new System.Drawing.Point(126, 3);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(91, 68);
            this.Cancelar.TabIndex = 1;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // BtnGenVen
            // 
            this.BtnGenVen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(194)))), ((int)(((byte)(12)))));
            this.BtnGenVen.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnGenVen.FlatAppearance.BorderSize = 3;
            this.BtnGenVen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenVen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenVen.ForeColor = System.Drawing.Color.White;
            this.BtnGenVen.Location = new System.Drawing.Point(21, 3);
            this.BtnGenVen.Name = "BtnGenVen";
            this.BtnGenVen.Size = new System.Drawing.Size(99, 68);
            this.BtnGenVen.TabIndex = 0;
            this.BtnGenVen.Text = "Generar Venta";
            this.BtnGenVen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGenVen.UseVisualStyleBackColor = false;
            // 
            // PanArriba
            // 
            this.PanArriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanArriba.Location = new System.Drawing.Point(0, 0);
            this.PanArriba.Name = "PanArriba";
            this.PanArriba.Size = new System.Drawing.Size(897, 67);
            this.PanArriba.TabIndex = 0;
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 629);
            this.Controls.Add(this.PanCentral);
            this.Controls.Add(this.PanData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ventas";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.Ventas_Load);
            this.PanData.ResumeLayout(false);
            this.Gbx2.ResumeLayout(false);
            this.Gbx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCant)).EndInit();
            this.Gbx1.ResumeLayout(false);
            this.Gbx1.PerformLayout();
            this.PanCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProd)).EndInit();
            this.PanAbajo.ResumeLayout(false);
            this.PanAbajo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanData;
        private System.Windows.Forms.GroupBox Gbx2;
        private System.Windows.Forms.GroupBox Gbx1;
        private System.Windows.Forms.TextBox TxtCredito;
        private System.Windows.Forms.TextBox TxtNit;
        private System.Windows.Forms.TextBox TxtDirCli;
        private System.Windows.Forms.ComboBox CboNomCli;
        private System.Windows.Forms.Panel PanCentral;
        private System.Windows.Forms.Button BtnAgr;
        private System.Windows.Forms.NumericUpDown NudCant;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.ComboBox CboProd;
        private System.Windows.Forms.Panel PanAbajo;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button BtnGenVen;
        private System.Windows.Forms.Panel PanArriba;
        private System.Windows.Forms.RadioButton RdbConce;
        private System.Windows.Forms.RadioButton RdbCredito;
        private System.Windows.Forms.RadioButton RdbContado;
        private System.Windows.Forms.DataGridView DgvProd;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}