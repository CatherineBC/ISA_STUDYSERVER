
namespace ProjectISA_StudyServer
{
    partial class FormKeranjang
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
            this.labelTambahBarang = new System.Windows.Forms.Label();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTambahBarang
            // 
            this.labelTambahBarang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.labelTambahBarang.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTambahBarang.ForeColor = System.Drawing.Color.LightCoral;
            this.labelTambahBarang.Location = new System.Drawing.Point(1, 0);
            this.labelTambahBarang.Name = "labelTambahBarang";
            this.labelTambahBarang.Size = new System.Drawing.Size(956, 117);
            this.labelTambahBarang.TabIndex = 34;
            this.labelTambahBarang.Text = "KERANJANG";
            this.labelTambahBarang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(0, 120);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowHeadersWidth = 62;
            this.dataGridViewData.RowTemplate.Height = 28;
            this.dataGridViewData.Size = new System.Drawing.Size(957, 335);
            this.dataGridViewData.TabIndex = 33;
            // 
            // FormKeranjang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 455);
            this.Controls.Add(this.labelTambahBarang);
            this.Controls.Add(this.dataGridViewData);
            this.Name = "FormKeranjang";
            this.Text = "FormKeranjang";
            this.Load += new System.EventHandler(this.FormKeranjang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTambahBarang;
        private System.Windows.Forms.DataGridView dataGridViewData;
    }
}