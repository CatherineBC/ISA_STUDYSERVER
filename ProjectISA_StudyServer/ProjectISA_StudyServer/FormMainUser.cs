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

namespace ProjectISA_StudyServer
{
    public partial class FormMainUser : Form
    {
        public FormMainUser()
        {
            InitializeComponent();
        }
        public Pembeli pembeli;
        public Penjual penjual;
        public Administrator administrator;
        public string status;

        public List<Penjual_has_Produk> listProdukPenjuals = new List<Penjual_has_Produk>();

        public void FormMainUser_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; //Form Utama menjadi Fullscreen
            this.IsMdiContainer = true;
            try
            {
                Koneksi koneksi = new Koneksi();
                FormLogin frmLogin = new FormLogin();
                frmLogin.Owner = this;
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Selamat berbelanja di Aplikasi Study Server");
                    if (status == "pembeli")
                    {
                        
                        labelNama.Text = "Selamat datang, " + pembeli.Nama;
                        konfirmasiTokoToolStripMenuItem.Visible = false;
                        chatToolStripMenuItem.Visible = true;
                        tambahBarangToolStripMenuItem.Visible = false;
                        keranjangToolStripMenuItem.Visible = true;
                        detailOrderToolStripMenuItem.Visible = true;
                        pembeliToolStripMenuItem.Visible = false;
                        penjualToolStripMenuItem.Visible = false;
                        listProdukPenjuals = Penjual_has_Produk.BacaData("", "");

                        if (listProdukPenjuals.Count > 0 && listProdukPenjuals != null)
                        {
                            dataGridViewData.DataSource = listProdukPenjuals;
                            if (dataGridViewData.Columns.Count < 9)
                            {
                                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                                bcol.HeaderText = "Aksi";
                                bcol.Text = "Chat";
                                bcol.Name = "btnChatGrid";
                                bcol.UseColumnTextForButtonValue = true;
                                dataGridViewData.Columns.Add(bcol);

                                
                                DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                                bcol2.HeaderText = "Masukkan";
                                bcol2.Text = "Keranjang";
                                bcol2.Name = "btnKeranjangGrid";
                                bcol2.UseColumnTextForButtonValue = true;
                                dataGridViewData.Columns.Add(bcol2);
                            }
                        }
                        else
                        {
                            dataGridViewData.DataSource = null;
                        }

                    }
                    else if(status == "penjual")
                    {
                        labelNama.Text = "Selamat datang, " + penjual.Nama;

                        konfirmasiTokoToolStripMenuItem.Visible = false;
                        chatToolStripMenuItem.Visible = true;
                        tambahBarangToolStripMenuItem.Visible = true;
                        keranjangToolStripMenuItem.Visible = false;
                        detailOrderToolStripMenuItem.Visible = true;
                        pembeliToolStripMenuItem.Visible = false;
                        penjualToolStripMenuItem.Visible = false;

                        int cekStatus = Penjual.CekStatus(penjual.Id);
                        if(cekStatus == 1)
                        {
                            tambahBarangToolStripMenuItem.Visible = true;
                            
                            listProdukPenjuals = Penjual_has_Produk.BacaDataPenjuals("", "", penjual.Id);

                            if(listProdukPenjuals.Count > 0 && listProdukPenjuals != null)
                            {
                                dataGridViewData.DataSource = listProdukPenjuals;
                                if (dataGridViewData.Columns.Count < 9)
                                {
                                    DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                                    bcol.HeaderText = "Aksi";
                                    bcol.Text = "Ubah";
                                    bcol.Name = "btnUbahGrid";
                                    bcol.UseColumnTextForButtonValue = true;
                                    dataGridViewData.Columns.Add(bcol);
                                }
                            }
                            else
                            {
                                dataGridViewData.DataSource = null;
                            }
                            
                        }
                        else if(cekStatus == 0)
                        {
                            tambahBarangToolStripMenuItem.Visible = false;
                        }
                    }
                    else
                    {
                        labelNama.Text = "Selamat datang, " + administrator.Username;
                        listProdukPenjuals = Penjual_has_Produk.BacaData("", "");

                        konfirmasiTokoToolStripMenuItem.Visible = true;
                        chatToolStripMenuItem.Visible = true;
                        tambahBarangToolStripMenuItem.Visible = false;
                        keranjangToolStripMenuItem.Visible = false;
                        detailOrderToolStripMenuItem.Visible = false;
                        pembeliToolStripMenuItem.Visible = true;
                        penjualToolStripMenuItem.Visible = true;

                        if (listProdukPenjuals.Count > 0 && listProdukPenjuals != null)
                        {
                            dataGridViewData.DataSource = listProdukPenjuals;
                        }
                        else
                        {
                            dataGridViewData.DataSource = null;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Gagal login");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal. Pesan kesalahan : " + ex.Message);
                this.Close();
            }
        }

