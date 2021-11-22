using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStats
{
    public class ProblemStat
    {
        protected ProblemSystem.ProgramProblem programProblem = new ProblemSystem.ProgramProblem();
        protected Submission.AllSubmission allSubmission = new Submission.AllSubmission();
        protected List<Model.Problems> Allproblem = new List<Model.Problems>();

        public ProblemStat() 
        {
            
        }

        public List<Model.ProblemStat> GetProblemStat()
        {
            Allproblem = programProblem.AllProblems;
            int LoopCount = Allproblem.Count;
            List<Model.ProblemStat> problemstat = new List<Model.ProblemStat>();
           for (int i = 0; i < LoopCount; i++)
            {
                List<Model.Submissions> submissiontemp = allSubmission.AllSubmissionsOfProblem(Allproblem[i].ID);
                Model.ProblemStat temp = new Model.ProblemStat();

                temp.problemID = Allproblem[i].ID;
                temp.problemTitle = Allproblem[i].title;
                Allproblem[i].acRate = allSubmission.ProblemACRate(submissiontemp);

                temp.correct = getResultCount("Correct", submissiontemp);
                temp.wrong = getResultCount("Wrong", submissiontemp);
                temp.compile_error = getResultCount("Compile Error", submissiontemp);
                temp.attempts = submissiontemp.Count;

                if (temp.attempts != 0)
                    temp.acRate = (double)temp.correct / (double)temp.attempts;
                else
                    temp.acRate = 0;

                Allproblem[i].acRate = temp.acRate;

                temp.acRateStr = temp.acRate.ToString("P");
                Allproblem[i].acRateStr = temp.acRate.ToString("P");
                programProblem.edit_problem(Allproblem[i]);
                

                problemstat.Add(temp);
            }
                                     
            return problemstat;
        }

        public int getResultCount(string target , List<Model.Submissions> list)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].result == target)
                    count++;
            }
            return count;

        }
    }
}
