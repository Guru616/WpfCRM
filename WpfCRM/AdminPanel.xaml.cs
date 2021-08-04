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
            TitleWindow.Text = Title;
        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_SignOut(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();

            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Close();
        }
        private void Button_Delete_User(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedItems != null)
            {
                for (int i = 0; i < UserList.SelectedItems.Count; i++)
                {
                    User user = UserList.SelectedItems[i] as User;
                    if (user != null)
                    {
                        context.Users.Remove(user);
                    }
                }
                context.SaveChangesAsync();
            }

        }
        private void Button_Delete_Order(object sender, RoutedEventArgs e)
        {
            //if (OrderList.SelectedItems != null)
            //{
            //    for (int i = 0; i < OrderList.SelectedItems.Count; i++)
            //    {
            //        Order order = OrderList.SelectedItems[i] as Order;
            //        if (order != null)
            //        {
            //            context.Orders.Remove(order);
            //        }
            //    }
            //}
            //context.SaveChanges();
            //OrderList.UpdateLayout();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var userResult = context.Users;
            UserList.ItemsSource = userResult.ToList();

            var productResult = context.Products;
            ProductList.ItemsSource = productResult.ToList();

            var RoleResult = context.Roles;
            RoleList.ItemsSource = RoleResult.ToList();
        }
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedItems != null)
            {
                for (int i = 0; i < UserList.SelectedItems.Count; i++)
                {
                    User user = UserList.SelectedItems[i] as User;
                    if (user != null)
                    {
                        context.Users.Remove(user);
                    }
                }
            }
            context.SaveChanges();
            UserList.UpdateLayout();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WpfCRM.CRMDBDataSet cRMDBDataSet = ((WpfCRM.CRMDBDataSet)(this.FindResource("cRMDBDataSet")));
            // Load data into the table Users. You can modify this code as needed.
            WpfCRM.CRMDBDataSetTableAdapters.UsersTableAdapter cRMDBDataSetUsersTableAdapter = new WpfCRM.CRMDBDataSetTableAdapters.UsersTableAdapter();
            cRMDBDataSetUsersTableAdapter.Fill(cRMDBDataSet.Users);
            System.Windows.Data.CollectionViewSource usersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("usersViewSource")));
            usersViewSource.View.MoveCurrentToFirst();
        }
    }
}
