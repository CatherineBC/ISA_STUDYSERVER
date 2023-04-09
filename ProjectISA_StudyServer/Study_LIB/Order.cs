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

        #endregion
    }
}
