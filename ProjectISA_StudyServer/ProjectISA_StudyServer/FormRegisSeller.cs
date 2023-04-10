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
    public partial class FormRegisSeller : Form
    {
        public FormRegisSeller()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Penjual.GenerateId();
                if(textBoxPwD.Text == textBoxUlang.Text)
                {
                    Boolean status = Penjual.TambahData(id, textBoxNamaToko.Text, textBoxUserName.Text, textBoxEmail.Text, textBoxUlang.Text, "Tidak");
                    if (status == true)
                    {
                        MessageBox.Show("Data penjual berhasil ditambahkan\nMohon Tunggu Konfirmasi Akun oleh Administrator!", "Informasi");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal ditambahkan.", "Informasi");
                    }
                }
                else
                {
                    MessageBox.Show("Password Tidak Sesuai");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
