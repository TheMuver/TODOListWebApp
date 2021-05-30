using System;
using System.Collections.Generic;
using System.Linq;

namespace TODOListWebApp.Repository.User
{
    public class UserInMemoryDb : IUserRepository
    {
        private List<UserDTO> _data = new List<UserDTO>();

        public void DeleteUser(UserDTO user)
        {
            _data.RemoveAt(_data.FindIndex(u => u.Login == user.Login));
        }

        public void InsertUser(UserDTO user)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCorrectData(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public bool IsUserExist(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserDTO user)
        {
            throw new System.NotImplementedException();
        }
    }
}