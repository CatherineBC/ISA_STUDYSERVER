using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_LIB
{
    public class Produks
    {
        #region Data Members
        int id;
        string nama;
        #endregion

        #region Constructors
        public Produks(int id, string nama)
        {
            Id = id;
            Nama = nama;
        }
        public Produks()
        {
            Id = 0;
            Nama = "";
        }

        public Produks(int id)
        {
            Id = id;
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        
        #endregion

        #region Methods

        public static Boolean TambahData(Produks p)
        {
            string sql = "insert into produks(id,nama) values ('" + p.Id + "', '" + p.Nama.Replace("'", "\\") +"')";

            int jumlahDitambahkan = Koneksi.JalankanPerintahDML(sql);
            Boolean status;

            if (jumlahDitambahkan == 0)
            {
                status = false;
            }
            else
            {
                status = true;
            }

            return status;
        }

        //public static Boolean UbahData(Produks p)
        //{
        //    string sql = "update produks set nama ='" + p.Nama.Replace("'", "\\'") + "' where id  ='" + p.Id + "'";

        //    int jumlahDiubah = Koneksi.JalankanPerintahDML(sql);
        //    Boolean status;
        //    if (jumlahDiubah == 0)
        //    {
        //        status = false;
        //    }
        //    else
        //    {
        //        status = true;
        //    }
        //    return status;
        //}

        public static Boolean HapusData(Produks p)
        {
            string sql = "Delete from produks where id ='" + p.Id + "'";

            int jumlahDiubah = Koneksi.JalankanPerintahDML(sql);
            Boolean status;
            if (jumlahDiubah == 0)
            {
                status = false;
            }
            else
            {
                status = true;
            }
            return status;
        }

        public static int GenerateId()
        {
            string sql = "select max(right(id,3)) from produks";
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
        public override string ToString()
        {
            return Nama;
        }
        #endregion


    }
}
