using System;
using System.Collections.Generic;
using System.Transactions;

//using ThinkArctBank.enumdata;

namespace ThinkArctBank.Model
{
    public class Account 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Amount { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }



    public enum AccountType
    {
        Savings, Current
    }
}
