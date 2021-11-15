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

            }
            else
            {

            }
        }
        public void logout() { }
        public void browse_problem_list() { }
        public void browse_problem() { }
        public void browse_statistics() { }
        public void load_admin_page() { }
    }
}
