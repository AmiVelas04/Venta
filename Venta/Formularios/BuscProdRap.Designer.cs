namespace Venta.Formularios
{
    partial class BuscProdRap
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
            this.BtnBusc = new System.Windows.Forms.Button();
            this.TxtNomB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PanCent = new System.Windows.Forms.Panel();
            this.PanntCent = new System.Windows.Forms.Panel();
            this.Dgv1 = new System.Windows.Forms.DataGridView();
            this.PanIntDer = new System.Windows.Forms.Panel();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.PicImagen = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanSup.SuspendLayout();
            this.PanCent.SuspendLayout();
            this.PanntCent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.PanIntDer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // PanSup
            // 
            this.PanSup.Controls.Add(this.BtnBusc);
            this.PanSup.Controls.Add(this.TxtNomB);
            this.PanSup.Controls.Add(this.label4);
            this.PanSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSup.Location = new System.Drawing.Point(0, 0);
            this.PanSup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PanSup.Name = "PanSup";
            this.PanSup.Size = new System.Drawing.Size(735, 65);
            this.PanSup.TabIndex = 0;
            // 
            // BtnBusc
            // 
            this.BtnBusc.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnBusc.Location = new System.Drawing.Point(616, 0);
            this.BtnBusc.Name = "BtnBusc";
            this.BtnBusc.Size = new System.Drawing.Size(119, 65);
            this.BtnBusc.TabIndex = 2;
            this.BtnBusc.Text = "Buscar";
            this.BtnBusc.UseVisualStyleBackColor = true;
            this.BtnBusc.Click += new System.EventHandler(this.BtnBusc_Click);
            // 
            // TxtNomB
            // 
            this.TxtNomB.Location = new System.Drawing.Point(97, 22);
            this.TxtNomB.Name = "TxtNomB";
            this.TxtNomB.Size = new System.Drawing.Size(312, 23);
            this.TxtNomB.TabIndex = 1;
            this.TxtNomB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNomB_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Producto";
            // 
            // PanCent
            // 
            this.PanCent.Controls.Add(this.PanntCent);
            this.PanCent.Controls.Add(this.PanIntDer);
            this.PanCent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCent.Location = new System.Drawing.Point(0, 65);
            this.PanCent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PanCent.Name = "PanCent";
            this.PanCent.Size = new System.Drawing.Size(735, 338);
            this.PanCent.TabIndex = 1;
            // 
            // PanntCent
            // 
            this.PanntCent.Controls.Add(this.Dgv1);
            this.PanntCent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanntCent.Location = new System.Drawing.Point(0, 0);
            this.PanntCent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PanntCent.Name = "PanntCent";
            this.PanntCent.Size = new System.Drawing.Size(562, 338);
            this.PanntCent.TabIndex = 1;
            // 
            // Dgv1
            // 
            this.Dgv1.AllowUserToAddRows = false;
            this.Dgv1.AllowUserToDeleteRows = false;
            this.Dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Dgv1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv1.Location = new System.Drawing.Point(0, 0);
            this.Dgv1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.ReadOnly = true;
            this.Dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv1.Size = new System.Drawing.Size(562, 338);
            this.Dgv1.TabIndex = 0;
            this.Dgv1.Click += new System.EventHandler(this.Dgv1_Click);
            // 
            // PanIntDer
            // 
            this.PanIntDer.Controls.Add(this.BtnAdd);
            this.PanIntDer.Controls.Add(this.PicImagen);
            this.PanIntDer.Controls.Add(this.label3);
            this.PanIntDer.Controls.Add(this.TxtNom);
            this.PanIntDer.Controls.Add(this.label2);
            this.PanIntDer.Controls.Add(this.TxtCod);
            this.PanIntDer.Controls.Add(this.label1);
            this.PanIntDer.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanIntDer.Location = new System.Drawing.Point(562, 0);
            this.PanIntDer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PanIntDer.Name = "PanIntDer";
            this.PanIntDer.Size = new System.Drawing.Size(173, 338);
            this.PanIntDer.TabIndex = 0;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnAdd.Location = new System.Drawing.Point(0, 291);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(173, 47);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Agregar Producto";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PicImagen
            // 
            this.PicImagen.Location = new System.Drawing.Point(25, 171);
            this.PicImagen.Name = "PicImagen";
            this.PicImagen.Size = new System.Drawing.Size(125, 100);
            this.PicImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicImagen.TabIndex = 5;
            this.PicImagen.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Imagen";
            // 
            // TxtNom
            // 
            this.TxtNom.Enabled = false;
            this.TxtNom.Location = new System.Drawing.Point(25, 82);
            this.TxtNom.Multiline = true;
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(131, 53);
            this.TxtNom.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del producto";
            // 
            // TxtCod
            // 
            this.TxtCod.Enabled = false;
            this.TxtCod.Location = new System.Drawing.Point(25, 32);
            this.TxtCod.Name = "TxtCod";
            this.TxtCod.Size = new System.Drawing.Size(131, 23);
            this.TxtCod.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código del producto";
            // 
            // BuscProdRap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 403);
            this.Controls.Add(this.PanCent);
            this.Controls.Add(this.PanSup);
            this.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "BuscProdRap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda rápida de productos";
            this.PanSup.ResumeLayout(false);
            this.PanSup.PerformLayout();
            this.PanCent.ResumeLayout(false);
            this.PanntCent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.PanIntDer.ResumeLayout(false);
            this.PanIntDer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanSup;
        private System.Windows.Forms.Panel PanCent;
        private System.Windows.Forms.Panel PanntCent;
        private System.Windows.Forms.DataGridView Dgv1;
        private System.Windows.Forms.Panel PanIntDer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.PictureBox PicImagen;
        private System.Windows.Forms.Button BtnBusc;
        private System.Windows.Forms.TextBox TxtNomB;
        private System.Windows.Forms.Label label4;
    }
}