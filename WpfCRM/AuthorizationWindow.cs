using System;
using System.Collections.Generic;
using System.IO;
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
using WpfCRM.DataModels;

namespace WpfCRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }
        bool Check()
        {
            if (LoginBox.Text == "" || PassworsBox.Password == "") 
            {
                LoginBox.BorderBrush = Brushes.Red;
                PassworsBox.BorderBrush = Brushes.Red;
                Note.Text = "Incorrect username or password.";
                return false;
            }
            else 
            {
                LoginBox.BorderBrush = Brushes.Black;
                PassworsBox.BorderBrush = Brushes.Black;
                Note.Text = "";
                return true;
            }
        }

        private void Button_SignIn(object sender, RoutedEventArgs e)
        {

            if (Check())
            {
                AuthenticationClass authentication = new AuthenticationClass();
                authentication.SignIn(LoginBox.Text, PassworsBox.Password);
                //authentication.SignInAsync(LoginBox.Text, PassworsBox.Password);
                Close();
            }
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_SignUp(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Owner = this;
            registrationWindow.Show();
        }
    }
}
