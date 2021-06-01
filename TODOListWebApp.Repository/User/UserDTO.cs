using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListWebApp.Repository
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public UserDTO(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public override bool Equals(object obj)
        {
            if (obj is UserDTO) 
            {
                var tmp = obj as UserDTO;
                return Login.Equals(tmp.Login) && Password.Equals(tmp.Password);
            }
            return base.Equals(obj);
        }
    }
}
