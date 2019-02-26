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
        DataBaseConnection dataBaseConnection = new DataBaseConnection();
        NewUser newUser = new NewUser();
        CheckingService checkingService = new CheckingService();
        CheckBoxMainWindow checkBoxMainWindow = new CheckBoxMainWindow();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoToCreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            newUser.Show();
            this.Close();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                LoginIn();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginIn();
        }

        private void LoginIn()
        {
            ErrorLoginTextBlock.Text = "";
            if (checkingService.CheckIfUserExists(UserLoginTextBox.Text))
            {
                ErrorLoginTextBlock.Text = errorForLogin;
            }
            else
            {
                if(UserLoginTextBox.Text == null && UserLoginPasswordBox.Password.ToString() == null)
                {
                    ErrorLoginTextBlock.Text = errorForLogin;
                }
                else
                {
                    if(!checkingService.CheckIfPasswordMatch(UserLoginPasswordBox.Password.ToString(), UserLoginTextBox.Text))
                    {
                        ErrorLoginTextBlock.Text = errorForLogin;
                    }
                    else
                    {
                        checkBoxMainWindow.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}
