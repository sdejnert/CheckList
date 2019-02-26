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
        CheckingService checkingService = new CheckingService();
        

        public NewUser()
        {
            InitializeComponent();
        }

        private void GoToMainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CreateNewUserButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUser();
        }

        private void CreateNewUser() {
            user.userName = NewUserTextBox.Text;
            user.password = NewUserPasswordBox1.Password.ToString();
            string password2 = NewUserPasswordBox2.Password.ToString();
            MainWindow mainWindow = new MainWindow();

            if (!checkingService.CheckIfPasswordAreSame(user.password, password2))
            {
                MessageBox.Show("Hasła są różne");
            }
            else
            {
                if (!checkingService.CheckIfUserExists(user.userName))
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
    }
}
