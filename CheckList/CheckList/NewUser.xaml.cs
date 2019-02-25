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
            string password1 = NewUserPassword1TextBox.Text;
            string password2 = NewUserPassword2TextBox.Text;
    
            if (!CheckIfPasswordAreSame(password1, password2))
            {
                MessageBox.Show("Hasła są różne");
            }
            else
            {
                MessageBox.Show("Stworzono nowego użytkownika");
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
