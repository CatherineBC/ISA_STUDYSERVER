using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Study_LIB
{
    public class Penjual_has_Produk
    {

        #region DATA MEMBERS
        Penjual penjual;
        Produks produk;
        string keterangan;
        double harga;
        int stok;
        double rating;

        #endregion

        #region CONSTRUCTORS

        public Penjual_has_Produk(Penjual penjual, Produks produk, string keterangan, double harga, int stok, double rating)
        {
            Penjual = penjual;
            Produk = produk;
            Keterangan = keterangan;
            Harga = harga;
            Stok = stok;
            Rating = rating;
        }
        public Penjual_has_Produk()
        {
            Penjual = new Penjual();
            Produk = new Produks();
            Keterangan = keterangan;
            Harga = harga;
            Stok = stok;
            Rating = rating;
        }

        #endregion

        #region PROPERTIES

        public Penjual Penjual { get => penjual; set => penjual = value; }
        public Produks Produk { get => produk; set => produk = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public double Harga { get => harga; set => harga = value; }
        public int Stok { get => stok; set => stok = value; }
        public double Rating { get => rating; set => rating = value; }

        #endregion

        #region METHODS

        public static Boolean TambahData(Produks produk, Penjual penjual, string keterangan, double harga, int stok, double rating)
        {
            string sql = "Insert into penjuals_has_produks(penjuals_id, produks_id, keterangan, harga, stok, rating ) VALUES ('" + penjual.Id + "','" + produk.Id + "','" + keterangan + "','" + harga + "','" + stok + "','" + rating + "')";
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0)
            {
                return false;
            }
            else { return true; }
        }

        public static Boolean UbahData(int idProduk, int idPenjual, string deskripsi, int stok)
        {
            string sql = "UPDATE penjuals_has_produks SET keterangan = '" + deskripsi + "', stok = '" + stok + "' WHERE penjuals_id = '" + idPenjual + "' AND produks_id ='" + idProduk + "'";

            int jumlahDiubah = Koneksi.JalankanPerintahDML(sql);

            if (jumlahDiubah == 0)
            {
                return false;
            }
            else { return true; }
        }

        public static List<Penjual_has_Produk> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "select p.id, p.nama_toko, ps.id, ps.nama, php.keterangan, php.harga, php.stok, php.rating FROM Penjuals_has_produks php INNER JOIN penjuals p ON php.penjuals_id = p.id" +
                    " INNER JOIN produks ps ON php.produks_id = ps.id";
                
            }
            else
            {
                sql = "select p.id, p.nama_toko, ps.id, ps.nama, php.keterangan, php.harga, php.stok, php.rating FROM Penjuals_has_produks php INNER JOIN penjuals ON php.penjuals_id = p.id" +
                    " INNER JOIN produks ps ON php.produks_id = p.id" +
                    "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Penjual_has_Produk> listPenjualHasProduk = new List<Penjual_has_Produk>();
            while (hasil.Read() == true)
            {

                Penjual_has_Produk php = new Penjual_has_Produk();

                Penjual p = new Penjual();
                p.Id = int.Parse(hasil.GetString(0));
                p.Nama = hasil.GetString(1);
                php.Penjual = p;

                Produks ps = new Produks();
                ps.Id = int.Parse(hasil.GetString(2));
                ps.Nama = hasil.GetString(3);
                php.Produk = ps;

                php.Keterangan = hasil.GetString(4);
                php.Harga = double.Parse(hasil.GetString(5));
                php.Stok = int.Parse(hasil.GetString(6));
                php.Rating = double.Parse(hasil.GetString(7));

                listPenjualHasProduk.Add(php);
            }
            return listPenjualHasProduk;
        }

        public static List<Penjual_has_Produk> BacaDataPenjuals(string kriteria, string nilaiKriteria, int idPenjuals)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "select p.id, p.nama_toko, ps.id, ps.nama, php.keterangan, php.harga, php.stok, php.rating FROM Penjuals_has_produks php INNER JOIN penjuals p ON php.penjuals_id = p.id" +
                    " INNER JOIN produks ps ON php.produks_id = ps.id where php.penjuals_id = '" + idPenjuals + "'";

            }
            else
            {
                sql = "select p.id, p.nama_toko, ps.id, ps.nama, php.keterangan, php.harga, php.stok, php.rating FROM Penjuals_has_produks php INNER JOIN penjuals p ON php.penjuals_id = p.id" +
                    " INNER JOIN produks ps ON php.produks_id = p.id" +
                    "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Penjual_has_Produk> listPenjualHasProduk = new List<Penjual_has_Produk>();
            while (hasil.Read() == true)
            {

                Penjual_has_Produk php = new Penjual_has_Produk();

                Penjual p = new Penjual();
                p.Id = int.Parse(hasil.GetString(0));
                p.Nama = hasil.GetString(1);
                php.Penjual = p;

                Produks ps = new Produks();
                ps.Id = int.Parse(hasil.GetString(2));
                ps.Nama = hasil.GetString(3);
                php.Produk = ps;

                php.Keterangan = hasil.GetString(4);
                php.Harga = double.Parse(hasil.GetString(5));
                php.Stok = int.Parse(hasil.GetString(6));
                php.Rating = double.Parse(hasil.GetString(7));

                listPenjualHasProduk.Add(php);
            }
            return listPenjualHasProduk;
        }
        public static int DapatStok(int idProduk)
        {
            string sql = "select stok from penjuals_has_produks where produks_id = '" + idProduk + "'";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            int stok = 0;
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    stok = int.Parse(hasil.GetValue(0).ToString());
                }
            }
            return stok;
        }
        public static Boolean UpdateStok(int idProduk, int idPenjual, int stok)
        {
            int jumlahStok = DapatStok(idProduk);
            jumlahStok -= stok;
            string sql = "UPDATE penjuals_has_produks SET stok = '" + jumlahStok + "' WHERE penjuals_id = '" + idPenjual + "' AND produks_id ='" + idProduk + "'";

            int jumlahDiubah = Koneksi.JalankanPerintahDML(sql);

            if (jumlahDiubah == 0)
            {
                return false;
            }
            else { return true; }
        }
        #endregion
    }
}

