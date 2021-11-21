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
using System.Collections.ObjectModel;

namespace StatisticTab
{
    /// <summary>
    /// Page1.xaml 的互動邏輯
    /// </summary>
    public partial class StatisticTab : Page
    {
        protected ProblemStats.ProblemStat ProblemStat = new ProblemStats.ProblemStat();

        public ObservableCollection<Model.ProblemStat> AllList = new ObservableCollection<Model.ProblemStat>();
        protected Model.ProblemStat problemStat = new Model.ProblemStat();

        public StatisticTab(Model.Users UserInfo)
        {
            InitializeComponent();

            List<Model.ProblemStat> list_problem = ProblemStat.GetProblemStat();
            foreach (Model.ProblemStat temp1 in list_problem)
                AllList.Add(temp1);

            dataGrid.ItemsSource = AllList;
        }
    }
}
