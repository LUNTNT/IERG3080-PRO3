using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionFiles
{
    public class SubmissionFiles
    {
        public SubmissionFiles() { }


        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

    }
}
