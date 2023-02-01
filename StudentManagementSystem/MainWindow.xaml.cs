using StudentManagementSystem.Database;
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

namespace StudentManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numOfTries = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(userNameText.Text) || String.IsNullOrEmpty(LoginPassword.Password))
            {
                this.numOfTries--;
                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Username or Password is missing," +
                    "\nType in anything to test.", "Oops!", System.Windows.MessageBoxButton.YesNoCancel);

                if (this.numOfTries <= 0)
                {
                    signInButton.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                this.Visibility = Visibility.Hidden;
                // Connect to database and verify username and password
                string userName = userNameText.Text;
                string password = LoginPassword.Password;
                string sql = $"SELECT TOP 1 1 FROM Account WHERE User_Name='{userName}' AND Password = '{password}'";
                var result = DbRepository.ReadData(sql);

                if (result.Tables[0].Rows.Count > 0)
                {
                    StudentListDashboard studentListDashboardObject = new StudentListDashboard();
                    studentListDashboardObject.Show();
                }
                else
                {
                    userNameText.Text = "";
                    LoginPassword.Password = "";
                    this.Visibility = Visibility.Visible;
                    MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Invalid User name or Password. Retry again!", "Oops!", System.Windows.MessageBoxButton.OK);
                }
            }
        }

        private void SignInResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            ResetPassword resetPasswordObject = new ResetPassword();
            resetPasswordObject.Show();
        }
    }
}
