namespace Venta.Formularios
{
    partial class Compras
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
            this.PanDer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PanDer
            // 
            this.PanDer.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanDer.Location = new System.Drawing.Point(722, 0);
            this.PanDer.Name = "PanDer";
            this.PanDer.Size = new System.Drawing.Size(408, 590);
            this.PanDer.TabIndex = 0;
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 590);
            this.Controls.Add(this.PanDer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Compras";
            this.Text = "Compras";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanDer;
    }
}