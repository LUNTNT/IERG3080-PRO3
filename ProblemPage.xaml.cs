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
using System.Windows.Forms;

namespace ProblemPage
{
    public partial class ProblemPage : Page
    {
        protected string userID;
        protected string textline;

        protected Judger.Judge Judge = new Judger.Judge();
        protected Submission.AllSubmission submission = new Submission.AllSubmission();
        protected Submission.SubmissionFiles submissionFiles = new Submission.SubmissionFiles();

        protected ObservableCollection<Model.PiePoint> PieCollection;
        
        Model.Problems selectedProblem;

        public ProblemPage(Model.Problems selectedProblem, string userID)
        {
            InitializeComponent();
            this.selectedProblem = selectedProblem;
            this.userID = userID;

            //init problem information
            ProblemID.Text = selectedProblem.ID;
            ProblemName.Text = selectedProblem.title;
            Description.Text = selectedProblem.description;
            InputDescription.Text = selectedProblem.inputContent;
            OutputDescription.Text = selectedProblem.outputContent;
            SampleInput.Text = selectedProblem.inputSample;
            SampleOutput.Text = selectedProblem.outputSample;
            
            ID.Text = selectedProblem.ID;
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
            string result;

            if (LanguageComboBox.SelectedItem.ToString() != "Java")
                result = Judge.JudgeProblem(LanguageComboBox.SelectedItem.ToString(), submissionID, selectedProblem);
            else
                result = Judge.JudgeProblem(LanguageComboBox.SelectedItem.ToString(), submissionID, textline, selectedProblem);

            showresult.Content = result;
            if (LanguageComboBox.SelectedItem.ToString() != "Java")
                submission.CreateSubmission(submissionID, userID, selectedProblem.ID, LanguageComboBox.SelectedItem.ToString(), result, submissionID);
            else
                submission.CreateSubmission(submissionID, userID, selectedProblem.ID, LanguageComboBox.SelectedItem.ToString(), result, textline);
            System.Windows.MessageBox.Show("Done for submission. Your result is " + result);

            
        }
        private void saveFile (string submissionID, string fileType)
        {
            string savePath = Judge.Create_Dire(submissionID);

            if (fileType == "C")
                savePath += submissionID + ".c";
            else if (fileType == "C++")
                savePath += submissionID + ".cpp";
            else if (fileType == "Java")
            {
                textline = findText();

                if (textline == "") 
                {
                    System.Windows.Forms.MessageBox.Show("Public Class Not Found!");
                    return;
                }
                else
                {
                    savePath += submissionFiles.GetJavaFileName(textline) + ".java";
                }
                    
            }
            else if (fileType == "Python")
                savePath += submissionID + ".py";

            textEditor.Save(savePath);
        }

        private string findText()
        {
            ICSharpCode.AvalonEdit.Document.DocumentLine line;
            string textline;

            for (int i = 1; i <= textEditor.Document.Lines.Count; i++)
            {
                line = textEditor.Document.GetLineByNumber(i);
                textline = textEditor.Document.GetText(line.Offset, line.Length);
                if (textline.Contains("public class"))
                    return textline;
            }
            return "";
        }

        private void UploadProblem_Click(object sender, RoutedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Python|*.py|Java|*.java|C|*.c|C++|*.cpp" })
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    string text = System.IO.File.ReadAllText(filename);
                    textEditor.Text = text;


                }
            }
        }
    }
}
