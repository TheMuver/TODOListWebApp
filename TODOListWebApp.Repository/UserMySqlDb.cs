using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using MySql.Data.MySqlClient;
using Dapper;

namespace TODOListWebApp.Repository
{
    class UserMySqlDb : IUserRepository
    {
        public void InsertUser(UserDTO user)
        {
            using (IDbConnection db = new MySqlConnection(Resources.CONNECTIONSTRING))
            {
                string sqlQuery = "insert into user values (@Login, @Password);";

                db.Execute(sqlQuery, user);
            }
        }

        public UserDTO GetUserByLogin(string login)
        {
            UserDTO user;
            using (IDbConnection db = new MySqlConnection(Resources.CONNECTIONSTRING))
            {
                string sqlQuery = "select * from user where @login = user.login;";

                user = db.Query<UserDTO>(sqlQuery).FirstOrDefault();
            }
            return user;
        }

        public void UpdateUser(UserDTO user)
        {
            using (IDbConnection db = new MySqlConnection(Resources.CONNECTIONSTRING))
            {
                string sqlQuery = "update user set @Login, @Password where @Login = user.login;";

                db.Execute(sqlQuery, user);
            }
        }

        public void DeleteUser(UserDTO user)
        {
            using (IDbConnection db = new MySqlConnection(Resources.CONNECTIONSTRING))
            {
                string sqlQuery = "delete from user where @Login = user.login;";

                db.Execute(sqlQuery, user);
            }
        }
    }
}
