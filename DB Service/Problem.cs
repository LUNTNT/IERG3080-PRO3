using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSystem
{
    // Each problems has its ID, title, text descriptions, test cases and stat
    // Admin or author can edit the problems, including test cases
    // Stat of the problem is updated once user attempts the problem
    public class ProgramProblem
    {
        protected Database.ProblemCol ProblemColl = new Database.ProblemCol();
        protected Submission.AllSubmission submit = new Submission.AllSubmission();

        public ProgramProblem() { }

        public List<Model.Problems> AllProblems
        {
            set { }
            get { return ProblemColl.GetAll(); } // Byte to MB
        }
        public List<Model.Problems> SelectProblem(string problemID)
        {
            return ProblemColl.GetOneByID(problemID);
        }


        // compile time polymorphism
        public void edit_problem(Model.Problems problem)
        {
            ProblemColl.UpdateOne(problem);
        }
/*        public void edit_statistics(string problemID) 
        {         
            double newAC = submit.ProblemACRate(list);

            List<Model.Problems> UpdataProblem = SelectProblem(problemID);
            UpdataProblem[0].acRate = newAC;
            edit_problem(UpdataProblem[0]);

        }*/

        public void edit_testcases(string inputFile, string outputFile)
        {

        }
    }
}
