namespace Venta.Formularios
{
    partial class Concesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Concesion));
            this.PanSup = new System.Windows.Forms.Panel();
            this.GbxConce = new System.Windows.Forms.GroupBox();
            this.BtnImp = new System.Windows.Forms.Button();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CboConce = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GbxCliente = new System.Windows.Forms.GroupBox();
            this.CboCli = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanInf = new System.Windows.Forms.Panel();
            this.BtnCambaircant = new System.Windows.Forms.Button();
            this.NudProd = new System.Windows.Forms.NumericUpDown();
            this.BtnFacturar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.PanMed = new System.Windows.Forms.Panel();
            this.DgvProd = new System.Windows.Forms.DataGridView();
            this.PanSup.SuspendLayout();
            this.GbxConce.SuspendLayout();
            this.GbxCliente.SuspendLayout();
            this.PanInf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudProd)).BeginInit();
            this.PanMed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProd)).BeginInit();
            this.SuspendLayout();
            // 
            // PanSup
            // 
            this.PanSup.Controls.Add(this.GbxConce);
            this.PanSup.Controls.Add(this.GbxCliente);
            this.PanSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSup.Location = new System.Drawing.Point(0, 0);
            this.PanSup.Name = "PanSup";
            this.PanSup.Size = new System.Drawing.Size(1130, 114);
            this.PanSup.TabIndex = 0;
            // 
            // GbxConce
            // 
            this.GbxConce.Controls.Add(this.BtnImp);
            this.GbxConce.Controls.Add(this.TxtTotal);
            this.GbxConce.Controls.Add(this.label3);
            this.GbxConce.Controls.Add(this.CboConce);
            this.GbxConce.Controls.Add(this.label2);
            this.GbxConce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxConce.Location = new System.Drawing.Point(348, 0);
            this.GbxConce.Name = "GbxConce";
            this.GbxConce.Size = new System.Drawing.Size(782, 114);
            this.GbxConce.TabIndex = 1;
            this.GbxConce.TabStop = false;
            this.GbxConce.Text = "Concesion";
            // 
            // BtnImp
            // 
            this.BtnImp.Image = ((System.Drawing.Image)(resources.GetObject("BtnImp.Image")));
            this.BtnImp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImp.Location = new System.Drawing.Point(440, 38);
            this.BtnImp.Name = "BtnImp";
            this.BtnImp.Size = new System.Drawing.Size(133, 56);
            this.BtnImp.TabIndex = 4;
            this.BtnImp.Text = "Imprimir Concesion";
            this.BtnImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImp.UseVisualStyleBackColor = true;
            this.BtnImp.Click += new System.EventHandler(this.BtnImp_Click);
            // 
            // TxtTotal
            // 
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Location = new System.Drawing.Point(217, 55);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(87, 26);
            this.TxtTotal.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total";
            // 
            // CboConce
            // 
            this.CboConce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboConce.FormattingEnabled = true;
            this.CboConce.Location = new System.Drawing.Point(24, 54);
            this.CboConce.Name = "CboConce";
            this.CboConce.Size = new System.Drawing.Size(91, 27);
            this.CboConce.TabIndex = 1;
            this.CboConce.SelectedIndexChanged += new System.EventHandler(this.CboVenta_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "No. Concesion";
            // 
            // GbxCliente
            // 
            this.GbxCliente.Controls.Add(this.CboCli);
            this.GbxCliente.Controls.Add(this.label1);
            this.GbxCliente.Dock = System.Windows.Forms.DockStyle.Left;
            this.GbxCliente.Location = new System.Drawing.Point(0, 0);
            this.GbxCliente.Name = "GbxCliente";
            this.GbxCliente.Size = new System.Drawing.Size(348, 114);
            this.GbxCliente.TabIndex = 0;
            this.GbxCliente.TabStop = false;
            this.GbxCliente.Text = "Cliente";
            // 
            // CboCli
            // 
            this.CboCli.FormattingEnabled = true;
            this.CboCli.Location = new System.Drawing.Point(25, 54);
            this.CboCli.Name = "CboCli";
            this.CboCli.Size = new System.Drawing.Size(291, 27);
            this.CboCli.TabIndex = 1;
            this.CboCli.SelectedIndexChanged += new System.EventHandler(this.CboCli_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del cliente";
            // 
            // PanInf
            // 
            this.PanInf.Controls.Add(this.BtnCambaircant);
            this.PanInf.Controls.Add(this.NudProd);
            this.PanInf.Controls.Add(this.BtnFacturar);
            this.PanInf.Controls.Add(this.BtnEliminar);
            this.PanInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanInf.Location = new System.Drawing.Point(0, 529);
            this.PanInf.Name = "PanInf";
            this.PanInf.Size = new System.Drawing.Size(1130, 61);
            this.PanInf.TabIndex = 1;
            // 
            // BtnCambaircant
            // 
            this.BtnCambaircant.Location = new System.Drawing.Point(427, 5);
            this.BtnCambaircant.Name = "BtnCambaircant";
            this.BtnCambaircant.Size = new System.Drawing.Size(98, 50);
            this.BtnCambaircant.TabIndex = 5;
            this.BtnCambaircant.Text = "Cambiar Cantidad";
            this.BtnCambaircant.UseVisualStyleBackColor = true;
            this.BtnCambaircant.Visible = false;
            this.BtnCambaircant.Click += new System.EventHandler(this.BtnCambaircant_Click);
            // 
            // NudProd
            // 
            this.NudProd.Location = new System.Drawing.Point(322, 18);
            this.NudProd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NudProd.Name = "NudProd";
            this.NudProd.Size = new System.Drawing.Size(89, 26);
            this.NudProd.TabIndex = 4;
            this.NudProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudProd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudProd.Visible = false;
            this.NudProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudProd_KeyDown);
            // 
            // BtnFacturar
            // 
            this.BtnFacturar.Location = new System.Drawing.Point(1028, 8);
            this.BtnFacturar.Name = "BtnFacturar";
            this.BtnFacturar.Size = new System.Drawing.Size(90, 47);
            this.BtnFacturar.TabIndex = 3;
            this.BtnFacturar.Text = "Facturar";
            this.BtnFacturar.UseVisualStyleBackColor = true;
            this.BtnFacturar.Click += new System.EventHandler(this.BtnFacturar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(10, 8);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(98, 47);
            this.BtnEliminar.TabIndex = 0;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // PanMed
            // 
            this.PanMed.Controls.Add(this.DgvProd);
            this.PanMed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanMed.Location = new System.Drawing.Point(0, 114);
            this.PanMed.Name = "PanMed";
            this.PanMed.Size = new System.Drawing.Size(1130, 415);
            this.PanMed.TabIndex = 2;
            // 
            // DgvProd
            // 
            this.DgvProd.AllowUserToAddRows = false;
            this.DgvProd.AllowUserToDeleteRows = false;
            this.DgvProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProd.Location = new System.Drawing.Point(0, 0);
            this.DgvProd.MultiSelect = false;
            this.DgvProd.Name = "DgvProd";
            this.DgvProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProd.Size = new System.Drawing.Size(1130, 415);
            this.DgvProd.TabIndex = 0;
            this.DgvProd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProd_CellEndEdit);
            this.DgvProd.SelectionChanged += new System.EventHandler(this.DgvProd_SelectionChanged);
            this.DgvProd.Click += new System.EventHandler(this.DgvProd_Click);
            // 
            // Concesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 590);
            this.Controls.Add(this.PanMed);
            this.Controls.Add(this.PanInf);
            this.Controls.Add(this.PanSup);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Concesion";
            this.Text = "Concesion";
            this.Load += new System.EventHandler(this.Concesion_Load);
            this.PanSup.ResumeLayout(false);
            this.GbxConce.ResumeLayout(false);
            this.GbxConce.PerformLayout();
            this.GbxCliente.ResumeLayout(false);
            this.GbxCliente.PerformLayout();
            this.PanInf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NudProd)).EndInit();
            this.PanMed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanSup;
        private System.Windows.Forms.Panel PanInf;
        private System.Windows.Forms.Panel PanMed;
        private System.Windows.Forms.GroupBox GbxConce;
        private System.Windows.Forms.GroupBox GbxCliente;
        private System.Windows.Forms.ComboBox CboConce;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboCli;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvProd;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnFacturar;
        private System.Windows.Forms.NumericUpDown NudProd;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnImp;
        private System.Windows.Forms.Button BtnCambaircant;
    }
}