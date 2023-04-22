using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkArctBank.DataBase;
using ThinkArctBank.Model;

namespace ThinkArctBank.BusinessLogic
{
    public interface ITransactionLogic
    {
        public DataTable GetTransaction(string accountNumber, string firstDate, string secondDate);
        public void Transfer(string senderAccount, decimal transactionAmount, string recipientAccount,
            string recipientName, string descriptions);
        public void Withdraw(string accountNumber, decimal transactionAmount);
        public void Deposit(string accountNumber, decimal transactionAmount);
    }
}
