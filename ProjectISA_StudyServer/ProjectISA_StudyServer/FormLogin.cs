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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi();
                Pembeli p = Pembeli.CekLogin(textBoxUsername.Text, textBoxPassword.Text);

                FormMainUser frmMainUser = (FormMainUser)this.Owner;

                if (!(p is null))
                {
                    frmMainUser.pembeli = p;
                    frmMainUser.status = "pembeli";
                    MessageBox.Show("Login Berhasil. Selamat Menggunakan Aplikasi: " + p.Nama, "Informasi");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                Penjual pe = Penjual.CekLogin(textBoxUsername.Text, textBoxPassword.Text);
                if (!(pe is null))
                {
                    frmMainUser.penjual = pe;
                    frmMainUser.status = "penjual";
                    MessageBox.Show("Login Berhasil. Selamat Menggunakan Aplikasi: " + pe.Nama, "Informasi");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Gagal. Pesan Kesalahan : " + ex.Message, "Information");
            }
        }

        private void labelDriver_Click(object sender, EventArgs e)
        {
            FormRegisPengguna formRegisPengguna = new FormRegisPengguna();
            formRegisPengguna.Owner = this;
            formRegisPengguna.ShowDialog();
        }
    }
}
