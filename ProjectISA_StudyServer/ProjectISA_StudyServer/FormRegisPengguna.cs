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
    public partial class FormRegisPengguna : Form
    {
        public FormRegisPengguna()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxPwd.Text == textBoxPwdUlang.Text && textBoxNoHp.TextLength == 12)
                {
                    int id = Pembeli.GenerateId();
                    string key = textBoxNoHp.Text + "1234";
                    string cipherText = Cyrptography.Encryption(textBoxPwdUlang.Text, key);
                    Pembeli pembeli = new Pembeli(id, textBoxNama.Text, textBoxUserName.Text, cipherText,
                        textBoxEmail.Text, textBoxAlamat.Text, textBoxNoHp.Text);
                    Boolean status = Pembeli.TambahData(pembeli);
                    if (status == true)
                    {
                        MessageBox.Show("Data pengguna berhasil ditambahkan.", "Informasi");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal ditambahkan.", "Informasi");
                    }
                }
                else
                {
                    MessageBox.Show("Password yang dimasukkan tidak sesuai");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
