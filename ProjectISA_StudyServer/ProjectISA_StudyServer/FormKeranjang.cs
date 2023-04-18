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
    public partial class FormKeranjang : Form
    {
        public FormKeranjang()
        {
            InitializeComponent();
        }

        public List<Keranjang> listKeranjang = new List<Keranjang>();
        Koneksi k;
        FormMainUser formMainUser;
        Keranjang keranjang;

        private void FormKeranjang_Load(object sender, EventArgs e)
        {
            k = new Koneksi();

            formMainUser = (FormMainUser)this.MdiParent;


            listKeranjang = Keranjang.BacaData("", "");

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
                int id = int.Parse(dataGridViewData.CurrentRow.Cells["id"].Value.ToString());
                string nama_hadiah = dataGridViewData.CurrentRow.Cells["nama_hadiah"].Value.ToString();
                int harga_hadiah = int.Parse(dataGridViewData.CurrentRow.Cells["harga_hadiah"].Value.ToString());

                DialogResult hasil = MessageBox.Show("Data yang ingin dihapus : " +
                                                                    "\nnama_hadiah : " + nama_hadiah +
                                                                    "\nharga_hadiah : " + harga_hadiah +
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
    }
}
