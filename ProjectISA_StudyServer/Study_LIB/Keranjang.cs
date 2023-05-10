using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        Penjual namaPenjual;
        Pembeli namaPembeli;
        Produks namaProduk;
        double sub_total;
        int jumlah_item;
        string status;
        #endregion

        #region CONSTRUCTOR
        public Keranjang(int id, Penjual id_penjual, Pembeli id_pembeli, Produks id_produk, double sub_total, int jumlah_item, string status)
        {
            Id = id;
            NamaPenjual = id_penjual;
            NamaPembeli = id_pembeli;
            namaProduk = id_produk;
            Sub_total = sub_total;
            Jumlah_item = jumlah_item;
            Status = status;
        }

        public Keranjang()
        {
            Id = 1;
            NamaPenjual = new Penjual();
            NamaPembeli = new Pembeli();
            NamaProduk = new Produks();
            Sub_total = 0;
            Jumlah_item = 0;
            Status = "belum";
        }
        #endregion

        #region PROPERTIES
        public int Id { get => id; set => id = value; }
        public Penjual NamaPenjual { get => namaPenjual; set => namaPenjual = value; }
        public Pembeli NamaPembeli { get => namaPembeli; set => namaPembeli = value; }
        public Produks NamaProduk { get => namaProduk; set => namaProduk = value; }
        public double Sub_total { get => sub_total; set => sub_total = value; }
        public int Jumlah_item { get => jumlah_item; set => jumlah_item = value; }
        public string Status { get => status; set => status = value; } 
        #endregion

        #region METHODS
        public static Boolean TambahData(int idKeranjang, int idPembeli, int idPenjual, int idProduk, double sub, int jumlahItem, string statusKeran)
        {
            string sql = "";
            if(jumlahItem != 0)
            {
                sql = "insert into keranjang(id, pembelis_id, penjuals_id, produks_id, sub_total, jumlah_item, status) values ('" + idKeranjang + "', '" + idPembeli + "', '" +
               idPenjual + "','" + idProduk + "', '" + sub + "', '" + jumlahItem + "', '" + statusKeran + "')";

            }
            else
            {
                throw new Exception("Pembelian minimal 1 buah.");
            }

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

            int jumlahDiubah = Koneksi.JalankanPerintahDML(sql);

            if (jumlahDiubah == 0)
            {
                return false;
            }
            else { return true; }
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
                sql = "select k.id, pem.id, pem.username, pen.id, pen.nama_toko, pro.id, pro.nama, k.sub_total, k.jumlah_item " +
                "FROM keranjang k INNER JOIN pembelis pem ON k.pembelis_id = pem.id " +
                "INNER JOIN penjuals_has_produks penp ON k.penjuals_id=penp.penjuals_id " +
                "INNER JOIN penjuals pen ON penp.penjuals_id = pen.id " +
                "INNER JOIN penjuals_has_produks penp2 ON k.produks_id = penp2.produks_id " +
                "inner join produks pro on penp2.produks_id = pro.id";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Keranjang> listKeranjang = new List<Keranjang>();

            while(hasil.Read() == true)
            {
                Keranjang k = new Keranjang();
                k.Id = int.Parse(hasil.GetString(0));
                k.Sub_total = double.Parse(hasil.GetString(7));
                k.Jumlah_item = int.Parse(hasil.GetString(8));

                Pembeli pem = new Pembeli();
                pem.Id = int.Parse(hasil.GetString(1));
                pem.Username = hasil.GetString(2);
                k.NamaPembeli = pem;

                Penjual pen = new Penjual();
                pen.Id = int.Parse(hasil.GetString(3));
                pen.Nama = hasil.GetString(4);
                k.NamaPenjual = pen;

                Produks pro = new Produks();
                pro.Id = int.Parse(hasil.GetString(5));
                pro.Nama = hasil.GetString(6);
                k.NamaProduk = pro;

                listKeranjang.Add(k);

            }
            return listKeranjang;       
        }

        public static List<Keranjang> BacaDataPengguna(string kriteria, string nilaiKriteria, int idPembeli)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select k.id, pem.id, pem.username, pen.id, pen.nama_toko, pro.id, pro.nama, k.sub_total, k.jumlah_item " +
                "FROM keranjang k INNER JOIN pembelis pem ON k.pembelis_id = pem.id " +
                "INNER JOIN penjuals_has_produks penp ON k.penjuals_id=penp.penjuals_id " +
                "INNER JOIN penjuals pen ON penp.penjuals_id = pen.id " +
                "INNER JOIN penjuals_has_produks penp2 ON k.produks_id = penp2.produks_id " +
                "inner join produks pro on penp2.produks_id = pro.id " + 
                "where k.pembelis_id = '" + idPembeli + "' and k.status ='belum'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Keranjang> listKeranjang = new List<Keranjang>();

            while (hasil.Read() == true)
            {
                Keranjang k = new Keranjang();
                k.Id = int.Parse(hasil.GetString(0));
                k.Sub_total = double.Parse(hasil.GetString(7));
                k.Jumlah_item = int.Parse(hasil.GetString(8));

                Pembeli pem = new Pembeli();
                pem.Id = int.Parse(hasil.GetString(1));
                pem.Username = hasil.GetString(2);
                k.NamaPembeli = pem;

                Penjual pen = new Penjual();
                pen.Id = int.Parse(hasil.GetString(3));
                pen.Nama = hasil.GetString(4);
                k.NamaPenjual = pen;

                Produks pro = new Produks();
                pro.Id = int.Parse(hasil.GetString(5));
                pro.Nama = hasil.GetString(6);
                k.NamaProduk = pro;

                listKeranjang.Add(k);

            }
            return listKeranjang;
        }
        public static List<Keranjang> BacaDataPenggunaSelesai(string kriteria, string nilaiKriteria, int idPembeli)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select k.id, pem.id, pem.username, pen.id, pen.nama_toko, pro.id, pro.nama, k.sub_total, k.jumlah_item, k.status " +
                "FROM keranjang k INNER JOIN pembelis pem ON k.pembelis_id = pem.id " +
                "INNER JOIN penjuals_has_produks penp ON k.penjuals_id=penp.penjuals_id " +
                "INNER JOIN penjuals pen ON penp.penjuals_id = pen.id " +
                "INNER JOIN penjuals_has_produks penp2 ON k.produks_id = penp2.produks_id " +
                "inner join produks pro on penp2.produks_id = pro.id " +
                "where k.pembelis_id = '" + idPembeli + "' and k.status ='selesai'";
            }
            else
            {
                sql = "select k.id, pem.id, pem.username, pen.id, pen.nama_toko, pro.id, pro.nama, k.sub_total, k.jumlah_item, k.status " +
                "FROM keranjang k INNER JOIN pembelis pem ON k.pembelis_id = pem.id " +
                "INNER JOIN penjuals_has_produks penp ON k.penjuals_id=penp.penjuals_id " +
                "INNER JOIN penjuals pen ON penp.penjuals_id = pen.id " +
                "INNER JOIN penjuals_has_produks penp2 ON k.produks_id = penp2.produks_id " +
                "inner join produks pro on penp2.produks_id = pro.id " +
                "where k.pembelis_id = '" + idPembeli + "' and k.status ='selesai' and " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Keranjang> listKeranjang = new List<Keranjang>();

            while (hasil.Read() == true)
            {
                Keranjang k = new Keranjang();
                k.Id = int.Parse(hasil.GetString(0));
                k.Sub_total = double.Parse(hasil.GetString(7));
                k.Jumlah_item = int.Parse(hasil.GetString(8));
                k.Status = hasil.GetString(9);

                Pembeli pem = new Pembeli();
                pem.Id = int.Parse(hasil.GetString(1));
                pem.Username = hasil.GetString(2);
                k.NamaPembeli = pem;

                Penjual pen = new Penjual();
                pen.Id = int.Parse(hasil.GetString(3));
                pen.Nama = hasil.GetString(4);
                k.NamaPenjual = pen;

                Produks pro = new Produks();
                pro.Id = int.Parse(hasil.GetString(5));
                pro.Nama = hasil.GetString(6);
                k.NamaProduk = pro;

                listKeranjang.Add(k);

            }
            return listKeranjang;
        }
        public static List<Keranjang> BacaDataPenjualSelesai(int idPenjual)
        {
            string sql = "";
            sql = "select k.id, pem.id, pem.username, pen.id, pen.nama_toko, pro.id, pro.nama, k.sub_total, k.jumlah_item, k.status " +
                "FROM keranjang k INNER JOIN pembelis pem ON k.pembelis_id = pem.id " +
                "INNER JOIN penjuals_has_produks penp ON k.penjuals_id=penp.penjuals_id " +
                "INNER JOIN penjuals pen ON penp.penjuals_id = pen.id " +
                "INNER JOIN penjuals_has_produks penp2 ON k.produks_id = penp2.produks_id " +
                "inner join produks pro on penp2.produks_id = pro.id " +
                "where k.penjuals_id = '" + idPenjual + "' and k.status ='selesai'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Keranjang> listKeranjang = new List<Keranjang>();

            while (hasil.Read() == true)
            {
                Keranjang k = new Keranjang();
                k.Id = int.Parse(hasil.GetString(0));
                k.Sub_total = double.Parse(hasil.GetString(7));
                k.Jumlah_item = int.Parse(hasil.GetString(8));
                k.Status = hasil.GetString(9);

                Pembeli pem = new Pembeli();
                pem.Id = int.Parse(hasil.GetString(1));
                pem.Username = hasil.GetString(2);
                k.NamaPembeli = pem;

                Penjual pen = new Penjual();
                pen.Id = int.Parse(hasil.GetString(3));
                pen.Nama = hasil.GetString(4);
                k.NamaPenjual = pen;

                Produks pro = new Produks();
                pro.Id = int.Parse(hasil.GetString(5));
                pro.Nama = hasil.GetString(6);
                k.NamaProduk = pro;

                listKeranjang.Add(k);

            }
            return listKeranjang;
        }
        public static List<Keranjang> BacaDataPenggunaGetStok(int idPembeli)
        {
            string sql = "";
            sql = "select k.id, pem.id, pem.username, pen.id, pen.nama_toko, pro.id, pro.nama, k.sub_total, k.jumlah_item, k.status " +
                "FROM keranjang k INNER JOIN pembelis pem ON k.pembelis_id = pem.id " +
                "INNER JOIN penjuals_has_produks penp ON k.penjuals_id=penp.penjuals_id " +
                "INNER JOIN penjuals pen ON penp.penjuals_id = pen.id " +
                "INNER JOIN penjuals_has_produks penp2 ON k.produks_id = penp2.produks_id " +
                "inner join produks pro on penp2.produks_id = pro.id " +
                "where k.pembelis_id = '" + idPembeli + "' and k.status ='belum'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Keranjang> listKeranjang = new List<Keranjang>();

            while (hasil.Read() == true)
            {
                Keranjang k = new Keranjang();
                k.Id = int.Parse(hasil.GetString(0));
                k.Sub_total = double.Parse(hasil.GetString(7));
                k.Jumlah_item = int.Parse(hasil.GetString(8));
                k.Status = hasil.GetString(9);

                Pembeli pem = new Pembeli();
                pem.Id = int.Parse(hasil.GetString(1));
                pem.Username = hasil.GetString(2);
                k.NamaPembeli = pem;

                Penjual pen = new Penjual();
                pen.Id = int.Parse(hasil.GetString(3));
                pen.Nama = hasil.GetString(4);
                k.NamaPenjual = pen;

                Produks pro = new Produks();
                pro.Id = int.Parse(hasil.GetString(5));
                pro.Nama = hasil.GetString(6);
                k.NamaProduk = pro;

                listKeranjang.Add(k);

            }
            return listKeranjang;
        }
        public static List<Keranjang> BacaDataKeranjang(int idKeranjang)
        {
            string sql = "";
            sql = "select k.id, pem.id, pem.username, pen.id, pen.nama_toko, pro.id, pro.nama, k.sub_total, k.jumlah_item " +
                "FROM keranjang k INNER JOIN pembelis pem ON k.pembelis_id = pem.id " +
                "INNER JOIN penjuals_has_produks penp ON k.penjuals_id=penp.penjuals_id " +
                "INNER JOIN penjuals pen ON penp.penjuals_id = pen.id " +
                "INNER JOIN penjuals_has_produks penp2 ON k.produks_id = penp2.produks_id " +
                "inner join produks pro on penp2.produks_id = pro.id " +
                "where k.id = '" + idKeranjang + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Keranjang> listKeranjang = new List<Keranjang>();

            while (hasil.Read() == true)
            {
                Keranjang k = new Keranjang();
                k.Id = int.Parse(hasil.GetString(0));
                k.Sub_total = double.Parse(hasil.GetString(7));
                k.Jumlah_item = int.Parse(hasil.GetString(8));

                Pembeli pem = new Pembeli();
                pem.Id = int.Parse(hasil.GetString(1));
                pem.Username = hasil.GetString(2);
                k.NamaPembeli = pem;

                Penjual pen = new Penjual();
                pen.Id = int.Parse(hasil.GetString(3));
                pen.Nama = hasil.GetString(4);
                k.NamaPenjual = pen;

                Produks pro = new Produks();
                pro.Id = int.Parse(hasil.GetString(5));
                pro.Nama = hasil.GetString(6);
                k.NamaProduk = pro;

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

        public static int jumlahSubTotal(int idPembeli) 
        {
            string sql = "select sum(sub_total) as jumlah from keranjang where status = 'belum' and pembelis_id ='" + idPembeli + "'";
            int hasilNo = 0;
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    hasilNo = int.Parse(hasil.GetValue(0).ToString());
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
        public static int CariId(int idPembeli)
        {
            string sql = "select id from keranjang where status = 'belum' and pembelis_id ='" + idPembeli + "'";
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

        public static Boolean UbahStatusKeranjang(int keranjangId)
        {
            string sql = "update keranjang set status = '" + "selesai" + "'" +
                " where id = " + keranjangId;
            int ubahData = Koneksi.JalankanPerintahDML(sql);
            if (ubahData == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override string ToString()
        {
            return Id.ToString();
        }
        #endregion
    }
}
