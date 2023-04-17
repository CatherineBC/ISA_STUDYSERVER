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

        private void FormKeranjang_Load(object sender, EventArgs e)
        {
            k = new Koneksi();
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
                        bcol2.Text = "Ubah Password";
                        bcol2.Name = "buttonUbahPasswordGrid";
                        bcol2.UseColumnTextForButtonValue = true;
                        dataGridViewData.Columns.Add(bcol2);

                        DataGridViewButtonColumn bcol3 = new DataGridViewButtonColumn();
                        bcol3.HeaderText = "Aksi";
                        bcol3.Text = "Hapus";
                        bcol3.Name = "buttonHapusGrid";
                        bcol3.UseColumnTextForButtonValue = true;
                        dataGridViewData.Columns.Add(bcol3);
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

        }
    }
}
