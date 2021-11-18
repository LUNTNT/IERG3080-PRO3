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
using ICSharpCode.AvalonEdit;

namespace ProblemPage
{
    /// <summary>
    /// Problem.xaml 的互動邏輯
    /// </summary>
    public partial class ProblemPage : Page
    {

        public ObservableCollection<Model.PiePoint> PieCollection;

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


        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
/*            if (LanguageComboBox.SelectedItem != null)
                textEditor.SyntaxHighlighting = */
        }

        private void SubmitProblem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
