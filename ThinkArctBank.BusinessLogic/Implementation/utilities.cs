using System;
using ThinkArctBank.DataBase;

namespace ThinkArctBank.BusinessLogic
{
    class utilities : IUtilities
    {
        private readonly IAccountLogic _accountLogic;
        public utilities( IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }
        public string GenerateAccountNumber()
        {

            Random getNumber = new Random();
            string accountNumber = string.Empty;
            bool isExist = true;

            while (isExist)
            {
                var getAccountNumber = getNumber.Next(113674, 986579);
                accountNumber = $"02{getAccountNumber}30";
                string accNo = ConfigService._accountDb.GetAccountNoByAccountNumber(accountNumber);
                isExist = accountNumber == accNo;
            }

            return accountNumber;
        }

    }
}
