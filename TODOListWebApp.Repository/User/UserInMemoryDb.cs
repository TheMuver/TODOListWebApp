using System;
using System.Collections.Generic;
using System.Linq;

namespace TODOListWebApp.Repository
{
    public class UserInMemoryDb : IUserRepository
    {
        private List<UserDTO> _data = new List<UserDTO>();

        // TODO удалить
        public UserInMemoryDb() {
            InsertUser(new UserDTO("q@q.qq", "1"));
        }

        public void DeleteUser(UserDTO user)
        {
            _data.RemoveAt(_data.FindIndex(u => u.Equals(user)));
        }

        public void InsertUser(UserDTO user)
        {
            _data.Add(user);
        }

        public bool IsCorrectData(UserDTO user)
        {
            return _data.Any(u => u.Equals(user));
        }

        public bool IsUserExist(UserDTO user)
        {
            return _data.Any(u => u.Login.Equals(user.Login));
        }

        public void UpdateUser(UserDTO user)
        {
            _data.RemoveAt(_data.FindIndex(u => u.Login.Equals(user.Login)));
            InsertUser(user);
        }
    }
}