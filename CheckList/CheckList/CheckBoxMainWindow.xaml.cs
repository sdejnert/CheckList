using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logika interakcji dla klasy CheckBoxMainWindow.xaml
    /// </summary>
    public partial class CheckBoxMainWindow : Window
    {
        public User user;
        public CheckBoxMainWindow()
        {
            InitializeComponent();
        }

        private void SignoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        private void Grid_Loaded(object sender, RoutedEventArgs re)
        {
            DataBaseConnection dataBaseConnection = new DataBaseConnection();
            dataBaseConnection.DownloadDataFromDataBase(user);
        }

    }
}
