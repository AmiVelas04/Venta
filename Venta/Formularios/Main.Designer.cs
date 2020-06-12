namespace Venta.Formularios
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.PanLat = new System.Windows.Forms.Panel();
            this.BtnCliente = new System.Windows.Forms.Button();
            this.BtnProd = new System.Windows.Forms.Button();
            this.BtnVenta = new System.Windows.Forms.Button();
            this.PanSup = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.PanCentral = new System.Windows.Forms.Panel();
            this.BtnCreditos = new System.Windows.Forms.Button();
            this.PanLat.SuspendLayout();
            this.PanSup.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanLat
            // 
            this.PanLat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PanLat.Controls.Add(this.BtnCreditos);
            this.PanLat.Controls.Add(this.BtnCliente);
            this.PanLat.Controls.Add(this.BtnProd);
            this.PanLat.Controls.Add(this.BtnVenta);
            this.PanLat.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanLat.Location = new System.Drawing.Point(0, 0);
            this.PanLat.Name = "PanLat";
            this.PanLat.Size = new System.Drawing.Size(134, 680);
            this.PanLat.TabIndex = 0;
            // 
            // BtnCliente
            // 
            this.BtnCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(65)))));
            this.BtnCliente.FlatAppearance.BorderSize = 0;
            this.BtnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCliente.Location = new System.Drawing.Point(8, 177);
            this.BtnCliente.Name = "BtnCliente";
            this.BtnCliente.Size = new System.Drawing.Size(120, 40);
            this.BtnCliente.TabIndex = 2;
            this.BtnCliente.Text = "Cliente";
            this.BtnCliente.UseVisualStyleBackColor = false;
            this.BtnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // BtnProd
            // 
            this.BtnProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(65)))));
            this.BtnProd.FlatAppearance.BorderSize = 0;
            this.BtnProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProd.Location = new System.Drawing.Point(8, 131);
            this.BtnProd.Name = "BtnProd";
            this.BtnProd.Size = new System.Drawing.Size(120, 40);
            this.BtnProd.TabIndex = 1;
            this.BtnProd.Text = "Productos";
            this.BtnProd.UseVisualStyleBackColor = false;
            this.BtnProd.Click += new System.EventHandler(this.BtnProd_Click);
            // 
            // BtnVenta
            // 
            this.BtnVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(65)))));
            this.BtnVenta.FlatAppearance.BorderSize = 0;
            this.BtnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVenta.Location = new System.Drawing.Point(8, 85);
            this.BtnVenta.Name = "BtnVenta";
            this.BtnVenta.Size = new System.Drawing.Size(120, 40);
            this.BtnVenta.TabIndex = 0;
            this.BtnVenta.Text = "Ventas";
            this.BtnVenta.UseVisualStyleBackColor = false;
            this.BtnVenta.Click += new System.EventHandler(this.BtnVenta_Click);
            // 
            // PanSup
            // 
            this.PanSup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(86)))));
            this.PanSup.Controls.Add(this.button1);
            this.PanSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSup.Location = new System.Drawing.Point(134, 0);
            this.PanSup.Name = "PanSup";
            this.PanSup.Size = new System.Drawing.Size(1146, 51);
            this.PanSup.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1088, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 42);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PanCentral
            // 
            this.PanCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCentral.Location = new System.Drawing.Point(134, 51);
            this.PanCentral.Name = "PanCentral";
            this.PanCentral.Size = new System.Drawing.Size(1146, 629);
            this.PanCentral.TabIndex = 2;
            // 
            // BtnCreditos
            // 
            this.BtnCreditos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(65)))));
            this.BtnCreditos.FlatAppearance.BorderSize = 0;
            this.BtnCreditos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreditos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreditos.Location = new System.Drawing.Point(8, 223);
            this.BtnCreditos.Name = "BtnCreditos";
            this.BtnCreditos.Size = new System.Drawing.Size(120, 40);
            this.BtnCreditos.TabIndex = 3;
            this.BtnCreditos.Text = "Creditos";
            this.BtnCreditos.UseVisualStyleBackColor = false;
            this.BtnCreditos.Click += new System.EventHandler(this.BtnCreditos_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 680);
            this.Controls.Add(this.PanCentral);
            this.Controls.Add(this.PanSup);
            this.Controls.Add(this.PanLat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.PanLat.ResumeLayout(false);
            this.PanSup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanLat;
        private System.Windows.Forms.Panel PanSup;
        private System.Windows.Forms.Panel PanCentral;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnVenta;
        private System.Windows.Forms.Button BtnProd;
        private System.Windows.Forms.Button BtnCliente;
        private System.Windows.Forms.Button BtnCreditos;
    }
}