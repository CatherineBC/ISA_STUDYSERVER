
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
            this.labelNama.Location = new System.Drawing.Point(750, 59);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(179, 20);
            this.labelNama.TabIndex = 3;
            this.labelNama.Text = "Selamat Datang , Nama";
            this.labelNama.Click += new System.EventHandler(this.labelNama_Click);
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(12, 108);
            this.dataGridViewData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowHeadersWidth = 62;
            this.dataGridViewData.RowTemplate.Height = 28;
            this.dataGridViewData.Size = new System.Drawing.Size(957, 335);
            this.dataGridViewData.TabIndex = 2;
            this.dataGridViewData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewData_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.konfirmasiTokoToolStripMenuItem,
            this.chatToolStripMenuItem,
            this.tambahBarangToolStripMenuItem,
            this.keranjangToolStripMenuItem,
            this.detailOrderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // konfirmasiTokoToolStripMenuItem
            // 
            this.konfirmasiTokoToolStripMenuItem.Name = "konfirmasiTokoToolStripMenuItem";
            this.konfirmasiTokoToolStripMenuItem.Size = new System.Drawing.Size(155, 29);
            this.konfirmasiTokoToolStripMenuItem.Text = "Konfirmasi Toko";
            this.konfirmasiTokoToolStripMenuItem.Click += new System.EventHandler(this.konfirmasiTokoToolStripMenuItem_Click);
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.chatToolStripMenuItem.Text = "Chat";
            this.chatToolStripMenuItem.Click += new System.EventHandler(this.chatToolStripMenuItem_Click);
            // 
            // tambahBarangToolStripMenuItem
            // 
            this.tambahBarangToolStripMenuItem.Name = "tambahBarangToolStripMenuItem";
            this.tambahBarangToolStripMenuItem.Size = new System.Drawing.Size(150, 29);
            this.tambahBarangToolStripMenuItem.Text = "Tambah Barang";
            this.tambahBarangToolStripMenuItem.Click += new System.EventHandler(this.tambahBarangToolStripMenuItem_Click);
            // 
            // keranjangToolStripMenuItem
            // 
            this.keranjangToolStripMenuItem.Name = "keranjangToolStripMenuItem";
            this.keranjangToolStripMenuItem.Size = new System.Drawing.Size(106, 29);
            this.keranjangToolStripMenuItem.Text = "Keranjang";
            this.keranjangToolStripMenuItem.Click += new System.EventHandler(this.keranjangToolStripMenuItem_Click);
            // 
            // detailOrderToolStripMenuItem
            // 
            this.detailOrderToolStripMenuItem.Name = "detailOrderToolStripMenuItem";
            this.detailOrderToolStripMenuItem.Size = new System.Drawing.Size(124, 29);
            this.detailOrderToolStripMenuItem.Text = "Detail Order";
            // 
            // FormMainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 458);
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