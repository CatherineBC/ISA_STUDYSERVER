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
    public partial class FormKonfirmasiToko : Form
    {
        public FormKonfirmasiToko()
        {
            InitializeComponent();
        }
        public List<Penjual> listPenjual = new List<Penjual>();
        private void FormKonfirmasiToko_Load(object sender, EventArgs e)
        {
            listPenjual = Penjual.BacaDataPenjualTidakAktif();
            if (listPenjual.Count > 0 && listPenjual != null)
            {
                dataGridViewData.DataSource = listPenjual;
                if (dataGridViewData.ColumnCount < 9)
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

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            FormMainUser frm = (FormMainUser)this.Owner;
            Administrator admin;
            admin = frm.administrator;

            if (e.ColumnIndex == dataGridViewDftrTabungan.Columns["btnUbahGrid"].Index && e.RowIndex >= 0)
            {
                try
                {
                    string noRek = dataGridViewDftrTabungan.CurrentRow.Cells["NoRekening"].Value.ToString();

                    Tabungan.UbahStatusTabungan(employee, noRek);
                    MessageBox.Show("Status berubah menjadi Aktif", "Informasi");
                    FormKonfirmasiTabungan_Load(this, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kesalahan :" + ex.Message);
                }
            }
            */
        }
    }
}
