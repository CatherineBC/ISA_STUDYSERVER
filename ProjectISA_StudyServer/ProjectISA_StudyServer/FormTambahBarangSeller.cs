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
                FormMainUser frm = (FormMainUser)this.Owner;

                int id = Produks.GenerateId();

                Produks p = new Produks(id, textBoxNamaBarang.Text);
                //Penjual_has_Produk php = new Penjual_has_Produk
                Boolean status = Produks.TambahData(p);
                int stok = (int)numericUpDownStok.Value;
                Boolean stats = Penjual_has_Produk.TambahData(p, frm.penjual, textBoxDeskripsiBarang.Text, double.Parse(textBoxHargaJual.Text), stok, 5);
                if (status == true)
                {
                    if(stats == true)
                    {
                        MessageBox.Show("Produk berhasil ditambahkan!", "Informasi");
                        this.Close();
                    }
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

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxHargaJual.Text = "";
            textBoxDeskripsiBarang.Text = "";
            textBoxNamaBarang.Text = "";
            numericUpDownStok.Value = 0;
        }
    }
}
