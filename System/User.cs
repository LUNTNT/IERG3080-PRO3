using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class User
    {
        protected Database.UsersCol UsersCol = new Database.UsersCol();

        protected string ID, name, password;
        public User() { } // constructors
        public User(string ID, string name, string password) { }

        public bool VerifyLogin(string userID, string password)
        {
            List<Model.Users> finduser = UsersCol.GetOneByID(userID);
            if (finduser.Count == 0)
            {
                return false;
            } 

            if (finduser[0].password != password)
            {
                return false;
            }
                
            return true;
        }
        public bool Isadmin(string userID)
        {
            List<Model.Users> finduser = UsersCol.GetOneByID(userID);
            if (finduser[0].userType != "admin")
            {
                return false;
            }

            return true;
        }

        public Model.Users GetUserInfo(string userID)
        {
            List<Model.Users> temp1 = UsersCol.GetOneByID(userID);

            return temp1[0];
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
