
using System;
using Transactions.Interfaces.Models;

namespace Transactions.Models
{
    public class Transaction  : IModels
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public Bank BanckOrigin { get; set; }
        public Bank BanckDestination { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Note { get; set; }

        public void Validate()
        {
            if (Value == 0)
                throw new Exception("Value 0");
        }
    }
}