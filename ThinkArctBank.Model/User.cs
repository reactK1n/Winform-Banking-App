using System;
using System.Collections.Generic;

namespace ThinkArctBank.Model
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        //empty ctor
        public User()
        {
            
        }
        //creating user
        public User(string username, string password, string fullName)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            CreatedOn = DateTime.UtcNow;
        }

    
    }
}
