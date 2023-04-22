using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkArctBank.DataBase
{
    public interface IAccountDb
    {
        public void AddAccount(string id, string accountNumber, string accountType, decimal amount,
            string userId, DateTime createdOn);
        public decimal AccountBalance(string accountNo);
        public DataTable FetchAccounts(string id);
        public List<string> MyAccounts(string id);
        public string GetAccountNoByAccountNumber(string accountNo);
    }
}
