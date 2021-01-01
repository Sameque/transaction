using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transactions.Models;

namespace Transactions.Data
{
    public class TransactionsContext : DbContext
    {
        public TransactionsContext(DbContextOptions<TransactionsContext> options)
            : base(options)
        {
        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
