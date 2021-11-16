using IERG3080_PRO3_Login;
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
//using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace IERG3080_PRO3
{

    public partial class MainWindow : Window
    {
        protected JudgeSystem JudgeSystem = new JudgeSystem();
        public ObservableCollection<Model.Problems> AllList = new ObservableCollection<Model.Problems>();


        public MainWindow()
        {
            InitializeComponent();

            List<Model.Problems> list_problem = JudgeSystem.browse_problem_list();
            foreach (Model.Problems temp1 in list_problem)
                AllList.Add(temp1);

            abc.Content = AllList[1].title;

            dataGrid.ItemsSource = AllList;

        }

        private void OpenLoginPage(object sender, RoutedEventArgs s)
        {

            Login objLogin = new Login();
            objLogin.Show();

        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
        }
    }

    public class JudgeSystem
    {
        //After done front end and put into it
        protected ProblemSystem.ProgramProblem problems = new ProblemSystem.ProgramProblem();
        protected User.User users = new User.User();



        public JudgeSystem() { } // constructor

        public void login(string userID, string password)
        {
            bool result = users.VerifyLogin(userID, password);

            if (result == true)
            {
                bool isadmin = users.Isadmin(userID);

                if (isadmin == true)
                {
                    load_admin_page();
                }
                else
                {
                    load_student_page();
                }
            }
            else
            {
                string message = "Wrong UerID or Password";
            }
        }
        public void logout()
        {
            load_login_page();

        }

        public List<Model.Problems> browse_problem_list()
        {
            return problems.AllProblems;
        }
        public List<Model.Problems> browse_problem(string problemID)
        {
            return problems.SelectProblem(problemID);
        }

        public void browse_records() { }
        public void browse_statistics() { }

        public void load_student_page() { }
        public void load_admin_page() { }
        public void load_login_page() { }
    }
}
