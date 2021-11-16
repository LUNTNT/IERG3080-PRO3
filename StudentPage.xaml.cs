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

namespace IERG3080_PRO3
{

    public partial class StudentPage : Window
    {
        public StudentPage(Model.Users UserInfo)
        {
            InitializeComponent();
            Username.Text = UserInfo.name;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            IERG3080_PRO3_Login.Login backlogin = new IERG3080_PRO3_Login.Login();
            backlogin.Show();
            this.Close();
        }
    }
}
