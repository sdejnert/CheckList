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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckList
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String errorForLogin = "Zły login lub hasło";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoToCreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorLoginTextBlock.Text = "";
            if (CheckIfUserExists()) {
                DataBaseConnection dataBaseConnection = new DataBaseConnection();
                MessageBox.Show("Zalogowno użytkownika o id " + dataBaseConnection.ConnectWithDataBasePublic(UserLoginTextBox.Text));
            }
            else
            {
                ErrorLoginTextBlock.Text = errorForLogin;
            }
        }

        public bool CheckIfUserExists()
        {
            if(UserLoginTextBox.Text == "A" && UserPasswordTextBox.Text == "A")
            {
                return true;
            }
            return false;
        }
    }
}
