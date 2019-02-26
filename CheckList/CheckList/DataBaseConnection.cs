using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace CheckList
{
    class DataBaseConnection
    {

        private int ConnectWithDataBase(string userName)
        {

            string userIdString = null;
            using (SQLiteConnection connect = new SQLiteConnection(@"Data source = checkdb.s3db"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT usersid FROM users U WHERE U.NAZWA = '" + userName + "'";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        userIdString = r["usersid"].ToString();
                    }
                }
                connect.Close();
            }
            return int.Parse(userIdString);
        }

        public int ConnectWithDataBasePublic(string userName)
        {
            int userId = ConnectWithDataBase(userName);
            return userId;
        }

        public bool CheckIfUserExistInDataBase(string userName)
        {
            string userNameFromDataBase = null;
            using (SQLiteConnection connect = new SQLiteConnection(@"Data source = checkdb.s3db"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT nazwa FROM users U WHERE U.NAZWA = '" + userName + "'";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        userNameFromDataBase = r["usersid"].ToString();
                    }
                }
                connect.Close();
            }
            if(userNameFromDataBase != null)
            {
                if (userName.ToLower() == userNameFromDataBase.ToLower())
                {
                    return false;
                }
            }
            return true;
       
        }

        public void CreateNewUserInDataBase(User user)
        {
            using (SQLiteConnection connect = new SQLiteConnection(@"Data source = checkdb.s3db"))
            {
                connect.Open();
                SQLiteCommand fmd = new SQLiteCommand(@"INSERT INTO USERS (nazwa, password) values (@nazwa, @password)", connect);
                fmd.Parameters.AddWithValue("@nazwa", user.userName);
                fmd.Parameters.AddWithValue("@password", user.password);

                fmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public User FindUserFromDataBaseByUser(User user)
        {
            User userFromDataBase = new User();
            string userIdString = null;
            using (SQLiteConnection connect = new SQLiteConnection(@"Data source = checkdb.s3db"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT * FROM users U WHERE U.NAZWA = '" + user.userName + "'";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        userIdString = r["usersid"].ToString();
                        userFromDataBase.userName = r["nazwa"].ToString();
                        userFromDataBase.password = r["password"].ToString();
                    }
                }
                connect.Close();
            }
            userFromDataBase.userId = int.Parse(userIdString);
            return userFromDataBase;
        }
        public User FindUserFromDataBaseByUserName(string userName)
        {
            User userFromDataBase = new User();
            String userIdString = null;
            using (SQLiteConnection connect = new SQLiteConnection(@"Data source = checkdb.s3db"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT * FROM users U WHERE U.NAZWA = '" + userName + "'";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        userIdString = r["usersid"].ToString();
                        userFromDataBase.userName = r["nazwa"].ToString();
                        userFromDataBase.password = r["password"].ToString();
                    }
                }
                connect.Close();
            }
            if(userIdString != null)
            {
                userFromDataBase.userId = int.Parse(userIdString);
            }
            
            return userFromDataBase;
        }

        public void DownloadDataFromDataBase()
        {

        }
    }
}
