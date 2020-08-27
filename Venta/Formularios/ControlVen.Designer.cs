namespace Venta.Formularios
{
    partial class ControlVen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlVen));
            this.PanDer = new System.Windows.Forms.Panel();
            this.GbxVenta = new System.Windows.Forms.GroupBox();
            this.BtnMostrar = new System.Windows.Forms.Button();
            this.TxtFech = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCli = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtVend = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CboVenta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanAbaj = new System.Windows.Forms.Panel();
            this.Lblt = new System.Windows.Forms.Label();
            this.BtnSuprVen = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.PanCent = new System.Windows.Forms.Panel();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.BtnImp = new System.Windows.Forms.Button();
            this.PanDer.SuspendLayout();
            this.GbxVenta.SuspendLayout();
            this.PanAbaj.SuspendLayout();
            this.PanCent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // PanDer
            // 
            this.PanDer.Controls.Add(this.GbxVenta);
            this.PanDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanDer.Location = new System.Drawing.Point(0, 0);
            this.PanDer.Margin = new System.Windows.Forms.Padding(4);
            this.PanDer.Name = "PanDer";
            this.PanDer.Size = new System.Drawing.Size(224, 590);
            this.PanDer.TabIndex = 0;
            // 
            // GbxVenta
            // 
            this.GbxVenta.Controls.Add(this.BtnImp);
            this.GbxVenta.Controls.Add(this.BtnMostrar);
            this.GbxVenta.Controls.Add(this.TxtFech);
            this.GbxVenta.Controls.Add(this.label4);
            this.GbxVenta.Controls.Add(this.TxtCli);
            this.GbxVenta.Controls.Add(this.label3);
            this.GbxVenta.Controls.Add(this.TxtVend);
            this.GbxVenta.Controls.Add(this.label2);
            this.GbxVenta.Controls.Add(this.CboVenta);
            this.GbxVenta.Controls.Add(this.label1);
            this.GbxVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxVenta.Location = new System.Drawing.Point(0, 0);
            this.GbxVenta.Margin = new System.Windows.Forms.Padding(4);
            this.GbxVenta.Name = "GbxVenta";
            this.GbxVenta.Padding = new System.Windows.Forms.Padding(4);
            this.GbxVenta.Size = new System.Drawing.Size(224, 590);
            this.GbxVenta.TabIndex = 0;
            this.GbxVenta.TabStop = false;
            this.GbxVenta.Text = "Datos de la venta";
            // 
            // BtnMostrar
            // 
            this.BtnMostrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMostrar.Location = new System.Drawing.Point(4, 548);
            this.BtnMostrar.Name = "BtnMostrar";
            this.BtnMostrar.Size = new System.Drawing.Size(216, 38);
            this.BtnMostrar.TabIndex = 8;
            this.BtnMostrar.Text = "Mostrar productos";
            this.BtnMostrar.UseVisualStyleBackColor = true;
            this.BtnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // TxtFech
            // 
            this.TxtFech.Enabled = false;
            this.TxtFech.Location = new System.Drawing.Point(12, 277);
            this.TxtFech.Name = "TxtFech";
            this.TxtFech.Size = new System.Drawing.Size(178, 22);
            this.TxtFech.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha";
            // 
            // TxtCli
            // 
            this.TxtCli.Enabled = false;
            this.TxtCli.Location = new System.Drawing.Point(12, 203);
            this.TxtCli.Name = "TxtCli";
            this.TxtCli.Size = new System.Drawing.Size(178, 22);
            this.TxtCli.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cliente";
            // 
            // TxtVend
            // 
            this.TxtVend.Enabled = false;
            this.TxtVend.Location = new System.Drawing.Point(12, 131);
            this.TxtVend.Name = "TxtVend";
            this.TxtVend.Size = new System.Drawing.Size(178, 22);
            this.TxtVend.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vendio";
            // 
            // CboVenta
            // 
            this.CboVenta.FormattingEnabled = true;
            this.CboVenta.Location = new System.Drawing.Point(12, 54);
            this.CboVenta.Name = "CboVenta";
            this.CboVenta.Size = new System.Drawing.Size(181, 24);
            this.CboVenta.TabIndex = 1;
            this.CboVenta.SelectedIndexChanged += new System.EventHandler(this.CboVenta_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "No de venta";
            // 
            // PanAbaj
            // 
            this.PanAbaj.Controls.Add(this.Lblt);
            this.PanAbaj.Controls.Add(this.BtnSuprVen);
            this.PanAbaj.Controls.Add(this.lblTotal);
            this.PanAbaj.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanAbaj.Location = new System.Drawing.Point(224, 508);
            this.PanAbaj.Margin = new System.Windows.Forms.Padding(4);
            this.PanAbaj.Name = "PanAbaj";
            this.PanAbaj.Size = new System.Drawing.Size(906, 82);
            this.PanAbaj.TabIndex = 1;
            // 
            // Lblt
            // 
            this.Lblt.AutoSize = true;
            this.Lblt.Location = new System.Drawing.Point(831, 31);
            this.Lblt.Name = "Lblt";
            this.Lblt.Size = new System.Drawing.Size(12, 16);
            this.Lblt.TabIndex = 2;
            this.Lblt.Text = ".";
            this.Lblt.Visible = false;
            // 
            // BtnSuprVen
            // 
            this.BtnSuprVen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnSuprVen.Enabled = false;
            this.BtnSuprVen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSuprVen.ForeColor = System.Drawing.Color.White;
            this.BtnSuprVen.Location = new System.Drawing.Point(7, 40);
            this.BtnSuprVen.Name = "BtnSuprVen";
            this.BtnSuprVen.Size = new System.Drawing.Size(216, 38);
            this.BtnSuprVen.TabIndex = 1;
            this.BtnSuprVen.Text = "Cancelar Venta";
            this.BtnSuprVen.UseVisualStyleBackColor = false;
            this.BtnSuprVen.Click += new System.EventHandler(this.BtnSuprVen_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(657, 31);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(76, 25);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "label5";
            // 
            // PanCent
            // 
            this.PanCent.Controls.Add(this.DgvDatos);
            this.PanCent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCent.Location = new System.Drawing.Point(224, 0);
            this.PanCent.Margin = new System.Windows.Forms.Padding(4);
            this.PanCent.Name = "PanCent";
            this.PanCent.Size = new System.Drawing.Size(906, 508);
            this.PanCent.TabIndex = 2;
            // 
            // DgvDatos
            // 
            this.DgvDatos.AllowUserToAddRows = false;
            this.DgvDatos.AllowUserToDeleteRows = false;
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDatos.Location = new System.Drawing.Point(0, 0);
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.ReadOnly = true;
            this.DgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDatos.Size = new System.Drawing.Size(906, 508);
            this.DgvDatos.TabIndex = 0;
            // 
            // BtnImp
            // 
            this.BtnImp.Image = ((System.Drawing.Image)(resources.GetObject("BtnImp.Image")));
            this.BtnImp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImp.Location = new System.Drawing.Point(25, 372);
            this.BtnImp.Name = "BtnImp";
            this.BtnImp.Size = new System.Drawing.Size(149, 64);
            this.BtnImp.TabIndex = 9;
            this.BtnImp.Text = "Imprimir comprobante";
            this.BtnImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImp.UseVisualStyleBackColor = true;
            this.BtnImp.Click += new System.EventHandler(this.BtnImp_Click);
            // 
            // ControlVen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 590);
            this.Controls.Add(this.PanCent);
            this.Controls.Add(this.PanAbaj);
            this.Controls.Add(this.PanDer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ControlVen";
            this.Text = "ControlVen";
            this.Load += new System.EventHandler(this.ControlVen_Load);
            this.PanDer.ResumeLayout(false);
            this.GbxVenta.ResumeLayout(false);
            this.GbxVenta.PerformLayout();
            this.PanAbaj.ResumeLayout(false);
            this.PanAbaj.PerformLayout();
            this.PanCent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanDer;
        private System.Windows.Forms.Panel PanAbaj;
        private System.Windows.Forms.Panel PanCent;
        private System.Windows.Forms.GroupBox GbxVenta;
        private System.Windows.Forms.Button BtnMostrar;
        private System.Windows.Forms.TextBox TxtFech;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCli;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtVend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvDatos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button BtnSuprVen;
        private System.Windows.Forms.Label Lblt;
        private System.Windows.Forms.Button BtnImp;
    }
}