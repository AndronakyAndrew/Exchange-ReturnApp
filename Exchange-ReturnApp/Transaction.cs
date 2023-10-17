using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_ReturnApp
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public decimal Cost { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public int SmallCoinsCount { get; set; }

        public Transaction() { }

        public Transaction(decimal cost, decimal amountPaid, decimal change, int smallCoinsCount)
        {
            this.Cost = cost;
            this.AmountPaid = amountPaid;
            this.Change = change;
            this.SmallCoinsCount = smallCoinsCount;
        }
    }
}
