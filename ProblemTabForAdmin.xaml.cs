using Login;
using UploadProblem;

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


namespace ProblemTabForAdmin
{
    /// <summary>
    /// ProblemTab.xaml 的互動邏輯
    /// </summary>
    public partial class ProblemTabForAdmin : Page
    {
        protected JudgeSystem JudgeSystem = new JudgeSystem();

        public Model.Users UserInfo = new Model.Users();

        public ObservableCollection<Model.Problems> AllList = new ObservableCollection<Model.Problems>();

        public ProblemTabForAdmin(Model.Users UserInfo)
        {
            InitializeComponent();
            this.UserInfo = UserInfo;

            List<Model.Problems> list_problem = JudgeSystem.browse_problem_list();
            foreach (Model.Problems temp1 in list_problem)
                AllList.Add(temp1);


            dataGrid.ItemsSource = AllList;
            
             
        }


        private void UploadProblem_Clck(object sender, RoutedEventArgs e)
        {

            UploadProblem.UploadProblem upload = new UploadProblem.UploadProblem(UserInfo.userID);
            upload.Show();
        }
        private void EditProblem_Click(object sender, RoutedEventArgs e)
        {
            EditProblem.EditProblem edit = new EditProblem.EditProblem(UserInfo.userID);
            edit.Show();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            DataGridRow row = sender as DataGridRow;
            // Some operations with this row
            Model.Problems selectedProblem = (Model.Problems)row.Item;
            // this.Content = new ProblemPage.ProblemPage(selectedProblem);
            Main.Content = new ProblemPage.ProblemPage(selectedProblem, UserInfo.userID);
        }

        private void Main_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }


    }

    public class JudgeSystem
    {
        //After done front end and put into it
        protected ProblemSystem.ProgramProblem problems = new ProblemSystem.ProgramProblem();




        public JudgeSystem() { } // constructor


        public List<Model.Problems> browse_problem_list()
        {
            return problems.AllProblems;
        }
        public List<Model.Problems> browse_problem(string problemID)
        {
            return problems.SelectProblem(problemID);
        }

    }

}
