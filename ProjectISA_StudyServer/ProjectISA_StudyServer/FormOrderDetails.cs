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
        Koneksi k;
        public FormOrderDetails()
        {
            InitializeComponent();
        }

        private void FormOrderDetails_Load(object sender, EventArgs e)
        {
            k = new Koneksi();
            listOrderDetails = OrderDetails.BacaData("","");

            if(listOrderDetails.Count > 0)
            {
                dataGridViewData.DataSource = listOrderDetails;
                
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
