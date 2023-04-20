using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Study_LIB
{
    public class Keranjang
    {
        #region DATA MEMBERS
        int id;
        Penjual id_penjual;
        Pembeli id_pembeli;
        Produks id_produk;
        double sub_total;
        int jumlah_item;
        string status;
        #endregion

        #region CONSTRUCTOR
        public Keranjang(int id, Penjual id_penjual, Pembeli id_pembeli, Produks id_produk, double sub_total, int jumlah_item, string status)
        {
            Id = id;
            Id_penjual = id_penjual;
            Id_pembeli = id_pembeli;
            Id_produk = id_produk;
            Sub_total = sub_total;
            Jumlah_item = jumlah_item;
            Status = status;
        }

        public Keranjang()
        {
            Id = 1;
            Id_penjual = new Penjual();
            Id_pembeli = new Pembeli();
            Id_produk = new Produks();
            Sub_total = 0;
            Jumlah_item = 0;
            Status = "belum";
        }
        #endregion

        #region PROPERTIES
        public int Id { get => id; set => id = value; }
        public Penjual Id_penjual { get => id_penjual; set => id_penjual = value; }
        public Pembeli Id_pembeli { get => id_pembeli; set => id_pembeli = value; }
        public Produks Id_produk { get => id_produk; set => id_produk = value; }
        public double Sub_total { get => sub_total; set => sub_total = value; }
        public int Jumlah_item { get => jumlah_item; set => jumlah_item = value; }
        public string Status { get => status; set => status = value; } 
        #endregion

        #region METHODS
        public static Boolean TambahData(int idKeranjang, int idPembeli, int idPenjual, int idProduk, double sub, int jumlahItem, string statusKeran)
        {
            string sql = "insert into keranjang(id, pembelis_id, penjuals_id, produks_id, sub_total, jumlah_item, status) values ('" + idKeranjang + "', '" + idPembeli + "', '" +
                idPenjual + "','" + idProduk + "', '" + sub + "', '" + jumlahItem + "', '" + statusKeran + "')";

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

        public static Boolean UbahData(Keranjang k)
        {
            string sql = "update keranjang set jumlah_item=" + k.Jumlah_item + " where id = " + k.Id;

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

        public static Boolean HapusData(Keranjang k)
        {
            string sql = "Delete from keranjang where id = " + k.Id;

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

        public static List<Keranjang> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if(kriteria == "")
            {
                sql = "select k.id, b.id, s.id, p.id, k.sub_total, k.jumlah_item, p.nama " +
                "FROM keranjang k INNER JOIN penjuals s ON k.penjuals_id = s.id " +
                "INNER JOIN penjuals_has_produks pp ON k.produks_id=pp.produks_id " +
                "INNER JOIN pembelis b ON k.pembelis_id = b.id " +
                "INNER JOIN produks p ON k.produks_id = p.id";
            }
            else
            {
                sql = "select k.id, s.id, b.id, p.id, k.sub_total, k.jumlah_item, p.nama " +
                    "FROM keranjang k INNER JOIN penjuals s ON k.penjuals_id = s.id " +
                    "INNER JOIN penjuals_has_produks pp ON k.produks_id=pp.produks_id " +
                    "INNER JOIN pembelis b ON k.pembelis_id = b.id " +
                    "INNER JOIN produks p ON k.produks_id = p.id " +
                     "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Keranjang> listKeranjang = new List<Keranjang>();

            while(hasil.Read() == true)
            {
                Keranjang k = new Keranjang();

                Penjual s = new Penjual();
                s.Id = int.Parse(hasil.GetString(1));
                k.Id_penjual = s;

                Pembeli b = new Pembeli();
                b.Id = int.Parse(hasil.GetString(2));
                k.Id_pembeli = b;

                Produks p = new Produks();
                p.Id = int.Parse(hasil.GetString(3));
                p.Nama = hasil.GetString(6);
                k.Id_produk = p;

                k.Id = int.Parse(hasil.GetString(0));
                k.Sub_total = int.Parse(hasil.GetString(4));
                k.Jumlah_item = int.Parse(hasil.GetString(5));

                listKeranjang.Add(k);

            }
            return listKeranjang;       
        }

        public static int GenerateIdBaru()
        {
            string sql = "select max(id) from keranjang";
            int hasilNo = 1000;
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    hasilNo = int.Parse(hasil.GetValue(0).ToString()) + 1;
                }
                else
                {
                    hasilNo = 1000;
                }
            }

            return hasilNo;
        }
        public static int GenerateIdLama(int idPembeli) //yg belum selesai statusnya
        {
            string sql = "select id from keranjang where status = 'belum' and pembelis_id ='" + idPembeli + "'";
            int hasilNo = 1000;
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int noId = int.Parse(hasil.GetValue(0).ToString());
                    hasilNo = noId;
                }
            }
            return hasilNo;
        }

        public static int CekIdStatus(int idPembeli)
        {
            string sql = "select id from keranjang where status = 'belum' and pembelis_id ='" + idPembeli + "'";
            int ada = 0;
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                ada = 1;
            }

            return ada;
        }
        #endregion
    }
}
