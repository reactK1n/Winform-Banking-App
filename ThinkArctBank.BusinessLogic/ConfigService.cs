using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkArctBank.DataBase;


namespace ThinkArctBank.BusinessLogic
{
    public class ConfigService
    {
        public static IUserDb _userDb;
        public static IAccountDb _accountDb;
        public static ITransactionDb _transactionDb;
        public static IAuthentication _authentication;
        public static IAccountLogic _accountLogic;
        public static ITransactionLogic _transactionLogic;
        public static IUtilities _utilities;

        public ConfigService()
        {
            _userDb = new UserDb();
            _accountDb = new AccountDb();
            _transactionDb = new TransactionDb();
            _authentication = new Authentication(_userDb, _accountLogic);
            _accountLogic = new AccountLogic(_utilities, _accountDb);
            _transactionLogic = new TransactionLogic(_transactionDb);
            _utilities = new utilities(_accountLogic);
        }



    }
}
