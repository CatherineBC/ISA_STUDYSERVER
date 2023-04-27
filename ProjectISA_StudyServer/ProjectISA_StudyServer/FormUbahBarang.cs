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
    public partial class FormUbahBarang : Form
    {
        public FormUbahBarang()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            Boolean UbahPHP = Penjual_has_Produk.UbahData(Produks.CariId(textBoxNamaBarang.Text), Penjual.CariIdByProduk(textBoxNamaBarang.Text),
                textBoxDeskripsi.Text, int.Parse(textBoxHarga.Text));

            if (UbahPHP == true)
            {
                Penjual_has_Produk.UbahData(Produks.CariId(textBoxNamaBarang.Text), Penjual.CariIdByProduk(textBoxNamaBarang.Text),
                    textBoxDeskripsi.Text, (int)(numericUpDownStok.Value));
                MessageBox.Show("Data produk berhasil diubah.", "Informasi");
            }
            else
            {
                MessageBox.Show("Data gagal diubah.", "Informasi");
            }

            //try
            //{
            //    Penjual_has_Produk.UbahData(Produks.CariId(textBoxNamaBarang.Text), Penjual.CariIdByProduk(textBoxNamaBarang.Text),
            //        textBoxDeskripsi.Text, int.Parse(textBoxHarga.Text));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
