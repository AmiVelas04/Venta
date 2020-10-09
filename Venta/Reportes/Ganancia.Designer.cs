namespace Venta.Reportes
{
    partial class Ganancia
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
            this.RpvGanancia = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RpvGanancia
            // 
            this.RpvGanancia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RpvGanancia.LocalReport.ReportEmbeddedResource = "Venta.Reportes.Ganancia.rdlc";
            this.RpvGanancia.Location = new System.Drawing.Point(0, 0);
            this.RpvGanancia.Name = "RpvGanancia";
            this.RpvGanancia.Size = new System.Drawing.Size(658, 409);
            this.RpvGanancia.TabIndex = 0;
            // 
            // Ganancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 409);
            this.Controls.Add(this.RpvGanancia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Ganancia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ganancia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ganancia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RpvGanancia;
    }
}