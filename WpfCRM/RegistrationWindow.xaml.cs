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
using System.Windows.Shapes;

namespace WpfCRM
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            
        }
        bool Check()
        {
            if (NameBox.Text == "" || SurnameBox.Text == "" || LoginBox.Text == "" || PassworsBox.Password == "" || PassworsBox_Copy.Password == "" && PassworsBox.Password == PassworsBox_Copy.Password)
            {
                NameBox.BorderBrush = Brushes.Red;
                SurnameBox.BorderBrush = Brushes.Red;
                LoginBox.BorderBrush = Brushes.Red;
                PassworsBox.BorderBrush = Brushes.Red;
                PassworsBox_Copy.BorderBrush = Brushes.Red;
                NoteReg.Text = "Incorrect username or password.";

                return false;
            }
            else
            {
                NameBox.BorderBrush = Brushes.Black;
                SurnameBox.BorderBrush = Brushes.Black;
                LoginBox.BorderBrush = Brushes.Black;
                PassworsBox.BorderBrush = Brushes.Black;
                PassworsBox_Copy.BorderBrush = Brushes.Black;
                NoteReg.Text = "";

                return true;
            }
        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_SignUp(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                AuthenticationClass authentication = new AuthenticationClass();
                authentication.SignUp(NameBox.Text, SurnameBox.Text,EmailBox.Text, LoginBox.Text, PassworsBox.Password);
                Close();
            }
        }

    }
}
