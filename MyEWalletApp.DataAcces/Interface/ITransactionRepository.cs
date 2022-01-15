using MyEWalletApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess.Interface
{
    public interface ITransactionRepository
    {
        public Task<Transactions> LogTransactions(Transactions transactions);
        public Task<List<Transactions>> GetAllTransactions();
        public Task<List<Transactions>> GetAllWalletTransactions(string walletid);
        public Task<List<Transactions>> GetAllCurrencyTransactions(string currencyId);
        public Task<Transactions> GetTransaction(string transactonId);
        public Task<List<Transactions>> GetAllCreditTransactions();
        public Task<List<Transactions>> GetAllWalletCreditTransactions(string walletid);
        public Task<List<Transactions>> GetAllCurrencyCreditTransactions(string currencyId);
        public Task<List<Transactions>> GetAllDebitTransactions();
        public Task<List<Transactions>> GetAllWalletDebitTransactions(string walletid);
        public Task<List<Transactions>> GetAllCurrencyDebitTransactions(string currencyId);
        public Task<List<Transactions>> GetAllTransferTransactions();
        public Task<List<Transactions>> GetAllWalletTransferTransactions(string walletid);
        public Task<List<Transactions>> GetAllCurrencyTransferTransactions(string currencyId);
    }
}
