
namespace ProjectISA_StudyServer
{
    partial class FormListChat
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
            this.buttonTambah = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.dataGridViewDftrCs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDftrCs)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.Navy;
            this.buttonTambah.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.White;
            this.buttonTambah.Location = new System.Drawing.Point(318, 442);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(142, 38);
            this.buttonTambah.TabIndex = 28;
            this.buttonTambah.Text = "TAMBAH";
            this.buttonTambah.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightCoral;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1308, 55);
            this.label1.TabIndex = 25;
            this.label1.Text = "DAFTAR SEMUA PESAN CUSTOMER SERVICE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Navy;
            this.buttonExit.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(18, 442);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(142, 38);
            this.buttonExit.TabIndex = 27;
            this.buttonExit.Text = "KELUAR";
            this.buttonExit.UseVisualStyleBackColor = false;
            // 
            // dataGridViewDftrCs
            // 
            this.dataGridViewDftrCs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDftrCs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDftrCs.Location = new System.Drawing.Point(18, 91);
            this.dataGridViewDftrCs.Name = "dataGridViewDftrCs";
            this.dataGridViewDftrCs.RowHeadersWidth = 51;
            this.dataGridViewDftrCs.RowTemplate.Height = 24;
            this.dataGridViewDftrCs.Size = new System.Drawing.Size(1308, 334);
            this.dataGridViewDftrCs.TabIndex = 26;
            // 
            // FormListChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 493);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dataGridViewDftrCs);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormListChat";
            this.Text = "FormListChat";
            this.Load += new System.EventHandler(this.FormListChat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDftrCs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTambah;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExit;
        public System.Windows.Forms.DataGridView dataGridViewDftrCs;
    }
}