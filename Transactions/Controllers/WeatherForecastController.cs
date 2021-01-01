using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Transactions.Data;
using Transactions.Models;
using System;
using System.Threading.Tasks;

namespace Transactions.Controllers
{
    [ApiController()]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private TransactionsContext _context;

        public WeatherForecastController(TransactionsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/transactions")]
        public IEnumerable<Transaction> GetTransactions()
        {
            return _context.Transactions.ToList();
        }

        [HttpGet]
        [Route("/transaction/{id}")]
        public Transaction GetTransaction(int id)
        {
            return _context.Transactions.Find(id);
        }

        [HttpPost]
        [Route("/transaction")]
        public async Task<ActionResult<Transaction>> PostTransaction([FromBody] Transaction model)
        {
            try
            {
                model.Validate();
                _context.Transactions.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(e.Message));
            }
        }

        [HttpDelete]
        [Route("/deletetransaction/{id}")]
        public async Task<ActionResult<string>> DeleteTransaction(int id)
        {
            try
            {
                var model = _context.Transactions.Find(id);

                if (model == null)
                    throw new Exception($"Transaction Not Found\nId: {id}");

                _context.Transactions.Remove(model);
                _context.SaveChanges();

                return $"Transaction Deleted: {id}";
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(e.Message));
            }
        }

        [HttpGet]
        [Route("/banks")]
        public IEnumerable<Bank> GetBanks()
        {
            return _context.Banks.ToList();
        }

        [HttpGet]
        [Route("/bank/{id}")]
        public async Task<ActionResult<Bank>> GetBank(int id)
        {
            try
            {
                var model = _context.Banks.Find(id);
                if (model == null)
                    throw new Exception($"Bank Not Found\nId: {id}");

                return model;
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(e.Message));
            }
        }

        [HttpDelete]
        [Route("/bank/{id}")]
        public async Task<ActionResult<string>> DeleteBank(int id)
        {
            try
            {
                var model = _context.Banks.Find(id);

                if (model == null)
                    throw new Exception($"Bank Not Found\nId: {id}");

                _context.Banks.Remove(model);
                _context.SaveChanges();

                return $"Bank Deleted: {id}";
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(e));
            }
        }

        [HttpPost]
        [Route("/bank")]
        public async Task<ActionResult<Bank>> PostBank([FromBody] Bank model)
        {
            try
            {
                model.Validate();
                _context.Banks.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(e.Message));
            }
        }

        [HttpGet]
        [Route("/transactiontypes")]
        public IEnumerable<TransactionType> GetTransactionTypes()
        {
            return _context.TransactionTypes.ToList();
        }

        [HttpGet]
        [Route("/transactiontype/{id}")]
        public TransactionType GetTransactionType(int id)
        {
            return _context.TransactionTypes.Find(id);
        }

        [HttpDelete]
        [Route("/transactiontype/{id}")]
        public async Task<ActionResult<string>> DeleteTransactionType(int id)
        {
            var model = _context.TransactionTypes.Find(id);

            if (model == null)
                return await Task.FromResult(BadRequest($"TransactionType Not Found\nId: {id}"));

            _context.TransactionTypes.Remove(model);
            _context.SaveChanges();

            return $"TransactionType Deleted: {id}";
        }

        [HttpPost]
        [Route("/transactiontype")]
        public async Task<ActionResult<TransactionType>> PostTransactionType([FromBody] TransactionType model)
        {
            try
            {
                model.Validate();
                _context.TransactionTypes.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                return await Task.FromResult(BadRequest(e.Message));
            }
        }
    }
}
