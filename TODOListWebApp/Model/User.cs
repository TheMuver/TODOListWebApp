using System;

namespace TODOListWebApp
{
    public class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public User() { }

        public User(string login, string password) 
        {
            Login = login;
            Password = password;
        }
    }
}