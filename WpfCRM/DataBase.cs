using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCRM
{
    class DataBaseProcessor : InterfaceData
    {
        
        List<Users> users = new List<Users>();
        public List<Users> GetUsers()
        {
            users.Add(new Users { Name = "Fred", Surname = "Guru", Login = "admin", Password = "1" });
            users.Add(new Users { Name = "Fred", Surname = "Guru", Login = "user", Password = "2" });
            return users;
        }
    }
}
