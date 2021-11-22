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

        public UploadProblem(string userID)
        {
            InitializeComponent();
            uploadproblems.author = userID;

            Problemlevel.Items.Add("Easy");
            Problemlevel.Items.Add("Medium");
            Problemlevel.Items.Add("Hard");
        }


        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            if (ProblemID.Text == "")
            {
                MessageBox.Show("Fill in all boxes.");
                return;
            }
            else
            {
                uploadproblems.ID = ProblemID.Text;
                uploadproblems._id = ProblemID.Text;
            }

            if (ProblemTitle.Text == "")
            {
                MessageBox.Show("Fill in all boxes.");
                return;
            }
            else
                uploadproblems.title = ProblemTitle.Text;

            if (ProblemDescription.Text == "")
            {
                MessageBox.Show("Fill in all boxes.");
                return;
            }
            else
                uploadproblems.description = ProblemDescription.Text;

            if (InputDescrip.Text == "")
            {
                MessageBox.Show("Fill in all boxes.");
                return;
            }
            else
                uploadproblems.inputContent = InputDescrip.Text;

            if (OutputDescrip.Text == "")
            {
                MessageBox.Show("Fill in all boxes.");
                return;
            }
            else
                uploadproblems.outputContent = OutputDescrip.Text;

            if (ProblemSInput.Text == "")
            {
                MessageBox.Show("Fill in all boxes.");
                return;
            }
            else
                uploadproblems.inputSample = ProblemSInput.Text;

            if (ProblemSOutput.Text == "")
            {
                MessageBox.Show("Fill in all boxes.");
                return;
            }
            else
                uploadproblems.outputSample = ProblemSOutput.Text;

            if (Problemlevel.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Fill in all boxes.");
                return;
            }
            else
                uploadproblems.difficulty = Problemlevel.SelectedItem.ToString();

            if (CaseBox.Items.Count == 0)
            {
                MessageBox.Show("Fill in all boxes.");
                return;
            }
            else
            {
                uploadproblems.testInput = new string[CaseBox.Items.Count];
                uploadproblems.testOutput = new string[CaseBox.Items.Count];
                for (int i = 0; i < CaseBox.Items.Count; i++)
                {
                    string[] temp = CaseBox.Items[i].ToString().Split('~');
                    uploadproblems.testInput[i] = temp[0];
                    uploadproblems.testOutput[i] = temp[1];
                }
            }

            bool result = ProblemCol.InsertOne(uploadproblems);
            if (result == false)
                MessageBox.Show("Problem ID is existed.. ");
            else
            {
                var ClickOk = MessageBox.Show("Problem uploaded.", "Done for uploading problem", MessageBoxButton.OK);
                if (ClickOk == MessageBoxResult.OK)
                    this.Close();
            }
        }

        private void AddCase_Click(object sender, RoutedEventArgs e)
        {
            CaseBox.Items.Add(InputCase.Text + "~" + OutputCase.Text);
        }

        private void DeleteCase_Click(object sender, RoutedEventArgs e)
        {
            CaseBox.Items.Remove(CaseBox.SelectedItem);
        }
    }
}
