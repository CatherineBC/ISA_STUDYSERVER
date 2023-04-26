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
        public Pembeli(int id)
        {
            Id = id;
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

            sql = "select * from pembelis where username='" + username +
                "' and password = '" + password + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            while (hasil.Read() == true)
            {

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
        public static string DapatPassword(string username)
        {
            string sql = "select password from pembelis where username = '" + username + "'";
            string hasilPass = "";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    hasilPass = hasil.GetValue(0).ToString();
                }
            }
            return hasilPass;
        }
        public static string DapatNoTelpon(string username)
        {
            string sql = "select no_telpon from pembelis where username = '" + username + "'";
            string hasilPass = "";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    hasilPass = hasil.GetValue(0).ToString() + "1234";
                }
            }
            return hasilPass;
        }
        public static int CariId(string nama)
        {
            string sql = "select id from pembelis where username = '" + nama + "'";
            int hasilId = 0;
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    hasilId = int.Parse(hasil.GetValue(0).ToString());
                }
            }
            return hasilId;
        }

        public override string ToString()
        {
            return Username;
        }

        #endregion
    }
}
