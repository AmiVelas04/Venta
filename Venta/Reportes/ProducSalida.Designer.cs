namespace Venta.Reportes
{
    partial class ProducSalida
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
            this.TiendaInterDetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TiendaInterEncaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TiendaInterDetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TiendaInterEncaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Rpv1
            // 
            this.Rpv1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Detalle";
            reportDataSource1.Value = this.TiendaInterDetBindingSource;
            reportDataSource2.Name = "Encabezado";
            reportDataSource2.Value = this.TiendaInterEncaBindingSource;
            this.Rpv1.LocalReport.DataSources.Add(reportDataSource1);
            this.Rpv1.LocalReport.DataSources.Add(reportDataSource2);
            this.Rpv1.LocalReport.ReportEmbeddedResource = "Venta.Reportes.ProducSalida.rdlc";
            this.Rpv1.Location = new System.Drawing.Point(0, 0);
            this.Rpv1.Name = "Rpv1";
            this.Rpv1.Size = new System.Drawing.Size(817, 286);
            this.Rpv1.TabIndex = 0;
            // 
            // TiendaInterDetBindingSource
            // 
            this.TiendaInterDetBindingSource.DataSource = typeof(Venta.Reportes.TiendaInterDet);
            // 
            // TiendaInterEncaBindingSource
            // 
            this.TiendaInterEncaBindingSource.DataSource = typeof(Venta.Reportes.TiendaInterEnca);
            // 
            // ProducSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 286);
            this.Controls.Add(this.Rpv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProducSalida";
            this.Text = "Salida de producto a producción";
            this.Load += new System.EventHandler(this.ProducSalida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TiendaInterDetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TiendaInterEncaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Rpv1;
        private System.Windows.Forms.BindingSource TiendaInterDetBindingSource;
        private System.Windows.Forms.BindingSource TiendaInterEncaBindingSource;
    }
}