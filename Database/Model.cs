using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Users
    {
        public string userID;
        public string password;
        public string userType;

        public string name;
    }

    public class Problems
    {
        public string ID;
        public string title;
        public string content;
        public string author;

        public int trial;
        public string difficulty;
        public int timeLimit;
        public int memoryLimit;

        public double acRate;
        public double tags;

        public bool isLive;
    }

    public class Submissions
    {
        public string submissionID;
        public string userID;
        public string problemID;

        public string programpath;
        public string result;
    }
}
