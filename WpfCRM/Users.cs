using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCRM
{
    class Users
    {
        private readonly int id;
        private string name;
        private string surname;
        private string login;
        private string password;
        private int id_acces;

        public string Name {get;set;}
        public string Surname {get;set;}
        public string Login {get;set;}
        public string Password {get;set;}
        public string Id_acces {get;set;}
    }
}
