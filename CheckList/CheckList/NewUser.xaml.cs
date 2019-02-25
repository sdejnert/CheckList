using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CheckList
{
    /// <summary>
    /// Logika interakcji dla klasy NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        User user = new User();
        DataBaseConnection baseConnection = new DataBaseConnection();
        MainWindow mainWindow = new MainWindow();

        public NewUser()
        {
            InitializeComponent();
        }

        private void GoToMainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }

        private void CreateNewUserButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUser();
        }

        private void CreateNewUser() {
            user.userName = NewUserTextBox.Text;
            user.password = NewUserPassword1TextBox.Text;
            string password2 = NewUserPassword2TextBox.Text;
    
            if (!CheckIfPasswordAreSame(user.password, password2))
            {
                MessageBox.Show("Hasła są różne");
            }
            else
            {
                if (!baseConnection.CheckIfUserExistInDataBase(user.userName))
                {
                    MessageBox.Show("Użytkownik o takim loginie już istnieje");
                }
                else
                {
                    baseConnection.CreateNewUserInDataBase(user);
                    MessageBox.Show("Stworzono nowego użytkownika");
                    mainWindow.Show();
                    mainWindow.UserLoginTextBox.Text = user.userName;
                    this.Close();
                }
            }
        }

        private bool CheckIfPasswordAreSame(string pass1, string pass2) {
            if(pass1 == pass2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
