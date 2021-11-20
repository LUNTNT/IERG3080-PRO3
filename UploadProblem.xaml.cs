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
using System.Windows.Shapes;

namespace UploadProblem
{
    /// <summary>
    /// UploadProblem.xaml 的互動邏輯
    /// </summary>
    public partial class UploadProblem : Window
    {

        protected Model.Problems uploadproblems = new Model.Problems();
        protected Database.ProblemCol ProblemCol = new Database.ProblemCol();

        public UploadProblem()
        {
            InitializeComponent();
        }


        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            ProblemID.Text = uploadproblems.ID;
            ProblemTitle.Text = uploadproblems.title;
            ProblemDescription.Text = uploadproblems.description;
            ProblemInput.Text = uploadproblems.inputSample;
            ProblemOutput.Text = uploadproblems.outputSample;
            ProblemAuthor.Text = uploadproblems.author;
            ProblemLevel.Text = uploadproblems.difficulty;
            ProblemTimeLimit.Text = uploadproblems.timeLimit.ToString();
            ProblemMemoryLimit.Text = uploadproblems.memoryLimit.ToString();
            ProblemACRate.Text = uploadproblems.acRate.ToString();

            ProblemCol.InsertOne(uploadproblems);

        }
    }
}
