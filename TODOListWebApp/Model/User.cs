using System;
using System.ComponentModel.DataAnnotations;
using TODOListWebApp.Repository;

namespace TODOListWebApp
{
    public class User
    {
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Login { get; set; }

        public string Password { get; set; }

        public User() { }

        public User(string login, string password) 
        {
            Login = login;
            Password = password;
        }

        public User(UserDTO dto) 
        {
            Login = dto.Login;
            Password = dto.Password;
        }

        public UserDTO ToDTO () 
        {
            return new UserDTO(Login, Password);
        }

        public override bool Equals(object obj)
        {
            if (obj is User) 
            {
                var tmp = obj as User;
                return Login.Equals(tmp.Login) && Password.Equals(tmp.Password);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"User: {Login} {Password}";
        }
    }
}