using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ThinkArctBank.DataBase
{
    public class AccountDb : IAccountDb
    {
        public void AddAccount(string id, string accountNumber, string accountType, decimal amount, string userId, DateTime createdOn)
        {
            SqlConnection connected = Connector.Connect();
            using (connected)
            {
                SqlCommand cmd = new SqlCommand("spInsertAccountDataIntoTable", connected)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
                cmd.Parameters.AddWithValue("@AccountType", accountType);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@CreatedOn", createdOn);
                connected.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public decimal AccountBalance(string accountNo)
        {
            SqlConnection connected = Connector.Connect();
            string balance = string.Empty;
            using (connected)
            {
                SqlCommand command = new SqlCommand("spGetAmountFromAccountNo", connected);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AccountNo", accountNo);
                connected.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    balance = reader["Amount"].ToString();
                }

            }

            return Convert.ToDecimal(balance);
        }

        public DataTable FetchAccounts(string id)
        {

            SqlConnection connected = Connector.Connect();
            var table = new DataTable();

            table.Columns.Add("Name");
            table.Columns.Add("Account Number");
            table.Columns.Add("Account Type");
            table.Columns.Add("Balance");
            using (connected)
            {
                SqlCommand command = new SqlCommand("spFetchAccount", connected);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                connected.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    table.Rows.Add(reader["FullName"].ToString(), reader["AccountNumber"].ToString(), reader["AccountType"].ToString(), reader["Amount"].ToString());
                }
            }
            return table;
        }

        public List<string> MyAccounts(string id)
        {
            List<string> accountNumber = new List<string>();
            int count = 0;
            SqlConnection connected = Connector.Connect();
            using (connected)
            {
                SqlCommand command = new SqlCommand("spGetAccountNoFromId ", connected);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                connected.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    accountNumber.Add(reader[count].ToString());
                    count = 0;
                }

            }

            return accountNumber;
        }

        public string GetAccountNoByAccountNumber(string accountNo)
        {
            var accountNumber = string.Empty;
            SqlConnection connected = Connector.Connect();
            try
            {
                using (connected)
                {
                    SqlCommand command = new SqlCommand("spGetAccountNumberFromAccountNo", connected);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AccountNo", accountNo);
                    connected.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accountNumber = reader["AccountNumber"].ToString();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Account Number Not Found!");
            }

            return accountNumber;
        }
    }
}
