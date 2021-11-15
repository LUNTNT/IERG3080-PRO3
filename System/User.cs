using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class User
    {
        protected Database.UsersCol UsersCol;

        protected string ID, name, password;
        public User() { } // constructors
        public User(string ID, string name, string password) { }

        public bool VerifyLogin(string userID, string password)
        {
            
            return true;
        }

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
