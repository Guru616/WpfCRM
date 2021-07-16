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

namespace WpfCRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool Check()
        {
            if (LoginBox.Text == "" || PassworsBox.Password == "") { return false; }
            else { return true; }
        }

        private void Button_SignIn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Check())
                {
                    LoginBox.BorderBrush = Brushes.Red;
                    PassworsBox.BorderBrush = Brushes.Red;
                    Note.Text = "Incorrect username or password.";
                }
                else
                {
                    LoginBox.BorderBrush = Brushes.Black;
                    PassworsBox.BorderBrush = Brushes.Black;
                    Note.Text = "";
                    SignIn sign = new SignIn();
                    sign.signIn(LoginBox.Text, PassworsBox.Password);
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
