using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Study_LIB;

namespace ProjectISA_StudyServer
{
    public partial class FormOrderDetails : Form
    {

        public List<OrderDetails> listOrderDetails = new List<OrderDetails>();
        public List<Keranjang> listKeranjang = new List<Keranjang>();
        Koneksi k;
        public FormOrderDetails()
        {
            InitializeComponent();
        }

        private void FormOrderDetails_Load(object sender, EventArgs e)
        {
            FormMainUser frm = (FormMainUser)this.Owner;
            if(frm.status == "pembeli")
            {
                listOrderDetails = OrderDetails.BacaDataPengguna("", "", frm.pembeli.Id);

                if (listOrderDetails.Count > 0)
                {
                    dataGridViewData.DataSource = listOrderDetails;
                    if (dataGridViewData.ColumnCount < 10)
                    {
                        if (!dataGridViewData.Columns.Contains("buttonPrintGrid"))
                        {
                            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                            bcol.HeaderText = "Aksi";
                            bcol.Text = "Print";
                            bcol.Name = "buttonPrintGrid";
                            bcol.UseColumnTextForButtonValue = true;
                            dataGridViewData.Columns.Add(bcol);
                        }
                    }

                }
                else
                {
                    dataGridViewData.DataSource = null;
                }
            }
            else if(frm.status == "penjual")
            {
                listKeranjang = Keranjang.BacaDataPenjual(frm.penjual.Id);
                if (listKeranjang.Count > 0)
                {
                    dataGridViewData.DataSource = listKeranjang;
                }

            }
        }

        private void dataGridViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FormMainUser frm = (FormMainUser)this.Owner;
            if(frm.status == "pembeli")
            {
                if (e.ColumnIndex == dataGridViewData.Columns["buttonPrintGrid"].Index && e.RowIndex >= 0)
                {
                    //OrderDetails.PrintOrderDetails("id", dataGridViewData.Rows[e.RowIndex].Cells["id"].Value.ToString(), "OrderDetails.txt", new Font("Courier New", 12));
                    OrderDetails.PrintOrderDetails("idorders", dataGridViewData.Rows[e.RowIndex].Cells["IdOrders"].Value.ToString(), "k.id",
                        dataGridViewData.Rows[e.RowIndex].Cells["Keranjang_id"].Value.ToString(), "OrderDetails.txt", new Font("Courier New", 12), frm.pembeli.Id);
                    MessageBox.Show("Nota Telah Tercetak");
                }
            }

        }
    }
}
