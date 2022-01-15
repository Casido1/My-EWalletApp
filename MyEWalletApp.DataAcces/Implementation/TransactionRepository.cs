using MyEWalletApp.DataAccess.Interface;
using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task<List<Transactions>> GetAllCreditTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllCurrencyCreditTransactions(string currencyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllCurrencyDebitTransactions(string currencyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllCurrencyTransactions(string currencyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllCurrencyTransferTransactions(string currencyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllDebitTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllTransferTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllWalletCreditTransactions(string walletid)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllWalletDebitTransactions(string walletid)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllWalletTransactions(string walletid)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transactions>> GetAllWalletTransferTransactions(string walletid)
        {
            throw new NotImplementedException();
        }

        public Task<Transactions> GetTransaction(string transactonId)
        {
            throw new NotImplementedException();
        }

        public Task<Transactions> LogTransactions(Transactions transactions)
        {
            throw new NotImplementedException();
        }
    }
}
