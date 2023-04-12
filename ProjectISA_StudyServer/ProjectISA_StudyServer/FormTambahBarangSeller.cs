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
    public partial class FormTambahBarangSeller : Form
    {
        public FormTambahBarangSeller()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Produks.GenerateId();

                Produks p = new Produks(id, textBoxNamaBarang.Text);
                //Penjual_has_Produk php = new Penjual_has_Produk
                Boolean status = Produks.TambahData(p);
                if (status == true)
                {
                    MessageBox.Show("Produk berhasil ditambahkan!", "Informasi");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Produk gagal ditambahkan.", "Informasi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
