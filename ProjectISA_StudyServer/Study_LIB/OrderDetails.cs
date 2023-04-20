using System;
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
        double total;
        DateTime tanggal;

        #endregion

        #region CONSTRUCTORS

        public OrderDetails(int idOrders, Keranjang keranjang_id, double total, DateTime tanggal)
        {
            IdOrders = idOrders;
            Keranjang_id = keranjang_id;
            Total = total;
            Tanggal = tanggal;
        }

        public OrderDetails()
        {
            IdOrders = idOrders;
            Keranjang_id = new Keranjang();
            Total = total;
            Tanggal = tanggal;
        }


        
        #endregion

        #region PROPERTIES
        public int IdOrders { get => idOrders; set => idOrders = value; }
        public Keranjang Keranjang_id { get => keranjang_id; set => keranjang_id = value; }
        public double Total { get => total; set => total = value; }
        public DateTime Tanggal { get => tanggal; set => tanggal = value; }

        #endregion


        #region METHODS
        public static List<OrderDetails> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "select od.idorders, k.keranjang_id,od.total,od.tanggal FROM order_details od INNER JOIN Keranjang k on od.keranjang_id = k.id INNER JOIN penjual_has_produks_ php on od.produks_id = php.produks_id INNER JOIN produks p on od.produks_id = p.id ";

            }
            else
            {
                sql = "select od.idorders, k.keranjang_id,od.total,od.tanggal FROM order_details od INNER JOIN Keranjang k on od.keranjang_id = k.id INNER JOIN penjual_has_produks_ php on od.produks_id = php.produks_id INNER JOIN produks p on od.produks_id = p.id " +
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

                od.Total = int.Parse(hasil.GetString(2));
                od.Tanggal = DateTime.Parse(hasil.GetString(3));

                listOrderDetails.Add(od);
            }
            return listOrderDetails;
        }
        public static Boolean TambahData(int id, int idKeranjang, int total)
        {
            string sql = "insert into order_details(idorders, keranjang_id, total, tanggal) values ('" + id + "', '" + idKeranjang + "', '" +
                total + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

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
        public static int GenerateId()
        {
            string sql = "select max(right(idorders,3)) from order_details";
            int hasilNo = 1;
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int noId = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    hasilNo = noId;
                }
                else
                {
                    hasilNo = 1;
                }
            }

            return hasilNo;
        }
        
        public static void PrintOrderDetails(string printKriteria, string nilaiKriteria, string fileName, Font fontType, int idPembeli)
        {
            List<Keranjang> listKeranjang = new List<Keranjang>();
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

                tempFile.WriteLine("=".PadRight(50, '='));
                tempFile.WriteLine("Product".PadRight(30, ' '));
                tempFile.WriteLine("Jumlah Produk".PadRight(4, ' '));
                tempFile.WriteLine("Sub Total".PadRight(7, ' '));
                tempFile.WriteLine("");
                tempFile.WriteLine("=".PadRight(50, '='));

                listKeranjang = Keranjang.BacaDataPengguna("", "", idPembeli);
                foreach(Keranjang keran in listKeranjang)
                {
                    string namaBarang = keran.NamaProduk.Nama;
                    int qnty = keran.Jumlah_item;
                    double subTotal = keran.Sub_total;

                    tempFile.Write(namaBarang.PadRight(30, ' '));
                    tempFile.Write(qnty.ToString().PadRight(4, ' '));
                    tempFile.Write(subTotal.ToString().PadRight(7, ' '));
                    tempFile.WriteLine("");
                }
                tempFile.WriteLine("=".PadRight(50, '='));
                tempFile.WriteLine("Jumlah          : " + od.Total);
                tempFile.WriteLine("=".PadRight(50, '='));
            }
            tempFile.Close();

            CustomPrint p = new CustomPrint(fontType, fileName, 20, 10, 10, 10);
            p.SendToPrinter();
        }
        
        #endregion


    }
}
