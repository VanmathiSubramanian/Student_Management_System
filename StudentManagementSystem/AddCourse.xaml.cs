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
    /// Interaction logic for AddCourse.xaml
    /// </summary>
    public partial class AddCourse : Window
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(courseCodeText.Text) || String.IsNullOrEmpty(CourseNameTextBox.Text) || String.IsNullOrEmpty(DepartmentTextBox.Text)
               || String.IsNullOrEmpty(CourseTypeText.Text))
            {

                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("fields are missing," +
                    "\nAll the fields are required.", "Oops!", System.Windows.MessageBoxButton.YesNoCancel);

            }
        }
    }
}
