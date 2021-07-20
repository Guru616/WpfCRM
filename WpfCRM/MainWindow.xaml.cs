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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {   
           using(var context = new AppContext())
            {
                var user = new User()
                {
                    Name = "Fedor",
                    Surname = "Guru",
                    Login = "Guru",
                    Password = "1",
                    Id_acces = 1
                };
                var role = new Role()
                {
                    NameRole = "admin",
                };
                context.Roles.Add(role);
                context.Users.Add(user);
                context.SaveChanges();


                MessageBox.Show($" id: {user.Id}, name: {user.Name},(login: {user.Login}), role: {role.NameRole}");
            }
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
