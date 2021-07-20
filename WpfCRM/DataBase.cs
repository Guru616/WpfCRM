using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCRM.DataModels;

namespace WpfCRM
{
    class DataBaseProcessor : InterfaceData
    {
        
        List<User> users = new List<User>();

        public List<User> GetUsers()
        {
            users.Add(new User { Name = "Fred", Surname = "Guru", Login = "admin", Password = "1" });
            users.Add(new User { Name = "Feduk", Surname = "Guru", Login = "user", Password = "2" });
            return users;
        }
    }
}
