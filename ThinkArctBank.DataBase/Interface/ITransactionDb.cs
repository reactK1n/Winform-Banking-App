using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkArctBank.DataBase
{
    public interface ITransactionDb
    {
        public DataTable FetchTransactions(string accountNo, string firstDate, string secondDate);
        public void AddTransaction(string accountNo, decimal transactionAmount, string description,
            string transactionType, string id, DateTime createdOn);
        public decimal UpdateBalance(string accountNo, decimal amount, string transactionType);
        public string GetAccountId(string accountNo);
    }
}
