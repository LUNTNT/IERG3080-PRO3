using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Users
    {
        public object _id { get; set; }
        public string userID { get; set; }
        public string password { get; set; }
        public string userType { get; set; }

        public string name { get; set; }
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
        public string acRateStr { get; set; }
        public string[] tags { get; set; }

        public bool isLive { get; set; }

        public string[] testInput { get; set; }
        public string[] testOutput { get; set; }


    }

    public class Submissions
    {
        public object _id { get; set; }
        public string submissionID { get; set; }
        public string userID { get; set; }
        public string problemID { get; set; }

        public string language { get; set; }
        public string time { get; set; }
        public string result { get; set; }

        public string author { get; set; }
        public string filename { get; set; }
    }

    public class ProblemStat
    {
        public string problemID { get; set; }
        public string problemTitle { get; set; }
        public double acRate { get; set; }
        public string acRateStr { get; set; }

        public int attempts { get; set; }
        public int correct { get; set; }
        public int wrong { get; set; }
        public int compile_error { get; set; }
    }

    public class PiePoint
    {
        public string Name { get; set; }
        public Int16 Share { get; set; }
    }
}
