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
        string id;
        string nama;
        string username;
        string password;
        string email;
        double rating;
        #endregion

        #region Constructors
        public Penjual(string id, string nama, string username, string password, string email, double rating)
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
            Id = "";
            Nama = "";
            Username = "";
            Password = "";
            Email = "";
            Rating = 0;
        }
        #endregion

        #region Properties
        public string Id { get => id; set => id = value; }
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
                penjual.Id = hasil.GetValue(0).ToString();
                penjual.Nama = hasil.GetValue(1).ToString();
                penjual.Username = hasil.GetValue(2).ToString();
                penjual.Email = hasil.GetValue(3).ToString();
                penjual.Password = hasil.GetValue(4).ToString();

                penjual.Rating = double.Parse(hasil.GetValue(5).ToString());
                return penjual;
            }
            return null;
        }
        #endregion
    }
}
