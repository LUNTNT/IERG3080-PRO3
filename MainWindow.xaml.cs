﻿using IERG3080_PRO3_Login;
using IERG3080_PRO3_UploadProblem;
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

namespace IERG3080_PRO3_UploadProblem
{
    public partial class MainWindow : Window
    {
        protected JudgeSystem JudgeSystem = new JudgeSystem();
        
        public ObservableCollection<Model.Problems> AllList = new ObservableCollection<Model.Problems>();


        public MainWindow(Model.Users UserInfo)
        {
            InitializeComponent();

            Username.Text = UserInfo.name;

            List<Model.Problems> list_problem = JudgeSystem.browse_problem_list();
            foreach (Model.Problems temp1 in list_problem)
                AllList.Add(temp1);


            dataGrid.ItemsSource = AllList;

        }

       
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            IERG3080_PRO3_Login.Login backlogin = new Login();
            backlogin.Show();
            this.Close();
        }

        private void UploadProblem_Clck(object sender, RoutedEventArgs e)
        {
            IERG3080_PRO3_UploadProblem.UploadProblem upload = new UploadProblem();
            upload.Show();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            DataGridRow row = sender as DataGridRow;
            // Some operations with this row
            Model.Problems selectedProblem = (Model.Problems)row.Item;
             // this.Content = new ProblemPage.ProblemPage(selectedProblem);
            Main.Content = new ProblemPage.ProblemPage(selectedProblem);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }



    public class JudgeSystem
    {
        //After done front end and put into it
        protected ProblemSystem.ProgramProblem problems = new ProblemSystem.ProgramProblem();




        public JudgeSystem() { } // constructor


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
