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

        private void FormMainUser_Load(object sender, EventArgs e)
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
                        listProdukPenjuals = Penjual_has_Produk.BacaData("", "");

                        if (listProdukPenjuals.Count > 0 && listProdukPenjuals != null)
                        {
                            dataGridViewData.DataSource = listProdukPenjuals;
                            if (dataGridViewData.Columns.Count < 7)
                            {
                                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                                bcol.HeaderText = "Aksi";
                                bcol.Text = "Chat";
                                bcol.Name = "btnChatGrid";
                                bcol.UseColumnTextForButtonValue = true;
                                dataGridViewData.Columns.Add(bcol);
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
                        int cekStatus = Penjual.CekStatus(penjual.Id);
                        if(cekStatus == 1)
                        {
                            tambahBarangToolStripMenuItem.Visible = true;
                            
                            listProdukPenjuals = Penjual_has_Produk.BacaDataPenjuals("", "", penjual.Id);

                            if(listProdukPenjuals.Count > 0 && listProdukPenjuals != null)
                            {
                                dataGridViewData.DataSource = listProdukPenjuals;
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

        }
    }
}
