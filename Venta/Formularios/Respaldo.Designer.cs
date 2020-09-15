namespace Venta.Formularios
{
    partial class Respaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Respaldo));
            this.TxtRuta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCarpeta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtRuta
            // 
            this.TxtRuta.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRuta.Location = new System.Drawing.Point(12, 45);
            this.TxtRuta.Name = "TxtRuta";
            this.TxtRuta.Size = new System.Drawing.Size(417, 39);
            this.TxtRuta.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Carpeta de respaldo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuardar.Image")));
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.Location = new System.Drawing.Point(12, 90);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(97, 52);
            this.BtnGuardar.TabIndex = 2;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCarpeta
            // 
            this.BtnCarpeta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCarpeta.Image = ((System.Drawing.Image)(resources.GetObject("BtnCarpeta.Image")));
            this.BtnCarpeta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCarpeta.Location = new System.Drawing.Point(310, 90);
            this.BtnCarpeta.Name = "BtnCarpeta";
            this.BtnCarpeta.Size = new System.Drawing.Size(119, 52);
            this.BtnCarpeta.TabIndex = 3;
            this.BtnCarpeta.Text = "Seleccionar Carpeta";
            this.BtnCarpeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCarpeta.UseVisualStyleBackColor = true;
            this.BtnCarpeta.Click += new System.EventHandler(this.BtnCarpeta_Click);
            // 
            // Respaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 147);
            this.Controls.Add(this.BtnCarpeta);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtRuta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Respaldo";
            this.Text = "Respaldo";
            this.Load += new System.EventHandler(this.Respaldo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtRuta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCarpeta;
    }
}