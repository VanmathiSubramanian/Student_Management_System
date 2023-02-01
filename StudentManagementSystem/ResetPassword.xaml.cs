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

namespace StudentManagementSystem
{
    /// <summary>
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void SignInResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(userNameText.Text) || String.IsNullOrEmpty(LoginPassword.Text) || String.IsNullOrEmpty(EnterConfirmPassword.Text))
            {

                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("fields are missing," +
                    "\nAll the fields are required.", "Oops!", System.Windows.MessageBoxButton.YesNoCancel);

            }
            this.Visibility = Visibility.Hidden;
           // ResetPassword resetPasswordObject = new ResetPassword();
           // resetPasswordObject.Show();
        }
    }
}
