
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
using Login;
using MainWindow;

namespace StudentWindow
{

    public partial class StudentWindow : Window
    {
        //protected JudgeSystem JudgeSystem = new JudgeSystem();
        public Model.Users UserInfo = new Model.Users();

        //public ObservableCollection<Model.Problems> AllList = new ObservableCollection<Model.Problems>();


        public StudentWindow(Model.Users UserInfo)
        {
            InitializeComponent();
            this.UserInfo = UserInfo;

            Username.Text = UserInfo.name;


        }


        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login.Login backlogin = new Login.Login();
            backlogin.Show();
            this.Close();
        }

        private void ProblemTab_Click(object sender, RoutedEventArgs e)
        {
            Tab.Content = new ProblemTab.ProblemTab(UserInfo);
        }
        private void RecordTab_Click(object sender, RoutedEventArgs e)
        {
            RecordTab.RecordTab recordtab = new RecordTab.RecordTab(UserInfo);
            Tab.Content = recordtab;
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class JudgeSystemForStudent
    {
        //After done front end and put into it
        protected ProblemSystem.ProgramProblem problems = new ProblemSystem.ProgramProblem();


        public JudgeSystemForStudent() { } // constructor


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


        public void load_login_page() { }
    }
}
