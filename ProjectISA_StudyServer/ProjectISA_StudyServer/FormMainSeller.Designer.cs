
namespace ProjectISA_StudyServer
{
    partial class FormMainSeller
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
            this.labelToko = new System.Windows.Forms.Label();
            this.labelNama = new System.Windows.Forms.Label();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.SuspendLayout();
            // 
            // labelToko
            // 
            this.labelToko.AutoSize = true;
            this.labelToko.Location = new System.Drawing.Point(35, 166);
            this.labelToko.Name = "labelToko";
            this.labelToko.Size = new System.Drawing.Size(90, 20);
            this.labelToko.TabIndex = 7;
            this.labelToko.Text = "Nama Toko";
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Location = new System.Drawing.Point(769, 23);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(179, 20);
            this.labelNama.TabIndex = 6;
            this.labelNama.Text = "Selamat Datang , Nama";
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(22, 208);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowHeadersWidth = 62;
            this.dataGridViewData.RowTemplate.Height = 28;
            this.dataGridViewData.Size = new System.Drawing.Size(957, 333);
            this.dataGridViewData.TabIndex = 5;
            // 
            // FormMainSeller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 564);
            this.Controls.Add(this.labelToko);
            this.Controls.Add(this.labelNama);
            this.Controls.Add(this.dataGridViewData);
            this.Name = "FormMainSeller";
            this.Text = "FormMainSeller";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelToko;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.DataGridView dataGridViewData;
    }
}