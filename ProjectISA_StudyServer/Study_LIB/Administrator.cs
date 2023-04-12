using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_LIB
{
    public class Administrator
    {
        #region Data Members
        int id;
        string username;
        string password;
        string email;
        #endregion

        #region Constructors
        public Administrator(int id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }
        public Administrator()
        {
            Id = 1;
            Username = "";
            Password = "";
            Email = "";
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        #endregion

        #region Methods
        public static Administrator CekLogin(string username, string password)
        {
            string sql = "";

            sql = "select * from administrator where username='" + username +
                "' and password = '" + password + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            while (hasil.Read() == true)
            {
                Administrator administrator = new Administrator(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(),
                    hasil.GetValue(2).ToString(),
                    hasil.GetValue(3).ToString());
                return administrator;
            }
            return null;
        }
        public override string ToString()
        {
            return Username;
        }

        /*
        public static Boolean TambahData(Pembeli pembeli)
        {

            string sql = "INSERT INTO pembelis(id, nama, username, password, email, alamat, no_telpon) VALUES ('"
                + pembeli.Id + "','" +
                pembeli.Nama.Replace("'", "\\'") + "','" + pembeli.Username + "','" + pembeli.Password + "','"
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
        */
        #endregion
    }
}
