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
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(StudentId.Text) || String.IsNullOrEmpty(FirstName.Text) || String.IsNullOrEmpty(LastNametext.Text)
               || String.IsNullOrEmpty(gendertext.Text) || String.IsNullOrEmpty(Date.Text) || String.IsNullOrEmpty(CCText.Text)
               || String.IsNullOrEmpty(yeartext.Text))
            {

                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("fields are missing," +
                    "\nAll the fields are required.", "Oops!", System.Windows.MessageBoxButton.YesNoCancel);

            }

        }

        private void cancelEditBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
