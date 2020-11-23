namespace Venta.Reportes
{
    partial class ConceRep
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
            this.RpvConce = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RpvConce
            // 
            this.RpvConce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RpvConce.LocalReport.ReportEmbeddedResource = "Venta.Reportes.ConceRep.rdlc";
            this.RpvConce.Location = new System.Drawing.Point(0, 0);
            this.RpvConce.Name = "RpvConce";
            this.RpvConce.Size = new System.Drawing.Size(807, 318);
            this.RpvConce.TabIndex = 0;
            // 
            // ConceRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 318);
            this.Controls.Add(this.RpvConce);
            this.Name = "ConceRep";
            this.Text = "ConceRep";
            this.Load += new System.EventHandler(this.ConceRep_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RpvConce;
    }
}