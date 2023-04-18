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
    public partial class FormBalasChatLagi : Form
    {
        public FormBalasChatLagi()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormBalasChatLagi_Load(object sender, EventArgs e)
        {
            FormListChat frmC = (FormListChat)this.Owner;
            FormMainUser frm = (FormMainUser)frmC.Owner;

            if (frm.status == "pembeli")
            {
                labelPengirim.Text = frm.pembeli.Username;
            }
            else
            {
                labelPengirim.Text = frm.penjual.Nama;
            }
            int id = Chat.GenerateIdCs();
            textBoxIdVoucher.Enabled = false;
            textBoxIdVoucher.Text = id.ToString();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            FormListChat frmC = (FormListChat)this.Owner;
            FormMainUser frm = (FormMainUser)frmC.Owner;
            if (frm.status == "pembeli")
            {
                int idPenjual = Penjual.CariId(labelPenerima.Text);
                Chat.BalasPesan(int.Parse(textBoxIdVoucher.Text), frm.pembeli.Id, idPenjual, textBoxPesan.Text, DateTime.Now);
                MessageBox.Show("Pesan terkirim ke : " + labelPenerima.Text);
            }
            else
            {
                int idPembeli = Pembeli.CariId(labelPenerima.Text);
                Chat.BalasPesan(int.Parse(textBoxIdVoucher.Text), idPembeli, frm.penjual.Id, textBoxPesan.Text, DateTime.Now);
                MessageBox.Show("Pesan terkirim ke : " + labelPenerima.Text);
            }

        }
    }
}
