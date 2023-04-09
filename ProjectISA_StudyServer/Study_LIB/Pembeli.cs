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
        int id;
        string nama;
        string username;
        string password;
        string email;
        string alamat;
        string no_telpon;
        #endregion

        #region Constructors
        public Pembeli(int id, string nama, string username, string password, string email, string alamat, string no_telpon)
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
            Id = 1;
            Nama = "";
            Username = "";
            Password = "";
            Email = "";
            Alamat = "";
            No_telpon = "";
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
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
                Pembeli pembeli = new Pembeli(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(),
                    hasil.GetValue(2).ToString(),
                    hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString(),
                    hasil.GetValue(5).ToString(), hasil.GetValue(6).ToString());
                return pembeli;
            }
            return null;
        }

        public static Boolean TambahData(Pembeli pembeli)
        {
            
            string sql = "INSERT INTO pembelis(id, nama, username, password, email, alamat, no_telpon) VALUES ('"
                + pembeli.Id + "','" +
                pembeli.Nama.Replace("'", "\\'") + "','" + pembeli.Username + "','" +  pembeli.Password + "','"
                + pembeli.Email + "','" + pembeli.Alamat + "','" + pembeli.No_telpon + "')";
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0)
            {
                return false;
            }
            else { return true; }
        }

        public static int GenerateId()
        {
            string sql = "select max(right(id,3)) from pembelis";
            int hasilNo = 1;
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int noId = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    hasilNo = noId;
                }
                else
                {
                    hasilNo = 1;
                }
            }

            return hasilNo;
        }
        #endregion
    }
}
