using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_LIB
{
    public class Pembeli
    {
        #region Data Members
        string id;
        string nama;
        string username;
        string password;
        string email;
        string alamat;
        string no_telpon;
        #endregion

        #region Constructors
        public Pembeli(string id, string nama, string username, string password, string email, string alamat, string no_telpon)
        {
            Id = id;
            Nama = nama;
            Username = username;
            Password = password;
            Email = email;
            Alamat = alamat;
            No_telpon = no_telpon;
        }
        public Pembeli()
        {
            Id = "";
            Nama = "";
            Username = "";
            Password = "";
            Email = "";
            Alamat = "";
            No_telpon = "";
        }
        #endregion

        #region Properties
        public string Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string No_telpon { get => no_telpon; set => no_telpon = value; }
        #endregion

        #region Methods
        public static Pembeli CekLogin(string username, string password)
        {
            string sql = "";

            sql = "select * from pembelis where username='" + username + "' or email ='" + username +
                "' and password = '" + password + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            while (hasil.Read() == true)
            {
                /*
                Pembeli pembeli = new Pembeli();
                pembeli.Id = hasil.GetValue(0).ToString();
                pembeli.Nama = hasil.GetValue(1).ToString();
                pembeli.Username = hasil.GetValue(2).ToString();
                pembeli.Password = hasil.GetValue(3).ToString();
                pembeli.Email = hasil.GetValue(4).ToString();
                pembeli.Alamat = hasil.GetValue(5).ToString();
                pembeli.No_telpon = hasil.GetValue(6).ToString();
                return pembeli;
                */
                Pembeli pembeli = new Pembeli(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(),
                    hasil.GetValue(2).ToString(),
                    hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString(),
                    hasil.GetValue(5).ToString(), hasil.GetValue(6).ToString());
                return pembeli;
            }
            return null;
        }
        #endregion
    }
}
