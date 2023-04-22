using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ThinkArctBank.Model;

namespace ThinkArctBank.DataBase
{
    public class UserDb : IUserDb
    {

        //register user
        public void RegisterUser(User data)
        {
            SqlConnection connected = Connector.Connect();
            using (connected)
            {
                SqlCommand cmd = new SqlCommand("spInsertUserDataIntoTable", connected);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", data.Id);
                cmd.Parameters.AddWithValue("@FullName", data.FullName);
                cmd.Parameters.AddWithValue("@Username", data.Username);
                cmd.Parameters.AddWithValue("@Password", data.Password);
                cmd.Parameters.AddWithValue("@CreatedOn", data.CreatedOn);
                connected.Open();
                cmd.ExecuteNonQuery();
            }
        }


        //login user
        public User UserLogin(string username, string password)
        {
            SqlConnection connected = Connector.Connect();
            var user = new User();
            try
            {
                using (connected)
                {
                    SqlCommand command =
                        new SqlCommand("spGetLoginDetailsFromUsernameAndPassword", connected);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    connected.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader["Id"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                    }
                }

            }
            catch (Exception)
            {
                return null;
            }
            return user;
        }

        //recipientName finder
        public string AccountNameFinder(string recipientAccount)
        {
            string recipientAccountName = string.Empty;
            IList<string> userId = new List<string>();
            IList<string> fullname = new List<string>();
            SqlConnection connected = Connector.Connect();
            try
            {
                using (connected)
                {
                    SqlCommand command = new SqlCommand("spGetUserIdFromAccountNumber",
                        connected);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accountNumber", recipientAccount);
                    connected.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userId.Add(reader
                                .GetString(0)); // provided that first (0-index) column is int which you are looking for
                        }
                    }

                }

            }
            catch (Exception e) { }

            SqlConnection connected2 = Connector.Connect();
            try
            {
                using (connected2)
                {
                    SqlCommand command = new SqlCommand("spGetUFullnameFromUserId", connected2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userId", userId[0]);
                    connected2.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fullname.Add(reader
                                .GetString(0)); // provided that first (0-index) column is int which you are looking for
                        }
                    }

                }

            }
            catch (Exception e) { }

            if (fullname.Count == 0)
            {
                return string.Empty;
            }

            return fullname[0];
        }

        public string GetUserByUserName(string username)
        {
            var userName = String.Empty;
            SqlConnection connected = Connector.Connect();
            try
            {
                using (connected)
                {
                    SqlCommand command = new SqlCommand(" spGetUsernameWithThesameUsername", connected);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", username);
                    connected.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userName = reader["Username"].ToString();
                        }
                    }

                }

            }
            catch (Exception e) { }

            return userName;
        }

        public void LoginChecker(string username, string password)
        {
            var userName = string.Empty;
            var passWord = string.Empty;
            SqlConnection connected = Connector.Connect();
            try
            {
                using (connected)
                {
                    SqlCommand command = new SqlCommand("spGetLoginDetailsFromUsernameAndPassword ", connected);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    connected.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userName = reader["Username"].ToString();
                            passWord = reader["Password"].ToString();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid username or password");
            }
            //return new string[2] {userName, passWord};
        }
    }
}
