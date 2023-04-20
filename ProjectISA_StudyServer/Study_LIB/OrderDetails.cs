﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

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
                sql = "select od.idorders, k.keranjang_id,p.id,p.nama,od.total,od.tanggal FROM order_details od INNER JOIN Keranjang k on od.keranjang_id = k.id " +
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
                ps.Nama = hasil.GetString(3);
                od.Produks_id = ps;

                od.Total = int.Parse(hasil.GetString(4));
                od.Tanggal = hasil.GetDateTime(5);

                listOrderDetails.Add(od);
            }
            return listOrderDetails;
        }

        public static void PrintOrderDetails(string printKriteria, string nilaiKriteria, string fileName, Font fontType)
        {
            List<OrderDetails> listOrderDetails = new List<OrderDetails>();
            listOrderDetails = OrderDetails.BacaData(printKriteria, nilaiKriteria);

            StreamWriter tempFile = new StreamWriter(fileName);
            foreach (OrderDetails od in listOrderDetails)
            {
                tempFile.WriteLine("");
                tempFile.WriteLine("Order Date      : " + od.Tanggal);
                tempFile.WriteLine("Toko            : " + od.Keranjang_id.NamaPenjual);
                tempFile.WriteLine("Alamat          : " + od.keranjang_id.NamaPembeli.Alamat);
                tempFile.WriteLine("Penerima        : " + od.Keranjang_id.NamaPembeli.Nama);

                tempFile.WriteLine("====================================================");
                tempFile.WriteLine("Barang          : " + od.Produks_id.Nama);
                tempFile.WriteLine("Jumlah Barang   : " + od.Keranjang_id.Jumlah_item);
                tempFile.WriteLine("Jumlah          : " + od.Total);


            }
            tempFile.Close();

            CustomPrint p = new CustomPrint(fontType, fileName, 20, 10, 10, 10);
            p.SendToPrinter();
        }

        #endregion


    }
}
