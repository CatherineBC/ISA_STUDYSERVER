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
        string status;
        Administrator admin;
        #endregion

        #region Constructors
        public Penjual(int id, string nama, string username, string password, string email, double rating, string status, Administrator admin)
        {
            Id = id;
            Nama = nama;
            Username = username;
            Password = password;
            Email = email;
            Rating = rating;
            Status = status;
            Admin = admin;
        }
        public Penjual()
        {
            Id = 0;
            Nama = "";
            Username = "";
            Password = "";
            Email = "";
            Rating = 0;
            status = "";
            Admin = new Administrator();
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public double Rating { get => rating; set => rating = value; }
        public string Status { get => status; set => status = value; }
        public Administrator Admin { get => admin; set => admin = value; }
        #endregion

        #region Methods
        public static Penjual CekLogin(string username, string password)
        {
            string sql = "";

            sql = "select p.id, p.nama_toko, p.username, p.email, p.password, p.rating, p.status, a.id" +
                " from penjuals p inner join administrator a on p.administrator_id = a.id" +
                " where p.username='" + username + "' or p.email ='" + username +
                "' and p.password = '" + password + "'";

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
                penjual.Status = hasil.GetString(6);

                Administrator a = new Administrator();
                a.Id = int.Parse(hasil.GetValue(7).ToString());
                penjual.Admin = a;
                return penjual;
                
            }
            return null;
        }

        public static Boolean TambahData(int id, string namaToko, string username, string email, string password, string status)
        {

            string sql = "INSERT INTO penjuals(id, nama_toko, username, email, password, rating, status) VALUES ('"
                + id + "','" +
                namaToko + "','" + username + "','" + email + "','"
                + password + "','" + 5 + "','" + status + "')";
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
