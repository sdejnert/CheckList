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
            int userId = 0;
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
    }
}
