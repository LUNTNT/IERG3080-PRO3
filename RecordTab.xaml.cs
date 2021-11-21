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

namespace RecordTab
{
    /// <summary>
    /// Page1.xaml 的互動邏輯
    /// </summary>
    public partial class RecordTab : Page
    {
        protected JudgeSystem JudgeSystem = new JudgeSystem();

        public Model.Users UserInfo = new Model.Users();

        public ObservableCollection<Model.Submissions> AllList = new ObservableCollection<Model.Submissions>();

        protected Model.Submissions Submissions = new Model.Submissions();

        public RecordTab(Model.Users UserInfo)
        {
            InitializeComponent();

            this.UserInfo = UserInfo;

            List<Model.Submissions> list_problem = JudgeSystem.browse_record();
            foreach (Model.Submissions temp1 in list_problem)
                AllList.Add(temp1);

            dataGrid.ItemsSource = AllList;
        }

        private void Main_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }

    public class JudgeSystem
    {
        //After done front end and put into it
        protected Submission.AllSubmission submission = new Submission.AllSubmission();

        public JudgeSystem() { } // constructor


        public List<Model.Submissions> browse_record()
        {
            return submission.AllSubmissions;
        }

        

    }

}
