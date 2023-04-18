using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Study_LIB
{
    public class OrderDetails
    {
        #region DATA MEMBERS;
        int idOrders;
        Keranjang keranjang_id;
        Produks produks_id;
        double total;
        DateTime tanggal;

        #endregion

        #region CONSTRUCTORS

        public OrderDetails(int idOrders, Keranjang keranjang_id, Produks produks_id, double total, DateTime tanggal)
        {
            IdOrders = idOrders;
            Keranjang_id = keranjang_id;
            Produks_id = produks_id;
            Total = total;
            Tanggal = tanggal;
        }

        public OrderDetails()
        {
            IdOrders = idOrders;
            Keranjang_id = new Keranjang();
            Produks_id = new Produks();
            Total = total;
            Tanggal = tanggal;
        }


        
        #endregion

        #region PROPERTIES
        public int IdOrders { get => idOrders; set => idOrders = value; }
        public Keranjang Keranjang_id { get => keranjang_id; set => keranjang_id = value; }
        public Produks Produks_id { get => produks_id; set => produks_id = value; }
        public double Total { get => total; set => total = value; }
        public DateTime Tanggal { get => tanggal; set => tanggal = value; }

        #endregion


        #region METHODS
        public static List<OrderDetails> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "select od.idorders, k.keranjang_id,p.nama,od.total,od.tanggal FROM order_details od INNER JOIN Keranjang k on od.keranjang_id = k.id INNER JOIN penjual_has_produks_ php on od.produks_id = php.produks_id INNER JOIN produks p on od.produks_id = p.id ";

            }
            else
            {
                sql = "select od.idorders, k.keranjang_id,p.nama,od.total,od.tanggal FROM order_details od INNER JOIN Keranjang k on od.keranjang_id = k.id " +
                    "INNER JOIN penjual_has_produks_ php on od.produks_id = php.produks_id INNER JOIN produks p on od.produks_id = p.id " +
                    "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<OrderDetails> listOrderDetails = new List<OrderDetails>();
            while (hasil.Read() == true)
            {
                OrderDetails od = new OrderDetails();
                od.IdOrders = int.Parse(hasil.GetString(0));


                Keranjang k = new Keranjang();
                k.Id = int.Parse(hasil.GetString(1));
                od.Keranjang_id = k;

                Produks ps = new Produks();
                ps.Id = int.Parse(hasil.GetString(2));
                od.Produks_id = ps;

                od.Total = int.Parse(hasil.GetString(3));
                od.Tanggal = hasil.GetDateTime(4);

                listOrderDetails.Add(od);
            }
            return listOrderDetails;
        }




        #endregion


    }
}
