using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IERG3080_PRO3_Login
{
    public partial class Login : Window
    {

        protected User.User users = new User.User();

        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userid = textBoxUserName.Text;
            string password = textBoxPassword.Password;

            login(userid, password);

        }

        public void login(string userID, string password)
        {
            bool result = users.VerifyLogin(userID, password);

            if (result == true)
            {
                bool isadmin = users.Isadmin(userID);

                if (isadmin == true)
                {
                    load_admin_page(userID);
                }
                else
                {
                    load_student_page(userID);
                }
            }
            else
            {
                MessageBox.Show("Wrong UerID or Password");
            }
        }

        public void load_student_page(string userid) 
        {
            IERG3080_PRO3.MainWindow main = new IERG3080_PRO3.MainWindow(userid);
            main.Show();
            this.Close();
        }
        public void load_admin_page(string userid) 
        {
            IERG3080_PRO3.MainWindow main = new IERG3080_PRO3.MainWindow(userid);
            main.Show();
            this.Close();
        }
    }
}