        private void labelNama_Click(object sender, EventArgs e)
        {

        }

        private void konfirmasiTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormKonfirmasiToko"];
            if (form == null)
            {
                FormKonfirmasiToko frmKonfirmasi = new FormKonfirmasiToko();
                frmKonfirmasi.Owner = this;
                frmKonfirmasi.Show();
            }
        }

        private void tambahBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTambahBarangSeller"];
            if (form == null)
            {
                FormTambahBarangSeller frm = new FormTambahBarangSeller();
                frm.Owner = this;
                frm.Show();
            }
        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormListChat"];
            if (form == null)
            {
                FormListChat frm = new FormListChat();
                frm.Owner = this;
                frm.Show();
            }
        }

        private void dataGridViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (status == "pembeli")
            {
                if (e.ColumnIndex == dataGridViewData.Columns["btnChatGrid"].Index && e.RowIndex >= 0)
                {
                    FormBalasChat frm = new FormBalasChat();
                    frm.Owner = this;
                    frm.labelPenerima.Text = dataGridViewData.CurrentRow.Cells["Penjual"].Value.ToString();
                    frm.ShowDialog();
                }
                else if(e.ColumnIndex == dataGridViewData.Columns["btnKeranjangGrid"].Index && e.RowIndex >= 0)
                {
                    FormBeli frm = new FormBeli();
                    frm.Owner = this;
                    frm.textBoxNamaBarang.Text = dataGridViewData.CurrentRow.Cells["Produk"].Value.ToString();
                    frm.textBoxDeskripsi.Text = dataGridViewData.CurrentRow.Cells["Keterangan"].Value.ToString();
                    frm.textBoxHarga.Text = dataGridViewData.CurrentRow.Cells["Harga"].Value.ToString();
                    frm.namaPenjual = dataGridViewData.CurrentRow.Cells["Penjual"].Value.ToString();
                    frm.stok = int.Parse(dataGridViewData.CurrentRow.Cells["Stok"].Value.ToString());
                    frm.ShowDialog();
                }
            }
            else if (status == "penjual")
            {
                if (e.ColumnIndex == dataGridViewData.Columns["btnUbahGrid"].Index && e.RowIndex >= 0)
                {
                    FormUbahBarang formUbahBarang = new FormUbahBarang();
                    formUbahBarang.Owner = this;
                 
                    formUbahBarang.textBoxNamaBarang.Text = dataGridViewData.CurrentRow.Cells["Produk"].Value.ToString();
                    formUbahBarang.textBoxDeskripsi.Text = dataGridViewData.CurrentRow.Cells["Keterangan"].Value.ToString();
                    formUbahBarang.textBoxHarga.Text = dataGridViewData.CurrentRow.Cells["Harga"].Value.ToString();
                    formUbahBarang.numericUpDownStok.Value = Decimal.Parse(dataGridViewData.CurrentRow.Cells["Stok"].Value.ToString());

                    formUbahBarang.ShowDialog();
                }
            }
                
        }

        private void keranjangToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form form = Application.OpenForms["FormKeranjang"];
            if (form == null)
            {
                FormKeranjang fk = new FormKeranjang();
                fk.Owner = this;
                fk.ShowDialog();
            }

        }

        private void detailOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormOrderDetails"];
            if (form == null)
            {
                FormOrderDetails fk = new FormOrderDetails();
                fk.Owner = this;
                fk.ShowDialog();
            }
        }

        private void penjualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPenjual"];
            if (form == null)
            {
                FormDaftarPenjual fk = new FormDaftarPenjual();
                fk.ShowDialog();
            }
        }

        private void pembeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPembeli"];
            if (form == null)
            {
                FormDaftarPembeli fk = new FormDaftarPembeli();
                fk.ShowDialog();
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status = "";
            dataGridViewData.DataSource = null;
            dataGridViewData.Rows.Clear();
            dataGridViewData.Columns.Clear();
            dataGridViewData.Refresh();
            pembeli = null;
            penjual = null;
            administrator = null;
            FormMainUser_Load(logOutToolStripMenuItem, e);
        }
    }
}
