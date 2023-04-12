using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_LIB
{
    public class Penjual_has_Produk
    {

        #region DATA MEMBERS
        int penjualId;
        int produkId;
        string keterangan;
        double harga;
        int stok;
        double rating;

        #endregion

        #region CONSTRUCTORS

        public Penjual_has_Produk(int penjualId, int produkId, string keterangan, double harga, int stok, double rating)
        {
            PenjualId = penjualId;
            ProdukId = produkId;
            Keterangan = keterangan;
            Harga = harga;
            Stok = stok;
            Rating = rating;
        }

        #endregion

        #region PROPERTIES

        public int PenjualId { get => penjualId; set => penjualId = value; }
        public int ProdukId { get => produkId; set => produkId = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public double Harga { get => harga; set => harga = value; }
        public int Stok { get => stok; set => stok = value; }
        public double Rating { get => rating; set => rating = value; }

        #endregion

        #region METHODS
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







            #endregion
        }
    }
}

