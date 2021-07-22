using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfCRM.DataModels;

namespace WpfCRM
{
    class AuthenticationClass : IAuthentication
    {
        public void SignIn (string login, string password)
        {
            using (var context = new AppContext())
            {
                var users = context.Users;
                foreach(User item in users)
                {
                    if (login == item.Login && password.GetHashCode().ToString() == item.Password)
                    {
                        if(item.Id_acces.ToString() == "")
                        {
                            MessageBox.Show("Wait for check administration");
                        }
                        else
                        {
                            AdminPanel panel = new AdminPanel();
                            panel.Show();
                            LogWriter logWriter = new LogWriter();
                            logWriter.LogWrite(login);
                        }
                    }
                }
            }
        }

        public void SignUp(string name,string surname, string email,string login, string password)
        {
            using(var context = new AppContext())
            {
                var user = new User()
                {
                    Name = name,
                    Surname = surname,
                    Login = login,
                    Password = password.GetHashCode().ToString(),
                    Email = email,
                };
                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show($" id: {user.Id}, name: {user.Name},(login: {user.Login})");
            }

        }
    }
}
