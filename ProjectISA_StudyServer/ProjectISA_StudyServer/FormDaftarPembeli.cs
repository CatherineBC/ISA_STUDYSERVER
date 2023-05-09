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
    public partial class FormDaftarPembeli : Form
    {
        public FormDaftarPembeli()
        {
            InitializeComponent();
        }
        public List<Pembeli> listPembeli = new List<Pembeli>();
        private void FormDaftarPembeli_Load(object sender, EventArgs e)
        {
            listPembeli = Pembeli.BacaDataPembeli();
            if (listPembeli.Count > 0 && listPembeli != null)
            {
                dataGridViewData.DataSource = listPembeli;
            }
            else
            {
                dataGridViewData.DataSource = null;
            }
        }
    }
}
