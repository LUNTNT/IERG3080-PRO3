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

namespace Login
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
                Model.Users UserInfo = users.GetUserInfo(userID);

                bool isadmin = users.Isadmin(userID);

                if (isadmin == true)
                {
                    load_admin_page(UserInfo);
                }
                else
                {
                    load_student_page(UserInfo);
                }
            }
            else
            {
                MessageBox.Show("Wrong UserID or Password");
            }
        }

        public void load_student_page(Model.Users UserInfo) 
        {
            StudentWindow.StudentWindow main1 = new StudentWindow.StudentWindow(UserInfo);
            main1.Show();
            this.Close();
        }
        public void load_admin_page(Model.Users UserInfo) 
        {
            MainWindow.MainWindow main2 = new MainWindow.MainWindow(UserInfo);
            main2.Show();
            this.Close();
        }
    }
}
