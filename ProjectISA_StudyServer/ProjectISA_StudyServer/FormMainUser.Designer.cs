
namespace ProjectISA_StudyServer
{
    partial class FormMainUser
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
            this.labelNama = new System.Windows.Forms.Label();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.konfirmasiTokoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tambahBarangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keranjangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Location = new System.Drawing.Point(667, 47);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(150, 16);
            this.labelNama.TabIndex = 3;
            this.labelNama.Text = "Selamat Datang , Nama";
            this.labelNama.Click += new System.EventHandler(this.labelNama_Click);
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(11, 86);
            this.dataGridViewData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowHeadersWidth = 62;
            this.dataGridViewData.RowTemplate.Height = 28;
            this.dataGridViewData.Size = new System.Drawing.Size(851, 268);
            this.dataGridViewData.TabIndex = 2;
            this.dataGridViewData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewData_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.konfirmasiTokoToolStripMenuItem,
            this.chatToolStripMenuItem,
            this.tambahBarangToolStripMenuItem,
            this.keranjangToolStripMenuItem,
            this.detailOrderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(872, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // konfirmasiTokoToolStripMenuItem
            // 
            this.konfirmasiTokoToolStripMenuItem.Name = "konfirmasiTokoToolStripMenuItem";
            this.konfirmasiTokoToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.konfirmasiTokoToolStripMenuItem.Text = "Konfirmasi Toko";
            this.konfirmasiTokoToolStripMenuItem.Click += new System.EventHandler(this.konfirmasiTokoToolStripMenuItem_Click);
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.chatToolStripMenuItem.Text = "Chat";
            this.chatToolStripMenuItem.Click += new System.EventHandler(this.chatToolStripMenuItem_Click);
            // 
            // tambahBarangToolStripMenuItem
            // 
            this.tambahBarangToolStripMenuItem.Name = "tambahBarangToolStripMenuItem";
            this.tambahBarangToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.tambahBarangToolStripMenuItem.Text = "Tambah Barang";
            this.tambahBarangToolStripMenuItem.Click += new System.EventHandler(this.tambahBarangToolStripMenuItem_Click);
            // 
            // keranjangToolStripMenuItem
            // 
            this.keranjangToolStripMenuItem.Name = "keranjangToolStripMenuItem";
            this.keranjangToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.keranjangToolStripMenuItem.Text = "Keranjang";
            this.keranjangToolStripMenuItem.Click += new System.EventHandler(this.keranjangToolStripMenuItem_Click);
            // 
            // detailOrderToolStripMenuItem
            // 
            this.detailOrderToolStripMenuItem.Name = "detailOrderToolStripMenuItem";
            this.detailOrderToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.detailOrderToolStripMenuItem.Text = "Detail Order";
            this.detailOrderToolStripMenuItem.Click += new System.EventHandler(this.detailOrderToolStripMenuItem_Click);
            // 
            // FormMainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 366);
            this.Controls.Add(this.labelNama);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMainUser";
            this.Text = "FormMainUser";
            this.Load += new System.EventHandler(this.FormMainUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem konfirmasiTokoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tambahBarangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keranjangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailOrderToolStripMenuItem;
    }
}