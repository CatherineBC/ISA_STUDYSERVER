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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectISA_StudyServer
{
    public partial class FormKeranjang : Form
    {
        public FormKeranjang()
        {
            InitializeComponent();
        }

        public List<Keranjang> listKeranjang = new List<Keranjang>();
        Keranjang keranjang;

        private void FormKeranjang_Load(object sender, EventArgs e)
        {
            FormMainUser frm = (FormMainUser)this.Owner;
            listKeranjang = Keranjang.BacaDataPengguna("", "", frm.pembeli.Id);

            if(listKeranjang.Count > 0)
            {
                dataGridViewData.DataSource = listKeranjang;

                if(dataGridViewData.ColumnCount == 6)
                {
                    if (!dataGridViewData.Columns.Contains("buttonUbahGrid") && !dataGridViewData.Columns.Contains("buttonUbahPasswordGrid") && !dataGridViewData.Columns.Contains("buttonHapusGrid"))
                    {
                        DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                        bcol.HeaderText = "Aksi";
                        bcol.Text = "Ubah";
                        bcol.Name = "buttonUbahGrid";
                        bcol.UseColumnTextForButtonValue = true;
                        dataGridViewData.Columns.Add(bcol);

                        DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                        bcol2.HeaderText = "Aksi";
                        bcol2.Text = "Hapus";
                        bcol2.Name = "buttonHapusGrid";
                        bcol2.UseColumnTextForButtonValue = true;
                        dataGridViewData.Columns.Add(bcol2);
                    }
                }
            }
            else
            {
                dataGridViewData.DataSource = null;
            }

        }

        private void dataGridViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewData.Columns["buttonUbahGrid"].Index && e.RowIndex >= 0)
            {
                
            }
            else if (e.ColumnIndex == dataGridViewData.Columns["buttonHapusGrid"].Index && e.RowIndex >= 0)
            {
                string nama_produk = dataGridViewData.CurrentRow.Cells["nama"].Value.ToString();
                int jmlh_item = int.Parse(dataGridViewData.CurrentRow.Cells["jumlah_item"].Value.ToString());
                double sub_ttl = double.Parse(dataGridViewData.CurrentRow.Cells["sub_total"].Value.ToString());

                DialogResult hasil = MessageBox.Show("Data yang ingin dihapus : " +
                                                                    "\nNama Produk : " + nama_produk +
                                                                    "\nJumlah Item: " + jmlh_item +
                                                                    "\nSub-Total: " + sub_ttl +
                                                                    "\nApakah anda yakin menghapus data tersebut ?", "Konfirmasi",
                                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    keranjang = new Keranjang();
                    Keranjang.HapusData(keranjang);
                    MessageBox.Show("Data berhasil dihapus.", "Informasi");
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormMainUser frm = (FormMainUser)this.Owner;
            int id = OrderDetails.GenerateId();
            int jumlahSubTotal = Keranjang.jumlahSubTotal(frm.pembeli.Id);
            int idKeranjang = Keranjang.CariId(frm.pembeli.Id);
            Boolean tambahOrderDetails = OrderDetails.TambahData(id, idKeranjang, jumlahSubTotal);
            if (tambahOrderDetails == true)
            {
                MessageBox.Show("Data OrderDetails berhasil ditambahkan!", "Informasi");
                Keranjang.print(frm.pembeli.Id, "notaJual.txt", new Font("Courier New", 12));
                this.Close();
            }
            else
            {
                MessageBox.Show("Data gagal ditambahkan.", "Informasi");
            }
        }
    }
}
