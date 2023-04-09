﻿using Study_LIB;
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
    public partial class FormMainUser : Form
    {
        public FormMainUser()
        {
            InitializeComponent();
        }
        public Pembeli pembeli;
        public Penjual penjual;
        public string status;
        private void FormMainUser_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; //Form Utama menjadi Fullscreen
            this.IsMdiContainer = true;
            try
            {
                Koneksi koneksi = new Koneksi();
                FormLogin frmLogin = new FormLogin();
                frmLogin.Owner = this;
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Selamat datang di Aplikasi Study Server");
                    if (status == "pembeli")
                    {
                        labelNama.Text = "Selamat datang, " + pembeli.Nama;
                    }
                    else
                    {
                        labelNama.Text = "Selamat datang, " + penjual.Nama;
                    }

                }
                else
                {
                    MessageBox.Show("Gagal login");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal. Pesan kesalahan" + ex.Message);
                this.Close();
            }
        }
    }
}
