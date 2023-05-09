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
    public partial class FormDaftarPenjual : Form
    {
        public FormDaftarPenjual()
        {
            InitializeComponent();
        }
        public List<Penjual> listPenjual = new List<Penjual>();
        private void dataGridViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormDaftarPenjual_Load(object sender, EventArgs e)
        {
            listPenjual = Penjual.BacaDataPenjual();
            if (listPenjual.Count > 0 && listPenjual != null)
            {
                dataGridViewData.DataSource = listPenjual;
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
    }
}
