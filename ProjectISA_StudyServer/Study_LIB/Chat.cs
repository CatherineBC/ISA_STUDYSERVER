using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_LIB
{
    public class Chat
    {
        #region Data Members
        private int id;
        private Pembeli pembeli;
        private Penjual penjual;
        private string pesan;
        private DateTime waktu;
        #endregion
        #region Constructors
        public Chat()
        {
            id = 0;
            Penjual = new Penjual();
            Pembeli = new Pembeli();
            Pesan = "";
            Waktu = DateTime.Now;
        }
        public Chat(int id, Pembeli pembeli, Penjual penjual, string pesan, DateTime waktu)
        {
            Id = id;
            Pembeli = pembeli;
            Penjual = penjual;
            Pesan = pesan;
            Waktu = waktu;
        }
        #endregion
        #region Properties
        public int Id { get => id; set => id = value; }
        public Pembeli Pembeli { get => pembeli; set => pembeli = value; }
        public Penjual Penjual { get => penjual; set => penjual = value; }
        public string Pesan { get => pesan; set => pesan = value; }
        public DateTime Waktu { get => waktu; set => waktu = value; }
        #endregion

        #region Methods
        public static List<Chat>BacaData(string kriteria, string nilaiKriteria, int idPenjual)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select c.id,pem.id, pen.id, c.isi_pesan, c.waktu" +
                " from chats c inner join pembelis pem on c.pembelis_id = pem.id inner join penjuals pen on c.penjuals_id = pen.id" +
                " where c.penjuals_id = '" + idPenjual + "'";
            }
            else
            {
                sql = "select c.id,pem.id, pen.id, c.isi_pesan, c.waktu" +
                " from chats c inner join pembelis pem on c.pembelis_id = pem.id inner join penjuals pen on c.penjuals_id = pen.id" +
                " where " + kriteria + " like '%" + nilaiKriteria + "%' and c.penjuals_id = '" + idPenjual + "'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Chat> listChat = new List<Chat>();
            while (hasil.Read() == true)
            {
                Chat chat = new Chat();
                chat.Id = int.Parse(hasil.GetString(0));
                chat.Pesan = hasil.GetString(3);
                chat.Waktu = DateTime.Parse(hasil.GetString(4));

                chat.Pembeli = new Pembeli();
                chat.Pembeli.Id = int.Parse(hasil.GetString(1));

                chat.Penjual = new Penjual();
                chat.Penjual.Id = int.Parse(hasil.GetString(2));

                listChat.Add(chat);
            }
            return listChat;
        }
        public static void BalasPesan(int id, int pembeliId, int penjualId, string pesan, DateTime waktu)
        {
            string sql = "insert into chats(id, pembelis_id, penjuals_id, isi_pesan, waktu) values ('" + id + "','" + pembeliId + "','" +
                penjualId + "','" + pesan + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            Koneksi.JalankanPerintahDML(sql);
        }

        public static List<Chat> BacaPesanSudahDibalasPenjuals(int id)
        //ngeload semua pesan yang sudah dibalaas untuk (Pengguna)
        {
            string sql = "";
            sql = "select c.id,pem.id, pen.id, c.isi_pesan, c.waktu" +
                " from chats c inner join pembelis pem on c.pembelis_id = pem.id inner join penjuals pen on c.penjuals_id = pen.id" +
                " where c.pembelis_id = '" + id + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Chat> listChat = new List<Chat>();
            while (hasil.Read() == true)
            {
                Chat chat = new Chat();
                chat.Id = int.Parse(hasil.GetString(0));
                chat.Pesan = hasil.GetString(3);
                chat.Waktu = DateTime.Parse(hasil.GetString(4));

                chat.Pembeli = new Pembeli();
                chat.Pembeli.Id = int.Parse(hasil.GetString(1));

                chat.Penjual = new Penjual();
                chat.Penjual.Id = int.Parse(hasil.GetString(2));

                listChat.Add(chat);
            }
            return listChat;
        }

        public static int GenerateIdCs() //Generate ID
        {
            string sql = "select max(id) from chats";
            int hasilNo = 0;
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
        #endregion
    }
}
