using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_LIB
{
    public class Penjual
    {
        #region Data Members
        int id;
        string nama;
        string username;
        string password;
        string email;
        double rating;
        #endregion

        #region Constructors
        public Penjual(int id, string nama, string username, string password, string email, double rating)
        {
            Id = id;
            Nama = nama;
            Username = username;
            Password = password;
            Email = email;
            Rating = rating;
        }
        public Penjual()
        {
            Id = 0;
            Nama = "";
            Username = "";
            Password = "";
            Email = "";
            Rating = 0;
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public double Rating { get => rating; set => rating = value; }
        #endregion

        #region Methods
        public static Penjual CekLogin(string username, string password)
        {
            string sql = "";

            sql = "select * from penjuals where username='" + username + "' or email ='" + username +
                "' and password = '" + password + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            while (hasil.Read() == true)
            {

                Penjual penjual = new Penjual();
                penjual.Id = int.Parse(hasil.GetValue(0).ToString());
                penjual.Nama = hasil.GetValue(1).ToString();
                penjual.Username = hasil.GetValue(2).ToString();
                penjual.Email = hasil.GetValue(3).ToString();
                penjual.Password = hasil.GetValue(4).ToString();

                penjual.Rating = double.Parse(hasil.GetValue(5).ToString());
                return penjual;
            }
            return null;
        }

        public static Boolean TambahData(Penjual penjual)
        {

            string sql = "INSERT INTO penjuals(id, nama_toko, username, email, password, rating) VALUES ('"
                + penjual.Id + "','" +
                penjual.Nama.Replace("'", "\\'") + "','" + penjual.Username + "','" + penjual.Email + "','"
                + penjual.Password + "','" + penjual.Rating + "')";
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0)
            {
                return false;
            }
            else { return true; }
        }

        public static int GenerateId()
        {
            string sql = "select max(right(id,3)) from penjuals";
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
