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
using System.Windows.Controls.DataVisualization.Charting;
using System.Collections.ObjectModel;

namespace ProblemPage
{
    /// <summary>
    /// Problem.xaml 的互動邏輯
    /// </summary>
    public partial class ProblemPage : Page
    {
        public class PiePoint
        {
            public string Name { get; set; }
            public Int16 Share { get; set; }
        }
        public ObservableCollection<PiePoint> PieCollection;

        public ProblemPage(Model.Problems selectedProblem)
        {
            InitializeComponent();

            ProblemID.Text = selectedProblem.ID;
            ProblemName.Text = selectedProblem.title;
            Description.Text = selectedProblem.description;
            InputDescription.Text = selectedProblem.inputContent;
            OutputDescription.Text = selectedProblem.outputContent;
            SampleInput.Text = selectedProblem.inputSample;
            SampleOutput.Text = selectedProblem.outputSample;

            ID.Text = selectedProblem.ID;
            TimeLimit.Text = selectedProblem.timeLimit.ToString() + "MS";
            MemoryLimit.Text = selectedProblem.memoryLimit.ToString() + "MB";
            CreatedBy.Text = selectedProblem.author;
            Level.Text = selectedProblem.difficulty;


            List<KeyValuePair<string, double>> valueList = new List<KeyValuePair<string, double>>();
            valueList.Add(new KeyValuePair<string, double>("AC Rate", selectedProblem.acRate));
            valueList.Add(new KeyValuePair<string, double>("WR Rate", 1 - selectedProblem.acRate));

            pieChart.DataContext = valueList;
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ACpie_Opened(object sender, RoutedEventArgs e)
        {

        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {

        }
    }
}
