using System;
using System.Data;
using ThinkArctBank.DataBase;
using ThinkArctBank.Model;

namespace ThinkArctBank.BusinessLogic
{

    public class TransactionLogic : ITransactionLogic
    {
        private readonly ITransactionDb _transactionDb;

        public TransactionLogic(ITransactionDb transactionDb)
        {
            _transactionDb = transactionDb;
        }

        public DataTable GetTransaction(string accountNumber, string firstDate, string secondDate)
    {
        DataTable table = ConfigService._transactionDb.FetchTransactions(accountNumber, firstDate, secondDate);
        return table;
    }

    public void Transfer(string senderAccount, decimal transactionAmount, string recipientAccount, string recipientName,
        string descriptions)
    {
        string description = string.Empty;
        Transactions TransferSenderAccount = new Transactions();
        TransferSenderAccount.TransactionType = TransactionType.Debit.ToString();
        TransferSenderAccount.Description = $"You transfered money to {recipientName}";
        TransferSenderAccount.TransactionAmount = transactionAmount;
        TransferSenderAccount.CreatedOn = DateTime.Now.ToString();

        if (descriptions == string.Empty)
        {
            description = $"You Received money from {Authentication.CurrentUser.FullName}";
        }
        else
        {
            description = descriptions;
        }

        Transactions TransferRecipientAccount = new Transactions();
        TransferRecipientAccount.CreatedOn = DateTime.Now.ToString();
        TransferRecipientAccount.TransactionType = TransactionType.Credit.ToString();
        TransferRecipientAccount.Description = description;
        TransferRecipientAccount.TransactionAmount = transactionAmount;

        ConfigService._transactionDb.AddTransaction(senderAccount, TransferSenderAccount.TransactionAmount,
            TransferSenderAccount.Description, TransferSenderAccount.TransactionType, TransferSenderAccount.Id,
            Convert.ToDateTime(TransferSenderAccount.CreatedOn));
        ConfigService._transactionDb.AddTransaction(recipientAccount, TransferRecipientAccount.TransactionAmount,
            TransferRecipientAccount.Description, TransferRecipientAccount.TransactionType, TransferRecipientAccount.Id,
            Convert.ToDateTime(TransferRecipientAccount.CreatedOn));
    }

    public void Withdraw(string accountNumber, decimal transactionAmount)
    {
        Transactions withdrawAccount = new Transactions();
        withdrawAccount.CreatedOn = DateTime.Now.ToString();
        withdrawAccount.TransactionType = TransactionType.Debit.ToString();
        withdrawAccount.Description = $"Your Account Was Debited";
        withdrawAccount.TransactionAmount = transactionAmount;
        ConfigService._transactionDb.AddTransaction(accountNumber, withdrawAccount.TransactionAmount, withdrawAccount.Description,
            withdrawAccount.TransactionType, withdrawAccount.Id, Convert.ToDateTime(withdrawAccount.CreatedOn));
    }

    public void Deposit(string accountNumber, decimal transactionAmount)
    {
        Transactions depositAccount = new Transactions();
        depositAccount.CreatedOn = DateTime.Now.ToString();
        depositAccount.TransactionType = TransactionType.Credit.ToString();
        depositAccount.Description = "Your Account Was Credited";
        depositAccount.TransactionAmount = transactionAmount;
        ConfigService._transactionDb.AddTransaction(accountNumber, depositAccount.TransactionAmount, depositAccount.Description,
            depositAccount.TransactionType, depositAccount.Id, Convert.ToDateTime(depositAccount.CreatedOn));

    }


    }

}
