using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListWebApp.Repository
{
    public interface IUserRepository
    {
        void InsertUser(UserDTO user);

        //UserDTO GetUserByLogin(string login);

        bool IsUserExist(UserDTO user);

        bool IsCorrectData(UserDTO user);

        void DeleteUser(UserDTO user);

        void UpdateUser(UserDTO user);
    }
}
