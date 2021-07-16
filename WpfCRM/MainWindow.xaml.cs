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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LoginBox.Text == null || PassworsBox.Password == null)
                {
                    Note.Text = "Enter login or password";
                }
                else
                {
                    SignIn sign = new SignIn();
                    sign.signIn(LoginBox.Text, PassworsBox.Password.ToString());
                    LogWriter logWriter = new LogWriter();
                    logWriter.FileWrite(LoginBox.Text);
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
        }
    }
}
