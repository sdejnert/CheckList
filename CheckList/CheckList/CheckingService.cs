using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList
{
    public class CheckingService
    {
        DataBaseConnection dataBaseConnection = new DataBaseConnection();

        public bool CheckIfPasswordAreSame(string pass1, string pass2)
        {
            if (pass1 == pass2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfUserExists(String login)
        {
            if (dataBaseConnection.FindUserFromDataBaseByUserName(login).userName == null)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfPasswordMatch(string userPassword, string Login)
        {
            if (dataBaseConnection.FindUserFromDataBaseByUserName(Login).password == userPassword)
            {
                return true;
            }
            return false;
        }
    }
}
