using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListWebApp.Repository
{
    interface IUserRepository
    {
        public void InsertUser(UserDTO user);

        public UserDTO GetUserByLogin(string login);

        public void DeleteUser(UserDTO user);

        public void UpdateUser(UserDTO user);
    }
}
