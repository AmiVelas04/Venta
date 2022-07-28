namespace Venta.Formularios
{
    partial class IngresoRapidoProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoRapidoProd));
            this.PanCentral = new System.Windows.Forms.Panel();
            this.GbxProd = new System.Windows.Forms.GroupBox();
            this.LblDatos = new System.Windows.Forms.Label();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnAgre = new System.Windows.Forms.Button();
            this.NudCant = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanCentral.SuspendLayout();
            this.GbxProd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCant)).BeginInit();
            this.SuspendLayout();
            // 
            // PanCentral
            // 
            this.PanCentral.Controls.Add(this.GbxProd);
            this.PanCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCentral.Location = new System.Drawing.Point(0, 0);
            this.PanCentral.Margin = new System.Windows.Forms.Padding(4);
            this.PanCentral.Name = "PanCentral";
            this.PanCentral.Size = new System.Drawing.Size(349, 227);
            this.PanCentral.TabIndex = 0;
            // 
            // GbxProd
            // 
            this.GbxProd.Controls.Add(this.LblDatos);
            this.GbxProd.Controls.Add(this.BtnLimpiar);
            this.GbxProd.Controls.Add(this.BtnAgre);
            this.GbxProd.Controls.Add(this.NudCant);
            this.GbxProd.Controls.Add(this.label3);
            this.GbxProd.Controls.Add(this.TxtCod);
            this.GbxProd.Controls.Add(this.label1);
            this.GbxProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxProd.Location = new System.Drawing.Point(0, 0);
            this.GbxProd.Name = "GbxProd";
            this.GbxProd.Size = new System.Drawing.Size(349, 227);
            this.GbxProd.TabIndex = 0;
            this.GbxProd.TabStop = false;
            this.GbxProd.Text = "Datos del producto";
            // 
            // LblDatos
            // 
            this.LblDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDatos.Location = new System.Drawing.Point(12, 69);
            this.LblDatos.Name = "LblDatos";
            this.LblDatos.Size = new System.Drawing.Size(322, 99);
            this.LblDatos.TabIndex = 8;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("BtnLimpiar.Image")));
            this.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpiar.Location = new System.Drawing.Point(221, 186);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(113, 35);
            this.BtnLimpiar.TabIndex = 7;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnAgre
            // 
            this.BtnAgre.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgre.Image")));
            this.BtnAgre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgre.Location = new System.Drawing.Point(102, 186);
            this.BtnAgre.Name = "BtnAgre";
            this.BtnAgre.Size = new System.Drawing.Size(113, 35);
            this.BtnAgre.TabIndex = 6;
            this.BtnAgre.Text = "Agregar";
            this.BtnAgre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgre.UseVisualStyleBackColor = true;
            this.BtnAgre.Click += new System.EventHandler(this.BtnAgre_Click);
            // 
            // NudCant
            // 
            this.NudCant.Location = new System.Drawing.Point(12, 187);
            this.NudCant.Name = "NudCant";
            this.NudCant.Size = new System.Drawing.Size(83, 22);
            this.NudCant.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad";
            // 
            // TxtCod
            // 
            this.TxtCod.Location = new System.Drawing.Point(12, 44);
            this.TxtCod.Name = "TxtCod";
            this.TxtCod.Size = new System.Drawing.Size(140, 22);
            this.TxtCod.TabIndex = 1;
            this.TxtCod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCod_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // IngresoRapidoProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 227);
            this.Controls.Add(this.PanCentral);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IngresoRapidoProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingreso rápido de productos";
            this.Load += new System.EventHandler(this.IngresoRapidoProd_Load);
            this.PanCentral.ResumeLayout(false);
            this.GbxProd.ResumeLayout(false);
            this.GbxProd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanCentral;
        private System.Windows.Forms.GroupBox GbxProd;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnAgre;
        private System.Windows.Forms.NumericUpDown NudCant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblDatos;
    }
}