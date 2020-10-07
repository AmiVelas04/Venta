namespace Venta.Reportes
{
    partial class SalidaP
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SalidaPEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SalidaPdetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SalidaPEncBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalidaPdetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Encabezado";
            reportDataSource1.Value = this.SalidaPEncBindingSource;
            reportDataSource2.Name = "Detalle";
            reportDataSource2.Value = this.SalidaPdetBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Venta.Reportes.SalidaP.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(840, 346);
            this.reportViewer1.TabIndex = 0;
            // 
            // SalidaPEncBindingSource
            // 
            this.SalidaPEncBindingSource.DataSource = typeof(Venta.Reportes.SalidaPEnc);
            // 
            // SalidaPdetBindingSource
            // 
            this.SalidaPdetBindingSource.DataSource = typeof(Venta.Reportes.SalidaPdet);
            // 
            // SalidaP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 346);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SalidaP";
            this.Text = "Salida de producto";
            this.Load += new System.EventHandler(this.SalidaP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SalidaPEncBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalidaPdetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SalidaPEncBindingSource;
        private System.Windows.Forms.BindingSource SalidaPdetBindingSource;
    }
}