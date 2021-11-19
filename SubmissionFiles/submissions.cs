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

        public string GetJavaFileName(string lineText)
        {
            string[] temp = lineText.Split(' ', '{', '(');
            for(int i = 0; i < (temp.Length - 2); i++)
            {
                if (temp[i] == "public" && temp[i + 1] == "class")
                    return temp[i + 2];
            }
            return "";
        }
    }
}
