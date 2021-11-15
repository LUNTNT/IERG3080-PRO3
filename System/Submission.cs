using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission
{
    public class AllSubmission
    {
        protected Database.SubmissionCol SubmissionColl;

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
            return SubmissionColl.GetOneByID(problemID);
        }
        public List<Model.Submissions> SelectSubmissionsOfStudent(string userID)
        {
            return SubmissionColl.GetOneByID(userID);
        }

        public AllSubmission() { }

        public double ProblemACRate(string problemID)
        {
            List<Model.Submissions> ProblemSub = AllSubmissionsOfProblem(problemID);
            int ACcount = 0;

            for (int i = 0; i < ProblemSub.Count; i++)
            {
                if (ProblemSub[i].result == "Correct")
                    ACcount++;
            }

            return ACcount / ProblemSub.Count;
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
    }
}
