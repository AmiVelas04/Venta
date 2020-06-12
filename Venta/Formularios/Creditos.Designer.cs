namespace Venta.Formularios
{
    partial class Creditos
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
            this.PanSup = new System.Windows.Forms.Panel();
            this.PanMed = new System.Windows.Forms.Panel();
            this.PanInf = new System.Windows.Forms.Panel();
            this.GbxClinete = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CboCli = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDpi = new System.Windows.Forms.TextBox();
            this.GbxCredito = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CboCred = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtSaldo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtTot = new System.Windows.Forms.TextBox();
            this.GbxPago = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtPago = new System.Windows.Forms.TextBox();
            this.BtnPago = new System.Windows.Forms.Button();
            this.DgvPagos = new System.Windows.Forms.DataGridView();
            this.PanSup.SuspendLayout();
            this.PanMed.SuspendLayout();
            this.PanInf.SuspendLayout();
            this.GbxClinete.SuspendLayout();
            this.GbxCredito.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.GbxPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // PanSup
            // 
            this.PanSup.Controls.Add(this.GbxClinete);
            this.PanSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSup.Location = new System.Drawing.Point(0, 0);
            this.PanSup.Name = "PanSup";
            this.PanSup.Size = new System.Drawing.Size(833, 119);
            this.PanSup.TabIndex = 0;
            // 
            // PanMed
            // 
            this.PanMed.Controls.Add(this.GbxCredito);
            this.PanMed.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanMed.Location = new System.Drawing.Point(0, 119);
            this.PanMed.Name = "PanMed";
            this.PanMed.Size = new System.Drawing.Size(833, 137);
            this.PanMed.TabIndex = 1;
            // 
            // PanInf
            // 
            this.PanInf.Controls.Add(this.DgvPagos);
            this.PanInf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanInf.Location = new System.Drawing.Point(0, 256);
            this.PanInf.Name = "PanInf";
            this.PanInf.Size = new System.Drawing.Size(833, 124);
            this.PanInf.TabIndex = 2;
            // 
            // GbxClinete
            // 
            this.GbxClinete.Controls.Add(this.TxtDpi);
            this.GbxClinete.Controls.Add(this.label5);
            this.GbxClinete.Controls.Add(this.TxtNit);
            this.GbxClinete.Controls.Add(this.label4);
            this.GbxClinete.Controls.Add(this.TxtTel);
            this.GbxClinete.Controls.Add(this.label3);
            this.GbxClinete.Controls.Add(this.TxtDir);
            this.GbxClinete.Controls.Add(this.label2);
            this.GbxClinete.Controls.Add(this.CboCli);
            this.GbxClinete.Controls.Add(this.label1);
            this.GbxClinete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxClinete.Location = new System.Drawing.Point(0, 0);
            this.GbxClinete.Name = "GbxClinete";
            this.GbxClinete.Size = new System.Drawing.Size(833, 119);
            this.GbxClinete.TabIndex = 0;
            this.GbxClinete.TabStop = false;
            this.GbxClinete.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // CboCli
            // 
            this.CboCli.FormattingEnabled = true;
            this.CboCli.Location = new System.Drawing.Point(28, 32);
            this.CboCli.Name = "CboCli";
            this.CboCli.Size = new System.Drawing.Size(163, 21);
            this.CboCli.TabIndex = 1;
            this.CboCli.SelectedIndexChanged += new System.EventHandler(this.CboCli_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Direccion";
            // 
            // TxtDir
            // 
            this.TxtDir.Enabled = false;
            this.TxtDir.Location = new System.Drawing.Point(28, 83);
            this.TxtDir.Name = "TxtDir";
            this.TxtDir.Size = new System.Drawing.Size(163, 20);
            this.TxtDir.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Telefono";
            // 
            // TxtTel
            // 
            this.TxtTel.Enabled = false;
            this.TxtTel.Location = new System.Drawing.Point(256, 33);
            this.TxtTel.Name = "TxtTel";
            this.TxtTel.Size = new System.Drawing.Size(143, 20);
            this.TxtTel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nit";
            // 
            // TxtNit
            // 
            this.TxtNit.Enabled = false;
            this.TxtNit.Location = new System.Drawing.Point(256, 83);
            this.TxtNit.Name = "TxtNit";
            this.TxtNit.Size = new System.Drawing.Size(143, 20);
            this.TxtNit.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dpi";
            // 
            // TxtDpi
            // 
            this.TxtDpi.Enabled = false;
            this.TxtDpi.Location = new System.Drawing.Point(444, 33);
            this.TxtDpi.Name = "TxtDpi";
            this.TxtDpi.Size = new System.Drawing.Size(124, 20);
            this.TxtDpi.TabIndex = 9;
            // 
            // GbxCredito
            // 
            this.GbxCredito.Controls.Add(this.panel2);
            this.GbxCredito.Controls.Add(this.panel1);
            this.GbxCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxCredito.Location = new System.Drawing.Point(0, 0);
            this.GbxCredito.Name = "GbxCredito";
            this.GbxCredito.Size = new System.Drawing.Size(833, 137);
            this.GbxCredito.TabIndex = 0;
            this.GbxCredito.TabStop = false;
            this.GbxCredito.Text = "Datos del credito";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtTot);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TxtSaldo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CboCred);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 118);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GbxPago);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(442, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 118);
            this.panel2.TabIndex = 1;
            // 
            // CboCred
            // 
            this.CboCred.FormattingEnabled = true;
            this.CboCred.Location = new System.Drawing.Point(25, 28);
            this.CboCred.Name = "CboCred";
            this.CboCred.Size = new System.Drawing.Size(90, 21);
            this.CboCred.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "No. de Credito";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Saldo";
            // 
            // TxtSaldo
            // 
            this.TxtSaldo.Location = new System.Drawing.Point(25, 80);
            this.TxtSaldo.Name = "TxtSaldo";
            this.TxtSaldo.Size = new System.Drawing.Size(100, 20);
            this.TxtSaldo.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(181, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Monto";
            // 
            // TxtTot
            // 
            this.TxtTot.Location = new System.Drawing.Point(184, 28);
            this.TxtTot.Name = "TxtTot";
            this.TxtTot.Size = new System.Drawing.Size(100, 20);
            this.TxtTot.TabIndex = 7;
            // 
            // GbxPago
            // 
            this.GbxPago.Controls.Add(this.BtnPago);
            this.GbxPago.Controls.Add(this.TxtPago);
            this.GbxPago.Controls.Add(this.label9);
            this.GbxPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxPago.Location = new System.Drawing.Point(0, 0);
            this.GbxPago.Name = "GbxPago";
            this.GbxPago.Size = new System.Drawing.Size(388, 118);
            this.GbxPago.TabIndex = 0;
            this.GbxPago.TabStop = false;
            this.GbxPago.Text = "Pagos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Monto del pago";
            // 
            // TxtPago
            // 
            this.TxtPago.Location = new System.Drawing.Point(39, 47);
            this.TxtPago.Name = "TxtPago";
            this.TxtPago.Size = new System.Drawing.Size(100, 20);
            this.TxtPago.TabIndex = 1;
            // 
            // BtnPago
            // 
            this.BtnPago.Location = new System.Drawing.Point(206, 38);
            this.BtnPago.Name = "BtnPago";
            this.BtnPago.Size = new System.Drawing.Size(100, 39);
            this.BtnPago.TabIndex = 2;
            this.BtnPago.Text = "Pago";
            this.BtnPago.UseVisualStyleBackColor = true;
            // 
            // DgvPagos
            // 
            this.DgvPagos.AllowUserToAddRows = false;
            this.DgvPagos.AllowUserToDeleteRows = false;
            this.DgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPagos.Location = new System.Drawing.Point(0, 0);
            this.DgvPagos.Name = "DgvPagos";
            this.DgvPagos.ReadOnly = true;
            this.DgvPagos.Size = new System.Drawing.Size(833, 124);
            this.DgvPagos.TabIndex = 0;
            // 
            // Creditos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 380);
            this.Controls.Add(this.PanInf);
            this.Controls.Add(this.PanMed);
            this.Controls.Add(this.PanSup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Creditos";
            this.Text = "Creditos";
            this.Load += new System.EventHandler(this.Creditos_Load);
            this.PanSup.ResumeLayout(false);
            this.PanMed.ResumeLayout(false);
            this.PanInf.ResumeLayout(false);
            this.GbxClinete.ResumeLayout(false);
            this.GbxClinete.PerformLayout();
            this.GbxCredito.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.GbxPago.ResumeLayout(false);
            this.GbxPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPagos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanSup;
        private System.Windows.Forms.GroupBox GbxClinete;
        private System.Windows.Forms.TextBox TxtDpi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtNit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtTel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboCli;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanMed;
        private System.Windows.Forms.GroupBox GbxCredito;
        private System.Windows.Forms.Panel PanInf;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtTot;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtSaldo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CboCred;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox GbxPago;
        private System.Windows.Forms.Button BtnPago;
        private System.Windows.Forms.TextBox TxtPago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView DgvPagos;
    }
}