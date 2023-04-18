
namespace ProjectISA_StudyServer
{
    partial class FormOrderDetails
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
            this.labelOrderDetails = new System.Windows.Forms.Label();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.buttonTambah = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOrderDetails
            // 
            this.labelOrderDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.labelOrderDetails.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderDetails.ForeColor = System.Drawing.Color.LightCoral;
            this.labelOrderDetails.Location = new System.Drawing.Point(12, 9);
            this.labelOrderDetails.Name = "labelOrderDetails";
            this.labelOrderDetails.Size = new System.Drawing.Size(956, 117);
            this.labelOrderDetails.TabIndex = 36;
            this.labelOrderDetails.Text = "Detail Order";
            this.labelOrderDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(11, 129);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowHeadersWidth = 62;
            this.dataGridViewData.RowTemplate.Height = 28;
            this.dataGridViewData.Size = new System.Drawing.Size(957, 335);
            this.dataGridViewData.TabIndex = 35;
            this.dataGridViewData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewData_CellContentClick);
            // 
            // buttonTambah
            // 
            this.buttonTambah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambah.ForeColor = System.Drawing.Color.LightCoral;
            this.buttonTambah.Location = new System.Drawing.Point(771, 489);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(138, 45);
            this.buttonTambah.TabIndex = 44;
            this.buttonTambah.Text = "Keluar";
            this.buttonTambah.UseVisualStyleBackColor = false;
            // 
            // FormOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 565);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.labelOrderDetails);
            this.Controls.Add(this.dataGridViewData);
            this.Name = "FormOrderDetails";
            this.Text = "FormOrderDetails";
            this.Load += new System.EventHandler(this.FormOrderDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelOrderDetails;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.Button buttonTambah;
    }
}