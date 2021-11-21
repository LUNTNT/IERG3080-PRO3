using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Judger
{
    public class Judge
    {
        protected Process_Commnand process_Commnand = new Process_Commnand();

        public Judge() { }

        public string Create_Dire(string subID)
        {
            System.IO.Directory.CreateDirectory("./SubmissionFiles/" + subID );

            return ("./SubmissionFiles/" + subID + "/");
        }

        public string JudgeProblem(string language, string subID, Model.Problems problem)
        {
            string[] result = new string[problem.testInput.Length];

            for (int i = 0; i < problem.testInput.Length; i++)
            {
                if (problem.testInput[i] == "None")
                    result[i] = JudgeCase(language, subID, problem.testOutput[i]);
                else 
                    result[i] = JudgeCase(language, subID, problem.testInput[i], problem.testOutput[i]);

                if (result[i] == "Wrong")
                    return result[i];
                if (result[i] == "Compile Error")
                    return result[i];
            }

            return "Correct";
        }

        //special for java
        public string JudgeProblem(string language, string subID, string filename, Model.Problems problem)
        {
            string[] result = new string[problem.testInput.Length];

            for (int i = 0; i < problem.testInput.Length; i++)
            {
                if (problem.testInput[i] == "None")
                    result[i] = JudgeCase(language, subID, filename, "",  problem.testOutput[i]);
                else
                    result[i] = JudgeCase(language, subID, filename, problem.testInput[i], problem.testOutput[i]);

                if (result[i] == "Wrong")
                    return result[i];
                if (result[i] == "Compile Error")
                    return result[i];
            }

            return "Correct";
        }

        protected string JudgeCase(string language, string subID, string output)
        {
            string result = "";

            if (language == "Python")
                result = process_Commnand.runInPython(subID, "", output);
            else if (language == "C")
                result =  process_Commnand.runInC(subID, "", output);
            else if (language == "C++")
                result =  process_Commnand.runInCpp(subID, "", output);

            return result;

        }

        protected string JudgeCase(string language, string subID, string input, string output)
        {
            string result = "";

            if (language == "Python")
                result = process_Commnand.runInPython(subID, input, output);
            else if (language == "C")
                result = process_Commnand.runInC(subID, input, output);
            else if (language == "C++")
                result = process_Commnand.runInCpp(subID, input, output);

            return result;

        }

        //special for java
        protected string JudgeCase(string language, string subID, string filename, string input, string output)
        {
            string result = "";

            if (language == "Java")
                result = process_Commnand.runInJava(subID, filename, input, output);

            return result;

        }

    }

    public class Process_Commnand
    {
        public Process_Commnand() { }

        public string runInC(string subID, string input, string output)
        {
            Process run_proc = new Process();
            Process compile_proc = new Process();

            string WorkingDirectory = "./SubmissionFiles/" + subID;
            string CompileArguments = "/c gcc " + subID + ".c -o " + subID;
            string RunArguments = "/c " + subID;


            //Compile Command 
            compile_proc.StartInfo.RedirectStandardOutput = true;
            compile_proc.StartInfo.UseShellExecute = false;
            compile_proc.StartInfo.CreateNoWindow = true;
            compile_proc.StartInfo.WorkingDirectory = @WorkingDirectory;
            compile_proc.StartInfo.FileName = "cmd.exe";
            compile_proc.StartInfo.Arguments = @CompileArguments;

            //Compile start
            compile_proc.Start();
            compile_proc.WaitForExit();

            //Run Command
            run_proc.StartInfo.RedirectStandardOutput = true;
            run_proc.StartInfo.RedirectStandardInput = true;
            run_proc.StartInfo.CreateNoWindow = true;
            run_proc.StartInfo.UseShellExecute = false;
            run_proc.StartInfo.WorkingDirectory = @WorkingDirectory;
            run_proc.StartInfo.FileName = "cmd.exe";
            run_proc.StartInfo.Arguments = RunArguments;

            //Run start and input the string
            run_proc.Start();
            run_proc.StandardInput.WriteLine(input);
            string output2 = run_proc.StandardOutput.ReadToEnd();
            run_proc.WaitForExit();


            if (output2.Length == 0)
                return "Compile Error";
            if (output2.Contains(output))
                return "Correct";
            return "Wrong";
        }

        public string runInCpp(string subID, string input, string output)
        {
            Process run_proc = new Process();
            Process compile_proc = new Process();

            string WorkingDirectory = "./SubmissionFiles/" + subID;
            string CompileArguments = "/c g++ " + subID + ".cpp -o " + subID;
            string RunArguments = "/c " + subID;


            //Compile Command 
            compile_proc.StartInfo.RedirectStandardOutput = true;
            compile_proc.StartInfo.UseShellExecute = false;
            compile_proc.StartInfo.CreateNoWindow = true;
            compile_proc.StartInfo.WorkingDirectory = @WorkingDirectory;
            compile_proc.StartInfo.FileName = "cmd.exe";
            compile_proc.StartInfo.Arguments = @CompileArguments;

            //Compile start
            compile_proc.Start();
            compile_proc.WaitForExit();

            //Run Command
            run_proc.StartInfo.RedirectStandardOutput = true;
            run_proc.StartInfo.RedirectStandardInput = true;
            run_proc.StartInfo.CreateNoWindow = true;
            run_proc.StartInfo.UseShellExecute = false;
            run_proc.StartInfo.WorkingDirectory = @WorkingDirectory;
            run_proc.StartInfo.FileName = "cmd.exe";
            run_proc.StartInfo.Arguments = RunArguments;

            //Run start and input the string
            run_proc.Start();
            run_proc.StandardInput.WriteLine(input);
            string outputRun = run_proc.StandardOutput.ReadToEnd();
            run_proc.WaitForExit();


            if (outputRun.Length == 0)
                return "Compile Error";
            if (outputRun.Contains(output))
                return "Correct";
            return "Wrong";
        }

        public string runInJava(string subID, string filename, string input, string output)
        {
            Process run_proc = new Process();
            Process compile_proc = new Process();

            string WorkingDirectory = "./SubmissionFiles/" + subID;
            string CompileArguments = "/c javac " + filename + ".java";
            string RunArguments = "java -classpath " + @WorkingDirectory + " " + filename;


            //Compile Command 
            compile_proc.StartInfo.RedirectStandardOutput = true;
            compile_proc.StartInfo.UseShellExecute = false;
            compile_proc.StartInfo.CreateNoWindow = true;
            compile_proc.StartInfo.WorkingDirectory = @WorkingDirectory;
            compile_proc.StartInfo.FileName = "cmd.exe";
            compile_proc.StartInfo.Arguments = CompileArguments;

            //Compile start
            compile_proc.Start();
            compile_proc.WaitForExit();

            //Run Command
            run_proc.StartInfo.RedirectStandardOutput = true;
            run_proc.StartInfo.RedirectStandardInput = true;
            run_proc.StartInfo.UseShellExecute = false;
            run_proc.StartInfo.CreateNoWindow = true;
            run_proc.StartInfo.WorkingDirectory = @WorkingDirectory;
            run_proc.StartInfo.FileName = "cmd.exe";
            run_proc.StartInfo.Arguments = RunArguments;

            //Run start and input the string
            run_proc.Start();
            run_proc.StandardInput.WriteLine(input);
            string outputRun = run_proc.StandardOutput.ReadToEnd();
            run_proc.WaitForExit();


            if (outputRun.Length == 0)
                return "Compile Error";
            if (outputRun.Contains(output))
                return "Correct";
            return "Wrong";
        }

        public string runInPython(string subID, string input, string output)
        {
            Process compile_run_proc = new Process();

            string WorkingDirectory = "./SubmissionFiles/" + subID;
            string CompileArguments = subID + ".py";


            //Compile Command 
            compile_run_proc.StartInfo.RedirectStandardOutput = true;
            compile_run_proc.StartInfo.RedirectStandardInput = true;
            compile_run_proc.StartInfo.UseShellExecute = false;
            compile_run_proc.StartInfo.CreateNoWindow = true;
            compile_run_proc.StartInfo.WorkingDirectory = @WorkingDirectory;
            compile_run_proc.StartInfo.FileName = @"python.exe";
            compile_run_proc.StartInfo.Arguments = @CompileArguments;

            //Run Command
            compile_run_proc.Start();
            compile_run_proc.StandardInput.WriteLine(input);
            string outputRun = compile_run_proc.StandardOutput.ReadToEnd();
            compile_run_proc.WaitForExit();

            if (outputRun.Length == 0)
                return "Compile Error";
            if (outputRun.Contains(output))
                return "Correct";
            return "Wrong";
        }
    }

}
