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
    public partial class FormBalasChat : Form
    {
        public FormBalasChat()
        {
            InitializeComponent();
        }

        private void buttonKosong_Click(object sender, EventArgs e)
        {
            textBoxPesan.Clear();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormMainUser user = (FormMainUser)this.Owner;
            if(user.status == "pembeli")
            {
                int idPenjual = Penjual.CariId(labelPenerima.Text);
                Chat.BalasPesan(int.Parse(textBoxIdVoucher.Text), user.pembeli.Id, idPenjual, textBoxPesan.Text, DateTime.Now);
                MessageBox.Show("Pesan terkirim ke : " + labelPenerima.Text);
            }
            else
            {
                int idPembeli = Pembeli.CariId(labelPenerima.Text);
                Chat.BalasPesan(int.Parse(textBoxIdVoucher.Text), idPembeli, user.penjual.Id, textBoxPesan.Text, DateTime.Now);
            }
        }

        private void FormBalasChat_Load(object sender, EventArgs e)
        {
            FormMainUser user = (FormMainUser)this.Owner;
            if(user.status == "pembeli")
            {
                labelPengirim.Text = user.pembeli.Username;
            }
            else
            {
                labelPengirim.Text = user.penjual.Nama;
            }
            int id = Chat.GenerateIdCs();
            textBoxIdVoucher.Enabled = false;
            textBoxIdVoucher.Text = id.ToString();
        }
    }
}
