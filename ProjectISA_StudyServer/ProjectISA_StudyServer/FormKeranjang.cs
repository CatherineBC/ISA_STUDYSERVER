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
            listKeranjang = Keranjang.BacaData("e.id not", "0");

            if(listKeranjang.Count > 0)
            {
                dataGridViewData.DataSource = listKeranjang;

                if(dataGridViewData.ColumnCount == 6)
                {
                    if(!dataGridViewData.Columns.Contains("buttonUbahGrid")) &&
                }
            }

        }

        private void dataGridViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
