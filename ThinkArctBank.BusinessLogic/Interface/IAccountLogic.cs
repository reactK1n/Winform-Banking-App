using System.Collections.Generic;
using System.Data;

namespace ThinkArctBank.BusinessLogic
{
    public interface IAccountLogic
    {
        public void CreateAccount(string accountType, decimal amount, string userId);
        public decimal Balance(string accountNumber);
        public string AccountNumberChecker(string accountNumber);
        public DataTable GetAccountDetails(string id);
        public List<string> AddAccountToDropDown(string id);

    }
}
