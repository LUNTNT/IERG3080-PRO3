using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission
{
    class Submission
    {
        protected Database.SubmissionCol SubmissionColl;

        public List<Model.Submissions> AllSubmissions
        {
            get { return SubmissionColl.GetAll(); } // Byte to MB
        }
        public List<Model.Submissions> SelectSubmissions(string problemID)
        {
            return SubmissionColl.GetOneByID(problemID);
        }


    }
}
