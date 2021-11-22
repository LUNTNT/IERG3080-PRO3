using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission
{
    public class AllSubmission
    {
        protected Database.SubmissionCol SubmissionColl = new Database.SubmissionCol();

        public List<Model.Submissions> AllSubmissions
        {
            get { return SubmissionColl.GetAll(); } // Byte to MB
        }
        public List<Model.Submissions> SelectSubmissionsByID(string submissiionID)
        {
            return SubmissionColl.GetOneByID(submissiionID);
        }
        public List<Model.Submissions> AllSubmissionsOfProblem(string problemID)
        {
            return SubmissionColl.GetOneByProblem(problemID);
        }
        public List<Model.Submissions> SelectSubmissionsOfStudent(string userID)
        {
            return SubmissionColl.GetOneByUser(userID);
        }

        public AllSubmission() { }

        public double ProblemACRate(List<Model.Submissions> list)
        {       
            if (list.Count == 0)
                return 0;

            int ACcount = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].result == "Correct")
                    ACcount++;
            }

            return (ACcount / list.Count);
        }

        public List<string> SelectSolvedProblemByStudent(string userID)
        {
            List<string> SolvedProblem = new List<string>();
            List<Model.Submissions> AllSsSubmit = SelectSubmissionsOfStudent(userID);
            for (int i = 0; i < AllSsSubmit.Count; i++)
            {
                if (AllSsSubmit[i].result == "Correct")
                {
                    SolvedProblem.Add(AllSsSubmit[i].problemID);
                }
                    
            }

            return SolvedProblem;
        }

        public bool CreateSubmission(string submissionID, string userID, string problemID, string language, string result, string filename)
        {
            Model.Submissions NewSubmit = new Model.Submissions() ;

            NewSubmit._id = submissionID;
            NewSubmit.submissionID = submissionID;
            NewSubmit.userID = userID;
            NewSubmit.problemID = problemID;

            NewSubmit.language = language;
            NewSubmit.result = result;
            NewSubmit.filename = filename;

            DateTime nowtime = DateTime.Now;
            NewSubmit.time = nowtime.ToString();

            return SubmissionColl.InsertOne(NewSubmit);
            
    }
    }

    public class SubmissionFiles
    {
        public SubmissionFiles() { }


        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public string GetJavaFileName(string lineText)
        {
            string[] temp = lineText.Split(' ', '{', '(');
            for (int i = 0; i < (temp.Length - 2); i++)
            {
                if (temp[i] == "public" && temp[i + 1] == "class")
                    return temp[i + 2];
            }
            return "";
        }
    }
}
