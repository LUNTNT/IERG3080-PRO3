using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // Each problems has its ID, title, text descriptions, test cases and stat
    // Admin or author can edit the problems, including test cases
    // Stat of the problem is updated once user attempts the problem
    public class ProgramProblem
    {
        protected Database.ProblemCol ProblemColl;

        public List<Model.Problems> AllProblems
        {
            get { return ProblemColl.GetAll(); } // Byte to MB
        }
        public List<Model.Problems> SelectProblem(string problemID)
        {
            return ProblemColl.GetOneByID(problemID);
        }


        // compile time polymorphism
        public void edit_problem(string title) { }
        public void edit_problem(string title, string content) { }
        public void edit_problem(string title, string content, int difficulty,
        int timeLimit, int memoryLimit)
        { }
        public void edit_testcases(string inputFile, string outputFile) { }
        public void edit_statistics(int trial, int accepted) { }
    }
}
