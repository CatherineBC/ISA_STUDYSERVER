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
        public string namaPenjual;
        private void FormBeli_Load(object sender, EventArgs e)
        {
            FormMainUser user = (FormMainUser)this.Owner;
            int idCek = Keranjang.CekIdStatus(user.pembeli.Id);
            if(idCek == 1)
            {
                int id = Keranjang.GenerateIdLama(user.pembeli.Id);
                label2.Text = id.ToString();
            }
            else
            {
                int idBaru = Keranjang.GenerateIdBaru();
                label2.Text = idBaru.ToString();
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            
            try
            {
                FormMainUser user = (FormMainUser)this.Owner;
                int idPenjual = Penjual.CariId(namaPenjual);
                int idProduk = Produks.CariId(textBoxNamaBarang.Text);
                double subTotal = (double)numericUpDownStok.Value * double.Parse(textBoxHarga.Text);
                int jumItem = (int)numericUpDownStok.Value;
                Boolean status = Keranjang.TambahData(int.Parse(label2.Text), user.pembeli.Id, idPenjual, idProduk, subTotal, jumItem, "belum");
                if (status == true)
                {
                    MessageBox.Show("Data Keranjang berhasil ditambahkan!", "Informasi");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Data gagal ditambahkan.", "Informasi");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kesalahan : " + ex.Message);
            }
            
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
