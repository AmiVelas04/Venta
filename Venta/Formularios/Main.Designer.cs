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
            this.PanSup = new System.Windows.Forms.Panel();
            this.PanMain = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.PanSup.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanLat
            // 
            this.PanLat.BackColor = System.Drawing.Color.DimGray;
            this.PanLat.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanLat.Location = new System.Drawing.Point(0, 0);
            this.PanLat.Name = "PanLat";
            this.PanLat.Size = new System.Drawing.Size(134, 373);
            this.PanLat.TabIndex = 0;
            // 
            // PanSup
            // 
            this.PanSup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(12)))), ((int)(((byte)(168)))));
            this.PanSup.Controls.Add(this.button1);
            this.PanSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSup.Location = new System.Drawing.Point(134, 0);
            this.PanSup.Name = "PanSup";
            this.PanSup.Size = new System.Drawing.Size(713, 51);
            this.PanSup.TabIndex = 1;
            // 
            // PanMain
            // 
            this.PanMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanMain.Location = new System.Drawing.Point(134, 51);
            this.PanMain.Name = "PanMain";
            this.PanMain.Size = new System.Drawing.Size(713, 322);
            this.PanMain.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(658, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 42);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 373);
            this.Controls.Add(this.PanMain);
            this.Controls.Add(this.PanSup);
            this.Controls.Add(this.PanLat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.PanSup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanLat;
        private System.Windows.Forms.Panel PanSup;
        private System.Windows.Forms.Panel PanMain;
        private System.Windows.Forms.Button button1;
    }
}