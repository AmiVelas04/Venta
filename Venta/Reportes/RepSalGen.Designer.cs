namespace Venta.Reportes
{
    partial class RepSalGen
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
            this.RpvSalidaGen = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RpvSalidaGen
            // 
            this.RpvSalidaGen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RpvSalidaGen.LocalReport.ReportEmbeddedResource = "Venta.Reportes.RepSalGen.rdlc";
            this.RpvSalidaGen.Location = new System.Drawing.Point(0, 0);
            this.RpvSalidaGen.Name = "RpvSalidaGen";
            this.RpvSalidaGen.Size = new System.Drawing.Size(790, 391);
            this.RpvSalidaGen.TabIndex = 0;
            // 
            // RepSalGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 391);
            this.Controls.Add(this.RpvSalidaGen);
            this.Name = "RepSalGen";
            this.Text = "Reporte de Salida General";
            this.Load += new System.EventHandler(this.RepSalGen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RpvSalidaGen;
    }
}