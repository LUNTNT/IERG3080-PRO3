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
        public string description { get; set; }
        public string inputContent { get; set; }
        public string outputContent { get; set; }
        public string inputSample { get; set; }
        public string outputSample { get; set; }
        public string author { get; set; }

        public string difficulty { get; set; }
        public int timeLimit { get; set; }
        public int memoryLimit { get; set; }

        public double acRate { get; set; }
        public string[] tags { get; set; }

        public bool isLive { get; set; }
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

    public class PiePoint
    {
        public string Name { get; set; }
        public Int16 Share { get; set; }
    }
}
