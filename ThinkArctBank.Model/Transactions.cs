using System;

namespace ThinkArctBank.Model
{
    public class Transactions
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; }
        public string TransactionType { get; set; }
        public string AccountId { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal Balance { get; set; }
        public string CreatedOn { get; set; } = DateTime.Now.ToShortDateString();
        public string UpdatedOn { get; set; }
    }
    public enum TransactionType
    {
        Debit, Credit
    }
}
