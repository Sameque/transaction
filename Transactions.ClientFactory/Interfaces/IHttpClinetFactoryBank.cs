using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transactions.Models;

namespace Transactions.ClientFactory.Interfaces
{
    public interface IHttpClinetFactoryBank
    {
        [Get("/banks")]
        Task<List<Bank>> GetAll();
    }
}
