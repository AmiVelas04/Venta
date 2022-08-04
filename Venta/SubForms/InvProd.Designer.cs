namespace Venta.SubForms
{
    partial class InvProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvProd));
            this.PanCent = new System.Windows.Forms.Panel();
            this.DgvProd = new System.Windows.Forms.DataGridView();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanInf = new System.Windows.Forms.Panel();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtRev = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PanCent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProd)).BeginInit();
            this.PanInf.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanCent
            // 
            this.PanCent.Controls.Add(this.DgvProd);
            this.PanCent.Controls.Add(this.BtnBuscar);
            this.PanCent.Controls.Add(this.TxtNom);
            this.PanCent.Controls.Add(this.label1);
            this.PanCent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCent.Location = new System.Drawing.Point(0, 0);
            this.PanCent.Margin = new System.Windows.Forms.Padding(4);
            this.PanCent.Name = "PanCent";
            this.PanCent.Size = new System.Drawing.Size(872, 462);
            this.PanCent.TabIndex = 0;
            // 
            // DgvProd
            // 
            this.DgvProd.AllowUserToAddRows = false;
            this.DgvProd.AllowUserToDeleteRows = false;
            this.DgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DgvProd.Location = new System.Drawing.Point(0, 69);
            this.DgvProd.MultiSelect = false;
            this.DgvProd.Name = "DgvProd";
            this.DgvProd.ReadOnly = true;
            this.DgvProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProd.Size = new System.Drawing.Size(872, 393);
            this.DgvProd.TabIndex = 3;
            this.DgvProd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProd_CellClick);
            this.DgvProd.SelectionChanged += new System.EventHandler(this.DgvProd_SelectionChanged);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(516, 10);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(93, 45);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(96, 21);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(383, 25);
            this.TxtNom.TabIndex = 1;
            this.TxtNom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNom_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto";
            // 
            // PanInf
            // 
            this.PanInf.Controls.Add(this.BtnGuardar);
            this.PanInf.Controls.Add(this.TxtRev);
            this.PanInf.Controls.Add(this.label3);
            this.PanInf.Controls.Add(this.TxtCant);
            this.PanInf.Controls.Add(this.label2);
            this.PanInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanInf.Location = new System.Drawing.Point(0, 402);
            this.PanInf.Name = "PanInf";
            this.PanInf.Size = new System.Drawing.Size(872, 60);
            this.PanInf.TabIndex = 1;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuardar.Image")));
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(525, 10);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(116, 37);
            this.BtnGuardar.TabIndex = 4;
            this.BtnGuardar.Text = "Confirmar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TxtRev
            // 
            this.TxtRev.Location = new System.Drawing.Point(331, 17);
            this.TxtRev.Name = "TxtRev";
            this.TxtRev.Size = new System.Drawing.Size(108, 25);
            this.TxtRev.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Revision";
            // 
            // TxtCant
            // 
            this.TxtCant.Enabled = false;
            this.TxtCant.Location = new System.Drawing.Point(96, 17);
            this.TxtCant.Name = "TxtCant";
            this.TxtCant.Size = new System.Drawing.Size(100, 25);
            this.TxtCant.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cantidad";
            // 
            // InvProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 462);
            this.Controls.Add(this.PanInf);
            this.Controls.Add(this.PanCent);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InvProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Revision de inventario";
            this.Load += new System.EventHandler(this.InvProd_Load);
            this.PanCent.ResumeLayout(false);
            this.PanCent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProd)).EndInit();
            this.PanInf.ResumeLayout(false);
            this.PanInf.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanCent;
        private System.Windows.Forms.DataGridView DgvProd;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanInf;
        private System.Windows.Forms.TextBox TxtCant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox TxtRev;
        private System.Windows.Forms.Label label3;
    }
}