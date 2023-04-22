using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using ThinkArctBank.DataBase;
using ThinkArctBank.Model;

namespace ThinkArctBank.BusinessLogic
{
    public class Authentication : IAuthentication
    {
        private readonly IUserDb _userDb;
        private readonly IAccountLogic _accountLogic;

        public Authentication(IUserDb userDb, IAccountLogic accountLogic)
        {
            _userDb = userDb;
            _accountLogic = accountLogic;
        }
        public static User CurrentUser { get; set; }

        
        //register user
        public void UserSignUp(string userName, string fullName, string passWord, string accountType)
        {
            var data = new User(userName, passWord, fullName);
            var user = ConfigService._userDb.GetUserByUserName(userName);
            if (!string.IsNullOrEmpty(user))
            {
                throw new ArgumentException($"{userName} as been taken");
            }
            ConfigService._userDb.RegisterUser(data);
            var userId = data.Id;
            ConfigService._accountLogic.CreateAccount(accountType, 0, userId);
        }

        //login user
        public User Login(string username, string password)
        {
            var user = ConfigService._userDb.UserLogin(username, password);
            CurrentUser = user;
            return user;
        }

        //recipientName finder
        public string GetAccountName(string recipientAccount)
        {
            var recipientAccountName = ConfigService._userDb.AccountNameFinder(recipientAccount);
            return recipientAccountName;
        }

    }



}
