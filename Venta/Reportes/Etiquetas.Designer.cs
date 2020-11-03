namespace Venta.Reportes
{
    partial class Etiquetas
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Rpv1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.EtiquetaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SalidaPEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EtiquetaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalidaPEncBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Rpv1
            // 
            this.Rpv1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Etiqueta";
            reportDataSource1.Value = this.EtiquetaBindingSource;
            reportDataSource2.Name = "Encabezado";
            reportDataSource2.Value = this.SalidaPEncBindingSource;
            this.Rpv1.LocalReport.DataSources.Add(reportDataSource1);
            this.Rpv1.LocalReport.DataSources.Add(reportDataSource2);
            this.Rpv1.LocalReport.ReportEmbeddedResource = "Venta.Reportes.Etiquetas.rdlc";
            this.Rpv1.Location = new System.Drawing.Point(0, 0);
            this.Rpv1.Name = "Rpv1";
            this.Rpv1.Size = new System.Drawing.Size(811, 423);
            this.Rpv1.TabIndex = 0;
            // 
            // EtiquetaBindingSource
            // 
            this.EtiquetaBindingSource.DataSource = typeof(Venta.Reportes.Etiqueta);
            // 
            // SalidaPEncBindingSource
            // 
            this.SalidaPEncBindingSource.DataSource = typeof(Venta.Reportes.SalidaPEnc);
            // 
            // Etiquetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 423);
            this.Controls.Add(this.Rpv1);
            this.Name = "Etiquetas";
            this.Text = "Etiquetas";
            this.Load += new System.EventHandler(this.Etiquetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EtiquetaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalidaPEncBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Rpv1;
        private System.Windows.Forms.BindingSource EtiquetaBindingSource;
        private System.Windows.Forms.BindingSource SalidaPEncBindingSource;
    }
}