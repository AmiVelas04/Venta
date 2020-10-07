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
            this.SalidaPEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SalidaPdetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RpvSalida = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SalidaPEncBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalidaPdetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SalidaPEncBindingSource
            // 
            this.SalidaPEncBindingSource.DataSource = typeof(Venta.Reportes.SalidaPEnc);
            // 
            // SalidaPdetBindingSource
            // 
            this.SalidaPdetBindingSource.DataSource = typeof(Venta.Reportes.SalidaPdet);
            // 
            // RpvSalida
            // 
            this.RpvSalida.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Encabezado";
            reportDataSource1.Value = this.SalidaPEncBindingSource;
            reportDataSource2.Name = "Detalle";
            reportDataSource2.Value = this.SalidaPdetBindingSource;
            this.RpvSalida.LocalReport.DataSources.Add(reportDataSource1);
            this.RpvSalida.LocalReport.DataSources.Add(reportDataSource2);
            this.RpvSalida.LocalReport.ReportEmbeddedResource = "Venta.Reportes.SalidaP.rdlc";
            this.RpvSalida.Location = new System.Drawing.Point(0, 0);
            this.RpvSalida.Name = "RpvSalida";
            this.RpvSalida.Size = new System.Drawing.Size(840, 346);
            this.RpvSalida.TabIndex = 0;
            // 
            // SalidaP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 346);
            this.Controls.Add(this.RpvSalida);
            this.Name = "SalidaP";
            this.Text = "Salida de producto";
            this.Load += new System.EventHandler(this.SalidaP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SalidaPEncBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalidaPdetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RpvSalida;
        private System.Windows.Forms.BindingSource SalidaPEncBindingSource;
        private System.Windows.Forms.BindingSource SalidaPdetBindingSource;
    }
}