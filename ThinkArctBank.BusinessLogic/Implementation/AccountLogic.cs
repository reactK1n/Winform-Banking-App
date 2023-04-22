using System;
using System.Collections.Generic;
using System.Data;
using ThinkArctBank.DataBase;
using ThinkArctBank.Model;

namespace ThinkArctBank.BusinessLogic
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IUtilities _utilities;
        private readonly IAccountDb _accountDb;

        public AccountLogic(IUtilities utilities, IAccountDb accountDb)
        {
            _utilities = utilities;
            _accountDb = accountDb;
        }
        public void CreateAccount(string accountType, decimal amount, string userId)
        {
            Account getAccount = new Account();

            if (accountType == "Savings")
            {
                getAccount.AccountNumber = ConfigService._utilities.GenerateAccountNumber();
                getAccount.AccountType = AccountType.Savings.ToString();
                getAccount.CreatedOn = DateTime.UtcNow;
                getAccount.UserId = userId;
                getAccount.Amount = amount;
            }

            if (accountType == "Current")
            {
                getAccount.AccountNumber = ConfigService._utilities.GenerateAccountNumber();
                getAccount.AccountType = AccountType.Current.ToString();
                getAccount.CreatedOn = DateTime.UtcNow;
                getAccount.UserId = userId;
                getAccount.Amount = amount;

            }

            ConfigService._accountDb.AddAccount(getAccount.Id, getAccount.AccountNumber, getAccount.AccountType, getAccount.Amount,
                getAccount.UserId, getAccount.CreatedOn);
        }

        public decimal Balance(string accountNumber)
        {
            var balance = ConfigService._accountDb.AccountBalance(accountNumber);
            return balance;
        }

        public  string  AccountNumberChecker(string accountNumber)
        {
            return ConfigService._accountDb.GetAccountNoByAccountNumber(accountNumber);
        }

        public DataTable GetAccountDetails(string id)
        {
            DataTable table = ConfigService._accountDb.FetchAccounts(id);

            return table;
        }



        public List<string> AddAccountToDropDown(string id)
        {
            var accountList = ConfigService._accountDb.MyAccounts(id);
            return accountList;
        }

    }
}
