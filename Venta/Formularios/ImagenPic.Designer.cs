namespace Venta.Formularios
{
    partial class ImagenPic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagenPic));
            this.PcbImagen = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblCerrar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PcbImagen)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PcbImagen
            // 
            this.PcbImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PcbImagen.Location = new System.Drawing.Point(0, 0);
            this.PcbImagen.Name = "PcbImagen";
            this.PcbImagen.Size = new System.Drawing.Size(800, 600);
            this.PcbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PcbImagen.TabIndex = 0;
            this.PcbImagen.TabStop = false;
            this.PcbImagen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PcbImagen_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.LblCerrar);
            this.panel1.Location = new System.Drawing.Point(763, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(37, 32);
            this.panel1.TabIndex = 3;
            // 
            // LblCerrar
            // 
            this.LblCerrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblCerrar.Image = ((System.Drawing.Image)(resources.GetObject("LblCerrar.Image")));
            this.LblCerrar.Location = new System.Drawing.Point(0, 0);
            this.LblCerrar.Name = "LblCerrar";
            this.LblCerrar.Size = new System.Drawing.Size(37, 32);
            this.LblCerrar.TabIndex = 2;
            this.LblCerrar.Click += new System.EventHandler(this.LblCerrar_Click);
            // 
            // ImagenPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PcbImagen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImagenPic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImagenPic";
            this.Load += new System.EventHandler(this.ImagenPic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PcbImagen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PcbImagen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblCerrar;
    }
}