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
            textBox2.Clear();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormMainUser user = (FormMainUser)this.Owner;
            string key = Pembeli.DapatNoTelpon(user.pembeli.Username);
            string cipherText = Cyrptography.Encryption(textBox2.Text, key);
            int idPenjual = Penjual.CariId(labelPenerima.Text);
            Chat.BalasPesan(int.Parse(textBoxIdVoucher.Text), user.pembeli.Id, idPenjual, cipherText, DateTime.Now);
            MessageBox.Show("Pesan terkirim ke : " + labelPenerima.Text);
        }

        private void FormBalasChat_Load(object sender, EventArgs e)
        {
            FormMainUser user = (FormMainUser)this.Owner;
            labelPengirim.Text = user.pembeli.Username;
            int id = Chat.GenerateIdCs();
            textBoxIdVoucher.Enabled = false;
            textBoxIdVoucher.Text = id.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
