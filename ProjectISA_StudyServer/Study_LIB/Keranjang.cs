using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region CONSTRUCTOR
        public Keranjang(int id, Penjual id_penjual, Pembeli id_pembeli, Produks id_produk, double sub_total, int jumlah_item)
        {
            Id = id;
            Id_penjual = id_penjual;
            Id_pembeli = id_pembeli;
            Id_produk = id_produk;
            Sub_total = sub_total;
            Jumlah_item = jumlah_item;
        }
        #endregion

        #region PROPERTIES
        public int Id { get => id; set => id = value; }
        public Penjual Id_penjual { get => id_penjual; set => id_penjual = value; }
        public Pembeli Id_pembeli { get => id_pembeli; set => id_pembeli = value; }
        public Produks Id_produk { get => id_produk; set => id_produk = value; }
        public double Sub_total { get => sub_total; set => sub_total = value; }
        public int Jumlah_item { get => jumlah_item; set => jumlah_item = value; }
        #endregion

        #region METHODS
        public static Boolean TambahData(Keranjang k)
        {
            string sql = "insert into keranjang(id, pembelis_id, penjuals_id, produks_id, sub_total, jumlah_item) values ('" + k.Id + "', '" + k.Id_pembeli + "', '" +
                k.Id_penjual + "','" + k.Id_produk + "', '" + k.Sub_total + "', '" + k.Jumlah_item + "')";

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
        #endregion
    }
}
