namespace Venta.Reportes
{
    partial class Conces
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
            this.ConceEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ConceDetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RepConc = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ConceEncBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConceDetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ConceEncBindingSource
            // 
            this.ConceEncBindingSource.DataSource = typeof(Venta.Reportes.ConceEnc);
            // 
            // ConceDetBindingSource
            // 
            this.ConceDetBindingSource.DataSource = typeof(Venta.Reportes.ConceDet);
            // 
            // RepConc
            // 
            this.RepConc.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Encabezado";
            reportDataSource1.Value = this.ConceEncBindingSource;
            reportDataSource2.Name = "Detalle";
            reportDataSource2.Value = this.ConceDetBindingSource;
            this.RepConc.LocalReport.DataSources.Add(reportDataSource1);
            this.RepConc.LocalReport.DataSources.Add(reportDataSource2);
            this.RepConc.LocalReport.ReportEmbeddedResource = "Venta.Reportes.Conces.rdlc";
            this.RepConc.Location = new System.Drawing.Point(0, 0);
            this.RepConc.Name = "RepConc";
            this.RepConc.Size = new System.Drawing.Size(872, 342);
            this.RepConc.TabIndex = 0;
            // 
            // Conces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 342);
            this.Controls.Add(this.RepConc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Conces";
            this.Text = "Conces";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Conces_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConceEncBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConceDetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RepConc;
        private System.Windows.Forms.BindingSource ConceEncBindingSource;
        private System.Windows.Forms.BindingSource ConceDetBindingSource;
    }
}