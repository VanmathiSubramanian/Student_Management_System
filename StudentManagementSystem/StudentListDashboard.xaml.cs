using StudentManagementSystem.Database;
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

namespace StudentManagementSystem
{
    //NewS
    /// <summary>
    /// Interaction logic for StudentListDashboard.xaml
    /// </summary>
    public partial class StudentListDashboard : Window
    {
        public StudentListDashboard()
        {
            InitializeComponent();
            LoadDataGrid();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void LoadDataGrid()
        {
            string studentsSql = @"SELECT Student_Id, First_Name, Last_Name, S.Course_Code, C.Name AS 'Course_Name' FROM STUDENT S JOIN COURSE C
ON S.Course_Code = C.Course_Code";
            var result = DbRepository.ReadData(studentsSql);
            var studentTable = result.Tables[0];
            StudentListGrid.ItemsSource = studentTable.DefaultView;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void StudentListRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = StudentListGrid.SelectedItem as DataRowView;
            int selectedStudentId = Convert.ToInt32(selectedItem.Row.ItemArray[0]);
            StudentDetails objStudentDetails = new StudentDetails(selectedStudentId);
            objStudentDetails.ShowDialog();
        }
        private void StudListGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddCourse.IsMouseOver)
            {
                AddCourse.IsEnabled = true;
            }
            else
            {
              AddCourse.IsEnabled = false;
            }
        }
        private void StudListGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            DataGridRow objSelectedStudent = StudentListGrid.SelectedItem as DataGridRow;
            // EditStudentButton.IsEnabled = true;
        }
        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            AddStudent objNewStudent = new AddStudent();
            objNewStudent.ShowDialog();
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            AddCourse objNewCourse = new AddCourse();
            objNewCourse.ShowDialog();
        }
    }
}
