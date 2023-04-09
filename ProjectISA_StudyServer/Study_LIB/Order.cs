using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_LIB
{
    public class Order
    {
        #region DATA MEMBERS
        int id;
        DateTime tgl;
        Penjual id_penjual;
        Pembeli id_pembeli;
        #endregion

        #region CONSTRUCTOR
        public Order(int id, DateTime tgl, Penjual id_penjual, Pembeli id_pembeli)
        {
            Id = id;
            Tgl = tgl;
            Id_penjual = id_penjual;
            Id_pembeli = id_pembeli;
        }
        #endregion

        #region PROPERTIES
        public int Id { get => id; set => id = value; }
        public DateTime Tgl { get => tgl; set => tgl = value; }
        public Penjual Id_penjual { get => id_penjual; set => id_penjual = value; }
        public Pembeli Id_pembeli { get => id_pembeli; set => id_pembeli = value; }
        #endregion

        #region METHODS
        public static Boolean TambahData(Order o)
        {
            string sql = "insert into orders(idorders,tanggal,pembelis_id,penjuals_id) values ('" + o.id + "', '" + o.tgl.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                o.id_pembeli + "','" + o.id_penjual + "')";

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
