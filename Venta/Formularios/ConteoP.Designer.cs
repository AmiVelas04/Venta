namespace Venta.Formularios
{
    partial class ConteoP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConteoP));
            this.PanSup = new System.Windows.Forms.Panel();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnBusca = new System.Windows.Forms.Button();
            this.NudCant = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtProd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanCent = new System.Windows.Forms.Panel();
            this.DgvProd = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtEstilo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTipo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Txtcolor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtTalla = new System.Windows.Forms.TextBox();
            this.PanSup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCant)).BeginInit();
            this.PanCent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProd)).BeginInit();
            this.SuspendLayout();
            // 
            // PanSup
            // 
            this.PanSup.Controls.Add(this.TxtTalla);
            this.PanSup.Controls.Add(this.label6);
            this.PanSup.Controls.Add(this.Txtcolor);
            this.PanSup.Controls.Add(this.label5);
            this.PanSup.Controls.Add(this.TxtTipo);
            this.PanSup.Controls.Add(this.label4);
            this.PanSup.Controls.Add(this.TxtEstilo);
            this.PanSup.Controls.Add(this.label3);
            this.PanSup.Controls.Add(this.BtnPrint);
            this.PanSup.Controls.Add(this.BtnBusca);
            this.PanSup.Controls.Add(this.NudCant);
            this.PanSup.Controls.Add(this.label2);
            this.PanSup.Controls.Add(this.TxtProd);
            this.PanSup.Controls.Add(this.label1);
            this.PanSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSup.Location = new System.Drawing.Point(0, 0);
            this.PanSup.Margin = new System.Windows.Forms.Padding(4);
            this.PanSup.Name = "PanSup";
            this.PanSup.Size = new System.Drawing.Size(732, 109);
            this.PanSup.TabIndex = 0;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrint.Image")));
            this.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrint.Location = new System.Drawing.Point(599, 12);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(121, 37);
            this.BtnPrint.TabIndex = 5;
            this.BtnPrint.Text = "Imprimir";
            this.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnBusca
            // 
            this.BtnBusca.Image = ((System.Drawing.Image)(resources.GetObject("BtnBusca.Image")));
            this.BtnBusca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBusca.Location = new System.Drawing.Point(484, 12);
            this.BtnBusca.Name = "BtnBusca";
            this.BtnBusca.Size = new System.Drawing.Size(109, 36);
            this.BtnBusca.TabIndex = 4;
            this.BtnBusca.Text = "Buscar";
            this.BtnBusca.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBusca.UseVisualStyleBackColor = true;
            this.BtnBusca.Click += new System.EventHandler(this.BtnBusca_Click);
            // 
            // NudCant
            // 
            this.NudCant.Location = new System.Drawing.Point(354, 25);
            this.NudCant.Name = "NudCant";
            this.NudCant.Size = new System.Drawing.Size(64, 23);
            this.NudCant.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad";
            // 
            // TxtProd
            // 
            this.TxtProd.Location = new System.Drawing.Point(22, 26);
            this.TxtProd.Name = "TxtProd";
            this.TxtProd.Size = new System.Drawing.Size(304, 23);
            this.TxtProd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Producto";
            // 
            // PanCent
            // 
            this.PanCent.Controls.Add(this.DgvProd);
            this.PanCent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCent.Location = new System.Drawing.Point(0, 109);
            this.PanCent.Margin = new System.Windows.Forms.Padding(4);
            this.PanCent.Name = "PanCent";
            this.PanCent.Size = new System.Drawing.Size(732, 449);
            this.PanCent.TabIndex = 1;
            // 
            // DgvProd
            // 
            this.DgvProd.AllowUserToAddRows = false;
            this.DgvProd.AllowUserToDeleteRows = false;
            this.DgvProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvProd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProd.Location = new System.Drawing.Point(0, 0);
            this.DgvProd.Name = "DgvProd";
            this.DgvProd.ReadOnly = true;
            this.DgvProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProd.Size = new System.Drawing.Size(732, 449);
            this.DgvProd.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Estilo";
            // 
            // TxtEstilo
            // 
            this.TxtEstilo.Location = new System.Drawing.Point(22, 70);
            this.TxtEstilo.Name = "TxtEstilo";
            this.TxtEstilo.Size = new System.Drawing.Size(143, 23);
            this.TxtEstilo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tipo";
            // 
            // TxtTipo
            // 
            this.TxtTipo.Location = new System.Drawing.Point(194, 70);
            this.TxtTipo.Name = "TxtTipo";
            this.TxtTipo.Size = new System.Drawing.Size(132, 23);
            this.TxtTipo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Color";
            // 
            // Txtcolor
            // 
            this.Txtcolor.Location = new System.Drawing.Point(354, 70);
            this.Txtcolor.Name = "Txtcolor";
            this.Txtcolor.Size = new System.Drawing.Size(154, 23);
            this.Txtcolor.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(542, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Talla";
            // 
            // TxtTalla
            // 
            this.TxtTalla.Location = new System.Drawing.Point(540, 70);
            this.TxtTalla.Name = "TxtTalla";
            this.TxtTalla.Size = new System.Drawing.Size(157, 23);
            this.TxtTalla.TabIndex = 13;
            // 
            // ConteoP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 558);
            this.Controls.Add(this.PanCent);
            this.Controls.Add(this.PanSup);
            this.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConteoP";
            this.Text = "Conteo de productos";
            this.PanSup.ResumeLayout(false);
            this.PanSup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCant)).EndInit();
            this.PanCent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanSup;
        private System.Windows.Forms.TextBox TxtProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanCent;
        private System.Windows.Forms.Button BtnBusca;
        private System.Windows.Forms.NumericUpDown NudCant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvProd;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.TextBox TxtTalla;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txtcolor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtEstilo;
        private System.Windows.Forms.Label label3;
    }
}