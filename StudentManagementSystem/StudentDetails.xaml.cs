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
using System.Windows.Shapes;

namespace StudentManagementSystem
{
    /// <summary>
    /// Interaction logic for StudentDetails.xaml
    /// </summary>
    public partial class StudentDetails : Window
    {
        public StudentDetails(int studentId = 0)
        {
            InitializeComponent();
            string readStudentSql = $"SELECT S.Student_Id, First_Name, Last_Name, Gender, Date_Of_Birth, S.Course_Code, Is_Active, Year, Grade  FROM Student S JOIN Attendance A ON S.Student_Id = A.Student_Id WHERE S.Student_Id={studentId}";
            var result = DbRepository.ReadData(readStudentSql);

            if (result.Tables[0].Rows.Count < 0)
            {
                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show($"Unable to find user with student id = {studentId}!", "Oops!", System.Windows.MessageBoxButton.OK);
            }
            else
            {
                var itemArray = result.Tables[0].Rows[0].ItemArray;

                StudentIdtxt.Text = Convert.ToString(itemArray[0]);
                AddName.Text = Convert.ToString(itemArray[1]);
                LastNametxt.Text = Convert.ToString(itemArray[2]);
                gendertxt.Text = Convert.ToString(itemArray[3]);
                DatePicker.SelectedDate = Convert.ToDateTime(itemArray[4]); 
                CourseCodetxt.Text = Convert.ToString(itemArray[5]);
                IsActive.IsChecked = ToBoolen(Convert.ToString(itemArray[6]));
                Yeartxt.Text = Convert.ToString(itemArray[7]);
                gradetxt.Text = Convert.ToString(itemArray[8]);

            }
        }

        private bool? ToBoolen(string v)
        {
            return !string.IsNullOrEmpty(v) ? (string.Equals(v, "YES", StringComparison.OrdinalIgnoreCase) ? true : false) : false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStudent studentAddObject = new AddStudent();
            studentAddObject.Show();
        }

        private void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(StudentIdtxt.Text) || String.IsNullOrEmpty(AddName.Text)|| String.IsNullOrEmpty(LastNametxt.Text)
                || String.IsNullOrEmpty(gendertxt.Text) || String.IsNullOrEmpty(DatePicker.Text) || String.IsNullOrEmpty(CourseCodetxt.Text)
                || String.IsNullOrEmpty(Yeartxt.Text)|| IsActive.IsChecked.Value)
            {
               
                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("fields are missing," +
                    "\nAll the fields are required.", "Oops!", System.Windows.MessageBoxButton.YesNoCancel);

            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
