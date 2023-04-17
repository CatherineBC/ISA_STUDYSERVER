using Study_LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectISA_StudyServer
{
    public partial class FormListChat : Form
    {
        public FormListChat()
        {
            InitializeComponent();
        }
        public List<Chat> listChat = new List<Chat>();
        private void FormListChat_Load(object sender, EventArgs e)
        {
            FormMainUser frm = (FormMainUser)this.Owner;
            if(frm.status == "penjual")
            {
                listChat = Chat.BacaData("", "", frm.penjual.Id);
                if (listChat.Count > 0 && listChat != null)
                {
                    dataGridViewDftrCs.DataSource = listChat;
                    
                    if (dataGridViewDftrCs.Columns.Count < 6)
                    {
                        DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                        bcol.HeaderText = "Aksi";
                        bcol.Text = "Balas";
                        bcol.Name = "btnBalasGrid";
                        bcol.UseColumnTextForButtonValue = true;
                        dataGridViewDftrCs.Columns.Add(bcol);
                    }
                }
                else
                {
                    dataGridViewDftrCs.DataSource = null;
                }
            }
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDftrCs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FormMainUser frm = (FormMainUser)this.Owner;
            if (frm.status == "pembeli")
            {
                if (e.ColumnIndex == dataGridViewDftrCs.Columns["btnBalasGrid"].Index && e.RowIndex >= 0)
                {
                    FormBalasChat frm2 = new FormBalasChat();
                    frm2.Owner = this;
                    frm2.labelPenerima.Text = dataGridViewDftrCs.CurrentRow.Cells["Penjual"].Value.ToString();
                    frm2.ShowDialog();
                }
            }
            else
            {
                if (e.ColumnIndex == dataGridViewDftrCs.Columns["btnBalasGrid"].Index && e.RowIndex >= 0)
                {
                    FormBalasChat frm2 = new FormBalasChat();
                    frm2.Owner = this;
                    frm2.labelPenerima.Text = dataGridViewDftrCs.CurrentRow.Cells["Pembeli"].Value.ToString();
                    frm2.ShowDialog();
                }
            }
        }
    }
}
