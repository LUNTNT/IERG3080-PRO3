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
}
