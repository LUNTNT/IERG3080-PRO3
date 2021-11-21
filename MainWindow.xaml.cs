using Login;
using UploadProblem;
using ProblemTab;
using RecordTab;
using StatisticTab;

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

namespace MainWindow
{
    public partial class MainWindow : Window
    {
        //protected JudgeSystem JudgeSystem = new JudgeSystem();
        public Model.Users UserInfo = new Model.Users();

        //public ObservableCollection<Model.Problems> AllList = new ObservableCollection<Model.Problems>();


        public MainWindow(Model.Users UserInfo)
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
            Tab.Content = new ProblemTabForAdmin.ProblemTabForAdmin(UserInfo);
        }

        private void RecordTab_Click(object sender, RoutedEventArgs e)
        {
            RecordTab.RecordTab recordtab = new RecordTab.RecordTab(UserInfo);
            Tab.Content = recordtab;

        }
        private void StatisticTab_Click(object sender, RoutedEventArgs e)
        {
            StatisticTab.StatisticTab statisticTab = new StatisticTab.StatisticTab(UserInfo);
            Tab.Content = new StatisticTab.StatisticTab(UserInfo);

        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }



}
