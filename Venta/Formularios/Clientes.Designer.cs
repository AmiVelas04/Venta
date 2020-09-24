namespace Venta.Formularios
{
    partial class Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes));
            this.PanBaj = new System.Windows.Forms.Panel();
            this.BtnNvo = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.TxtCliNom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PanCentral = new System.Windows.Forms.Panel();
            this.Dgv1 = new System.Windows.Forms.DataGridView();
            this.PanIz = new System.Windows.Forms.Panel();
            this.GbxdataCli = new System.Windows.Forms.GroupBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtCre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtTel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDpi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanBaj.SuspendLayout();
            this.PanCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.PanIz.SuspendLayout();
            this.GbxdataCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanBaj
            // 
            this.PanBaj.Controls.Add(this.BtnNvo);
            this.PanBaj.Controls.Add(this.BtnEditar);
            this.PanBaj.Controls.Add(this.TxtCliNom);
            this.PanBaj.Controls.Add(this.label7);
            this.PanBaj.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanBaj.Location = new System.Drawing.Point(234, 554);
            this.PanBaj.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PanBaj.Name = "PanBaj";
            this.PanBaj.Size = new System.Drawing.Size(799, 57);
            this.PanBaj.TabIndex = 1;
            // 
            // BtnNvo
            // 
            this.BtnNvo.Location = new System.Drawing.Point(366, 20);
            this.BtnNvo.Name = "BtnNvo";
            this.BtnNvo.Size = new System.Drawing.Size(115, 30);
            this.BtnNvo.TabIndex = 3;
            this.BtnNvo.Text = "Nuevo";
            this.BtnNvo.UseVisualStyleBackColor = true;
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(245, 19);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(115, 30);
            this.BtnEditar.TabIndex = 2;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // TxtCliNom
            // 
            this.TxtCliNom.Location = new System.Drawing.Point(8, 23);
            this.TxtCliNom.Name = "TxtCliNom";
            this.TxtCliNom.Size = new System.Drawing.Size(209, 26);
            this.TxtCliNom.TabIndex = 1;
            this.TxtCliNom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCliNom_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nombre";
            // 
            // PanCentral
            // 
            this.PanCentral.Controls.Add(this.Dgv1);
            this.PanCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCentral.Location = new System.Drawing.Point(234, 0);
            this.PanCentral.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PanCentral.Name = "PanCentral";
            this.PanCentral.Size = new System.Drawing.Size(799, 554);
            this.PanCentral.TabIndex = 2;
            // 
            // Dgv1
            // 
            this.Dgv1.AllowUserToAddRows = false;
            this.Dgv1.AllowUserToDeleteRows = false;
            this.Dgv1.AllowUserToResizeColumns = false;
            this.Dgv1.AllowUserToResizeRows = false;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv1.Location = new System.Drawing.Point(0, 0);
            this.Dgv1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.ReadOnly = true;
            this.Dgv1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.Dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv1.Size = new System.Drawing.Size(799, 554);
            this.Dgv1.TabIndex = 0;
            // 
            // PanIz
            // 
            this.PanIz.Controls.Add(this.GbxdataCli);
            this.PanIz.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanIz.Location = new System.Drawing.Point(0, 0);
            this.PanIz.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PanIz.Name = "PanIz";
            this.PanIz.Size = new System.Drawing.Size(234, 611);
            this.PanIz.TabIndex = 0;
            // 
            // GbxdataCli
            // 
            this.GbxdataCli.Controls.Add(this.BtnGuardar);
            this.GbxdataCli.Controls.Add(this.TxtCre);
            this.GbxdataCli.Controls.Add(this.label6);
            this.GbxdataCli.Controls.Add(this.TxtTel);
            this.GbxdataCli.Controls.Add(this.label5);
            this.GbxdataCli.Controls.Add(this.TxtDpi);
            this.GbxdataCli.Controls.Add(this.label4);
            this.GbxdataCli.Controls.Add(this.TxtNit);
            this.GbxdataCli.Controls.Add(this.label3);
            this.GbxdataCli.Controls.Add(this.TxtDir);
            this.GbxdataCli.Controls.Add(this.label2);
            this.GbxdataCli.Controls.Add(this.TxtNom);
            this.GbxdataCli.Controls.Add(this.label1);
            this.GbxdataCli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxdataCli.Location = new System.Drawing.Point(0, 0);
            this.GbxdataCli.Name = "GbxdataCli";
            this.GbxdataCli.Size = new System.Drawing.Size(234, 611);
            this.GbxdataCli.TabIndex = 0;
            this.GbxdataCli.TabStop = false;
            this.GbxdataCli.Text = "Datos Del Cliente";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnGuardar.Location = new System.Drawing.Point(3, 574);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(228, 34);
            this.BtnGuardar.TabIndex = 25;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TxtCre
            // 
            this.TxtCre.Location = new System.Drawing.Point(14, 444);
            this.TxtCre.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TxtCre.Name = "TxtCre";
            this.TxtCre.Size = new System.Drawing.Size(197, 26);
            this.TxtCre.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 421);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 19);
            this.label6.TabIndex = 23;
            this.label6.Text = "Monto de credito";
            // 
            // TxtTel
            // 
            this.TxtTel.Location = new System.Drawing.Point(14, 373);
            this.TxtTel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TxtTel.MaxLength = 8;
            this.TxtTel.Name = "TxtTel";
            this.TxtTel.Size = new System.Drawing.Size(197, 26);
            this.TxtTel.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 350);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 19);
            this.label5.TabIndex = 21;
            this.label5.Text = "Teléfono";
            // 
            // TxtDpi
            // 
            this.TxtDpi.Location = new System.Drawing.Point(14, 300);
            this.TxtDpi.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TxtDpi.MaxLength = 13;
            this.TxtDpi.Name = "TxtDpi";
            this.TxtDpi.Size = new System.Drawing.Size(197, 26);
            this.TxtDpi.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 277);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Dpi";
            // 
            // TxtNit
            // 
            this.TxtNit.Location = new System.Drawing.Point(14, 234);
            this.TxtNit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TxtNit.Name = "TxtNit";
            this.TxtNit.Size = new System.Drawing.Size(197, 26);
            this.TxtNit.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Nit";
            // 
            // TxtDir
            // 
            this.TxtDir.Location = new System.Drawing.Point(14, 163);
            this.TxtDir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TxtDir.Name = "TxtDir";
            this.TxtDir.Size = new System.Drawing.Size(197, 26);
            this.TxtDir.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Dirección";
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(14, 74);
            this.TxtNom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(197, 26);
            this.TxtNom.TabIndex = 14;
            this.TxtNom.Tag = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre";
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 611);
            this.Controls.Add(this.PanCentral);
            this.Controls.Add(this.PanBaj);
            this.Controls.Add(this.PanIz);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Clientes";
            this.Text = "Clientes";
            this.PanBaj.ResumeLayout(false);
            this.PanBaj.PerformLayout();
            this.PanCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.PanIz.ResumeLayout(false);
            this.GbxdataCli.ResumeLayout(false);
            this.GbxdataCli.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanBaj;
        private System.Windows.Forms.Panel PanCentral;
        private System.Windows.Forms.DataGridView Dgv1;
        private System.Windows.Forms.TextBox TxtCliNom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PanIz;
        private System.Windows.Forms.GroupBox GbxdataCli;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox TxtCre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtTel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtDpi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtNit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnNvo;
    }
}