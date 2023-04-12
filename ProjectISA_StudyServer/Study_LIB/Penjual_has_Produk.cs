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
        Penjual penjualId;
        Produks produkId;
        string keterangan;
        double harga;
        int stok;
        double rating;

        #endregion

        #region CONSTRUCTORS

        public Penjual_has_Produk(Penjual penjualId, Produks produkId, string keterangan, double harga, int stok, double rating)
        {
            PenjualId = penjualId;
            ProdukId = produkId;
            Keterangan = keterangan;
            Harga = harga;
            Stok = stok;
            Rating = rating;
        }
        public Penjual_has_Produk()
        {
            PenjualId = new Penjual();
            ProdukId = new Produks();
            Keterangan = keterangan;
            Harga = harga;
            Stok = stok;
            Rating = rating;
        }

        #endregion

        #region PROPERTIES

        public Penjual PenjualId { get => penjualId; set => penjualId = value; }
        public Produks ProdukId { get => produkId; set => produkId = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public double Harga { get => harga; set => harga = value; }
        public int Stok { get => stok; set => stok = value; }
        public double Rating { get => rating; set => rating = value; }

        #endregion

        #region METHODS

        public static Boolean TambahData(Produks produk, Penjual penjual, Penjual_has_Produk php)
        {
            string sql = "Insert into penjual_has_produk(Penjuals_id, Pembelis_id, keterangan, harga, stok, rating ) VALUES ('" + penjual.Id + "','" + produk.Id + "','" + php.Keterangan + "','" + php.Harga + "','" + php.Stok + "','" + php.Rating + "')";
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0)
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
                sql = "select p.id, ps.id, php.keterangan, php.harga, php.stok, php.rating FROM Penjual_has_produk php INNER JOIN pembeli ON php.penjuals_id = p.id" +
                    " INNER JOIN produks ps ON php.produks_id = p.id";
                
            }
            else
            {
                sql = "select p.id, ps.id, php.keterangan, php.harga, php.stok, php.rating FROM Penjual_has_produk php INNER JOIN pembeli ON php.penjuals_id = p.id" +
                    " INNER JOIN produks ps ON php.produks_id = p.id" +
                    "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Penjual_has_Produk> listPenjualHasProduk = new List<Penjual_has_Produk>();
            while (hasil.Read() == true)
            {

                Penjual_has_Produk php = new Penjual_has_Produk();
                php.Keterangan = hasil.GetString(2);
                php.Harga = hasil.GetDouble(3);
                php.Stok = int.Parse(hasil.GetString(4));
                php.Rating = hasil.GetDouble(5);
                php.PenjualId = new Penjual();
                php.PenjualId.Id = int.Parse(hasil.GetString(0));
                php.ProdukId = new Produks();
                php.ProdukId.Id = int.Parse(hasil.GetString(1));


                listPenjualHasProduk.Add(php);
            }
            return listPenjualHasProduk;

            
        }


        public static Boolean HapusData(Penjual_has_Produk php, Koneksi k)
        {
            string sql = "DELETE FROM deposito where penjuals_id = '" + php.PenjualId + "' AND produks_id = '" + php.ProdukId + "'";

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

