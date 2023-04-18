
namespace ProjectISA_StudyServer
{
    partial class FormBeli
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
            this.textBoxNamaBarang = new System.Windows.Forms.TextBox();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonTambah = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxHarga = new System.Windows.Forms.TextBox();
            this.labelStok = new System.Windows.Forms.Label();
            this.numericUpDownStok = new System.Windows.Forms.NumericUpDown();
            this.textBoxDeskripsi = new System.Windows.Forms.TextBox();
            this.labelNama = new System.Windows.Forms.Label();
            this.labelHarga = new System.Windows.Forms.Label();
            this.labelDeskripsi = new System.Windows.Forms.Label();
            this.labelBeli = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStok)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNamaBarang
            // 
            this.textBoxNamaBarang.Enabled = false;
            this.textBoxNamaBarang.Location = new System.Drawing.Point(199, 30);
            this.textBoxNamaBarang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNamaBarang.Name = "textBoxNamaBarang";
            this.textBoxNamaBarang.Size = new System.Drawing.Size(232, 22);
            this.textBoxNamaBarang.TabIndex = 14;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.LightCoral;
            this.buttonKeluar.Location = new System.Drawing.Point(29, 348);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(123, 36);
            this.buttonKeluar.TabIndex = 44;
            this.buttonKeluar.Text = "Keluar";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.LightCoral;
            this.buttonTambah.Location = new System.Drawing.Point(308, 348);
            this.buttonTambah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(123, 36);
            this.buttonTambah.TabIndex = 43;
            this.buttonTambah.Text = "Tambah";
            this.buttonTambah.UseVisualStyleBackColor = false;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.textBoxHarga);
            this.panel1.Controls.Add(this.labelStok);
            this.panel1.Controls.Add(this.numericUpDownStok);
            this.panel1.Controls.Add(this.textBoxNamaBarang);
            this.panel1.Controls.Add(this.textBoxDeskripsi);
            this.panel1.Controls.Add(this.labelNama);
            this.panel1.Controls.Add(this.labelHarga);
            this.panel1.Controls.Add(this.labelDeskripsi);
            this.panel1.Location = new System.Drawing.Point(-7, 76);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 251);
            this.panel1.TabIndex = 42;
            // 
            // textBoxHarga
            // 
            this.textBoxHarga.Enabled = false;
            this.textBoxHarga.Location = new System.Drawing.Point(199, 138);
            this.textBoxHarga.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxHarga.Name = "textBoxHarga";
            this.textBoxHarga.Size = new System.Drawing.Size(232, 22);
            this.textBoxHarga.TabIndex = 17;
            // 
            // labelStok
            // 
            this.labelStok.AutoSize = true;
            this.labelStok.Location = new System.Drawing.Point(33, 186);
            this.labelStok.Name = "labelStok";
            this.labelStok.Size = new System.Drawing.Size(40, 16);
            this.labelStok.TabIndex = 16;
            this.labelStok.Text = "Stok :";
            // 
            // numericUpDownStok
            // 
            this.numericUpDownStok.Location = new System.Drawing.Point(199, 185);
            this.numericUpDownStok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownStok.Name = "numericUpDownStok";
            this.numericUpDownStok.Size = new System.Drawing.Size(231, 22);
            this.numericUpDownStok.TabIndex = 15;
            // 
            // textBoxDeskripsi
            // 
            this.textBoxDeskripsi.Location = new System.Drawing.Point(199, 68);
            this.textBoxDeskripsi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDeskripsi.Multiline = true;
            this.textBoxDeskripsi.Name = "textBoxDeskripsi";
            this.textBoxDeskripsi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDeskripsi.Size = new System.Drawing.Size(232, 56);
            this.textBoxDeskripsi.TabIndex = 13;
            // 
            // labelNama
            // 
            this.labelNama.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid;
            this.labelNama.AutoSize = true;
            this.labelNama.Location = new System.Drawing.Point(33, 30);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(97, 16);
            this.labelNama.TabIndex = 9;
            this.labelNama.Text = "Nama Barang :";
            // 
            // labelHarga
            // 
            this.labelHarga.AutoSize = true;
            this.labelHarga.Location = new System.Drawing.Point(33, 138);
            this.labelHarga.Name = "labelHarga";
            this.labelHarga.Size = new System.Drawing.Size(54, 16);
            this.labelHarga.TabIndex = 5;
            this.labelHarga.Text = "Harga : ";
            // 
            // labelDeskripsi
            // 
            this.labelDeskripsi.AutoSize = true;
            this.labelDeskripsi.Location = new System.Drawing.Point(33, 70);
            this.labelDeskripsi.Name = "labelDeskripsi";
            this.labelDeskripsi.Size = new System.Drawing.Size(117, 16);
            this.labelDeskripsi.TabIndex = 4;
            this.labelDeskripsi.Text = "Deksripsi Barang :";
            // 
            // labelBeli
            // 
            this.labelBeli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.labelBeli.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBeli.ForeColor = System.Drawing.Color.LightCoral;
            this.labelBeli.Location = new System.Drawing.Point(-1, -6);
            this.labelBeli.Name = "labelBeli";
            this.labelBeli.Size = new System.Drawing.Size(495, 89);
            this.labelBeli.TabIndex = 41;
            this.labelBeli.Text = "Tambah";
            this.labelBeli.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormBeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 401);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelBeli);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormBeli";
            this.Text = "FormBeli";
            this.Load += new System.EventHandler(this.FormBeli_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonTambah;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelStok;
        private System.Windows.Forms.NumericUpDown numericUpDownStok;
        private System.Windows.Forms.TextBox textBoxDeskripsi;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Label labelHarga;
        private System.Windows.Forms.Label labelDeskripsi;
        private System.Windows.Forms.Label labelBeli;
        private System.Windows.Forms.TextBox textBoxHarga;
        public System.Windows.Forms.TextBox textBoxNamaBarang;
    }
}