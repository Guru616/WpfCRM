using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WpfCRM.DataModels;

namespace WpfCRM
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        AppContext context = new AppContext();
        public AdminPanel()
        {
            InitializeComponent();
        }
        private void AdminPanel_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.Dispose();
        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_SignOut(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Close();
        }
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedItems.Count > 0)
            {
                for (int i = 0; i < UserList.SelectedItems.Count; i++)
                {
                    User user = UserList.SelectedItems[i] as User;
                    if(user != null)
                    {
                        context.Users.Remove(user);
                    }
                }
            }
            context.SaveChanges();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Users.Load();
            UserList.ItemsSource = context.Users.Local.ToBindingList();
            this.Closing += AdminPanel_Closing;
        }
    }
}
