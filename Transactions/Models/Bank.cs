
using System;
using System.Collections.Generic;
using Transactions.Interfaces.Models;

namespace Transactions.Models
{
    public class Bank : IModels
    {
        public Bank()
        {
            Code = 0;
            Name = "";
        }
        public int id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public void Validate()
        {
            if (Code == 0)
                throw new Exception("Code 0");
            if (Name == "")
                throw new Exception("Name is empty");
        }
    }
}