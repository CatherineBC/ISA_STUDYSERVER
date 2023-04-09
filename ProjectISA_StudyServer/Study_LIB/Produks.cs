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
        int harga;
        int stok;

        #endregion

        #region Constructors
        public Produks(int id, string nama, int harga, int stok)
        {
            Id = id;
            Nama = nama;
            Harga = harga;
            this.Stok = stok;
        }

        #endregion

        #region Properties

        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public int Harga { get => harga; set => harga = value; }
        public int Stok { get => stok; set => stok = value; }

        #endregion

        #region Methods

        public static Boolean TambahData(Produks p)
        {
            p.Stok = 0;
            string sql = "insert into produks(id,nama) values ('" + p.Nama.Replace("'", "\\") +"')";

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

        public static Boolean UbahData(Produks p)
        {
            string sql = "update produks set nama ='" + p.Nama.Replace("'", "\\'") + "' where id  ='" + p.Id + "'";

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




        #endregion


    }
}
