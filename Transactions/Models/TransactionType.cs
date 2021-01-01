using System;
using Transactions.Interfaces.Models;

namespace Transactions.Models
{
    public class TransactionType  : IModels
    {
        public TransactionType()
        {
            Name = "";
        }

        public int id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            if(Name == "")
                throw new Exception("Name is empty");
        }
    }
}