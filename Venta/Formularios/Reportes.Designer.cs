﻿namespace Venta.Formularios
{
    partial class Reportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reportes));
            this.PanIz = new System.Windows.Forms.Panel();
            this.GbxProd = new System.Windows.Forms.GroupBox();
            this.BtnInventario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PanDer = new System.Windows.Forms.Panel();
            this.GbxVentas = new System.Windows.Forms.GroupBox();
            this.BtnVenta = new System.Windows.Forms.Button();
            this.DtpFin = new System.Windows.Forms.DateTimePicker();
            this.DtpIni = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GbxFaltantes = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCant = new System.Windows.Forms.TextBox();
            this.BtnVer = new System.Windows.Forms.Button();
            this.PanIz.SuspendLayout();
            this.GbxProd.SuspendLayout();
            this.PanDer.SuspendLayout();
            this.GbxVentas.SuspendLayout();
            this.GbxFaltantes.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanIz
            // 
            this.PanIz.Controls.Add(this.GbxProd);
            this.PanIz.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanIz.Location = new System.Drawing.Point(0, 0);
            this.PanIz.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PanIz.Name = "PanIz";
            this.PanIz.Size = new System.Drawing.Size(544, 590);
            this.PanIz.TabIndex = 0;
            // 
            // GbxProd
            // 
            this.GbxProd.Controls.Add(this.GbxFaltantes);
            this.GbxProd.Controls.Add(this.BtnInventario);
            this.GbxProd.Controls.Add(this.label1);
            this.GbxProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxProd.Location = new System.Drawing.Point(0, 0);
            this.GbxProd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GbxProd.Name = "GbxProd";
            this.GbxProd.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GbxProd.Size = new System.Drawing.Size(544, 590);
            this.GbxProd.TabIndex = 0;
            this.GbxProd.TabStop = false;
            this.GbxProd.Text = "Productos";
            // 
            // BtnInventario
            // 
            this.BtnInventario.Location = new System.Drawing.Point(30, 68);
            this.BtnInventario.Name = "BtnInventario";
            this.BtnInventario.Size = new System.Drawing.Size(126, 50);
            this.BtnInventario.TabIndex = 1;
            this.BtnInventario.Text = "Inventario";
            this.BtnInventario.UseVisualStyleBackColor = true;
            this.BtnInventario.Click += new System.EventHandler(this.BtnInventario_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mostrar Inventario";
            // 
            // PanDer
            // 
            this.PanDer.Controls.Add(this.GbxVentas);
            this.PanDer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanDer.Location = new System.Drawing.Point(544, 0);
            this.PanDer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PanDer.Name = "PanDer";
            this.PanDer.Size = new System.Drawing.Size(586, 590);
            this.PanDer.TabIndex = 1;
            // 
            // GbxVentas
            // 
            this.GbxVentas.Controls.Add(this.BtnVenta);
            this.GbxVentas.Controls.Add(this.DtpFin);
            this.GbxVentas.Controls.Add(this.DtpIni);
            this.GbxVentas.Controls.Add(this.label3);
            this.GbxVentas.Controls.Add(this.label2);
            this.GbxVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxVentas.Location = new System.Drawing.Point(0, 0);
            this.GbxVentas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GbxVentas.Name = "GbxVentas";
            this.GbxVentas.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GbxVentas.Size = new System.Drawing.Size(586, 590);
            this.GbxVentas.TabIndex = 0;
            this.GbxVentas.TabStop = false;
            this.GbxVentas.Text = "Ventas";
            // 
            // BtnVenta
            // 
            this.BtnVenta.Location = new System.Drawing.Point(232, 100);
            this.BtnVenta.Name = "BtnVenta";
            this.BtnVenta.Size = new System.Drawing.Size(126, 53);
            this.BtnVenta.TabIndex = 4;
            this.BtnVenta.Text = "Ver ventas";
            this.BtnVenta.UseVisualStyleBackColor = true;
            this.BtnVenta.Click += new System.EventHandler(this.BtnVenta_Click);
            // 
            // DtpFin
            // 
            this.DtpFin.Location = new System.Drawing.Point(321, 60);
            this.DtpFin.Name = "DtpFin";
            this.DtpFin.Size = new System.Drawing.Size(253, 23);
            this.DtpFin.TabIndex = 3;
            // 
            // DtpIni
            // 
            this.DtpIni.Location = new System.Drawing.Point(23, 60);
            this.DtpIni.Name = "DtpIni";
            this.DtpIni.Size = new System.Drawing.Size(266, 23);
            this.DtpIni.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fecha de Fin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha de inicio";
            // 
            // GbxFaltantes
            // 
            this.GbxFaltantes.Controls.Add(this.BtnVer);
            this.GbxFaltantes.Controls.Add(this.TxtCant);
            this.GbxFaltantes.Controls.Add(this.label4);
            this.GbxFaltantes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GbxFaltantes.Location = new System.Drawing.Point(4, 440);
            this.GbxFaltantes.Name = "GbxFaltantes";
            this.GbxFaltantes.Size = new System.Drawing.Size(536, 147);
            this.GbxFaltantes.TabIndex = 2;
            this.GbxFaltantes.TabStop = false;
            this.GbxFaltantes.Text = "Conteo de productos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cantidad minima";
            // 
            // TxtCant
            // 
            this.TxtCant.Location = new System.Drawing.Point(108, 75);
            this.TxtCant.Name = "TxtCant";
            this.TxtCant.Size = new System.Drawing.Size(100, 23);
            this.TxtCant.TabIndex = 1;
            // 
            // BtnVer
            // 
            this.BtnVer.Location = new System.Drawing.Point(254, 70);
            this.BtnVer.Name = "BtnVer";
            this.BtnVer.Size = new System.Drawing.Size(111, 28);
            this.BtnVer.TabIndex = 2;
            this.BtnVer.Text = "Ver productos";
            this.BtnVer.UseVisualStyleBackColor = true;
            this.BtnVer.Click += new System.EventHandler(this.BtnVer_Click);
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1130, 590);
            this.Controls.Add(this.PanDer);
            this.Controls.Add(this.PanIz);
            this.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.PanIz.ResumeLayout(false);
            this.GbxProd.ResumeLayout(false);
            this.GbxProd.PerformLayout();
            this.PanDer.ResumeLayout(false);
            this.GbxVentas.ResumeLayout(false);
            this.GbxVentas.PerformLayout();
            this.GbxFaltantes.ResumeLayout(false);
            this.GbxFaltantes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanIz;
        private System.Windows.Forms.Panel PanDer;
        private System.Windows.Forms.GroupBox GbxProd;
        private System.Windows.Forms.GroupBox GbxVentas;
        private System.Windows.Forms.Button BtnInventario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnVenta;
        private System.Windows.Forms.DateTimePicker DtpFin;
        private System.Windows.Forms.DateTimePicker DtpIni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GbxFaltantes;
        private System.Windows.Forms.Button BtnVer;
        private System.Windows.Forms.TextBox TxtCant;
        private System.Windows.Forms.Label label4;
    }
}