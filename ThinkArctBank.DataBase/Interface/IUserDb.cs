using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkArctBank.Model;

namespace ThinkArctBank.DataBase
{
    public interface IUserDb
    {
        public void RegisterUser(User data);
        public User UserLogin(string username, string password);
        public string AccountNameFinder(string recipientAccount);
        public string GetUserByUserName(string username);
        public void LoginChecker(string username, string password);
    }
}
