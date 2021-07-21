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
        DataBaseProcessor dataBase = new DataBaseProcessor();
        public void SignIn (string login, string password)
        {
            foreach (User item in dataBase.GetUsers())
            {
                if (login == item.Login && password == item.Password)
                {
                    AdminPanel panel = new AdminPanel();
                    panel.Show();
                    LogWriter logWriter = new LogWriter();
                    logWriter.LogWrite(login);
                }
                //MessageBox.Show("1");
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
                    Id_acces = 1
                };
                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show($" id: {user.Id}, name: {user.Name},(login: {user.Login})");
            }

        }
    }
}
