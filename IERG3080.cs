using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IERG3080_PRO3
{
    // The judge system has a list of problems and users
    // When the judge starts, it initializes some data
    // Then, the login page is shown
    // After login, user can browse and attempt problems, view stat
    // If admin login the page, admin can perform some extra actions
    // Users can log out after use.
    public class JudgeSystem
    {

        protected List<ProgramProblem> problems;
        protected User user;
        public JudgeSystem() { } // constructor
        private void initialization() 
        {

        }
        public void login() { }
        public void logout() { }
        public void browse_problem_list() { }
        public void browse_problem() { }
        public void browse_statistics() { }
        public void load_admin_page() { }
    }
    // Each problems has its ID, title, text descriptions, test cases and stat
    // Admin or author can edit the problems, including test cases
    // Stat of the problem is updated once user attempts the problem
    public class ProgramProblem
    {
        protected string ID, title, content, author;
        protected int trial, difficulty, timeLimit, memoryLimit;
        protected double acRate, tags;
        protected bool isLive;
        public ProgramProblem() { } // constructors
        public ProgramProblem(string filename) { }
        public string Title { get; } // read-only property
        public string Content { get; } // read-only property
        public string Author { get; } // read-only property
        public string Difficulty
        { // Data abstraction, read-only property
            get
            {
                if (difficulty == 0) return "Easy";
                else if (difficulty == 1) return "Moderate";
                else if (difficulty == 2) return "Difficult";
            }
        }
        public double TimeLimit
        { // Data abstraction, read-only property
            get { return timeLimit / 1000.; } // ms to sec
        }
        public double MemoryLimit
        { // Data abstraction, read-only property
7
get { return memoryLimit / 1000000.; } // Byte to MB
        }
        public double ACRate
        { // read-only property
            get { return acRate; }
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
    // User has his ID, name, password and user type
    // User can edit problem, attempt problems
    // If admin or TA login the system, they can create problems, view student
    // submissions, view problem stat, ... et
    // If students login the system, they can select and attempt problems
    public class User
    {
        protected string ID, name, password;
        public User() { } // constructors
        public User(string ID, string name, string password) { }
        // runtime polymorphism
        public virtual void edit_profile(string name, string password) { }
        public void submit_problem(string problemID) { }
        public void select_problem(string problemID) { }
        public void upload_program(string problemID) { }
    }
    public class Student : User
    {
        public Student() { } // constructor
        public override void edit_profile(string name, string password) { }
    }
    public class Admin : User
    {
        public Admin() { } // constructor
        public override void edit_profile(string name, string password) { }
        void create_problem() { }
        void check_record() { }
        void view_statistics() { }
    }



}
