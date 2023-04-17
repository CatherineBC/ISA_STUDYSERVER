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
    public partial class FormListChat : Form
    {
        public FormListChat()
        {
            InitializeComponent();
        }
        public List<Penjual_has_Produk> listProdukPenjuals = new List<Penjual_has_Produk>();
        private void FormListChat_Load(object sender, EventArgs e)
        {

            
        }
    }
}
