using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCRM
{
    class SignIn
    {
        DataBase dataBase = new DataBase();
        MainWindow main = new MainWindow();
        public void signIn (string login, string password)
        {
            foreach (Users item in dataBase.getdata())
            {
                if (login == item.Login && password == item.Password)
                {
                    AdminPanel panel = new AdminPanel();
                    panel.Show();
                }
                else { main.Note.Text = "Enter login or password"; }
                //MessageBox.Show("1");
            }
        }

    }
}
