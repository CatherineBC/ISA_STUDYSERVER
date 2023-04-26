using Study_LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
                string noTelpon = Pembeli.DapatNoTelpon(textBoxUsername.Text);
                string cipherTextPembeli = "";
                if (noTelpon != "")
                {
                    cipherTextPembeli = Cyrptography.Encryption(textBoxPassword.Text, noTelpon);
                }
                string username = Penjual.DapatUsername(textBoxUsername.Text);
                string cipherTextPenjual = "";
                if (username != "")
                {
                    cipherTextPenjual = Cyrptography.Encryption(textBoxPassword.Text, username);
                }
                Pembeli p = Pembeli.CekLogin(textBoxUsername.Text, cipherTextPenjual);

                FormMainUser frmMainUser = (FormMainUser)this.Owner;

                if (!(p is null))
                {
                    frmMainUser.pembeli = p;
                    frmMainUser.status = "pembeli";
                    MessageBox.Show("Login Berhasil. Selamat Menggunakan Aplikasi: " + p.Nama, "Informasi");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                Penjual pe = Penjual.CekLogin(textBoxUsername.Text, cipherTextPenjual);
                if (!(pe is null))
                {
                    frmMainUser.penjual = pe;
                    frmMainUser.status = "penjual";
                    MessageBox.Show("Login Berhasil. Selamat Menggunakan Aplikasi: " + pe.Nama, "Informasi");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                Administrator adm = Administrator.CekLogin(textBoxUsername.Text, textBoxPassword.Text);
                if (!(adm is null))
                {
                    frmMainUser.administrator = adm;
                    frmMainUser.status = "admin";
                    MessageBox.Show("Login Berhasil. Selamat Menggunakan Aplikasi: " + adm.Username, "Informasi");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if((adm is null) && (pe is null) && (p is null))
                {
                    MessageBox.Show("Data tidak ditemukan.\nCek kembali email atau password!");
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

        private void labelSender_Click(object sender, EventArgs e)
        {
            FormRegisSeller frm = new FormRegisSeller();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
