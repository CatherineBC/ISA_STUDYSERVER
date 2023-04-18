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
    public partial class FormBeli : Form
    {
        public FormBeli()
        {
            InitializeComponent();
        }
        private void FormBeli_Load(object sender, EventArgs e)
        {
            FormMainUser user = (FormMainUser)this.Owner;
            int idCek = Keranjang.CekIdStatus(user.pembeli.Id);
            if(idCek == 1)
            {
                int id = Keranjang.GenerateIdLama(user.pembeli.Id);
                textBoxDeskripsi.Text = id.ToString();
            }
            else
            {
                int idBaru = Keranjang.GenerateIdBaru();
                textBoxDeskripsi.Text = idBaru.ToString();
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownStok_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
        
    
}
