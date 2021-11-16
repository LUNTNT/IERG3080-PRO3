using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Users
    {
        public object _id;
        public string userID;
        public string password;
        public string userType;

        public string name;
    }

    public class Problems
    {
        public object _id { get; set; }
        public string ID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }

        public int trial { get; set; }
        public string difficulty { get; set; }
        public int timeLimit { get; set; }
        public int memoryLimit { get; set; }

        public double acRate { get; set; }
        public string[] tags { get; set; }

        public bool isLive { get; set; }
    }

    public class Problem_list
    {
        public string ID;
        public string title;
        public string author;

        public string difficulty;
        public int timeLimit;

        public double acRate;
    }

    public class Submissions
    {
        public object _id;
        public string submissionID;
        public string userID;
        public string problemID;

        public string programpath;
        public string result;
    }
}
