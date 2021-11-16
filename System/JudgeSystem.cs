using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem
{
    // The judge system has a list of problems and users
    // When the judge starts, it initializes some data
    // Then, the login page is shown
    // After login, user can browse and attempt problems, view stat
    // If admin login the page, admin can perform some extra actions
    // Users can log out after use.
    public class JudgeSystem
    {
        //After done front end and put into it
        Problem.ProgramProblem problems;
        User.User users;
        


        public JudgeSystem() { } // constructor

        private void initialization()
        {
        }

        public void login(string userID, string password)
        {
            bool result = users.VerifyLogin(userID, password);
            
            if (result == true)
            {
                bool isadmin = users.Isadmin(userID);

                if (isadmin == true)
                {
                    load_admin_page();
                }
                else
                {
                    load_student_page();
                }
            }
            else
            {
                string message = "Wrong UerID or Password";
            }
        }
        public void logout() 
        {
            load_login_page();

        }

        public List<Model.Problems> browse_problem_list() 
        {
            return problems.AllProblems;
        }
        public List<Model.Problems> browse_problem(string problemID) 
        {
            return problems.SelectProblem(problemID);
        }

        public void browse_records() { }
        public void browse_statistics() { }

        public void load_student_page() { }
        public void load_admin_page() { }
        public void load_login_page() { }
    }
}
