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
    public partial class ProblemPage : Page
    {

        public ObservableCollection<Model.PiePoint> PieCollection;
        public SubmissionFiles.SubmissionFiles submissionFiles = new SubmissionFiles.SubmissionFiles();



        public ProblemPage(Model.Problems selectedProblem)
        {
            InitializeComponent();

            //init problem information
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

            //init Piechart
            List<KeyValuePair<string, double>> valueList = new List<KeyValuePair<string, double>>();
            valueList.Add(new KeyValuePair<string, double>("AC Rate", selectedProblem.acRate));
            valueList.Add(new KeyValuePair<string, double>("WR Rate", 1 - selectedProblem.acRate));
            pieChart.DataContext = valueList;


            //Init Combo Box for languague choosing
            LanguageComboBox.Items.Add("C");
            LanguageComboBox.Items.Add("C++");
            LanguageComboBox.Items.Add("Java");
            LanguageComboBox.Items.Add("Python");
            LanguageComboBox.SelectedIndex = 0;

        }


        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LanguageComboBox.SelectedItem != null)
            {

                if (LanguageComboBox.SelectedItem.ToString() == "C")
                {
                    textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C++");
                }
                else if (LanguageComboBox.SelectedItem.ToString() == "C++")
                {
                    textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C++");
                }
                else if (LanguageComboBox.SelectedItem.ToString() == "Java")
                {
                    textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Java");
                }
                else if (LanguageComboBox.SelectedItem.ToString() == "Python")
                {
                    textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Python");
                }
            }
        }

        private void SubmitProblem_Click(object sender, RoutedEventArgs e)
        {
            string submissionID = submissionFiles.generateID();
            saveFile(submissionID, LanguageComboBox.SelectedItem.ToString());

        }
        private void saveFile (string submissionID, string fileType)
        {
            string savePath;

            savePath = "./SubmissionFiles/" + submissionID + "";

            if (fileType == "C")
                savePath = "./SubmissionFiles/" + submissionID + ".c";
            else if (fileType == "C++")
                savePath = "./SubmissionFiles/" + submissionID + ".cpp";
            else if (fileType == "Java")
                savePath = "./SubmissionFiles/" + submissionID + ".java";
            else if (fileType == "Python")
                savePath = "./SubmissionFiles/" + submissionID + ".py";

            textEditor.Save(savePath);
        }
    }
}
