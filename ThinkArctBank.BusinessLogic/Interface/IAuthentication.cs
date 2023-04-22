using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkArctBank.DataBase;
using ThinkArctBank.Model;

namespace ThinkArctBank.BusinessLogic
{
    public interface IAuthentication
    {

        public void UserSignUp(string userName, string fullName, string passWord, string accountType);
        public User Login(string username, string password);
        public string GetAccountName(string recipientAccount);

    }
}
