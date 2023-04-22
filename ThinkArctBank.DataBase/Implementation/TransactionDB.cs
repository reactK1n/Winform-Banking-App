using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ThinkArctBank.DataBase
{
    public class TransactionDb : ITransactionDb
    {

        public DataTable FetchTransactions(string accountNo, string firstDate, string secondDate)
        {
            string id = GetAccountId(accountNo);
            var table = new DataTable();
            DateTime Dates = DateTime.Now;
            var hour = Dates.Hour;
            var minute = Dates.Minute;
            var second = Dates.Second;

            var startDate = Convert.ToDateTime(Convert.ToDateTime(firstDate).ToShortDateString());
            var endDates = Convert.ToDateTime(Convert.ToDateTime(secondDate).ToShortDateString());
            var endDate = new DateTime(endDates.Year, endDates.Month, endDates.Day + 1, Dates.Hour, Dates.Minute, Dates.Second);
            table.Columns.Add("DATE");
            table.Columns.Add("DESCRIPTION");
            table.Columns.Add("AMOUNT");
            table.Columns.Add("BALANCE");
            SqlConnection connected = Connector.Connect();
            using (connected)
            {

                SqlCommand cmd = new SqlCommand("spFetchTransactionDetailsJoinAccountAmount", connected);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                connected.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    table.Rows.Add(Convert.ToDateTime(reader["CreatedOn"].ToString()).ToShortDateString(), reader["Description"].ToString(), reader["TransactionAmount"].ToString(), reader["Balance"].ToString());
                }
            }
            return table;
        }


        public void AddTransaction(string accountNo, decimal transactionAmount, string description, string transactionType, string id, DateTime createdOn)
        {

            SqlConnection connected = Connector.Connect();
            using (connected)
            {
                connected.Open();
                SqlTransaction transaction = connected.BeginTransaction();
                try
                {
                    decimal balance = UpdateBalance(accountNo, transactionAmount, transactionType);
                    var accountId = GetAccountId(accountNo);
                    SqlCommand cmd = new SqlCommand("spInsertTransactionsDataIntoTable", connected, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                    cmd.Parameters.AddWithValue("@AccountId", accountId);
                    cmd.Parameters.AddWithValue("@TransactionAmount", transactionAmount);
                    cmd.Parameters.AddWithValue("@Balance", balance);
                    cmd.Parameters.AddWithValue("@CreatedOn", createdOn);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

            }

        }

        public decimal UpdateBalance(string accountNo, decimal amount, string transactionType)
        {

            SqlConnection connected = Connector.Connect();
            var myAmount = string.Empty;
            using (connected)
            {
                SqlCommand command = new SqlCommand("spGetAmountFromAccountNo", connected);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountNo", accountNo);
                connected.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myAmount = reader["Amount"].ToString();
                    }
                }

            }


            decimal balance = 0;
            if (transactionType == "Credit")
            {
                balance = Convert.ToDecimal(myAmount) + amount;
            }
            if (transactionType == "Debit")
            {
                balance = Convert.ToDecimal(myAmount) - amount;
            }
            SqlConnection connected2 = Connector.Connect();
            using (connected2)
            {
                connected2.Open();
                SqlTransaction transaction = connected2.BeginTransaction();
                try
                {
                    SqlCommand command = new SqlCommand("spUpdateAmount", connected2, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@balance", balance);
                    command.Parameters.AddWithValue("@senderAccountNo", accountNo);
                    command.ExecuteNonQuery();
                    transaction.Commit();

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }

            }

            return balance;
        }

        public string GetAccountId(string accountNo)
        {
            SqlConnection connected = Connector.Connect();
            IList<string> account = new List<string>();
            using (connected)
            {
                SqlCommand command = new SqlCommand("spGetIdFromAccountNumber", connected);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accountNumber", accountNo);
                connected.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        account.Add(reader.GetString(0)); // provided that first (0-index) column is int which you are looking for
                    }
                }

            }

            string id = account[0];
            return id;
        }



    }
}
