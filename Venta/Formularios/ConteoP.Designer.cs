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
            this.PanSup = new System.Windows.Forms.Panel();
            this.PanCent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtProd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NudCant = new System.Windows.Forms.NumericUpDown();
            this.BtnBusca = new System.Windows.Forms.Button();
            this.DgvProd = new System.Windows.Forms.DataGridView();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.PanSup.SuspendLayout();
            this.PanCent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProd)).BeginInit();
            this.SuspendLayout();
            // 
            // PanSup
            // 
            this.PanSup.Controls.Add(this.BtnPrint);
            this.PanSup.Controls.Add(this.BtnBusca);
            this.PanSup.Controls.Add(this.NudCant);
            this.PanSup.Controls.Add(this.label2);
            this.PanSup.Controls.Add(this.TxtProd);
            this.PanSup.Controls.Add(this.label1);
            this.PanSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSup.Location = new System.Drawing.Point(0, 0);
            this.PanSup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanSup.Name = "PanSup";
            this.PanSup.Size = new System.Drawing.Size(732, 70);
            this.PanSup.TabIndex = 0;
            // 
            // PanCent
            // 
            this.PanCent.Controls.Add(this.DgvProd);
            this.PanCent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCent.Location = new System.Drawing.Point(0, 70);
            this.PanCent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanCent.Name = "PanCent";
            this.PanCent.Size = new System.Drawing.Size(732, 488);
            this.PanCent.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Producto";
            // 
            // TxtProd
            // 
            this.TxtProd.Location = new System.Drawing.Point(42, 26);
            this.TxtProd.Name = "TxtProd";
            this.TxtProd.Size = new System.Drawing.Size(274, 23);
            this.TxtProd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad";
            // 
            // NudCant
            // 
            this.NudCant.Location = new System.Drawing.Point(354, 27);
            this.NudCant.Name = "NudCant";
            this.NudCant.Size = new System.Drawing.Size(64, 23);
            this.NudCant.TabIndex = 3;
            // 
            // BtnBusca
            // 
            this.BtnBusca.Location = new System.Drawing.Point(471, 14);
            this.BtnBusca.Name = "BtnBusca";
            this.BtnBusca.Size = new System.Drawing.Size(115, 45);
            this.BtnBusca.TabIndex = 4;
            this.BtnBusca.Text = "Buscar";
            this.BtnBusca.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBusca.UseVisualStyleBackColor = true;
            this.BtnBusca.Click += new System.EventHandler(this.BtnBusca_Click);
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
            this.DgvProd.Size = new System.Drawing.Size(732, 488);
            this.DgvProd.TabIndex = 0;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(604, 14);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(116, 45);
            this.BtnPrint.TabIndex = 5;
            this.BtnPrint.Text = "Imprimir";
            this.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConteoP";
            this.Text = "Conteo de productos";
            this.PanSup.ResumeLayout(false);
            this.PanSup.PerformLayout();
            this.PanCent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NudCant)).EndInit();
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
    }
}