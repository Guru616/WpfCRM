using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCRM.DataModels;

namespace WpfCRM
{
    class AppContext : DbContext
    {
        public AppContext() : base("WpfCRM.Properties.Settings.CRMdbConnectionString")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
